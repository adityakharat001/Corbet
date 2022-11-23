using System.Net.Http;

using Corbet.Application.Features.SuppliersDetails.Command.UpdateSupplierDetails;
using Corbet.Domain.Entities;
using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class SupplierDetailsController : Controller
    {
        private readonly ILogger<SupplierDetailsController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient client;
        public SupplierDetailsController(ILogger<SupplierDetailsController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        //add product category
        #region Add Supplier Details
        [HttpGet]
        public ActionResult AddSupplierDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSupplierDetails(SupplierDetailsViewModel supplier)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(supplier);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "SupplierDetails/AddSupplierDetails", content).Result;
                TempData["AlertMessage"] = "Product Category Added Suucessfully";
                return RedirectToRoute(new { controller = "SupplierDetails", action = "GetAlSupplierDetails" });

            }
            return View();
        }
        #endregion

        //get all supplier details
        [HttpGet]
        public ActionResult GetAllSupplierDetails()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "SupplierDetails/GetALlSuppliersDetails").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var roleList = JsonConvert.DeserializeObject<List<SupplierDetailsViewModel>>(data);
            return View(roleList);

        }

        [HttpGet]
        public ActionResult UpdateSupplierDetails(int supplierId)
        {
            string data = JsonConvert.SerializeObject(supplierId);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"SupplierDetails/GetSupplierDetailsById?i={supplierId}").Result;
            dynamic supplierData = response.Content.ReadAsStringAsync().Result;
            var supplier = JsonConvert.DeserializeObject<UpdateSupplierDetailsCommandDto>(supplierData);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult UpdateSupplierDetails(UpdateSupplierDetailsCommandDto supplierUpdate)
        {
            string data = JsonConvert.SerializeObject(supplierUpdate);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "SupplierDetails/UpdateSupplierDetails", content).Result;
            return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForPurchaseUser" });
        }

        //public ActionResult ToggleActiveStatus(int id)
        //{
        //    string data = JsonConvert.SerializeObject(id);
        //    StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/ToggleActiveStatus?supplierId={id}").Result;
        //    return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForAdmin" });
        //}


    }
}
