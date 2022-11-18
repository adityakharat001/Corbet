using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient client;
        public RoleController(ILogger<RoleController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(RoleResponseDto role)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(role);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Role/AddRole", content).Result;
                return RedirectToAction("GetAllRoles");

            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateRole(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Role/GetRoleById?id={id}").Result;
            dynamic roleData = response.Content.ReadAsStringAsync().Result;
            RoleUpdateDto role = JsonConvert.DeserializeObject<RoleUpdateDto>(roleData);
            return View(role);
        }

        [HttpPost]
        public ActionResult UpdateRole(RoleUpdateDto role)
        {
            string data = JsonConvert.SerializeObject(role);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Role/UpdateRole", content).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.roleUpdateAlert = "<script type='text/javascript'>Swal.fire('Role Update','Role Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/Role/GetAllRoles');</script>";
                return View();
            }
            else
            {
                ViewBag.roleUpdateAlert = "<script type='text/javascript'>Swal.fire('Roles Update','Failed To Update Role!','error');</script>";
                return View();

            }

            return RedirectToAction("GetAllRoles");
        }

        [HttpGet]
        public ActionResult GetAllRoles()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "Role/AllRoles").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var roleList = JsonConvert.DeserializeObject<List<Role>>(data);
            return View(roleList);

        }


        public ActionResult DeleteRole(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"Role/DeleteRole?id={id}").Result;
            return RedirectToAction("GetAllRoles");

        }

        [HttpGet]
        public JsonResult IsRoleExist(string RoleName)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Role/RoleNameExist/{RoleName}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            bool roleExists = JsonConvert.DeserializeObject(data);
            if (roleExists == true)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }


    }
}
