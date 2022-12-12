using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Nancy;
using Nancy.Diagnostics;
using Nancy.Helpers;

using Newtonsoft.Json;
using System.Net.Http;
using System.Xml.Linq;

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
            HttpResponseMessage msg = client.GetAsync(client.BaseAddress + "ProductCategory/GetAllCategories").Result;
            if (msg.IsSuccessStatusCode)
            {
                var responseData = msg.Content.ReadAsStringAsync().Result;

                dynamic SubCategoryList = JsonConvert.DeserializeObject(responseData);


                var SubCategorylistData = new List<SelectListItem>();
                foreach (var item in SubCategoryList)
                {
                    SubCategorylistData.Add(new SelectListItem { Text = item.categoryName.ToString(), Value = item.categoryId.ToString() });
                    // TaxNamelist.Add(new SelectListItem { Text = item.TaxId, Value = item.Name.ToString() });

                }
                ViewBag.SubCategorylistData = SubCategorylistData;

                HttpResponseMessage msg2 = client.GetAsync(client.BaseAddress + "Tax/GetAllTaxes").Result;
                if (msg.IsSuccessStatusCode)
                {
                    var responseData1 = msg2.Content.ReadAsStringAsync().Result;

                    dynamic TaxList = JsonConvert.DeserializeObject(responseData1);


                    var TaxNamelist = new List<SelectListItem>();
                    foreach (var item in TaxList)
                    {
                        TaxNamelist.Add(new SelectListItem { Text = item.name.ToString(), Value = item.taxId.ToString() });
                        // TaxNamelist.Add(new SelectListItem { Text = item.TaxId, Value = item.Name.ToString() });

                    }
                    ViewBag.TaxNamelist = TaxNamelist;

                }
                    return View();
            }
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
                if (response.IsSuccessStatusCode)
                {
                    TempData["AlertMessage"] = "Product SubCategory Added Suucessfully";
                    return RedirectToAction("GetAllSubCategory");
                }
                else
                {
                    TempData["Message"] = "SubCategory Data Already Exist!!!!";
                    return View();
                }
               


            }
            return View();

        }


        [HttpGet]
        public ActionResult GetAllSubCategory()
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "ProductSubCategory/GetAllSubCategories").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            List<GetSubCategoryVm> subCategoryList = JsonConvert.DeserializeObject<List<GetSubCategoryVm>>(data);
            //return View(subCategoryList);

            List<GetSubCategoryViewModel> getSubCategoryVmList = new List<GetSubCategoryViewModel>();
            for (int i = 0; i < subCategoryList.Count; i++)
            {
                GetSubCategoryViewModel getSubCategoryVm = new GetSubCategoryViewModel()
                {
                    SubCategoryId = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(Convert.ToString(subCategoryList[i].SubCategoryId))),
                    CategoryName = subCategoryList[i].CategoryName,
                    SubCategoryName = subCategoryList[i].SubCategoryName,
                    Description = subCategoryList[i].Description,
                    TaxName = subCategoryList[i].TaxName,
                    Status = subCategoryList[i].Status
                };
                getSubCategoryVmList.Add(getSubCategoryVm);
            }
            return View(getSubCategoryVmList);

        }


        //Update Controller
        [HttpGet]
        public ActionResult UpdateSubCategory(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + $"ProductSubCategory/GetSubCategoryById?id={_id}").Result;
            dynamic categoryData = response.Content.ReadAsStringAsync().Result;
            SubCategoryUpdateView category = JsonConvert.DeserializeObject<Response<SubCategoryUpdateView>>(categoryData).Data;
            HttpResponseMessage msg = client.GetAsync(client.BaseAddress + "ProductCategory/GetAllCategories").Result;
            if (msg.IsSuccessStatusCode)
            {
                var responseData = msg.Content.ReadAsStringAsync().Result;

                dynamic SubCategoryList = JsonConvert.DeserializeObject(responseData);


                var SubCategorylistData = new List<SelectListItem>();
                foreach (var item in SubCategoryList)
                {
                    SubCategorylistData.Add(new SelectListItem { Text = item.categoryName.ToString(), Value = item.categoryId.ToString() });
                    // TaxNamelist.Add(new SelectListItem { Text = item.TaxId, Value = item.Name.ToString() });

                }
                ViewBag.SubCategorylistData = SubCategorylistData;

                //Viewbag for Tax Type
                HttpResponseMessage Taxresponse = client.GetAsync(client.BaseAddress + "Tax/GetAllTaxes").Result;
                if (msg.IsSuccessStatusCode)
                   {
                    var TaxresponseData = Taxresponse.Content.ReadAsStringAsync().Result;

                    dynamic TaxList = JsonConvert.DeserializeObject(TaxresponseData);


                    var TaxNamelist = new List<SelectListItem>();
                    foreach (var item in TaxList)
                    {
                        TaxNamelist.Add(new SelectListItem { Text = item.name.ToString(), Value = item.taxId.ToString() });
                        // TaxNamelist.Add(new SelectListItem { Text = item.TaxId, Value = item.Name.ToString() });

                    }
                    ViewBag.TaxNameList = TaxNamelist;


                    return View(category);
                }
            }
            return View();
        }


        [HttpPost]
        public ActionResult UpdateSubCategory(SubCategoryUpdateView subcategoryUpdate)
        {
            if (ModelState.IsValid)
            {
                subcategoryUpdate.SubCategoryId = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(subcategoryUpdate.Id)));
                string userid = HttpContext.Session.GetString("UserId");
               
                subcategoryUpdate.LastModifiedBy = Convert.ToInt32(userid);
                string data = JsonConvert.SerializeObject(subcategoryUpdate);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(client.BaseAddress + "ProductSubCategory/UpdateSubCategory", content).Result;


                if (response.IsSuccessStatusCode)
                {
                    ViewBag.supplierUpdateAlert = "<script type='text/javascript'>Swal.fire('SubCategory Update','SubCategory Details Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/SubCategory/GetAllSubCategory');</script>";
                    return RedirectToAction("GetAllSubCategory");
                }
                else
                {
                    TempData["NotUpdate"] = "SubCategory Data Not updated !!!!";
                    return View();

                }
                
            }
            return RedirectToAction("GetAllSubCategory");
        }


        public ActionResult DeleteSubCategory(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + $"ProductSubCategory/DeleteSubCategory?id={_id}").Result;

            ViewBag.DeleteSuccess = "Data Deleted Successful!!";

            return Json("True");

        }
    }
}
