using Autofac;

namespace Repository_Pattern.Core
{
    public interface ITypeRegistrar
    {
        int Order { get; }

        void RegisterTypes(ContainerBuilder builder);
    }
}