using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZB.Tool.Authentication;

namespace ZZB.WebMVC.Core.Filter
{
    public class ErrorFilterAttribute : ExceptionFilterAttribute
    {
        public ErrorFilterAttribute()
        {

        }
        static Logger Logger = LogManager.GetCurrentClassLogger();

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            Console.WriteLine("我错了");
            var currentUser = (ICurrentUser)context.HttpContext.RequestServices.GetService(typeof(ICurrentUser));

            StringBuilder strInfo = new StringBuilder();
            strInfo.Append("\r\n");
            strInfo.Append("----------------------------------------------------Begin-------------------------------------\r\n");
            strInfo.Append("1. 操作时间: " + DateTime.Now.ToShortTimeString() + " \r\n");
            strInfo.Append("2. 操作人: " + currentUser.Id + " \r\n");
            strInfo.Append("3. Area  : " + context.RouteData.Values["Area"] + "\r\n");
            strInfo.Append("3. Controller  : " + context.RouteData.Values["Controller"] + "\r\n");
            strInfo.Append("3. Action  : " + context.RouteData.Values["Action"] + "\r\n");
            strInfo.Append("4. 错误内容: " + context.Exception.Message + "\r\n");
            strInfo.Append("5. 跟踪: " + context.Exception.StackTrace + "\r\n");
            strInfo.Append("-----------------------------------------------------End--------------------------------------\r\n");

            Logger.Error(strInfo);

            context.ExceptionHandled = true;
            context.HttpContext.Response.Redirect("/Home/Error");
            return base.OnExceptionAsync(context);
        }
    }
}
