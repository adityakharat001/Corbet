using System.Net.Http;

using Corbet.Domain.Entities;
using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class OrderManagementController : Controller
    {
        private readonly ILogger<OrderManagementController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient client;
        public IActionResult Index()
        {
            return View();
        }

        public OrderManagementController(ILogger<OrderManagementController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetAllCart()
        {
            string UserId = HttpContext.Session.GetString("UserId");
           int userid = Convert.ToInt32(UserId);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"OrderManagement/GetAllCartDetails?UserId={userid}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var cart = JsonConvert.DeserializeObject<List<GetAllCart>>(data);
            return View(cart);
        }


        public ActionResult DeleteCart(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"OrderManagement/DeleteCart?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["AlertMessage"] = "Cart Remove Suucessfully";
            }
            return RedirectToAction("GetAllCart");

        }

        [HttpGet]
        public ActionResult CreateOrder()
        {

            return View();
        }


        [HttpPost]
        public ActionResult CreateOrder(OrderViewModel orderViewModel)
        {
            string UserId = HttpContext.Session.GetString("UserId");
            orderViewModel.UserId = Convert.ToInt32(UserId);
            //TO Generat a OrderCode
            Random ran = new Random();

            String b = "abcdefghijklmnopqrstuvwxyz0123456789";
          

            int length = 6;

            String random = "";

            for (int i = 0; i < length; i++)
            {
                int a = ran.Next(b.Length); //string.Lenght gets the size of string
                random = random + b.ElementAt(a);
            }
            orderViewModel.OrderCode = random;  
           
            string data = JsonConvert.SerializeObject(orderViewModel);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "OrderManagement/AddOrder", content).Result;
            TempData["AlertMessage"] = "Order Added Suucessfully";
            return RedirectToRoute(new { controller = "OrderManagement", action = "GetAllOrderDetails" });
        }


        //[HttpGet]
        //public ActionResult CreateOrder()
        //{

        //    HttpResponseMessage msg = _httpClient.GetAsync(_httpClient.BaseAddress + "SupplierDetails/GetAlSuppliersDetails").Result;
        //    if (msg.IsSuccessStatusCode)
        //    {
        //        var responseData = msg.Content.ReadAsStringAsync().Result;

        //        dynamic SupplierList = JsonConvert.DeserializeObject(responseData);


        //        var SupplieNamelist = new List<SelectListItem>();
        //        foreach (var item in SupplierList)
        //        {
        //            SupplieNamelist.Add(new SelectListItem { Text = item.SupplierName.ToString(), Value = item.SupplierId.ToString() });
        //            // TaxNamelist.Add(new SelectListItem { Text = item.TaxId, Value = item.Name.ToString() });

        //        }
        //        ViewBag.SupplieNamelist = SupplieNamelist;
        //        return View();
        //    }

        //    return View();
        //}
    }
}
