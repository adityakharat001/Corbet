using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;

using Nancy.Helpers;
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
            var stockTypeList = new List<GetAllStockTypesModel>();
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
                    stockTypeList = js.Deserialize<List<GetAllStockTypesModel>>(resultData);
                    //return View(stockTypeList);
                }
                else
                {
                    return View();
                }

                List<GetAllStockTypesViewModel> getAllStockTypesVmList = new List<GetAllStockTypesViewModel>();
                for (int i = 0; i < stockTypeList.Count; i++)
                {
                    GetAllStockTypesViewModel getAllStockTypesVm = new GetAllStockTypesViewModel()
                    {
                        StockTypeId = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(Convert.ToString(stockTypeList[i].StockTypeId))),
                        StockTypeName = stockTypeList[i].StockTypeName
                    };
                    getAllStockTypesVmList.Add(getAllStockTypesVm);
                }
                return View(getAllStockTypesVmList);
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
        public IActionResult UpdateStockType(string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
                HttpResponseMessage response = httpClient.GetAsync($"{httpClient.BaseAddress}/StockType/GetStockTypeById/{_id}").Result;
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
                httpClient.BaseAddress = baseAddress;
                var _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(updateStockTypeModel.Id)));
                string data = JsonConvert.SerializeObject(updateStockTypeModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{httpClient.BaseAddress}/StockType/UpdateStockType/{_id}", content);
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

        public async Task<IActionResult> DeleteStockType(string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
                HttpResponseMessage response = await httpClient.DeleteAsync($"{httpClient.BaseAddress}/StockType/DeleteStockType/{_id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonArrayResponse = JObject.Parse(responseData);

                    var result = jsonArrayResponse["data"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var resultDeserialized = js.Deserialize<GetAllStockTypesModel>(result);
                    return Json("True");
                }
                else
                {
                    return Json("False");
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
