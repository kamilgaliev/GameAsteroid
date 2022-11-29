using Microsoft.AspNetCore.Mvc;

namespace WebStoreDuble.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

    }
}
