

using System.Reflection.PortableExecutable;

using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class ProductSupplierController : Controller
    {

        private readonly ILogger<ProductSupplierController> _logger;


        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        //Uri ddlAddress = new Uri("https://localhost:7221/Product/CategoryDdl")
        HttpClient client;
        public ProductSupplierController(ILogger<ProductSupplierController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }




        [HttpGet]
        public ActionResult GetAllProductsSupplier()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Product/GetAllProducts").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
          var  products = JsonConvert.DeserializeObject<List<Product>>(data);
            return View(products);
        }


        //   [HttpPost]

        [HttpPost]
        public JsonResult AddToCart(int stockId)
        {
            ProductCart product = new ProductCart();
            string UserId = HttpContext.Session.GetString("UserId");
            product.UserId = Convert.ToInt32(UserId);
            product.StockingId = stockId;
            product.Quantity = 1;
            string data = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "OrderManagement/AddCart", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return Json(true);
            }
            return Json(false);
        }
    }
}