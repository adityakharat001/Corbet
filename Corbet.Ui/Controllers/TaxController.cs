﻿using System.Data;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;

using Corbet.Application.Features.Taxes.Queries.GetAllTaxDetails;
using Corbet.Application.Responses;
using Corbet.Domain.Entities;
using Corbet.Infrastructure.EncryptDecrypt;
using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Primitives;

using Nancy.Helpers;

using Newtonsoft.Json;

using static AutoMapper.Internal.ExpressionFactory;

namespace Corbet.Ui.Controllers
{
    public class TaxController : Controller
    {

        private readonly ILogger<TaxController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient _httpClient;


        public TaxController(ILogger<TaxController> logger)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateTax()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateTax(CreateTaxModel tax)
        {
            if (ModelState.IsValid)
            {
                tax.CreatedBy = int.Parse(HttpContext.Session.GetString("UserId"));
                string data = JsonConvert.SerializeObject(tax);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "Tax/AddTax", content).Result;
                TempData["AlertMessage"] = "Tax Type Added Sucessfully";
                return RedirectToRoute(new { controller = "Tax", action = "GetAllTaxes" });
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateTaxDetails()
        {
            HttpResponseMessage msg = _httpClient.GetAsync(_httpClient.BaseAddress + "Tax/GetAllTaxes").Result;
            if (msg.IsSuccessStatusCode)
            {
                var responseData = msg.Content.ReadAsStringAsync().Result;

                dynamic TaxList = JsonConvert.DeserializeObject(responseData);


                var TaxNamelist = new List<SelectListItem>();
                foreach (var item in TaxList)
                {
                    TaxNamelist.Add(new SelectListItem { Text = item.name.ToString(), Value = item.taxId.ToString() });
                    // TaxNamelist.Add(new SelectListItem { Text = item.TaxId, Value = item.Name.ToString() });

                }
                ViewBag.TaxNamelist = TaxNamelist;

                return View();

            }
            return View();
        }


        [HttpPost]
        public ActionResult CreateTaxDetails(TaxDetailsViewModel taxDetails)
        {
            taxDetails.CreatedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            string data = JsonConvert.SerializeObject(taxDetails);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "Tax/AddTaxDetail", content).Result;
            TempData["AlertMessage"] = "Tax Details Added Sucessfully";
            return RedirectToRoute(new { controller = "Tax", action = "GetAllTaxDetails" });
        }



        #region Getting All TaxDetails
        [HttpGet]
        public ActionResult GetAllTaxDetails()
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Tax/GetAllTaxDetails").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var taxList = JsonConvert.DeserializeObject<List<GetTaxDetailListVm>>(data);
            //return View(taxList);

