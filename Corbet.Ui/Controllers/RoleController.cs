using Corbet.Application.Features.UnitMeasurements.Queries.GetAllUnitMeasurements;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Helpers;
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
                TempData["AlertMessage"] = "User Role Added Successfully";
                return RedirectToAction("GetAllRoles");

            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateRole(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"Role/GetRoleById?id={_id}").Result;
            dynamic roleData = response.Content.ReadAsStringAsync().Result;
            RoleUpdateDto role = JsonConvert.DeserializeObject<RoleUpdateDto>(roleData);
            return View(role);
        }

        [HttpPost]
        public ActionResult UpdateRole(RoleUpdateDto role)
        {
            role.RoleId = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(role.Id)));
            string data = JsonConvert.SerializeObject(role);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "Role/UpdateRole", content).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.roleUpdateAlert = "<script type='text/javascript'>Swal.fire('Role Update','Role Updated Successfully!','success').then(()=>window.location.href='/Role/GetAllRoles');</script>";
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
            List<Role> roleList = JsonConvert.DeserializeObject<List<Role>>(data);
            //return View(roleList);

            List<GetAllRolesViewModel> getAllRolesVmList = new List<GetAllRolesViewModel>();
            for (int i = 0; i < roleList.Count; i++)
            {
                GetAllRolesViewModel getAllRolesVm = new GetAllRolesViewModel()
                {
                    RoleId = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(Convert.ToString(roleList[i].RoleId))),
                    RoleName = roleList[i].RoleName
                };
                getAllRolesVmList.Add(getAllRolesVm);
            }
            return View(getAllRolesVmList);
        }


        public ActionResult DeleteRole(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"Role/DeleteRole?id={_id}").Result;
            return Json("True");

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
