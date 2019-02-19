using Autofac;
using Repository_Pattern.Core;
using Repository_Pattern.Entity;
using System.Reflection;

namespace Repository_Pattern.Repository
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public int Order => 5;

        public void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<,>))
                   .As(typeof(IRepository<>));

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork<RepositoryPatternContext>>()
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}