            List<GetAllTaxDetailsViewModel> getAllTaxDetailsVmList = new List<GetAllTaxDetailsViewModel>();
            for (int i = 0; i < taxList.Count; i++)
            {
                GetAllTaxDetailsViewModel getTaxDetailsVm = new GetAllTaxDetailsViewModel()
                {
                    TaxDetailsId = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(Convert.ToString(taxList[i].Id))),
                    Name = taxList[i].Name,
                    MinTax = taxList[i].MinTax,
                    MaxTax = taxList[i].MaxTax,
                    Percentage = taxList[i].Percentage,
                    Status = taxList[i].Status
                };
                getAllTaxDetailsVmList.Add(getTaxDetailsVm);
            }
            return View(getAllTaxDetailsVmList);

        }
        #endregion


        #region Getting All TaxTypes
        [HttpGet]
        public ActionResult GetAllTaxes()
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + "Tax/GetAllTaxes").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            List<TaxViewModel> taxList = JsonConvert.DeserializeObject<List<TaxViewModel>>(data);

            //string taxIdvalue;
            //foreach(var i in taxlist){
            //   // i.TaxId = i.TaxId;
            //    byte[] encoded = System.Text.Encoding.UTF8.GetBytes(i.TaxId.ToString());
            //    i.TaxId = Convert.ToBase64String(encoded);
            //   // i.TaxId=Convert.ToInt32(taxIdvalue);

            //}
            //    int id1 = taxlist.TaxId;
            //    //Encrypt Key
            //    byte[] byKey = { };
            //    byte[] IV =
            //      {
            //18,52,86,120,144,171,205,239
            //    };
            //    byKey = System.Text.Encoding.UTF8.GetBytes("SecrityKey");
            //    DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            //    byte[] inputByteArray = System.Text.Encoding.UTF8.GetBytes();
            //    MemoryStream ms = new MemoryStream();
            //    CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            //    cs.Write(inputByteArray, 0, inputByteArray.Length);
            //    cs.FlushFinalBlock();
            //    string valuenew = Convert.ToBase64String(ms.ToArray());
            //    taxlist.TaxId = valuenew;
            // byte[] encoded = System.Text.Encoding.UTF8.GetBytes(encodeMe);
            //taxlist.TaxId= Convert.ToInt32(encoded);
            //return View(taxlist);
            List<GetAllTaxTypesViewModel> getAllTaxTypesVmList = new List<GetAllTaxTypesViewModel>();
            for (int i = 0; i < taxList.Count; i++)
            {
                GetAllTaxTypesViewModel getTaxTypesVm = new GetAllTaxTypesViewModel()
                {
                    TaxId = HttpUtility.UrlEncode(EncryptionDecryption.EncryptString(Convert.ToString(taxList[i].TaxId))),
                    Name = taxList[i].Name
                };
                getAllTaxTypesVmList.Add(getTaxTypesVm);
            }
            return View(getAllTaxTypesVmList);
        }
        #endregion

        [HttpGet]
        public ActionResult UpdateTax(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"Tax/GetTaxById?id={_id}").Result;
            if (response.IsSuccessStatusCode)
            {
                dynamic responseData = response.Content.ReadAsStringAsync().Result;
                TaxUpdateModel taxData = JsonConvert.DeserializeObject<Response<TaxUpdateModel>>(responseData).Data;
                return View(taxData);
            }
            return RedirectToRoute(new { controller = "Home", action = "NotFoundPage" });
        }




        [HttpPost]
        public ActionResult UpdateTax(TaxUpdateModel tax)
        {
            if (ModelState.IsValid)
            {
                tax.LastModifiedBy = int.Parse(HttpContext.Session.GetString("UserId"));
                tax.TaxId = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(tax.Id)));
                string data = JsonConvert.SerializeObject(tax);
                StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "Tax/UpdateTax", content).Result;


                if (response.IsSuccessStatusCode)
                {
                    ViewBag.taxUpdateAlert = "<script type='text/javascript'>Swal.fire('Tax Update','Tax Type Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/Tax/GetAllTaxes');</script>";
                    return View();
                }
                else
                {
                    ViewBag.taxUpdateAlert = "<script type='text/javascript'>Swal.fire('Tax Update','Failed To Update Tax Type!','error');</script>";
                    return View();

                }

            }
            return View();
        }


        [HttpGet]
        public ActionResult UpdateTaxDetails(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"Tax/GetTaxDetailsById?id={_id}").Result;
            dynamic taxDetailsData = response.Content.ReadAsStringAsync().Result;
            TaxDetailsViewModel taxDetails = JsonConvert.DeserializeObject<Response<TaxDetailsViewModel>>(taxDetailsData).Data;

            HttpResponseMessage msg = _httpClient.GetAsync(_httpClient.BaseAddress + "Tax/GetAllTaxes").Result;
            if (msg.IsSuccessStatusCode)
            {
                var responseDataRead = msg.Content.ReadAsStringAsync().Result;

                dynamic TaxList = JsonConvert.DeserializeObject(responseDataRead);


                var TaxNamelist = new List<SelectListItem>();
                foreach (var item in TaxList)
                {
                    TaxNamelist.Add(new SelectListItem { Text = item.name.ToString(), Value = item.taxId.ToString() });
                    // TaxNamelist.Add(new SelectListItem { Text = item.TaxId, Value = item.Name.ToString() });

                }
                ViewBag.TaxNamelist = TaxNamelist;
                int[] MinTax = Enumerable.Range(0, 10).ToArray();
                var mintaxData = MinTax.Select((i) => new SelectListItem { Text = i.ToString(), Value = i.ToString() });
                ViewBag.MinTaxList = mintaxData;


                int[] MaxTax = Enumerable.Range(2, 10).ToArray();
                var maxtaxData = MaxTax.Select((i) => new SelectListItem { Text = i.ToString(), Value = i.ToString() });
                ViewBag.MaxTaxList = maxtaxData;
                return View(taxDetails);

            }


            return View(taxDetails);
        }


        [HttpPost]
        public ActionResult UpdateTaxDetails(TaxDetailsViewModel taxDetails)
        {
            taxDetails.LastModifiedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            taxDetails.TaxDetailsId = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(taxDetails.Id)));
            string data = JsonConvert.SerializeObject(taxDetails);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync(_httpClient.BaseAddress + "Tax/UpdateTaxDetail", content).Result;

            if (response.IsSuccessStatusCode)
            {
                ViewBag.taxDetailUpdateAlert = "<script type='text/javascript'>Swal.fire('Tax Details Update','Tax Details Updated Successfully!','success').then(()=>window.location.href='https://localhost:7221/Tax/GetAllTaxDetails');</script>";
                return View(taxDetails);
            }
            else
            {
                ViewBag.taxDetailUpdateAlert = "<script type='text/javascript'>Swal.fire('Tax Details Update','Failed To Update Tax Details!','error');</script>";
                return View(taxDetails);

            }

            return RedirectToAction("GetAllTaxDetails");
        }


        #region Delete TaxType
        public ActionResult DeleteTaxType(string id)
        {
            int deletedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            string delData = JsonConvert.SerializeObject(deletedBy);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            StringContent delContent = new StringContent(delData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + $"Tax/DeleteTaxType?id={_id}&deletedBy={deletedBy}").Result;
            return Json(true);
        }
        #endregion

        #region Delete TaxDetails
        public ActionResult DeleteTaxDetails(string id)
        {
            int deletedBy = int.Parse(HttpContext.Session.GetString("UserId"));
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            string delData = JsonConvert.SerializeObject(deletedBy);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            StringContent delContent = new StringContent(delData, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.DeleteAsync(_httpClient.BaseAddress + $"Tax/DeleteTaxDetails?id={_id}&deletedBy={deletedBy}").Result;
            return Json(true);
        }
        #endregion


        [HttpGet]
        public JsonResult IsTaxExist(string Name)
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"Tax/DoesTaxExists/{Name}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            bool taxExists = JsonConvert.DeserializeObject(data);
            if (taxExists == true)
            {
                return Json(false);
            }
            else
            {
                return Json(true);
            }
        }
        

        public ActionResult ToggleActiveStatus(string id)
        {
            int _id = Convert.ToInt32(EncryptionDecryption.DecryptString(HttpUtility.UrlDecode(id)));
            string data = JsonConvert.SerializeObject(_id);
            StringContent content = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"Tax/ToggleActiveStatus?id={_id}").Result;
            return NoContent();
        }




    }
}
