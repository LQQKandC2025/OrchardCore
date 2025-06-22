using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using OrchardCore.Admin;
using OrchardCore.Navigation;
namespace CustomerDashboard.Navigation
{

    public class CustomerDashboardMenu : AdminNavigationProvider
    {
        private readonly IStringLocalizer T;
        private readonly AdminOptions _adminOptions;


        public CustomerDashboardMenu(IStringLocalizer<CustomerDashboardMenu> localizer, IOptions<AdminOptions> adminOptions)
        {
            T = localizer;
            _adminOptions = adminOptions.Value;
        }


        protected override ValueTask BuildAsync(NavigationBuilder builder)
        {

         //   builder.Add(T["Hesabım"], menu => menu
         //    .Url("/Admin/Hesabim")  // veya .Action("Index","Account",new{area=""}) 
         //    .LocalNav()
         //);

            return ValueTask.CompletedTask;
        }
    }
}
