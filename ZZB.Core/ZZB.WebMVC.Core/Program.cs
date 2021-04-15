using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace ZZB.WebMVC.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // 设置读取指定位置的nlog.config文件
            NLogBuilder.ConfigureNLog("Config/NLog.config");
            CreateHostBuilder(args).Build().Run();
        }

        //构建web主机 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //Startup ：服务注册与中间件处理
                    webBuilder.UseStartup<Startup>();
                })
                //注册autofac服务
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                // 配置使用NLog
                .UseNLog();
    }
}
