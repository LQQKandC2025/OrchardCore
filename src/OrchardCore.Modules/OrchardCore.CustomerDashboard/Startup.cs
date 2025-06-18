using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Modules;
using OrchardCore.Navigation;

namespace CustomerDashboard
{
    public class Startup : StartupBase
    {
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<INavigationProvider, CustomerDashboard.Navigation.CustomerDashboardMenu>();
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            // Tek sefer "area" ekleyen MapAreaControllerRoute
            routes.MapAreaControllerRoute(
                name: "CustomerDashboard",
                areaName: "CustomerDashboard",     // ← module ID
                pattern: "Admin/Hesabim",
                defaults: new { controller = "Account", action = "Index" }
            );
        }
    }
}
