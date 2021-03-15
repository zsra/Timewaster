using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.Services;
using Timewaster.Infrastructure.DataAccess;
using Timewaster.Infrastructure.Logging;

namespace Timewaster.Web.Configurations
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IPlansService, PlansService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITeamService, TeamService>();

            return services;
        }
    }
}
