using Corbet.Application.Features.UnitMeasurements.Commands.CreateUnitMeasurement;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;

using Nancy.Helpers;
using Nancy.Json;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.Text;

namespace Corbet.Ui.Controllers
{
    public class UnitMeasurementController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:5000/api/v3");
        [HttpGet]
        public IActionResult GetAllUnitMeasurements()
        {
            var unitMeasurementList = new List<UnitMeasurement>();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                HttpResponseMessage response = httpClient.GetAsync($"{httpClient.BaseAddress}/UnitMeasurement/GetAllUnitMeasurements").Result;
                if (response.IsSuccessStatusCode)
                {
                    dynamic data = response.Content.ReadAsStringAsync().Result;
                    unitMeasurementList = JsonConvert.DeserializeObject<List<UnitMeasurement>>(data);
                    //return View(unitMeasurementList);
                }
                else
                {
                    return View();
                }

                List<GetAllUnitMeasurementsViewModel> getAllUnitMeasurementsVmList = new List<GetAllUnitMeasurementsViewModel>();
                for (int i = 0; i < unitMeasurementList.Count; i++)
                {
                    GetAllUnitMeasurementsViewModel getAllUnitMeasurementsVm = new GetAllUnitMeasurementsViewModel()
                    {
                        Id = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(Convert.ToString(unitMeasurementList[i].Id))),
                        Type = unitMeasurementList[i].Type
                    };
                    getAllUnitMeasurementsVmList.Add(getAllUnitMeasurementsVm);
                }
                return View(getAllUnitMeasurementsVmList);
            }
        }

        [HttpGet]
        public IActionResult CreateUnitMeasurement()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUnitMeasurement(UnitMeasurement unitMeasurement)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    unitMeasurement.CreatedBy = int.Parse(HttpContext.Session.GetString("UserId"));
                    httpClient.BaseAddress = baseAddress;
                    string data = JsonConvert.SerializeObject(unitMeasurement);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync($"{httpClient.BaseAddress}/UnitMeasurement/AddUnitMeasurement", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var jsonArrayResponse = JObject.Parse(responseData);

                        var result = jsonArrayResponse["data"].ToString();
                        TempData["AlertMessage"] = "Unit Measurement Added Sucessfully";
                        return RedirectToAction("GetAllUnitMeasurements");
                    }
                    else
                    {

                        //ViewBag.emailAvailabilityAlert = "<script type='text/javascript'>Swal.fire('','Incorrect email address or no user exists with this email id.','warning');</script>";
                        return View();
                    }

                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateUnitMeasurement(string id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
                HttpResponseMessage response = httpClient.GetAsync($"{httpClient.BaseAddress}/UnitMeasurement/GetUnitMeasurementById?id={_id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = response.Content.ReadAsStringAsync().Result;
                    var jsonArrayResponse = JObject.Parse(apiResponse);

                    var resultData = jsonArrayResponse["data"].ToString();

                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var unitMeasurement = js.Deserialize<UnitMeasurement>(resultData);
                    return View(unitMeasurement);
                }
                else
                {
                    //ViewBag.kang = "<script type='text/javascript'>Swal.fire('','Old password and new password are same. If you wanna reset the password, try different password.','warning');</script>";
                    return View();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUnitMeasurement(GetAllUnitMeasurementsViewModel getAllUnitMeasurementsVm)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    getAllUnitMeasurementsVm.LastModifiedBy = int.Parse(HttpContext.Session.GetString("UserId"));
                    httpClient.BaseAddress = baseAddress;
                    var _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(getAllUnitMeasurementsVm.Id)));
                    string data = JsonConvert.SerializeObject(getAllUnitMeasurementsVm);
                    StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PutAsync($"{baseAddress}/UnitMeasurement/UpdateUnitMeasurement/{_id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseData = await response.Content.ReadAsStringAsync();
                        var jsonArrayResponse = JObject.Parse(responseData);

                        var result = jsonArrayResponse["data"].ToString();
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        var resultDeserialized = js.Deserialize<UnitMeasurement>(result);

                        ViewBag.unitUpdateAlert = "<script type='text/javascript'>Swal.fire('Unit Update','Unit Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/UnitMeasurement/GetAllUnitMeasurements');</script>";
                        return View();
                    }
                    else
                    {
                        ViewBag.unitUpdateAlert = "<script type='text/javascript'>Swal.fire('Unit Update','Failed To Update Unit!','error');</script>";
                        return View();
                    }
                }
            }
            return View();
        }


        public async Task<IActionResult> DeleteUnitMeasurement(string id)
        {
            using (var httpClient = new HttpClient())
            {
                //https://localhost:5000/api/v3/UnitMeasurement/DeleteUnitMeasurement/12
                httpClient.BaseAddress = baseAddress;
                int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
                HttpResponseMessage response = await httpClient.DeleteAsync($"{httpClient.BaseAddress}/UnitMeasurement/DeleteUnitMeasurement/{_id}");
                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var jsonArrayResponse = JObject.Parse(responseData);

                    var result = jsonArrayResponse["data"].ToString();
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    var resultDeserialized = js.Deserialize<UnitMeasurement>(result);
                    return Json("True");
                }
                else
                {
                    return Json("False");
                }
            }
        }


        [AcceptVerbs("Post", "Get")]
        public async Task<IActionResult> IsUnitMeasurementExists(string type)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = baseAddress;
                var response = await httpClient.GetAsync(httpClient.BaseAddress + $"/UnitMeasurement/DoesUnitAlreadyExists/{type}");
                var apiResponse = await response.Content.ReadAsStringAsync();
                var jsonArrayResponses = JObject.Parse(apiResponse);
                var isUnitMeasurementExist = jsonArrayResponses["data"].ToString();
                if (isUnitMeasurementExist != "True")
                {
                    return Json("Unit Type Already Exists!");
                }
                else
                {
                    return Json(true);
                }
            }
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}