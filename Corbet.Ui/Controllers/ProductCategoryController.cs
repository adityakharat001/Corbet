using System.Data;

using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

using Nancy.Helpers;

using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class ProductCategoryController : Controller
    {
        private readonly ILogger<ProductCategoryController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient _httpClient;

        public ProductCategoryController(ILogger<ProductCategoryController> logger)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            _logger = logger;

        }


        public IActionResult Index()
        {
            return View();
        }

        //add product category
        #region Add Product Category
        [HttpGet]
        public ActionResult AddProductCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProductCategory(ProductCategoryModel category)
        {
            if (ModelState.IsValid)
            {
                string data = JsonConvert.SerializeObject(category);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "ProductCategory/AddProductCategory", content).Result;
                TempData["AlertMessage"] = "Product Category Added Suucessfully";
                return RedirectToRoute(new { controller = "ProductCategory", action = "GetAllCategories" });

            }
            return View();
        }
        #endregion

        //Get all product categories
        #region Get All categories
        [HttpGet]
        public ActionResult GetAllCategories()
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "ProductCategory/GetAllCategories").Result;
            dynamic data=response.Content.ReadAsStringAsync().Result;
            var categorylist=JsonConvert.DeserializeObject<List<ProductCategoryModel>>(data);
            //return View(categorylist);
            List<GetAllProductCategoriesViewModel> getAllProductCategoriesViewModelList = new List<GetAllProductCategoriesViewModel>();
            for (int i = 0; i < categorylist.Count; i++)
            {
                GetAllProductCategoriesViewModel getAllProductCategoriesVm = new GetAllProductCategoriesViewModel()
                {
                    CategoryId = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(Convert.ToString(categorylist[i].CategoryId))),
                    CategoryName = categorylist[i].CategoryName
                };
                getAllProductCategoriesViewModelList.Add(getAllProductCategoriesVm);
            }
            return View(getAllProductCategoriesViewModelList);
        }
        #endregion


        //Update product category
        #region Update category
        [HttpGet]
        public ActionResult UpdateCategory(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"ProductCategory/GetcategoryById?id={_id}").Result;
            dynamic categoryData = response.Content.ReadAsStringAsync().Result;
            ProductCategoryUpdateModel category = JsonConvert.DeserializeObject<Response<ProductCategoryUpdateModel>>(categoryData).Data;
            return View(category);
        }


        [HttpPost]
        public ActionResult UpdateCategory(ProductCategoryUpdateModel categoryUpdate)
        {
            if (ModelState.IsValid)
            {
                categoryUpdate.CategoryId = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(categoryUpdate.Id)));
                string data = JsonConvert.SerializeObject(categoryUpdate);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "ProductCategory/UpdateCategory", content).Result;


                if (response.IsSuccessStatusCode)
                {
                    ViewBag.categoryUpdateAlert = "<script type='text/javascript'>Swal.fire('Category Update','Product Category Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/ProductCategory/GetAllCategories');</script>";
                    return View();
                }
                else
                {
                    ViewBag.categoryUpdateAlert = "<script type='text/javascript'>Swal.fire('Category Update','Failed To Update Product Category!','error');</script>";
                    return View();

                }
                return RedirectToRoute(new { controller = "ProductCategory", action = "GetAllCategories" });
            }
            return RedirectToAction("GetAllCategories");
        }

        #endregion

        //delete category 
        #region Delete category
        public ActionResult DeleteCategory(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + $"ProductCategory/DeleteCategory?id={_id}").Result;
            return Json("True");
        }

        #endregion


        //is category exist
        #region Category exist

        public JsonResult IsCategoryExist(string CategoryName)
      {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"ProductCategory/CategoryNameExist?categoryName={CategoryName}").Result;
            dynamic data=response.Content.ReadAsStringAsync().Result;
            bool categoryExist=JsonConvert.DeserializeObject(data);
            if (categoryExist == true)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
        #endregion 

    }
}
