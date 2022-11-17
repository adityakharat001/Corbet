using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class UserRegisterController : Controller
    {
        private readonly ILogger<UserRegisterController> _logger;


        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient client;
        public UserRegisterController(ILogger<UserRegisterController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;

        }


        #region Add User
        [HttpGet]
        public ActionResult AddUser()
        {
            HttpResponseMessage msg = client.GetAsync(client.BaseAddress + "User/GetAllRolesOfUser").Result;
            if (msg.IsSuccessStatusCode)
            {
                var responseData = msg.Content.ReadAsStringAsync().Result;
                dynamic rolelList = JsonConvert.DeserializeObject(responseData);


                List<SelectListItem> UserRolelist = new List<SelectListItem>();
                foreach (var item in rolelList)
                {

                    UserRolelist.Add(new SelectListItem { Text = item.roleName.ToString(), Value = item.roleId.ToString() });

                }
                ViewBag.UserRolelist = UserRolelist;

                return View();
            }
            else
            {
                return View();
            }
        }


        [HttpPost]
        public ActionResult AddUser(UsersRegisterDto user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "User/AddUser", content).Result;
            return RedirectToRoute(new { controller = "UserRegister", action = "GetAllUsers" });
        }
        #endregion



        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"User/GetUserById?id={id}").Result;
            dynamic userData = response.Content.ReadAsStringAsync().Result;
            var user = JsonConvert.DeserializeObject<UserUpdateDto>(userData);
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateUser(UserUpdateDto user)
        {
            string data = JsonConvert.SerializeObject(user);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "User/UpdateUser", content).Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.userUpdateAlert = "<script type='text/javascript'>Swal.fire('User Update','User Details Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/UserRegister/GetAllUsers');</script>";
                return View();
            }
            else
            {
                ViewBag.userUpdateAlert = "<script type='text/javascript'>Swal.fire('User Update','Failed To Update User Details!','error');</script>";
                return View();

            }
        }




        #region Get All User
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "User/GetAllUsers").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var users = JsonConvert.DeserializeObject<List<UserViewModel>>(data);
            return View(users);
        }
        #endregion


        public ActionResult DeleteUser(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"User/DeleteUser?Id={id}").Result;
            return RedirectToAction("GetAllUsers");

        }


        [HttpGet]
        public JsonResult IsEmailExist(string Email)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Auth/DoesEmailExists/{Email}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            bool userExists = JsonConvert.DeserializeObject(data);
            if (userExists == true)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }

        //[HttpGet]
        //public JsonResult IsPhoneExist(string Phone)
        //    {
        //    HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Auth/DoesPhoneExists/{Phone}").Result;
        //    dynamic data = response.Content.ReadAsStringAsync().Result;
        //    bool phoneExists = JsonConvert.DeserializeObject(data);
        //    if (phoneExists == true)
        //    {
        //        return Json(false);
        //    }
        //    else
        //    {
        //        return Json(true);
        //    }
        //}


        public IActionResult Index()
        {
            return View();
        }
    }
}
