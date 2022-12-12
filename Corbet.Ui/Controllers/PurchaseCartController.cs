using System.Net;
using System.Net.Mail;

using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class PurchaseCartController : Controller
    {

        private readonly ILogger<PurchaseCartController> _logger;


        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");

        HttpClient client;
        public PurchaseCartController(ILogger<PurchaseCartController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetAllProductPurchase()
        {

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "OrderManagement/GetAllProductDetails").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var productsupplier = JsonConvert.DeserializeObject<List<ProductSupplierStock>>(data);
            return View(productsupplier);
        }



        #region PurchaseGetAllCart
        [HttpGet]
        public ActionResult PurchaseGetAllCart()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            int userid = Convert.ToInt32(UserId);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"PurchaseCart/PurchaseGetAllCartDetails?UserId={userid}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            List<GetAllCart> cart = JsonConvert.DeserializeObject<List<GetAllCart>>(data);
            if (cart != null)
            {
                return View(cart)
;
            }
            else
            {
                return View("EmptyCart");
            }
            //}
        }

        #endregion


        public ActionResult MailOrder()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            int userid = Convert.ToInt32(UserId);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"PurchaseCart/PurchaseGetAllCartDetails?UserId={userid}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var cart = JsonConvert.DeserializeObject<List<GetAllCart>>(data);


            return PartialView(cart);
        }

        [HttpPost]
        public JsonResult PurchaseAddToCart(int stockId, double price)
        {

            Corbet.Ui.Models.PurchaseCart product = new Corbet.Ui.Models.PurchaseCart();
            string UserId = HttpContext.Session.GetString("UserId");
            product.UserId = Convert.ToInt32(UserId);
            product.StockId = stockId;
            product.Price = price;
            string data = JsonConvert.SerializeObject(product);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "PurchaseCart/AddPurchaseCart", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return Json(true);
            }


            return Json(false);
        }



        #region RemoveCart
        public ActionResult PurchaseDeleteCart(int id)
        {
            string data = JsonConvert.SerializeObject(id)
;
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"PurchaseCart/PurchaseDeleteCart?id={id}").Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["AlertMessage"] = "Cart Remove Successfully";
            }
            return RedirectToAction("PurchaseGetAllCart");

        }
        #endregion


        [HttpGet]
        public JsonResult PurchaseIncreaseCartItem(int stockId, int UserId, int cartId, int productId, int Quantity)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"PurchaseCart/PurchaseIncreaseCart?cartid={cartId}&UserId={UserId}&stockId={stockId}&productId={productId}&Quantity={Quantity}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                return Json(true);
            }
            return Json(false);
        }

        [HttpGet]
        public JsonResult PurchaseDecreaseCartItem(int stockId, int UserId, int cartId, int productId, int Quantity)
        {

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"PurchaseCart/PurchaseDecreaseCart?cartid={cartId}&UserId={UserId}&stockId={stockId}&productId={productId}&Quantity={Quantity}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                return Json(true);
            }
            return Json(false);
        }

        #region QuantityUpdate

        [HttpGet]
        public JsonResult QuantityUpdate(int stockId, int UserId, int cartId, int productId, int Quantity)
        {

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"PurchaseCart/QuantityUpdate?cartid={cartId}&UserId={UserId}&stockId={stockId}&productId={productId}&Quantity={Quantity}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                return Json(true);
            }
            return Json(false);
        }

        #endregion

        [HttpGet]
        public JsonResult GetAllTotalBill()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            int userId = Convert.ToInt32(UserId);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"PurchaseCart/TotalBill?UserId={userId}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            GetTotalBill getTotalBill = JsonConvert.DeserializeObject<GetTotalBill>(data);
            return Json(getTotalBill.TotalBill);
        }

        [HttpGet]
        public JsonResult GetAllCartOrder()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            int userid = Convert.ToInt32(UserId);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"PurchaseCart/GetAllCartDetails?UserId={userid}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var cart = JsonConvert.DeserializeObject<List<GetAllCart>>(data);
            return Json(cart)
