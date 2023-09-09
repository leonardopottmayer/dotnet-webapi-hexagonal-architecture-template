using HexagonalArchitecture.Adapter.Rest.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace HexagonalArchitecture.Adapter.Rest.Extensions
{
    public static class RestExtensions
    {
        public static void ConfigureAdapterRest(this IServiceCollection services)
        {
            services.AddControllers().AddApplicationPart(typeof(AdapterRestDIModule).Assembly);

            services.AddTransient<ResponseWrapper>();
        }
    }
}
