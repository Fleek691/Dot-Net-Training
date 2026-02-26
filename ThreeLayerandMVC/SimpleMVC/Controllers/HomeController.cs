using Microsoft.AspNetCore.Mvc;
using SimpleMVC.Models;
using System.Diagnostics;

namespace SimpleMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private static List<Employee> _employeeList = new List<Employee>();


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private List<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department { Id = 1, Name = "IT" },
                new Department { Id = 2, Name = "HR" },
                new Department { Id = 3, Name = "Finance" },
                new Department { Id = 4, Name = "Marketing" },
                new Department { Id = 5, Name = "Operations" }
            };
        }


        public IActionResult AddEmp()
        {
            _logger.LogInformation("AddEmp page accessed");
            ViewBag.Departments = GetDepartments();
            return View("../Employee/EmpView");
        }

        [HttpPost]
        public IActionResult AddEmp(Employee emp)
        {
            _logger.LogInformation("AddEmp POST called - Id: {Id}, Name: {Name}, DepartmentId: {DepartmentId}",
                emp.Id, emp.Name, emp.DepartmentId);

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("ModelState is invalid:");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    _logger.LogWarning("  - {ErrorMessage}", error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                _employeeList.Add(emp); // Save the data to our list
                _logger.LogInformation("Employee added successfully. Total employees: {Count}", _employeeList.Count);
                return RedirectToAction("Index"); // Send the user to the Table view
            }
            ViewBag.Departments = GetDepartments();
            return View("../Employee/EmpView", emp);
        }
        public IActionResult Index()//IActionResult means any return type among the 10 types is applicable , but here we are returning a view, so it is of type ViewResult
        {
            _logger.LogInformation("Index page accessed. Employee count: {Count}", _employeeList.Count);
            ViewBag.Countries = "India,Russia,France,Japan,USA";
            ViewBag.Fruits = new List<string> { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
            ViewData["Countries"] = "India,Russia,France,Japan,USA";

            ViewData["Fruits"] = new List<string> { "Apple", "Banana", "Cherry", "Date", "Elderberry" };
            ViewData["EmployeeList"] = _employeeList;
            return View("../Home/Index", _employeeList);




        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("Privacy page accessed");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View();
        }
    }
}
