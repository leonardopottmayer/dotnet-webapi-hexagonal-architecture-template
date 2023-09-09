using Autofac;
using HexagonalArchitecture.Adapter.Authorization;
using HexagonalArchitecture.Adapter.Authorization.Extensions;
using HexagonalArchitecture.Adapter.Data;
using HexagonalArchitecture.Adapter.Rest;
using HexagonalArchitecture.Adapter.Rest.Extensions;
using HexagonalArchitecture.Adapter.Rest.Middlewares;
using HexagonalArchitecture.Adapter.SystemInfoProvider;
using HexagonalArchitecture.Adapter.UserProvider;
using HexagonalArchitecture.Api.Extensions;
using HexagonalArchitecture.Domain;
using HexagonalArchitecture.Domain.Adapters.Data;
using HexagonalArchitecture.Logic;
using HexagonalArchitecture.Logic.Profiles.ProductProfiles;
using Serilog;
using Serilog.Events;
using System.Reflection;

namespace HexagonalArchitecture.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProductProfile).GetTypeInfo().Assembly /*, typeof(DBProductProfile).GetTypeInfo().Assembly*/); // Map from different projects

            services.ConfigureSwagger();

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
            });

            services.AddEndpointsApiExplorer();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.ConfigureAuthentication(Configuration);

            services.AddHttpContextAccessor();

            services.ConfigureAdapterRest();
        }

        // Api configurations
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hexagonal Architecture API v1");
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Hexagonal Architecture API v1");
                    //options.SwaggerEndpoint("/swagger/v2/swagger.json", "Hexagonal Architecture API v2");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseMiddleware<ResponseWrapper>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute(name: "apiVersion", pattern: "api/v{version}/{controller=Home}/{action=Index}");
            });

            app.UseSerilogRequestLogging(options =>
            {
                options.GetLevel = (ctx, _, ex) =>
                {
                    if (ex != null || ctx.Response.StatusCode > 499)
                    {
                        return LogEventLevel.Error;
                    }
                    return LogEventLevel.Information;
                };
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Add modules for each class library in solution
            builder.RegisterAssemblyModules(typeof(DomainDIModule).Assembly);
            builder.RegisterAssemblyModules(typeof(AdapterDataDIModule).Assembly);
            builder.RegisterAssemblyModules(typeof(AdapterRestDIModule).Assembly);
            builder.RegisterAssemblyModules(typeof(LogicDIModule).Assembly);
            builder.RegisterAssemblyModules(typeof(AdapterUserProviderDIModule).Assembly);
            builder.RegisterAssemblyModules(typeof(AdapterSystemInfoProviderDIModule).Assembly);
            builder.RegisterModule(new AdapterAuthorizationDIModule(Configuration));

            builder.Register(c =>
            {
                var connectionString = Configuration.GetConnectionString("Default");
                return new DBConnectionFactory(connectionString);
            }).As<IDBConnection>().InstancePerLifetimeScope();

            builder.RegisterType<DBContext>().As<IDBContext>().InstancePerLifetimeScope();
            builder.RegisterType<ContainerService>().As<IContainerService>();
        }
    }
}
