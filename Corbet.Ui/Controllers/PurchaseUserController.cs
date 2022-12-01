using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;

using Nancy.Json;

using Newtonsoft.Json.Linq;

namespace Corbet.Ui.Controllers
{
    public class PurchaseUserController : Controller
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



        public IActionResult Index()
        {
            return View();
        }
    }
}
