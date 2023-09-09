using Autofac;

namespace HexagonalArchitecture.Domain
{
    public class DomainDIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Registre os tipos relacionados ao domínio aqui
            //builder.RegisterType<YourRepository>().As<IRepository>();
        }
    }
}
