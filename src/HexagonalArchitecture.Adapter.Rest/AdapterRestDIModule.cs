using Autofac;

namespace HexagonalArchitecture.Adapter.Rest
{
    public class AdapterRestDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Registre as interfaces de repositório aqui
            //builder.RegisterType<YourRepository>().As<IYourRepository>();
            builder.RegisterAssemblyTypes(this.ThisAssembly).AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
