using Microsoft.AspNetCore.Mvc;

namespace CustomerDashboard.Controllers;
public sealed class HomeController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
