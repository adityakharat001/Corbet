using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Controllers
{
    public class SalesUserController : Controller
    {
        public SalesUserController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
