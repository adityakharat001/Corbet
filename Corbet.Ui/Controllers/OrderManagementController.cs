using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Net.Mime;

using Corbet.Application.Models.Mail;
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
            return View(cart)
;
        }


        public ActionResult DeleteCart(int id)
        {
            string data = JsonConvert.SerializeObject(id)
;
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"OrderManagement/DeleteCart?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["AlertMessage"] = "Cart Remove Successfully";
            }
            return RedirectToAction("GetAllCart");

        }


        //GetAllProductSupplier
        [HttpGet]
        public ActionResult GetAllProductSupplier()
        {

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "OrderManagement/GetAllProductDetails").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var productsupplier = JsonConvert.DeserializeObject<List<ProductSupplierStock>>(data);
            return View(productsupplier);
        }

        [HttpGet]
        public ActionResult IncreaseCartItem(int stockId, int UserId, int cartId, int productId, int Quantity)
        {

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "OrderManagement/DecreaseQuantityCart").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            if (!response.IsSuccessStatusCode)
            {
                TempData["AlertMessage"] = "Sorry Stock is full";
            }
            return NoContent();
        }

        [HttpGet]
        public ActionResult CreateOrder()
        {

            //  string UserId = HttpContext.Session.GetString("UserId");
            //int userId = Convert.ToInt32(UserId);

            //  HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"OrderManagement/TotalBill?UserId={userId}").Result;
            //  dynamic data = response.Content.ReadAsStringAsync().Result;
            //  var cart = JsonConvert.DeserializeObject<double>(data);

            return View();
        }

        [HttpGet]

        [HttpPost]
        public ActionResult  CreateOrder(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                string UserId = HttpContext.Session.GetString("UserId");
                orderViewModel.UserId = Convert.ToInt32(UserId);
                //TO Generat a OrderCode
                Random ran = new Random();

                String b = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                string OrderCode = "ORD";
                int length = 2;

                String random = "";

                for (int i = 0; i < length; i++)
                {
                    int a = ran.Next(b.Length); //string.Lenght gets the size of string
                    random = random + b.ElementAt(a);
                }
                orderViewModel.OrderCode = "ORD" + random + "00" + UserId;

                string data = JsonConvert.SerializeObject(orderViewModel);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "OrderManagement/AddOrder", content).Result;
                if (response.IsSuccessStatusCode)

                {
                    int id;
                    id = (int)orderViewModel.UserId;
                    string dataUpdate = JsonConvert.SerializeObject(orderViewModel.UserId);
                    StringContent contentupdate = new StringContent(dataUpdate, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage responseupdate = client.GetAsync(client.BaseAddress + $"Stock/UpdateStockQuantity?id={id}").Result;
                    if (responseupdate.IsSuccessStatusCode)
                    {
                        string datadelete = JsonConvert.SerializeObject(orderViewModel.UserId);
                        StringContent contentdelete = new StringContent(datadelete, System.Text.Encoding.UTF8, "application/json");
                        HttpResponseMessage responsedelete = client.DeleteAsync(client.BaseAddress + $"OrderManagement/RemoveAllCart?userid={id}").Result;
                        if (responsedelete.IsSuccessStatusCode)
                        {
                            TempData["AlertMessage"] = "Cart Remove Successfully";
                            


                          // SendMail(filePath,emailFrom, emailTo);

                        }
                    }
                 return RedirectToRoute(new { controller = "OrderManagement", action = "GetAllProductSupplier" });

                }
                else
                {
                    return View();
                }
            }
            
            else
            {
                return View();
            }
           // return RedirectToRoute(new { controller = "OrderManagement", action = "GetAllOrderDetails" });
        }

        //[HttpGet]
        //public ActionResult GetAllOrderDetails()
        //{

        //}
        [HttpGet]
        public JsonResult GetAllTotalBill()
        {
             string UserId = HttpContext.Session.GetString("UserId");
            int userId = Convert.ToInt32(UserId);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"OrderManagement/TotalBill?UserId={userId}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
         GetTotalBill getTotalBill = JsonConvert.DeserializeObject<GetTotalBill>(data);
            return Json(getTotalBill.TotalBill);
        }


      


        [HttpGet]
        public JsonResult GetAllSupplier()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Supplier/GetAllSuppliers").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var supplier = JsonConvert.DeserializeObject<List<SupplierViewModel>>(data);
            return Json(supplier);
        }


        [HttpGet]
        public JsonResult GetAllCartOrder()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            int userid = Convert.ToInt32(UserId);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"OrderManagement/GetAllCartDetails?UserId={userid}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
   var cart = JsonConvert.DeserializeObject<List<GetAllCart>>(data);
            return Json(cart);


        }


        [HttpGet]
        public JsonResult GetAllState()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "OrderManagement/GetAllState").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var state = JsonConvert.DeserializeObject<List<StateView>>(data);
            return Json(state);
        }



        //Send a mail

        public string SendMail(string filePath, string emailFrom, string emailTo)
        {
            MailAddress sendTo = new MailAddress(emailTo);
            MailAddress sendFrom = new MailAddress(emailFrom);
            Attachment billAttachment = new Attachment(filePath, MediaTypeNames.Application.Octet);
            MailMessage message = new MailMessage(sendFrom, sendTo);
            message.Subject = "Order Placed successfully! Here is your bill invoice";
            message.IsBodyHtml = true;
            message.Body = $"Hello User, <br> Thank you for your purchase. Below attached is the invoice of your order, incase of " +
                $"any queries please write back to us. Purchase Again! <br> Regards, <br> Team Corbet.";
            message.Attachments.Add(billAttachment);
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(emailFrom, "password"),
                EnableSsl = true
            };
            client.Send(message);
            return "Order mail sent successfully!";
        }

        //Get User By Id
        public string  GetUserById(int userId)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"User/GetUserById?id={userId}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            UserViewModel user = JsonConvert.DeserializeObject<UserViewModel>(data);
            string email=user.Email;
            return email;

        }

        public string GetSupplierById(int supplierId)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Supplier/GetSupplierById?id={supplierId}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            SupplierViewModel supplier = JsonConvert.DeserializeObject<SupplierViewModel>(data);
            string email = supplier.Email;
            return email;

        }
    }
}








//
//    };
//    client.Send(message);
//    return "Invoice mail sent successfully!";
//}
