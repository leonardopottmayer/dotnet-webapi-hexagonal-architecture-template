using HexagonalArchitecture.Domain;

namespace HexagonalArchitecture.Api
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration _configuration;
        public ConfigurationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetApiVertion()
        {
            return _configuration["ApiSettings:Version"];
        }
    }
}