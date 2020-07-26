using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using WeiXin.BLL;

namespace WeiXin.Manager.App_Start
{
    public class AutoFacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetCallingAssembly())//注册mvc的Controller
                .PropertiesAutowired();//属性注入


            //1、无接口类注入
            //builder.RegisterType<BLL.newsClassBLL>().AsSelf().InstancePerRequest().PropertiesAutowired();
            //builder.RegisterType<WeiXinDbContext>().AsSelf().InstancePerRequest().PropertiesAutowired();

            builder.Register(o => new WeiXinService()).InstancePerRequest();//注册DbContext

            ////2、有接口类注入
            ////注入BLL，UI中使用
            //builder.RegisterAssemblyTypes(typeof(BLL.BaseBLL<>).Assembly)
            //    .AsImplementedInterfaces()  //是以接口方式进行注入
            //    .InstancePerRequest()       //每次http请求
            //    .PropertiesAutowired();     //属性注入

            ////注入DAL，BLL层中使用
            //builder.RegisterAssemblyTypes(typeof(DAL.BaseDAL<>).Assembly).AsImplementedInterfaces()
            //    .InstancePerRequest().PropertiesAutowired();     //属性注入

            //Cache的注入，使用单例模式
            //builder.RegisterType<RedisCacheManager>()
            //    .As<ICacheManager>()
            //    .SingleInstance()
            //    .PropertiesAutowired();

            //移除原本的mvc的容器，使用AutoFac的容器，将MVC的控制器对象实例交由autofac来创建
            //var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}