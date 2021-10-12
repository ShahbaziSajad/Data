FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["OKESWebApplication/OKESWebApplication.csproj", "OKESWebApplication/"]
COPY ["OKES.Automation.FormBuilder.Data.Services/OKES.Automation.FormBuilder.Data.Services.csproj", "OKES.Automation.FormBuilder.Data.Services/"]
COPY ["OKES.Automation.FormBuilder.Data.Repositories/OKES.Automation.FormBuilder.Data.Repositories.csproj", "OKES.Automation.FormBuilder.Data.Repositories/"]
COPY ["OKES.Automation.FormBuilder.Data.Schema.V1/OKES.Automation.FormBuilder.Data.Schema.V1.csproj", "OKES.Automation.FormBuilder.Data.Schema.V1/"]
COPY ["OKES.Automation.FormBuilder.Api.Version1/OKES.Automation.FormBuilder.Api.Version1.csproj", "OKES.Automation.FormBuilder.Api.Version1/"]
RUN dotnet restore "OKESWebApplication/OKESWebApplication.csproj"
COPY . .
WORKDIR "/src/OKESWebApplication"
RUN dotnet build "OKESWebApplication.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "OKESWebApplication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "OKESWebApplication.dll"]