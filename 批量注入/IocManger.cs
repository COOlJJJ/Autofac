using Autofac;
using System.Linq;
using System.Reflection;

namespace 批量注入
{
    public static class IocManger
    {
        /// <summary>
        /// 批量注入扩展
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="assembly"></param>
        public static void BatchAutowired(this ContainerBuilder builder, Assembly assembly)
        {

            var transientType = typeof(ITransitDenpendency); //瞬时注入
            var singletonType = typeof(ISingletonDenpendency); //单例注入
            var scopeType = typeof(IScopeDenpendency); //单例注入
            //瞬时注入
            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(transientType))
                .AsSelf()
                .AsImplementedInterfaces()
                .InstancePerDependency()
                .PropertiesAutowired(new AutowiredPropertySelector());
            //单例注入
            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(singletonType))
               .AsSelf()
               .AsImplementedInterfaces()
               .SingleInstance()
               .PropertiesAutowired(new AutowiredPropertySelector());
            //生命周期注入
            builder.RegisterAssemblyTypes(assembly).Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Contains(scopeType))
               .AsSelf()
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope()
               .PropertiesAutowired(new AutowiredPropertySelector());

        }
    }
}
