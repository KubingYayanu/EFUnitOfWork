using Autofac;
using Repository_Pattern.Core;
using System.Linq;
using System.Reflection;

namespace Repository_Pattern.Service
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public int Order => 40;

        public void RegisterTypes(ContainerBuilder builder)
        {
            var assemblyTypes = Assembly.GetExecutingAssembly()
                                        .GetExportedTypes();

            var services = 
                assemblyTypes.Where(x => x.FullName.EndsWith("Service") && x.IsInterface == false)
                             .ToList();

            services.ForEach(x =>
            {
                builder.RegisterType(x)
                       .AsImplementedInterfaces()
                       .InstancePerLifetimeScope();
            });
        }
    }
}