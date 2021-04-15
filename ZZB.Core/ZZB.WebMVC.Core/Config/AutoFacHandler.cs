using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ZZB.WebMVC.Core.Config
{
    public static class AutoFacHandler
    {
        private static object _lock = new object();
        /// <summary>
        /// //创建一个新IOC容器
        /// </summary>
        private static IContainer _container;
        /// <summary>
        /// AutoFac的容器 判断是否存在,存在就直接使用,不存在就创建
        /// </summary>
        /// <param name="svrName">服务程序集名称</param>
        /// <returns></returns>
        public static IServiceProvider Register(IServiceCollection services, string[] svrNames)
        {
            if (_container == null)
            {
                lock (_lock)
                {
                    if (_container == null)
                    {
                        //  IOC容器注册 构造一个AutoFac的builder容器
                        ContainerBuilder builder = new ContainerBuilder();
                        builder.Populate(services);
                        List<Type> types = new List<Type>();
                        foreach (string item in svrNames)
                        {
                            // 加载接口服务实现层。
                            Assembly SvrAss = Assembly.Load(item);
                            // 反射扫描这个程序集中所有的类，得到这个程序集中所有类的集合。
                            types.AddRange(SvrAss.GetTypes());
                        }
                        // 告诉AutoFac容器，创建stypes这个集合中所有类的对象实例  在一次Http请求上下文中,共享一个组件实例
                        Autofac.Builder.IRegistrationBuilder<object, Autofac.Features.Scanning.ScanningActivatorData, Autofac.Builder.DynamicRegistrationStyle> register = builder.RegisterTypes(types.ToArray()).AsImplementedInterfaces().InstancePerLifetimeScope().PropertiesAutowired();//指明创建的stypes这个集合中所有类的对象实例，以其接口的形式保存

                        //创建一个真正的AutoFac的工作容器
                        _container = builder.Build();
                    }
                }
            }
            return new AutofacServiceProvider(_container);
        }
    }
}
