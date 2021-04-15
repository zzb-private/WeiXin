using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using ZZB.WebMVC.Core.Controllers;

namespace ZZB.WebMVC.Core.Tool
{

    public class BaseControllerActivator : IControllerActivator
    {
        public object Create([NotNull] ControllerContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var controllerType = context.ActionDescriptor.ControllerTypeInfo.AsType();

            var controller = context.HttpContext.RequestServices.GetService(controllerType);

            if (controller is BaseController controllerBase)
            {
                controllerBase.ServiceProvider =
                    context.HttpContext.RequestServices.GetRequiredService<IServiceProvider>();
            }

            return controller;
        }

        public void Release(ControllerContext context, object controller)
        {
        }
    }
}
