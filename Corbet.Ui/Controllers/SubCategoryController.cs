using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;

namespace Corbet.Ui.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ILogger<SubCategoryController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient client;
        public SubCategoryController(ILogger<SubCategoryController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult CreateSubCategory()
        {
            
                return View();
        }

        [HttpPost]
        public ActionResult CreateSubCategory(SubCategoryAddView subCategoryAddView)
        {
            if (ModelState.IsValid) 
            {

                string userid = HttpContext.Session.GetString("UserId");
                subCategoryAddView.CreatedBy = Convert.ToInt32(userid);
                string data = JsonConvert.SerializeObject(subCategoryAddView);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "ProductSubCategory/AddSubProductCategory", content).Result;
                return RedirectToAction("GetAllSubCategory");

            }
            return View();
        }


        [HttpGet]
        public ActionResult GetAllSubCategory()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "ProductSubCategory/GetAllSubCategories").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var subCategoryList = JsonConvert.DeserializeObject<List<GetSubCategoryVm>>(data);
            return View(subCategoryList);

        }


    }
}
