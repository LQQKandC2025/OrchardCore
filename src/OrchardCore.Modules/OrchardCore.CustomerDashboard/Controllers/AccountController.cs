using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchardCore.Admin;


namespace CustomerDashboard.Controllers
{
    [Authorize]
    [Admin]
    public class AccountController : Controller
    {


        public IActionResult Index()
        {
            string path = HttpContext.Request.Path.Value?.ToLowerInvariant() ?? "";

            if (path.EndsWith("/hesabim"))
            {
                ViewData["Username"] = User.Identity?.Name;
                ViewData["OrderInfo"] = "Sipariş: Koltuk Takımı, Ödenen: 5.000 TL, Kalan: 2.500 TL";
                return View("Index"); // ~/Views/Account/Index.cshtml
            }
            else if (path.EndsWith("/siparis"))
            {
                ViewData["SiparisListesi"] = "Sipariş: Koltuk Takımı"; // örnek veri
                return View("Siparis"); // ~/Views/Account/Siparis.cshtml
            }
            else if (path.EndsWith("/odemeler"))
            {
                ViewData["borc"] = "21.450 TL"; // örnek veri
                return View("Odeme"); // ~/Views/Account/Adreslerim.cshtml
            }

            return Redirect("/admin/");
            //return View("Genel"); // fallback sayfası


        }
    }
}
