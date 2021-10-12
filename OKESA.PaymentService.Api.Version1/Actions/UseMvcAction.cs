using Microsoft.AspNetCore.Routing;
using OKES.Core.Mvc.Infrastructure.Actions;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKESA.PaymentService.Api.Version1.Actions
{
    public class UseMvcAction : IUseMvcAction
    {
        public int Priority => 1002;

        public void Execute(IRouteBuilder routeBuilder, IServiceProvider serviceProvider)
        {
            Console.WriteLine("");
        }
    }
}
