using System.Text;

using Corbet.Application.Contracts;
using Corbet.Application.Features.Customers.Commands.ChangePassword;
using Corbet.Application.Features.Customers.Commands.ResetPasswordForCustomer;
using Corbet.Application.Features.Customers.Commands.ResetPasswordForCustomer;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Helper;
using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;

using Nancy.Helpers;
using Nancy.Json;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Corbet.Ui.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILoggedInUserService _loggedInUserService;
        private readonly ILogger<CustomerController> _logger;


        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient client;
        public CustomerController(ILogger<CustomerController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }

        public ActionResult CustomerLogin()
        {
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            if (userSession != null)
            {
                return RedirectToRoute(new { controller = "Customer", action = "Index" });
            }
            return View();
        }


        [HttpPost]
        public ActionResult CustomerLogin(Login login)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(login);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                client.BaseAddress = baseAddress;
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Auth/LoginCustomer", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseData);
                    LoginResponseDto AuthData = JsonConvert.DeserializeObject<LoginResponseDto>(responseData);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "UserName", AuthData.UserName);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "user", AuthData);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "RoleName", AuthData.RoleName);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "UserId", AuthData.Id);
                    string Username = HttpContext.Session.GetString("UserName");
                    TempData["UserName"] = Username.Replace("\"", "");
                    string RoleName = HttpContext.Session.GetString("RoleName");
                    string roleName = RoleName.Replace("\"", "");
                    string trimmedRoleName = String.Concat(roleName.Where(r => !Char.IsWhiteSpace(r)));
                    if (trimmedRoleName.ToLower() == "customer")
                    {
                        return RedirectToRoute(new { controller = "Customer", action = "Index" });
                    }

                }
                HttpContext.Session.Remove("user");
                HttpContext.Session.Clear();
                TempData.Clear();
                TempData["Error"] = "Failed To Login User. Please Enter Valid Credentials";
                return View();
            }
            HttpContext.Session.Remove("user");
            return View();
        }


        [HttpGet]
        public ActionResult RegisterCustomer()
        {
           return View();
        }


        [HttpPost]
        public ActionResult RegisterCustomer(CustomerRegisterDto user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Customer/AddCustomer", content).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.customerUpdateAlert = "<script type='text/javascript'>Swal.fire('Account Registered Successfully','Login With Your Credentials To Proceed','success').then(()=>window.location.href='/Customer/CustomerLogin');</script>";
                return View();
            }
            else
            {
                ViewBag.customerUpdateAlert = "<script type='text/javascript'>Swal.fire('Account Registration Failed','Failed To Register Account','error');</script>";
                return View();

            }
            return RedirectToRoute(new { controller = "Customer", action = "CustomerLogin" });
        }



        [HttpGet]
        public ActionResult EditProfile()
        {
            int id = int.Parse(HttpContext.Session.GetString("UserId"));
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Customer/GetCustomerById?id={id}").Result;
            dynamic userData = response.Content.ReadAsStringAsync().Result;
            EditProfileViewModel vm = new EditProfileViewModel();
            vm.changePasswordCommand = new ChangePasswordCommand();
            vm.customerUpdateDto = JsonConvert.DeserializeObject<CustomerUpdateDto>(userData);
            return View(vm);
        }

        [HttpPost]
        public ActionResult EditProfile(EditProfileViewModel user)
        {
            user.customerUpdateDto.LastModifiedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            user.customerUpdateDto.CustomerId = int.Parse(HttpContext.Session.GetString("UserId"));
            string data = JsonConvert.SerializeObject(user.customerUpdateDto);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Customer/UpdateCustomer", content).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.userUpdateAlert = "<script type='text/javascript'>Swal.fire('Profile Update','Your Details Are Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/Customer/EditProfile');</script>";
                return View(user);
            }
            else
            {
                ViewBag.userUpdateAlert = "<script type='text/javascript'>Swal.fire('Profile Update','Failed To Update Your Details!','error');</script>";
                return RedirectToAction("EditProfile");

            }
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                string data = JsonConvert.SerializeObject(email)
;
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync($"{httpClient.BaseAddress}Auth/ForgotPasswordForCustomer?email={email}", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    ViewBag.emailAvailabilityAlert = "<script type='text/javascript'>Swal.fire('Mail Sending Operation','Email Sent Successfully!','success');</script>";
                    return View();
                }
                else
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var jsonArrayResponse = JObject.Parse(apiResponse);
                    var resultErrorsStr = jsonArrayResponse["errors"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var errorsList = js.Deserialize<List<string>>(resultErrorsStr);
                    ViewBag.emailAvailabilityAlert = $"<script type='text/javascript'>Swal.fire('{errorsList[0]}','{errorsList[1]}','warning');</script>";
                    return View();
                }
            }
        }

        [HttpGet]
        public IActionResult ResetPassword(string email)
        {
            ResetPasswordForCustomerCommand resetPasswordCommand = new ResetPasswordForCustomerCommand();
            resetPasswordCommand.Email = email;
            return View(resetPasswordCommand);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordForCustomerCommand resetPasswordCommand)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                StringContent content = new StringContent(JsonConvert.SerializeObject(resetPasswordCommand), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{httpClient.BaseAddress}Auth/ResetPasswordForCustomer", content);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.resetPasswordAlert = "<script type='text/javascript'>Swal.fire('Reset Password','Password Reset Successfully!','success').then(()=>window.location.href='/Customer/CustomerLogin');</script>";
                    return View();
                }
                else
                {
                    ViewBag.resetPasswordAlert = "<script type='text/javascript'>Swal.fire('','Old password and new password are same. If you wanna reset the password, try different password.','warning');</script>";
                    return View();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(EditProfileViewModel changePassword)
        {
            using (var httpClient = new HttpClient())
            {
                changePassword.changePasswordCommand.CustomerId = int.Parse(HttpContext.Session.GetString("UserId"));
                httpClient.BaseAddress = baseAddress;
                StringContent content = new StringContent(JsonConvert.SerializeObject(changePassword.changePasswordCommand), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{httpClient.BaseAddress}Auth/ChangePasswordForCustomer", content);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    TempData["changePasswordSuccess"] = "true";
                    return RedirectToAction("EditProfile");
                }
                else
                {
                    TempData["changePasswordFailed"] = "true";
                    return RedirectToAction("EditProfile");
                }
            }
        }


        [HttpGet]
        public IActionResult CustomerLogout()
        {
            Console.WriteLine(HttpContext.Session.GetString("user"));
            HttpContext.Session.Remove("user");
            HttpContext.Session.Clear();
            TempData.Clear();
            Console.WriteLine($"Null : {HttpContext.Session.GetString("user")}");
            return RedirectToAction("CustomerLogin");
        }


        public IActionResult Index()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Product/GetAllProducts").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var products = JsonConvert.DeserializeObject<List<Product>>(data);
            return View(products);
        }
    }
}
