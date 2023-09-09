using Autofac;

namespace HexagonalArchitecture.Logic
{
    public class LogicDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly).AsImplementedInterfaces().InstancePerLifetimeScope();

            //builder.RegisterType<LoggingUtils>().As<ILoggingUtils>().InstancePerLifetimeScope();
        }
    }
}
