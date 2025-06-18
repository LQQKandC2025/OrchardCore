using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomerDashboard.Controllers
{
    [Authorize]
       // → MapAreaControllerRoute ile tanımlı areaName ile eşleşmeli
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Hesabım";
            ViewData["Username"] = User.Identity?.Name;
            ViewData["OrderInfo"] = "Sipariş: Koltuk Takımı, Ödenen: 5.000 TL, Kalan: 2.500 TL";
            return View();       // ~/Areas/CustomerDashboard/Views/Account/Index.cshtml
        }
    }
}
