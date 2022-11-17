using Corbet.Domain.Entities;
using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ILogger<SupplierController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient client;
        public SupplierController(ILogger<SupplierController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetAllSuppliersForPurchaseUser()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Supplier/GetAllSuppliers").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var supplierList = JsonConvert.DeserializeObject<List<SupplierViewModel>>(data);
            return View(supplierList);
        }

        [HttpGet]
        public ActionResult GetAllSuppliersForAdmin()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Supplier/GetAllSuppliers").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var supplierList = JsonConvert.DeserializeObject<List<SupplierViewModel>>(data);
            return View(supplierList);
        }


        [HttpGet]
        public ActionResult UpdateSupplierForAdmin(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/GetSupplierById?id={id}").Result;
            dynamic supplierData = response.Content.ReadAsStringAsync().Result;
            var supplier = JsonConvert.DeserializeObject<SupplierUpdateAdminDto>(supplierData);

            return View(supplier);
        }


        [HttpPost]
        public ActionResult UpdateSupplierForAdmin(SupplierUpdateAdminDto supplierUpdate)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(supplierUpdate);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Supplier/UpdateSupplierForAdmin", content).Result;


                if (response.IsSuccessStatusCode)
                {
                    ViewBag.supplierUpdateAlert = "<script type='text/javascript'>Swal.fire('Supplier Update','Supplier Details Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/Supplier/GetAllSuppliersForAdmin');</script>";
                    return View();
                }
                else
                {
                    ViewBag.supplierUpdateAlert = "<script type='text/javascript'>Swal.fire('Supplier Update','Failed To Update Supplier Details!','error');</script>";
                    return View();

                }
                return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForAdmin" });
            }
            return View();
        }


        [HttpGet]
        public ActionResult UpdateSupplierForPurchaseUser(int supplierId)
        {
            string data = JsonConvert.SerializeObject(supplierId);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/GetSupplierById?id={supplierId}").Result;
            dynamic supplierData = response.Content.ReadAsStringAsync().Result;
            var supplier = JsonConvert.DeserializeObject<SupplierUpdatePurchaseUserDto>(supplierData);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult UpdateSupplierForPurchaseUser(SupplierUpdatePurchaseUserDto supplierUpdate)
        {
            string data = JsonConvert.SerializeObject(supplierUpdate);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Supplier/UpdateSupplierForPurchaseUser", content).Result;
            return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForPurchaseUser" });
        }

        public ActionResult ToggleActiveStatus(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/ToggleActiveStatus?supplierId={id}").Result;
            return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForAdmin" });
        }


        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
