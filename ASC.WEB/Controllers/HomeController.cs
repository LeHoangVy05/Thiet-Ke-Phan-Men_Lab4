using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

using ASC.WEB.Services;
using Microsoft.Identity.Client;
using ASC.Utilities;
using ASC.WEB.Configuration;
using ASC.WEB.Models;

namespace ASC.WEB.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private IOptions<ApplicationSettings> _settings;
        public HomeController(
            //ILogger<HomeController> logger, 
            IOptions<ApplicationSettings> settings)
        {
            //_logger = logger;
            _settings = settings;
        }

        //public HomeController(IOptions<ApplicationSettings> @object)
        //{
        //}

        //public IActionResult Index([FromServices] IEmailSender emailSender)
        //{
        //    var emailService = this.HttpContext.RequestServices.GetService(typeof(IEmailSender)) as IEmailSender;
        //    ViewBag.Title = _settings.Value.ApplicationTitle;
        //    return View();
        //}
        public IActionResult Index()
        {
            // Thiết lập Session
            HttpContext.Session.SetSession("Test", _settings.Value);

            // Lấy Session
            var settings = HttpContext.Session.GetSession<ApplicationSettings>("Test");

            // Sử dụng IOptions
            ViewBag.Title = settings.ApplicationTitle;

            // Trường hợp kiểm thử thất bại (đã comment)
            // ViewData.Model = "Test";
            // throw new Exception("Đăng nhập thất bại!!!");

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Dashboard()
        {
            return View();
        }


        //public IActionResult Index()
        //{
        //    //Test fail test case
        //    ViewData.Model = "Test";
        //    throw new Exception("Login Fail!!!");
        //    return View();
        //}
    }
}
