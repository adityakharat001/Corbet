using Corbet.Application.Responses;
using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;


        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        //Uri ddlAddress = new Uri("https://localhost:7221/Product/CategoryDdl")
        HttpClient client;
        public ProductController(ILogger<ProductController> logger, IWebHostEnvironment webHostEnvironment)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }



        [HttpGet]
        public ActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductResponseDto product)
        {

            if (product.Image != null)
            {
                product.ImagePath = product.Image.FileName;
                string folder = "Images/ProductImages/";
                string productGuid = Guid.NewGuid().ToString();
                product.ImagePath = productGuid + product.ImagePath;
                folder += productGuid + product.Image.FileName;

                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await product.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            else if (product.Image == null)
            {
                product.ImagePath = "default.jpg";
            }
            string data = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Product/AddProduct", content).Result;
            TempData["AlertMessage"] = "Product Added Suucessfully";
            return RedirectToRoute(new { controller = "Product", action = "GetAllProducts" });
        }

        [HttpGet]
        public ActionResult GetAllProducts()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Product/GetAllProducts").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<Product>>(data);
            return View(products);
        }


        [HttpGet]
        public JsonResult CategoryDdl()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "ProductCategory/GetAllCategories").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var categories = JsonConvert.DeserializeObject<List<ProductCategoryModel>>(data);
            return Json(categories);
        }

        [HttpGet]
        public JsonResult SubcategoryDdl(int id)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"ProductSubCategory/GetSubCategoryByCategoryId/{id}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var subCategories = JsonConvert.DeserializeObject<List<SubCategoryDdlModel>>(data);
            return Json(subCategories);
        }

        [HttpGet]
        public JsonResult UnitDdl()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "UnitMeasurement/GetAllUnitMeasurements").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var units = JsonConvert.DeserializeObject<List<UnitMeasurement>>(data);
            return Json(units);
        }

        [HttpGet]
        public JsonResult SupplierDdl()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Supplier/GetAllSuppliers").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var suppliers = JsonConvert.DeserializeObject<List<SupplierViewModel>>(data);
            return Json(suppliers);
        }
        
        [HttpGet]
        public JsonResult TaxDdl()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Tax/GetAllTaxes").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var taxes = JsonConvert.DeserializeObject<List<TaxViewModel>>(data);
            return Json(taxes);
        }


        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Product/GetProductById?id={id}").Result;
            dynamic productData = response.Content.ReadAsStringAsync().Result;
            var product = JsonConvert.DeserializeObject<ProductResponseDto>(productData);
            return View(product);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProduct(ProductResponseDto product)
        {
            if (product.Image != null)
            {
                product.ImagePath = product.Image.FileName;
                string folder = "Images/ProductImages/";
                string productGuid = Guid.NewGuid().ToString();
                product.ImagePath = productGuid + product.ImagePath;
                folder += productGuid + product.Image.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);
                await product.Image.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }
            else if(product.Image == null)
            {
                product.ImagePath = "default.jpg";
            }
            string data = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Product/UpdateProduct", content).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.productUpdateAlert = "<script type='text/javascript'>Swal.fire('Product Update','Product Details Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/Product/GetAllProducts');</script>";
                return View();
            }
            else
            {
                ViewBag.productUpdateAlert = "<script type='text/javascript'>Swal.fire('Product Update','Failed To Update Product Details!','error');</script>";
                return View();

            }
        }


        public ActionResult DeleteProduct(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"Product/DeleteProduct?Id={id}").Result;
            return RedirectToAction("GetAllProducts");

        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
