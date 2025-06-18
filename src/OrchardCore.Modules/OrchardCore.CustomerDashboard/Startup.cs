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

            // ➊ hangi admin teması aktifse onun root Views klasörünü de arayalım
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.AreaViewLocationFormats.Insert(0, "/Areas/{2}/Views/{0}.cshtml");
            });
        }

        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            // ➋ mutlaka bu route'u ekleyin:
            //     /{adminPrefix}/Hesabim => CustomerDashboard/Account/Index
            var prefix = _adminOptions.AdminUrlPrefix?.Trim('/') ?? "Admin";

            routes.MapAreaControllerRoute(
                name: "CustomerDashboard",
                areaName: "CustomerDashboard",
                pattern: $"{prefix}/Hesabim",
                defaults: new { controller = "Account", action = "Index" }
            );
        }
    }
}
