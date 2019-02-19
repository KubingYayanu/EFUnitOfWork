using Autofac;
using Autofac.Integration.Mvc;
using Repository_Pattern.Core;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Mvc;

namespace Repository_Pattern.Web
{
    public class AutofacConfig
    {
        /// <summary>
        /// 註冊DI/IOC Container
        /// </summary>
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            var registrars = BuildManager.GetReferencedAssemblies().Cast<Assembly>()
                                         .SelectMany(p => p.ExportedTypes.Where(s => s.IsAssignableTo<ITypeRegistrar>() && s.IsInterface == false))
                                         .Select(p => (ITypeRegistrar)Activator.CreateInstance(p))
                                         .OrderBy(p => p.Order)
                                         .ToList();

            registrars.ForEach(x => x.RegisterTypes(builder));

            var container = builder.Build();
            var resolver = new AutofacDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
        }
    }
}