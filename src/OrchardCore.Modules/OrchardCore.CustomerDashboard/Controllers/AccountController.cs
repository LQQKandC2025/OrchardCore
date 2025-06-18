using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CustomerDashboard.Controllers
{
    [Authorize]
    // [Area("CustomerDashboard")]    ← Bunu **kaldırın**
    public class AccountController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Hesap Bilgilerim";
            ViewData["Username"] = User.Identity?.Name;
            ViewData["OrderInfo"] = "Sipariş: Koltuk Takımı, Ödenen: 5.000 TL, Kalan: 2.500 TL";
            return View(); // ~/Areas/CustomerDashboard/Views/Account/Index.cshtml
        }
    }
}