;


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


        [HttpPost]
        public ActionResult CreateOrder(OrderViewModel orderViewModel)
        {
            if (ModelState.IsValid)
            {
                string UserId = HttpContext.Session.GetString("UserId");
                orderViewModel.UserId = Convert.ToInt32(UserId);
                //TO Generat a OrderCode
                Random ran = new Random();

                String b = "A1B2C3D4E5F6G7H8I9J0KLMNOPQRSTUVWXYZ";

                string OrderCode = "ORD";
                int length = 3;

                String random = "";

                for (int i = 0; i < length; i++)
                {
                    int a = ran.Next(b.Length); //string.Lenght gets the size of string
                    random = random + b.ElementAt(a);
                }
                orderViewModel.OrderCode = "ORD" + random + "0" + UserId;

                string data = JsonConvert.SerializeObject(orderViewModel);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "PurchaseCart/AddOrder", content).Result;
                if (response.IsSuccessStatusCode)

                {
                    int id;
                    id = (int)orderViewModel.UserId;


                    //string datadelete = JsonConvert.SerializeObject(orderViewModel.UserId);
                    //StringContent contentdelete = new StringContent(datadelete, System.Text.Encoding.UTF8, "application/json");
                    //HttpResponseMessage responsedelete = client.DeleteAsync(client.BaseAddress + $"PurchaseCart/RemoveAllCart?userid={id}").Result;


                    TempData["orderAlert"] = "order done";
                    return View(orderViewModel);
                    // SendMail(filePath,emailFrom, emailTo);

                }
            }
            //return RedirectToRoute(new { controller = "PurchaseCart", action = "GetAllProductPurchase" });



            return View();

        }




        [HttpGet]
        public ActionResult PurchaseAllOrder()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            int userid = Convert.ToInt32(UserId);
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"PurchaseOrder/PurchaseAllOrder?UserId={userid}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var cart = JsonConvert.DeserializeObject<List<PurchaseAllOrder>>(data);
            return View(cart)
;
        }


        //Sending a   mail
        public IActionResult GiveOrderAndSendMail(string html)
        {
            string UserId = HttpContext.Session.GetString("UserId");
            int userid = Convert.ToInt32(UserId);

            html = html.Replace("StartTag", "<").Replace("EngTag", ">");
            var btns = $"<br/><button><a href='https://localhost:7221/PurchaseCart/BtnState?status=accepted&UserId={userid}'>Accept</a></button><button><a href='https://localhost:7221/PurchaseCart/BtnState?status=rejected&UserId={userid}'>Reject</a></button>";
            var subject = "You received an order from Corbet (Purchase Staff)";


            SendMail(subject, html + btns, "kajolpathak04@gmail.com", "kajolpathak04@gmail.com");
            ViewBag.emailSentToSupplierStatusMessage = "<script type='text/javascript'>Swal.fire('Order Given Successfully!','Please wait for the supplier response.','success').then(()=>window.location.href='/PurchaseCart/GetAllProductPurchase');</script>";
            //Remove All Cart
            string data = JsonConvert.SerializeObject(userid);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"PurchaseCart/RemoveAllCart?userid={userid}").Result;
            return View("CreateOrder");
        }
        public void SendMail(string subject, string html, string emailFrom, string emailTo)
        {
            MailAddress sendTo = new MailAddress(emailTo);
            MailAddress sendFrom = new MailAddress(emailFrom);
            MailMessage message = new MailMessage(sendFrom, sendTo);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = html;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(emailFrom, "crmfkaflxfcxtyxh"),
                EnableSsl = true
            };
            client.Send(message);
        }



        public void UpdateOrderStatus(int UserId, string Status)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"PurchaseOrder/UpdateOrderStatus?UserId={UserId}&Status={Status}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;

        }



        public ActionResult EmptyPage()
        {
            return View();

        }
        public void BtnState(string status, int UserId)
        {
            bool check = true;
            if (status == "accepted")
            {
                if (check == true)
                {

                    UpdateStockQuantity(UserId);
                    UpdateOrderStatus(UserId, "accepted");



                }

                //edit quantity of stocks logic here

            }
            else
            {
                UpdateOrderStatus(UserId, "rejected");
                check = false;

                //no boaction done

            }
        }



        //Update Stock Quantity
        public bool UpdateStockQuantity(int UserId)
        {

            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Stock/UpdateStockQuantity?UserId={UserId}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            HttpResponseMessage responseremove = client.GetAsync(client.BaseAddress + $"PurchaseCart/RemoveAllCart?userid={UserId}").Result;
            dynamic dataremove = response.Content.ReadAsStringAsync().Result;
            return true;
        }



        #region EmptyOrder
        public ActionResult EmptyOrder()
        {
            return View();
        }
        #endregion
    }





}



