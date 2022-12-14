using System.Data;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nancy.Helpers;
using Newtonsoft.Json;
using Product = Corbet.Ui.Models.Product;
using UnitMeasurement = Corbet.Ui.Models.UnitMeasurement;

namespace Corbet.Ui.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;


        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
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
            product.CreatedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            string data = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Product/AddProduct", content).Result;
            return RedirectToRoute(new { controller = "Product", action = "GetAllProducts" });
        }


        [HttpGet]
        public ActionResult GetAllProducts()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Product/GetAllProducts").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<Product>>(data);
            //return View(products);

            List<GetAllProductsViewModel> getAllProductsVmList = new List<GetAllProductsViewModel>();
            for (int i = 0; i < products.Count; i++)
            {
                GetAllProductsViewModel getAllProductsVm = new GetAllProductsViewModel()
                {
                    ProductId = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(Convert.ToString(products[i].Id))),
                    ProductCode = products[i].ProductCode,
                    ProductName = products[i].ProductName,
                    ProductCategory = products[i].ProductCategory,
                    ProductSubCategory = products[i].ProductSubCategory,
                    Unit = products[i].Unit,
                    Price = products[i].Price,
                    PrimarySupplier = products[i].PrimarySupplier,
                    SecondarySupplier = products[i].SecondarySupplier,
                    ImagePath = products[i].ImagePath,
                    Tax = products[i].Tax,
                    TaxApplicable = products[i].TaxApplicable,
                    IsActive = products[i].IsActive
                };
                getAllProductsVmList.Add(getAllProductsVm);
            }
            return View(getAllProductsVmList);

        }

        [HttpGet]
        public ActionResult GetAllProductsForCustomer()
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
        public ActionResult UpdateProduct(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Product/GetProductById?id={_id}").Result;
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
            else if (product.Image == null)
            {
                product.ImagePath = "default.jpg";
            }
            product.LastModifiedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            product.ProductId = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(product.Id)));
            string data = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Product/UpdateProduct", content).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.productUpdateAlert = "<script type='text/javascript'>Swal.fire('Product Update','Product Details Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/Product/GetAllProducts');</script>";
                return View(product);
            }
            else
            {
                ViewBag.productUpdateAlert = "<script type='text/javascript'>Swal.fire('Product Update','Failed To Update Product Details!','error');</script>";
                return View(product);

            }
        }


        public ActionResult DeleteProduct(string id)
        {
            int deletedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"Product/DeleteProduct?Id={_id}&deletedBy={deletedBy}").Result;
            return Json(true);

        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
