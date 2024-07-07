using Microsoft.AspNetCore.Mvc;

namespace RapiApi.Controllers
{
    public class LayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
