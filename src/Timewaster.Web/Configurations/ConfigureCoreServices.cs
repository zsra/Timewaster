using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timewaster.Core.Interfaces;
using Timewaster.Core.Interfaces.Services;
using Timewaster.Core.Services;

namespace Timewaster.Web.Configurations
{
    public static class ConfigureCoreServices
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IPlanService, PlanService>();

            return services;
        }
    }
}
