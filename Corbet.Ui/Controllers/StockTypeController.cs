using Corbet.Domain.Entities;
using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Corbet.Mvc.Controllers
{
    public class StockTypeController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api/v3");

        [HttpGet]
        public IActionResult GetAllStockTypes()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                HttpResponseMessage response = httpClient.GetAsync($"{httpClient.BaseAddress}/StockType/GetAllStockTypes").Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    var jsonArrayResponse = JObject.Parse(apiResponse);

                    var resultData = jsonArrayResponse["data"].ToString();

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var stockTypeList = js.Deserialize<List<GetAllStockTypesModel>>(resultData);
                    return View(stockTypeList);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public IActionResult AddStockType()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStockType(AddStockTypeModel addStockTypeModel)
        {
            using (var httpClient = new HttpClient())
            {
                addStockTypeModel.CreatedBy = int.Parse(HttpContext.Session.GetString("UserId"));
                httpClient.BaseAddress = baseAddress;
                string data = JsonConvert.SerializeObject(addStockTypeModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync($"{httpClient.BaseAddress}/StockType/AddStockType", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonArrayResponse = JObject.Parse(responseData);

                    var result = jsonArrayResponse["data"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var resultDeserialized = js.Deserialize<AddStockTypeModel>(result);
                    return RedirectToAction("GetAllStockTypes");
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public IActionResult UpdateStockType(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                HttpResponseMessage response = httpClient.GetAsync($"{httpClient.BaseAddress}/StockType/GetStockTypeById/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    var jsonArrayResponse = JObject.Parse(apiResponse);

                    var resultData = jsonArrayResponse["data"].ToString();

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var updateStockTypeModel = js.Deserialize<UpdateStockTypeModel>(resultData);
                    return View(updateStockTypeModel);
                }
                else
                {
                    return Json("Cannot Update");
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStockType(UpdateStockTypeModel updateStockTypeModel)
        {
            using (var httpClient = new HttpClient())
            {
                updateStockTypeModel.LastModifiedBy = int.Parse(HttpContext.Session.GetString("UserId"));
                httpClient.BaseAddress = baseAddress;
                string data = JsonConvert.SerializeObject(updateStockTypeModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{httpClient.BaseAddress}/StockType/UpdateStockType/{updateStockTypeModel.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonArrayResponse = JObject.Parse(responseData);

                    var result = jsonArrayResponse["data"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var resultDeserialized = js.Deserialize<UpdateStockTypeModel>(result);

                    ViewBag.stockTypeUpdateAlert = "<script type='text/javascript'>Swal.fire('Update StockType Operation','StockType Updated Successfully!','success').then(()=>window.location.href='/StockType/GetAllStockTypes');</script>";
                    return View(resultDeserialized);
                }
                else
                {
                    ViewBag.stockTypeUpdateAlert = "<script type='text/javascript'>Swal.fire('Update Stock Operation','Stock Not Updated!','warning');</script>";
                    return Json("Something went wrong!");
                }
            }
        }

        public async Task<IActionResult> DeleteStockType(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                HttpResponseMessage response = await httpClient.DeleteAsync($"{httpClient.BaseAddress}/StockType/DeleteStockType/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonArrayResponse = JObject.Parse(responseData);

                    var result = jsonArrayResponse["data"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var resultDeserialized = js.Deserialize<GetAllStocksModel>(result);
                    return RedirectToAction("GetAllStockTypes");
                }
                else
                {
                    return View();
                }
            }
        }

        [AcceptVerbs("Post", "Get")]
        public async Task<IActionResult> CheckStockTypeExists(string stockTypeName)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                var response = await httpClient.GetAsync($"{httpClient.BaseAddress}/StockType/CheckStockTypeAlreadyExists?stockTypeName={stockTypeName}");
                var apiResponse = await response.Content.ReadAsStringAsync();
                var jsonArrayResponses = JObject.Parse(apiResponse);
                var stockTypePresent = jsonArrayResponses["data"].ToString();
                if (stockTypePresent != "True")
                {
                    return Json("StockType Already Exists!");
                }
                else
                {
                    return Json(true);
                }

            }
        }
    }
}
