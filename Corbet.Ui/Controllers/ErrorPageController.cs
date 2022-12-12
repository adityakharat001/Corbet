using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Controllers
{
    [Route("ErrorPage/{statutscode}")]
    public class ErrorPageController : Controller
    {
        public IActionResult Index(int statutscode)
        {
            switch (statutscode)
            {
                case 404:
                    ViewData["Error"] = "Page Not Found";

                    break;
                default:
                    break;
            }
            return View("ErrorPage");
        }
    }
}
