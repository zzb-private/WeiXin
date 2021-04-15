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
            // ���ö�ȡָ��λ�õ�nlog.config�ļ�
            NLogBuilder.ConfigureNLog("Config/NLog.config");
            CreateHostBuilder(args).Build().Run();
        }

        //����web���� 
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //Startup ������ע�����м������
                    webBuilder.UseStartup<Startup>();
                })
                //ע��autofac����
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                // ����ʹ��NLog
                .UseNLog();
    }
}
