using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Localization;
using OrchardCore.Navigation;

namespace CustomerDashboard.Navigation
{
    public class CustomerDashboardMenu : INavigationProvider
    {
        private readonly IStringLocalizer T;

        public CustomerDashboardMenu(IStringLocalizer<CustomerDashboardMenu> localizer)
        {
            T = localizer;
        }

        public ValueTask BuildNavigationAsync(string name, NavigationBuilder builder)
        {
            if (!string.Equals(name, "admin", StringComparison.OrdinalIgnoreCase))
            {
                return ValueTask.CompletedTask;
            }

            builder
    .Add(T["Hesabım"], menu => menu
        .Url("/Admin/Hesabim")  // 🔥 kesin çalışır
        .LocalNav()
    );

            return ValueTask.CompletedTask;
        }
    }
}
