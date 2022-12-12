using System.Text;

using Corbet.Domain.Entities;
using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Product = Corbet.Ui.Models.Product;

namespace Corbet.Ui.Controllers
{
    public class StockController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:5000/api/v3");

        [HttpGet]
        public IActionResult GetAllStocks()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                HttpResponseMessage response = httpClient.GetAsync($"{httpClient.BaseAddress}/Stock/GetAllStocks").Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    var jsonArrayResponse = JObject.Parse(apiResponse);

                    var resultData = jsonArrayResponse["data"].ToString();

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var stockList = js.Deserialize<List<GetAllStocksModel>>(resultData);
                    return View(stockList);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public IActionResult AddStock()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStock(AddStockModel addStockModel)
        {
            //int year, month, day, hour, min, sec;
            //year = addStockModel.TimeIn.Year;
            //month = addStockModel.TimeIn.Month;
            //day = addStockModel.TimeIn.Day;
            //hour = addStockModel.TimeIn.Hour;
            //min = addStockModel.TimeIn.Minute;
            //sec = 0;
            //addStockModel.TimeIn = new DateTime(year, month, day, hour, min, sec);//assigns year, month, day, hour, min, seconds
            using (var httpClient = new HttpClient())
            {
                addStockModel.CreatedBy = int.Parse(HttpContext.Session.GetString("UserId"));
                httpClient.BaseAddress = baseAddress;
                string data = JsonConvert.SerializeObject(addStockModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync($"{httpClient.BaseAddress}/Stock/AddStock", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonArrayResponse = JObject.Parse(responseData);

                    var result = jsonArrayResponse["data"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var product = js.Deserialize<Product>(result);
                    return RedirectToAction("GetAllStocks");
                }
                else
                {
                    return View();
                }
            }
        }

        public async Task<IActionResult> DeleteStock(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                HttpResponseMessage response = await httpClient.DeleteAsync($"{httpClient.BaseAddress}/Stock/DeleteStock/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonArrayResponse = JObject.Parse(responseData);

                    var result = jsonArrayResponse["data"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var resultDeserialized = js.Deserialize<GetAllStocksModel>(result);
                    return RedirectToAction("GetAllStocks");
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public IActionResult UpdateStock(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                HttpResponseMessage response = httpClient.GetAsync($"{httpClient.BaseAddress}/Stock/GetStockByStockId/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    var jsonArrayResponse = JObject.Parse(apiResponse);

                    var resultData = jsonArrayResponse["data"].ToString();

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var updateStockModel = js.Deserialize<UpdateStockModel>(resultData);
                    return View(updateStockModel);
                }
                else
                {
                    return Json("Cannot Update");
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStock(UpdateStockModel updateStockModel)
        {
            using (var httpClient = new HttpClient())
            {
                updateStockModel.LastModifiedBy = int.Parse(HttpContext.Session.GetString("UserId"));
                httpClient.BaseAddress = baseAddress;
                string data = JsonConvert.SerializeObject(updateStockModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{httpClient.BaseAddress}/Stock/UpdateStock/{updateStockModel.Id}", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonArrayResponse = JObject.Parse(responseData);

                    var result = jsonArrayResponse["data"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var resultDeserialized = js.Deserialize<UpdateStockModel>(result);

                    ViewBag.stockUpdateAlert = "<script type='text/javascript'>Swal.fire('Update Stock Operation','Stock Updated Successfully!','success').then(()=>window.location.href='/Stock/GetAllStocks');</script>";
                    return View(resultDeserialized);
                }
                else
                {
                    ViewBag.stockUpdateAlert = "<script type='text/javascript'>Swal.fire('Update Stock Operation','Stock Not Updated!','warning');</script>";
                    return Json("Something went wrong!");
                }
            }
        }

        [AcceptVerbs("Post", "Get")]
        public async Task<IActionResult> CheckProductExistsInStockList(int productId)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                var response = await httpClient.GetAsync($"{httpClient.BaseAddress}/Stock/CheckProductAlreadyExistsInStockList?productId={productId}");
                var apiResponse = await response.Content.ReadAsStringAsync();
                var jsonArrayResponses = JObject.Parse(apiResponse);
                var stockProductPresent = jsonArrayResponses["data"].ToString();
                if (stockProductPresent != "True")
                {
                    return Json("Product is already present in the stock list.");
                }
                else
                {
                    return Json(true);
                }

            }
        }

        [HttpGet]
        public List<Product> GetProductList()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                //HttpResponseMessage response = httpClient.GetAsync($"{httpClient.BaseAddress}/Product/GetAllProducts").Result;
                //string apiResponse = response.Content.ReadAsStringAsync().Result;
                ////var jsonArrayResponse = JObject.Parse(apiResponse);

                ////var resultData = jsonArrayResponse["data"].ToString();

                //JavaScriptSerializer js = new JavaScriptSerializer();
                //var productList = js.Deserialize<List<Product>>(resultData);
                HttpResponseMessage response = httpClient.GetAsync(httpClient.BaseAddress + "/Product/GetAllProducts").Result;
                dynamic data = response.Content.ReadAsStringAsync().Result;
                var productList = JsonConvert.DeserializeObject<List<Product>>(data);
                return productList;
            }
        }

        [HttpGet]
        public List<StockType> GetStockTypeList()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                HttpResponseMessage response = httpClient.GetAsync($"{httpClient.BaseAddress}/StockType/GetAllStockTypes").Result;
                string apiResponse = response.Content.ReadAsStringAsync().Result;
                var jsonArrayResponse = JObject.Parse(apiResponse);

                var resultData = jsonArrayResponse["data"].ToString();

                JavaScriptSerializer js = new JavaScriptSerializer();
                var stockTypeList = js.Deserialize<List<StockType>>(resultData);
                return stockTypeList;
            }
        }
    }
}
