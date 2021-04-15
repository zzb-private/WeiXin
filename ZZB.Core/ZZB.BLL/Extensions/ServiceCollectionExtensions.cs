using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ZZB.BLL.Extensions
{
    //public static class ServiceCollectionExtensions
    //{
    //    public static void ConfigureDependency(this IServiceCollection services)
    //    {
    //        var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.StartsWith("AilExpress"));


    //        foreach (var assembly in assemblies)
    //        {
    //            var types = AssemblyHelper
    //                .GetAllTypes(assembly)
    //                .Where(
    //                    type => type != null &&
    //                            type.IsClass &&
    //                            !type.IsAbstract &&
    //                            !type.IsGenericType)
    //                .ToList();

    //            foreach (var type in types)
    //            {
    //                //if (type.Name.Contains("CommodityAppService"))
    //                //    Console.WriteLine(nameof(ITransientDependency));
    //                //if (type.IsAssignableFrom(typeof(ITransientDependency)))
    //                //{
    //                //    type.GetInterfaces();
    //                //}
    //                AddType(services, type);
    //            }
    //        }
    //    }

    //    private static void AddType(IServiceCollection services, Type type)
    //    {
    //        //if (IsConventionalRegistrationDisabled(type))
    //        //{
    //        //    return;
    //        //}

    //        var dependencyAttribute = type.GetCustomAttribute<DependencyAttribute>(true);
    //        var lifeTime = GetLifeTimeOrNull(type, dependencyAttribute);

    //        if (lifeTime == null)
    //        {
    //            return;
    //        }

    //        var exposedServiceTypes = ExposedServiceExplorer.GetExposedServices(type);

    //        //TriggerServiceExposing(services, type, exposedServiceTypes);

    //        foreach (var serviceType in exposedServiceTypes)
    //        {
    //            services.Add(ServiceDescriptor.Describe(
    //                serviceType,
    //                type,
    //                lifeTime.Value));
    //        }
    //    }

    //    private static ServiceLifetime? GetLifeTimeOrNull(Type type, [CanBeNull] DependencyAttribute dependencyAttribute)
    //    {
    //        return dependencyAttribute?.Lifetime ?? GetServiceLifetimeFromClassHierarcy(type);
    //    }

    //    private static ServiceLifetime? GetServiceLifetimeFromClassHierarcy(Type type)
    //    {
    //        if (typeof(ITransientDependency).GetTypeInfo().IsAssignableFrom(type))
    //        {
    //            return ServiceLifetime.Transient;
    //        }

    //        if (typeof(ISingletonDependency).GetTypeInfo().IsAssignableFrom(type))
    //        {
    //            return ServiceLifetime.Singleton;
    //        }

    //        if (typeof(IScopedDependency).GetTypeInfo().IsAssignableFrom(type))
    //        {
    //            return ServiceLifetime.Scoped;
    //        }

    //        return null;
    //    }
    //}
}
