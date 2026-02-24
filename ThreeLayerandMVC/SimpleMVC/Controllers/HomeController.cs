using Microsoft.AspNetCore.Mvc;
using SimpleMVC.Models;
using System.Diagnostics;

namespace SimpleMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()//IActionResult means any return type among the 10 types is applicable , but here we are returning a view, so it is of type ViewResult
        {
            return View("../Employee/EmpView");
        }
        public IActionResult AddEmp()
        {
            return View("../Employee/EmpView");
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
    }
}
