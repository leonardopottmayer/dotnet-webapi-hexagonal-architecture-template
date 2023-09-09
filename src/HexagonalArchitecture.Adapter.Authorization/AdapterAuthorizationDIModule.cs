using Autofac;
using HexagonalArchitecture.Domain.Adapters.Authorization;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace HexagonalArchitecture.Adapter.Authorization
{
    public class AdapterAuthorizationDIModule : Module
    {
        private readonly IConfiguration _configuration;
        public AdapterAuthorizationDIModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PasswordHasher>().As<IPasswordHasher>().SingleInstance();

            builder.Register(c =>
            {
                var jwtSettings = _configuration.GetSection("JwtSettings");

                var key = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);
                var issuer = jwtSettings["Issuer"];
                var audience = jwtSettings["Audience"];

                return new TokenService(key, issuer, audience);
            }).As<ITokenService>().InstancePerLifetimeScope();
        }   
    }
}
