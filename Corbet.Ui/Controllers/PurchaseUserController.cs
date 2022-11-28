using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Controllers
{
    public class PurchaseUserController : Controller
    {
        public PurchaseUserController()
        {

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
