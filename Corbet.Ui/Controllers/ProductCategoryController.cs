using Corbet.Application.Responses;
using Corbet.Ui.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ILogger<ProductCategoryController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient _httpClient;

        public ProductCategoryController(ILogger<ProductCategoryController> logger)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            _logger = logger;

        }


        public IActionResult Index()
        {
            return View();
        }

        //add product category
        #region Add Product Category
        [HttpGet]
        public ActionResult AddProductCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProductCategory(ProductCategoryModel category)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(category);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "ProductCategory/AddProductCategory", content).Result;
                TempData["AlertMessage"] = "Product Category Added Suucessfully";
                return RedirectToRoute(new { controller = "ProductCategory", action = "GetAllCategories" });

            }
            return View();
        }
        #endregion


        //Get all product categories
        #region Get All categories
        [HttpGet]
        public ActionResult GetAllCategories()
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "ProductCategory/GetAllCategories").Result;
            dynamic data=response.Content.ReadAsStringAsync().Result;
            var categorylist=JsonConvert.DeserializeObject<List<ProductCategoryModel>>(data);
            return View(categorylist);
        }
        #endregion


        //Update product category

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"ProductCategory/GetcategoryById?id={id}").Result;
            dynamic categoryData = response.Content.ReadAsStringAsync().Result;
            ProductCategoryModel category = JsonConvert.DeserializeObject<Response<ProductCategoryModel>>(categoryData).Data;
            return View(category);
        }



        [HttpPost]
        public ActionResult UpdateCategory(ProductCategoryModel categoryUpdate)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(categoryUpdate);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "ProductCategory/UpdateCategory", content).Result;


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
                return RedirectToRoute(new { controller = "ProductCategory", action = "GetAllCategories" });
            }
            return RedirectToAction("GetAllCategories");
        }
        public ActionResult DeleteCategory(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + $"ProductCategory/DeleteCategory?id={id}").Result;
            return RedirectToAction("GetAllCategories");

        }

    }
}
