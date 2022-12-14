using System.Text;

using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;

using Nancy.Helpers;
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
            var stockList = new List<GetAllStocksModel>();
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
                    stockList = js.Deserialize<List<GetAllStocksModel>>(resultData);
                    //return View(stockList);
                }
                else
                {
                    return View();
                }
            }

            List<GetAllStocksViewModel> getAllStocksVmList = new List<GetAllStocksViewModel>();
            for (int i = 0; i < stockList.Count; i++)
            {
                GetAllStocksViewModel getAllStocksVm = new GetAllStocksViewModel()
                {
                    StockId = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(Convert.ToString(stockList[i].StockId))),
                    //StockId = (EncryptionDecryption.EncryptString(stockList[i].StockId.ToString())),
                    ProductName = stockList[i].ProductName,
                    Quantity = stockList[i].Quantity,
                    StockTypeName = stockList[i].StockTypeName,
                    TimeIn = stockList[i].TimeIn,
                    TimeOut = stockList[i].TimeOut
                };
                getAllStocksVmList.Add(getAllStocksVm);
            }
            return View(getAllStocksVmList);
        }

        [HttpGet]
        public IActionResult AddStock()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStock(AddStockModel addStockModel)
        {
            int year, month, day, hour, min, sec;
            year = addStockModel.TimeIn.Year;
            month = addStockModel.TimeIn.Month;
            day = addStockModel.TimeIn.Day;
            hour = addStockModel.TimeIn.Hour;
            min = addStockModel.TimeIn.Minute;
            sec = 0;
            addStockModel.TimeIn = new DateTime(year, month, day, hour, min, sec);//assigns year, month, day, hour, min, seconds
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

        public async Task<IActionResult> DeleteStock(string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
                HttpResponseMessage response = await httpClient.DeleteAsync($"{httpClient.BaseAddress}/Stock/DeleteStock/{_id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonArrayResponse = JObject.Parse(responseData);

                    var result = jsonArrayResponse["data"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var resultDeserialized = js.Deserialize<GetAllStocksModel>(result);
                    return Json("True");
                }
                else
                {
                    return Json("False");
                }
            }
        }

        [HttpGet]
        public IActionResult UpdateStock(string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
                HttpResponseMessage response = httpClient.GetAsync($"{httpClient.BaseAddress}/Stock/GetStockByStockId/{_id}").Result;
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
                httpClient.BaseAddress = baseAddress;
                var _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(updateStockModel.Id)));
                string data = JsonConvert.SerializeObject(updateStockModel);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PutAsync($"{httpClient.BaseAddress}/Stock/UpdateStock/{_id}", content);
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
