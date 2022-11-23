using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;
using Corbet.Application.Responses;
using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;


namespace Corbet.Ui.Controllers
{
    public class CategoryDetailsController : Controller
    {
        private readonly ILogger<CategoryDetailsController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient _httpClient;


        public CategoryDetailsController(ILogger<CategoryDetailsController> logger)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        //CreateCategoryDetails
        #region Add Category Details
        [HttpGet]
        public ActionResult CreateCategoryDetails()
        {
            HttpResponseMessage msg = _httpClient.GetAsync(_httpClient.BaseAddress + "ProductCategory/GetAllCategories").Result;
            if (msg.IsSuccessStatusCode)
            {
                var responseData = msg.Content.ReadAsStringAsync().Result;

                dynamic CategoryList = JsonConvert.DeserializeObject(responseData);


                var CategoryNamelist = new List<SelectListItem>();
                foreach (var item in CategoryList)
                {
                    CategoryNamelist.Add(new SelectListItem { Text = item.categoryName.ToString(), Value = item.categoryId.ToString() });

                }
                ViewBag.CategoryNamelist = CategoryNamelist;

            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategoryDetails(CategoryDetailsUpdateModel categoryDetails)
        {
            string data = JsonConvert.SerializeObject(categoryDetails);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "ProductCategoryDetails/AddCategoryDetails", content).Result;
            TempData["AlertMessage"] = "Product Category Deatails Added Suucessfully";
            return RedirectToRoute(new { controller = "CategoryDetails", action = "GetAllCategoryDetails" });
        }

        #endregion



        //Get All Category details
        #region GetAllCategoryDetails
        [HttpGet]
        public ActionResult GetAllCategoryDetails()
        {
            HttpResponseMessage msg = _httpClient.GetAsync(_httpClient.BaseAddress + "ProductCategoryDetails/GetAllCategoryDetails").Result;
            dynamic data = msg.Content.ReadAsStringAsync().Result;
            var detailsList = JsonConvert.DeserializeObject<List<GetCategoryDetailView>>(data);
            return View(detailsList);
        }
        #endregion


        #region Delete Category Details
        public ActionResult DeleteCategoryDetails(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + $"ProductCategoryDetails/DeleteCategoryDetails?id={id}").Result;
            return RedirectToAction("GetAllCategoryDetails");
        }
        #endregion


        //update category details
        #region Update Category Details
        [HttpGet]
        public ActionResult UpdateCategoryDetails(int id)
        {
            string data = JsonConvert.SerializeObject(id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"ProductCategoryDetails/GetcategoryDetailsById?id={id}").Result;
            dynamic categoryDetailsData = response.Content.ReadAsStringAsync().Result;
            CategoryDetailsViewModel categoryDetails = JsonConvert.DeserializeObject<Response<CategoryDetailsViewModel>>(categoryDetailsData).Data;

            HttpResponseMessage msg = _httpClient.GetAsync(_httpClient.BaseAddress + "ProductCategory/GetAllCategories").Result;
            if (msg.IsSuccessStatusCode)
            {
                var responseDataRead = msg.Content.ReadAsStringAsync().Result;

                dynamic CategoryList = JsonConvert.DeserializeObject(responseDataRead);


                var CategoryNamelist = new List<SelectListItem>();
                foreach (var item in CategoryList)
                {
                    CategoryNamelist.Add(new SelectListItem { Text = item.categoryName.ToString(), Value = item.categoryId.ToString() });
                    // TaxNamelist.Add(new SelectListItem { Text = item.TaxId, Value = item.Name.ToString() });

                }
                ViewBag.CategoryNameList = CategoryNamelist;

            }
            return View(categoryDetails);
        }


        [HttpPost]
        public ActionResult UpdateCategoryDetails(CategoryDetailsUpdateModel taxDetails)
        {
            string data = JsonConvert.SerializeObject(taxDetails);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "ProductCategoryDetails/UpdateCategoryDetail", content).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.categoryDetailUpdateAlert = "<script type='text/javascript'>Swal.fire('Product Category Details Update','Product Category Details Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/Tax/GetAllTaxDetails');</script>";
                return View();
            }
            else
            {
                ViewBag.categoryDetailUpdateAlert = "<script type='text/javascript'>Swal.fire('Product Category Details Update','Failed To Update Product Category Details !','error');</script>";
                return View();

            }
            return RedirectToAction("GetAllCategoryDetails");
        }
        #endregion

    }
}
