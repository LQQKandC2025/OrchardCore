using OrchardCore.Security.Permissions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerDashboard
{
    public class Permissions : IPermissionProvider
    {
        public static readonly Permission AccessCustomerDashboard = new("AccessCustomerDashboard", "Can access customer dashboard");

        public Task<IEnumerable<Permission>> GetPermissionsAsync()
        {
            return Task.FromResult<IEnumerable<Permission>>(new[]
            {
                AccessCustomerDashboard
            });
        }

        public IEnumerable<PermissionStereotype> GetDefaultStereotypes()
        {
            return new[]
            {
                new PermissionStereotype
                {
                    Name = "Customer", // bu rolün adı
                    Permissions = new[] { AccessCustomerDashboard }
                }
            };
        }
    }
}
