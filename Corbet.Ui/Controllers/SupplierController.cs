using Corbet.Application.Responses;
using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Corbet.Ui.Controllers
{
    public class SupplierController : Controller
    {
        private readonly ILogger<SupplierController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient client;
        public SupplierController(ILogger<SupplierController> logger, IWebHostEnvironment webHostEnvironment)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public ActionResult GetAllSuppliersForPurchaseUser()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Supplier/GetAllSuppliersForPurchaseUser").Result;
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
        public ActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddSupplier(SupplierAddDto supplier)
        {
            if (supplier.Document != null)
            {
                supplier.DocumentPath = supplier.Document.FileName;
                string folder = "Documents/SupplierDocs/";
                string supplierGuid = Guid.NewGuid().ToString();
                supplier.DocumentPath = supplierGuid + supplier.DocumentPath;
                folder += supplierGuid + supplier.Document.FileName;

                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await supplier.Document.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }

            string data = JsonConvert.SerializeObject(supplier);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Supplier/AddSupplier", content).Result;
            return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForPurchaseUser" });
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
        public ActionResult UpdateSupplierForPurchaseUser(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/GetSupplierById?id={id}").Result;
            dynamic supplierData = response.Content.ReadAsStringAsync().Result;
            var supplier = JsonConvert.DeserializeObject<SupplierUpdatePurchaseUserDto>(supplierData);
            return View(supplier);
        }

        [HttpPost]
        public ActionResult UpdateSupplierForPurchaseUser(SupplierUpdatePurchaseUserDto supplierUpdate)
        {
            supplierUpdate.LastModifiedDate = DateTime.Now;
            supplierUpdate.LastModifiedBy = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
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

        public ActionResult DeleteSupplier(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/DeleteSupplier?Id={id}").Result;
            return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForPurchaseUser" });
        }

        public ActionResult GetSupplierDetails(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/GetSupplierById?id={id}").Result;
            dynamic supplierData = response.Content.ReadAsStringAsync().Result;
            var supplier = JsonConvert.DeserializeObject<SupplierViewModel>(supplierData);
            return View(supplier);
        }


        [AcceptVerbs("Post", "Get")]
        public async Task<IActionResult> CheckSupplierExists(string supplierName)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                var response = await httpClient.GetAsync($"{httpClient.BaseAddress}Supplier/CheckSupplierExists?supplierName={supplierName}");
                var apiResponse = await response.Content.ReadAsStringAsync();
                var jsonArrayResponses = JObject.Parse(apiResponse);
                var supplierPresent = jsonArrayResponses["data"].ToString();
                if (supplierPresent != "True")
                {
                    return Json("Supplier Already Exists!");
                }
                else
                {
                    return Json(true);
                }

            }

        }

    }
}
