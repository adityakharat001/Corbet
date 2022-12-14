using Corbet.Application.Responses;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;

using Nancy.Helpers;

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
            List<SupplierViewModel> supplierList = JsonConvert.DeserializeObject<List<SupplierViewModel>>(data);
            foreach (var supplier in supplierList)
            {
                supplier.SupplierId = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(Convert.ToString(supplier.SupplierId)));
            }
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

            supplier.CreatedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            string data = JsonConvert.SerializeObject(supplier);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Supplier/AddSupplier", content).Result;
            return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForPurchaseUser" });
        }


        [HttpGet]
        public ActionResult AddSupplierForAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddSupplierForAdmin(SupplierAddDto supplier)
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

            supplier.CreatedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            string data = JsonConvert.SerializeObject(supplier);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Supplier/AddSupplier", content).Result;
            return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForPurchaseUser" });
        }


        [HttpGet]
        public ActionResult UpdateSupplierForAdmin(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/GetSupplierById?id={_id}").Result;
            dynamic supplierData = response.Content.ReadAsStringAsync().Result;
            var supplier = JsonConvert.DeserializeObject<SupplierUpdateAdminDto>(supplierData);

            return View(supplier);
        }


        [HttpPost]
        public ActionResult UpdateSupplierForAdmin(SupplierUpdateAdminDto supplierUpdate)
        {
            if (ModelState.IsValid)
            {
                supplierUpdate.LastModifiedBy = int.Parse(HttpContext.Session.GetString("UserId"));
                supplierUpdate.SupplierId = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(supplierUpdate.Id)));

                string data = JsonConvert.SerializeObject(supplierUpdate);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Supplier/UpdateSupplierForAdmin", content).Result;


                if (response.IsSuccessStatusCode)
                {
                    ViewBag.supplierUpdateAlert = "<script type='text/javascript'>Swal.fire('Supplier Update','Supplier Details Updated Successfully!','success').then(()=>window.location.href='/Supplier/GetAllSuppliersForAdmin');</script>";
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
            supplierUpdate.LastModifiedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            string data = JsonConvert.SerializeObject(supplierUpdate);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Supplier/UpdateSupplierForPurchaseUser", content).Result;
            return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForPurchaseUser" });
        }

        public ActionResult ToggleActiveStatus(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/ToggleActiveStatus?supplierId={_id}").Result;
            return Json(true);
        }

        public ActionResult DeleteSupplier(int id)
        {
            int deletedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            string data = JsonConvert.SerializeObject(id);
            string delData = JsonConvert.SerializeObject(deletedBy);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            StringContent delContent = new StringContent(delData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"Supplier/DeleteSupplier?Id={id}&deletedBy={deletedBy}").Result;
            return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliersForPurchaseUser" });
        }

        public ActionResult DeleteSupplierForAdmin(string id)
        {
            int deletedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            string delData = JsonConvert.SerializeObject(deletedBy);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            StringContent delContent = new StringContent(delData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"Supplier/DeleteSupplier?Id={_id}&deletedBy={deletedBy}").Result;
            return Json(true);
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
