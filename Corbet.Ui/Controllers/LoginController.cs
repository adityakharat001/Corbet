using Corbet.Application.Contracts;
using Corbet.Application.Features.Users.Commands.ResetPassword;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Helper;
using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;

using Nancy.Json;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Text;

namespace Corbet.Ui.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoggedInUserService _loggedInUserService;


        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");


        public ActionResult Login()
        {
            var userSession = SessionHelper.GetObjectFromJson<LoginResponseDto>(HttpContext.Session, "user");
            if (userSession != null)
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return View();
        }


        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(login);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                client.BaseAddress = baseAddress;
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Auth/Login", content).Result;
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
                    if (trimmedRoleName.ToLower() == "admin")
                    {
                        return RedirectToRoute(new { controller = "Home", action = "Index" });
                    }
                    else if (trimmedRoleName.ToLower() == "cspurchaseuser")
                    {
                        return RedirectToRoute(new { controller = "Home", action = "PurchaseLayout" });

                    }
                    else if (trimmedRoleName.ToLower() == "cssalesuser")
                    {
                        return RedirectToRoute(new { controller = "SalesUser", action = "Index" });

                    }
                    else if (trimmedRoleName.ToLower() == "backofficeuser")
                    {
                        return RedirectToRoute(new { controller = "BackOffice", action = "Index" });
                    }

                }
                HttpContext.Session.Remove("user");
                HttpContext.Session.Clear();
                TempData.Clear();
                TempData["Error"] = "Failed To Login User. Please Enter Valid Credentials";
                return View();
            }
            return View();
        }


        //NotFound

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
                HttpResponseMessage response = await httpClient.PostAsync($"{httpClient.BaseAddress}Auth/ForgotPassword?email={email}", content);
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
        public IActionResult ResetPassword(string userId)
        {
            try
            {
                var decryptedUserId = Convert.ToInt32(EncryptionDecryption.DecryptString(userId));
                //GetAllUsers
                Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
                var httpClient = new HttpClient();
                httpClient.BaseAddress = baseAddress;
                HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "User/GetAllUsers").Result;
                dynamic data = response.Content.ReadAsStringAsync().Result;
                List<UserViewModel> users = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
                StringBuilder emailId = new StringBuilder("");

                StringBuilder resetPasswordSignal = new StringBuilder("Red");
                foreach (var user in users)
                {
                    if (user.UserId == decryptedUserId)
                    {
                        emailId.Append(user.Email);
                        resetPasswordSignal.Clear().Append("Green");
                        break;
                    }
                }
                if (resetPasswordSignal.Equals("Red"))
                {
                    return RedirectToAction("Index", "ErrorPage", 404);
                }
                else
                {
                    ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel()
                    {
                        UserId = userId,
                        Email = emailId.ToString()
                    };
                    return View(resetPasswordViewModel);
                }
            }
            catch
            {
                return RedirectToAction("Index", "ErrorPage", 404);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordCommand)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(resetPasswordCommand.UserId));
            //int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(resetPasswordCommand.UserId)));
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                StringContent content = new StringContent(JsonConvert.SerializeObject(resetPasswordCommand), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync($"{httpClient.BaseAddress}Auth/ResetPassword", content);
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.resetPasswordAlert = "<script type='text/javascript'>Swal.fire('Reset Password','Password Reset Successfully!','success').then(()=>window.location.href='/Login');</script>";
                    return View();
                }
                else
                {
                    TempData["OldNew"] = "Old password and new password are same. If you wanna reset the password, try using different password.";
                    string userId = resetPasswordCommand.UserId;
                    return RedirectToRoute(new { controller = "Login", action = "ResetPassword", userId });
                }
            }
        }

        [HttpGet]
        public IActionResult UserLogout()
        {
            Console.WriteLine(HttpContext.Session.GetString("user"));
            HttpContext.Session.Remove("user");
            HttpContext.Session.Clear();
            TempData.Clear();
            Console.WriteLine($"Null : {HttpContext.Session.GetString("user")}");
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
