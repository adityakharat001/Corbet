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
        public IActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult AddSupplier()
        {
            return View();
        }
        //Add Suppliers
        #region Add Suppliers
        [HttpPost]
        public ActionResult AddSupplier(SupplierViewModel suppliers)
        {
            string data = JsonConvert.SerializeObject(suppliers);
            StringContent content=new StringContent(data, System.Text.Encoding.UTF8,"application/json");
            HttpResponseMessage msg= client.PostAsync(client.BaseAddress+ "Supplier/AddSupplier", content).Result;
            TempData["AlertMessage"] = "Supplier Added Sucessfully";
            return RedirectToAction("GetAllSuppliers");
        }
        #endregion


        //Get All Suppliers
        #region get all suppliers
        [HttpGet]
        public ActionResult GetAllSuppliers()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Supplier/GetAllSuppliers").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var supplierList = JsonConvert.DeserializeObject<List<SupplierViewModel>>(data);
            return View(supplierList);
        }
        #endregion

        //Update Suppliers
        #region Update supplier 
        [HttpGet]
        public ActionResult UpdateSupplier(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/GetSupplierById?id={id}").Result;
            dynamic supplierData = response.Content.ReadAsStringAsync().Result;
            var supplier = JsonConvert.DeserializeObject<SupplierViewModel>(supplierData);

            return View(supplier);
        }



        [HttpPost]
        public ActionResult UpdateSupplier(SupplierViewModel supplierUpdate)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(supplierUpdate);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Supplier/UpdateSupplier", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    ViewBag.supplierUpdateAlert = "<script type='text/javascript'>Swal.fire('Supplier Update','Supplier Details Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/Supplier/GetAllSuppliers');</script>";
                    return View();
                }
                else
                {
                    ViewBag.supplierUpdateAlert = "<script type='text/javascript'>Swal.fire('Supplier Update','Failed To Update Supplier Details!','error');</script>";
                    return View();

                }
                return RedirectToRoute(new { controller = "Supplier", action = "GetAllSuppliers" });
            }
            return View();
        }
        #endregion


    }
}
