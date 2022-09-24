using ContactsMVC6.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactsMVC6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code)
        {
            var customError = new CustomError();

            customError.code = code;

            if (code == 404)
            {
                customError.message = "404 - page not found!";
            }
            else 
            {
                customError.message = "something went wrong, but is wasn't 404!";
            }  
             
            return View("~/Views/Shared/CustomError.cshtml", customError);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}