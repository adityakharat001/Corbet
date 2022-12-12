using Corbet.Domain.Entities;
using Corbet.Ui.Models;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

namespace Corbet.Ui.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;
        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient _httpClient;

        public InvoiceController(ILogger<InvoiceController> logger)
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
        public ActionResult GetAllInvoices()
        {
            string UserId = HttpContext.Session.GetString("UserId");
            int userid = Convert.ToInt32(UserId);

            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"Invoice/GetAllInvoices?UserId={userid}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var invoice = JsonConvert.DeserializeObject<List<InvoiceViewModel>>(data);
            return View(invoice);
        }

        [HttpGet]
        public ActionResult GetInvoiceDetails(int id)
        {
            HttpResponseMessage response = _httpClient.GetAsync(_httpClient.BaseAddress + $"Invoice/GetInvoiceById?id={id}").Result;
            dynamic data = response.Content.ReadAsStringAsync().Result;
            var invoice = JsonConvert.DeserializeObject<InvoiceViewModel>(data);
            return View(invoice);
        }
    }
}
