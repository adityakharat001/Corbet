using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Controllers
{
    public class BackOfficeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
