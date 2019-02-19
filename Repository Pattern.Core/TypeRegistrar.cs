using Autofac;
using System.Reflection;

namespace Repository_Pattern.Core
{
    public class TypeRegistrar : ITypeRegistrar
    {
        public int Order => 0;

        public void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .AsImplementedInterfaces();
        }
    }
}