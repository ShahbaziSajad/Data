using System;
using System.Reflection;
using Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OKES.Core.Data.Dapper;
using OKES.Core.Data.EntityFramework;
using OKES.Core.Data.MongoDriver;
using OKES.Core.Pattern.Abstractions;
using OKES.Core.WebApplication.Extensions;
using OKESA.Notification.Provider.Sms.Models;
using OKESA.PaymentService.Saman.PAYA;
using OKESA.PaymentService.Saman.PAYA.Infrastructure;
using OKESA.PaymentService.Saman.PAYA.Models;
using OKESWebApplication.Infrastructure;


namespace OKESWebApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly string _extensionsPath;
        private readonly IHostingEnvironment _hostingEnvironment;

        public Startup(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", optional: true)
                .AddJsonFile($"appsettings.SmsProviders.json", false,true)
                .AddEnvironmentVariables();

            Configuration = configurationBuilder.Build();
            _extensionsPath = hostingEnvironment.ContentRootPath + Configuration[AppSettings.ExtensionsPath];
            _hostingEnvironment = hostingEnvironment;


            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug(LogLevel.Warning);
            //loggerFactory.AddFile(_configurationRoot.GetSection("Logging"));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            services.AddOptions();

            services.AddOKESCore(_extensionsPath);

            services.Configure<MongoStorageContextOptions>(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("Mongo");
            }
            );
            services.Configure<SqlStorageContextOptions>(options =>
            {
                options.ConnectionString = Configuration.GetConnectionString("Sql");
            }

            );

            services.Configure<DapperStorageContextOptions>(options =>
            {
                options.DefaultConnectionString = Configuration.GetConnectionString("AccountDB");
            });
            services.AddScoped<IPaymentService, PaymentService>();
            services.Configure<PayamSmsSettings>(Configuration.GetSection("Sms:PayamSms"));

            services.Configure<SamanConfig>(Configuration.GetSection("SamanPAYA"));

            // Add framework services.
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseDatabaseErrorPage();
            }

            applicationBuilder.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    // the IsTrusted() extension method doesn't exist and
                    // you should implement your own as you may want to interpret it differently
                    // i.e. based on the current principal

                    var gres = new GenericResponse<Exception>
                    {
                        IsSuccess = false,
                        Response = exception,
                        ErrorMessage = exception.Message,
                        ErrorCode = 1000
                    };
                    var problemDetails = new ProblemDetails
                    {
                        Instance = $"urn:myorganization:error:{Guid.NewGuid()}"
                    };

                    if (exception is BadHttpRequestException badHttpRequestException)
                    {
                        problemDetails.Title = "Invalid request";
                        problemDetails.Status = (int)typeof(BadHttpRequestException).GetProperty("StatusCode",
                            BindingFlags.NonPublic | BindingFlags.Instance).GetValue(badHttpRequestException);
                        problemDetails.Detail = badHttpRequestException.Message;
                    }
                    else
                    {
                        problemDetails.Title = "An unexpected error occurred!";
                        problemDetails.Status = 500;
                        //problemDetails.Detail = exception.Demystify().ToString();
                    }

                    // log the exception etc..

                    context.Response.StatusCode = problemDetails.Status.Value;
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(gres));
                });
                // handle
            });

            applicationBuilder.UseHttpsRedirection();
            applicationBuilder.UseStaticFiles();
            applicationBuilder.UseCookiePolicy();

            applicationBuilder.UseCors("AllowAll");

            applicationBuilder.UseAuthentication();
            applicationBuilder.UseOKESCore();
        }
    }
}
