using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.Modules;
using OrchardCore.Navigation;

namespace CustomerDashboard
{
    public class Startup : StartupBase
    {
        private readonly AdminOptions _adminOptions;

        public Startup(IOptions<AdminOptions> adminOptions)
        {
            _adminOptions = adminOptions.Value;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<INavigationProvider, CustomerDashboard.Navigation.CustomerDashboardMenu>();

            services.Configure<RazorViewEngineOptions>(options =>
            {
                // 1) /Areas/{Area}/Views/Shared/*.cshtml
                options.AreaViewLocationFormats.Insert(0, "/Areas/{2}/Views/Shared/{0}.cshtml");
                // 2) /Areas/{Area}/Views/{Controller}/*.cshtml
                options.AreaViewLocationFormats.Insert(1, "/Areas/{2}/Views/{1}/{0}.cshtml");
                // 3) /Areas/{Area}/Views/*.cshtml (fallback)
                options.AreaViewLocationFormats.Insert(2, "/Areas/{2}/Views/{0}.cshtml");
            });
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            var prefix = _adminOptions.AdminUrlPrefix?.Trim('/') ?? "Admin";

            routes.MapAreaControllerRoute(
            name: "CustomerDashboardCatchAll",
            areaName: "CustomerDashboard",
            pattern: $"{prefix}/Customer/{{*path}}",
            defaults: new { controller = "Account", action = "Index" }
        );
        }
    }
}
