using Microsoft.AspNetCore.Mvc;

namespace Corbet.Ui.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;


        Uri baseAddress = new Uri("https://localhost:5000/api/v3/");
        HttpClient client;
        public ProductController(ILogger<ProductController> logger)
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
            _logger = logger;

        }

        //[HttpGet]
        //public ActionResult AddProduct()
        //{
        //    HttpResponseMessage categories = client.GetAsync(client.BaseAddress + "ProductCategory/GetAllCategories").Result;
        //    if (categories.IsSuccessStatusCode)
        //    {
        //        var responseData = categories.Content.ReadAsStringAsync().Result;
        //        dynamic rolelList = JsonConvert.DeserializeObject(responseData);


        //        List<SelectListItem> UserRolelist = new List<SelectListItem>();
        //        foreach (var item in rolelList)
        //        {

        //            UserRolelist.Add(new SelectListItem { Text = item.roleName.ToString(), Value = item.roleId.ToString() });

        //        }
        //        ViewBag.UserRolelist = UserRolelist;

        //        return View();
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}


        public IActionResult Index()
        {
            return View();
        }
    }
}
