using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class OrderManagementController : Controller
    {
        private readonly ILogger<TaxController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient _httpClient;
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CreateOrder()
        {

            HttpResponseMessage msg = _httpClient.GetAsync(_httpClient.BaseAddress + "SupplierDetails/GetAlSuppliersDetails").Result;
            if (msg.IsSuccessStatusCode)
            {
                var responseData = msg.Content.ReadAsStringAsync().Result;

                dynamic SupplierList = JsonConvert.DeserializeObject(responseData);


                var SupplieNamelist = new List<SelectListItem>();
                foreach (var item in SupplierList)
                {
                    SupplieNamelist.Add(new SelectListItem { Text = item.SupplierName.ToString(), Value = item.SupplierId.ToString() });
                    // TaxNamelist.Add(new SelectListItem { Text = item.TaxId, Value = item.Name.ToString() });

                }
                ViewBag.SupplieNamelist = SupplieNamelist;
                return View();
            }

            return View();
        }
    }
}
