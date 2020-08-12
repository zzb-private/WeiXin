using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WeiXin.DAL;
using WeiXin.Server.WeiXin;
using WeiXin.Server.WX_Servies;

namespace WeiXin.Manager.App_Start
{
    public class DependencyInjector
    {
        private static IContainer _container;

        public static IContainer Container
        {
            get { return _container; }
        }

        /// <summary>
        /// 注册相关接口
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            builder.RegisterControllers(assembly);

            builder.RegisterType<WeiXinDbContext>();
            builder.RegisterType<WeiXinService>();
            builder.RegisterType<WeiXinApi>();
            

            builder.RegisterAssemblyTypes(assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();


            //builder.Register(o => new WeiXinDbContext()).InstancePerRequest();//注册DbContext
            //builder.Register(o => new WeiXinService()).InstancePerRequest();

            //builder.RegisterType<SecondValidate>().As<IValidateData>().InstancePerDependency();
            //builder.RegisterType<MySqlHelper>().As<IDBHelper>().InstancePerDependency();

            _container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(_container));
        }
    }
}