using Microsoft.AspNetCore.Mvc;
using StudentMVC.Models;
using StudentMVC.Services;
using System.Text.Json;

namespace StudentMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: /Student/Index
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View(new CreateStudentViewModel());
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateStudentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            HttpResponseMessage response = await _studentService.CreateStudentAsync(model);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Student created successfully!";
                return RedirectToAction(nameof(Index));
            }

            // Handle error
            string errorData = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                try
                {
                    var errorObject = JsonSerializer.Deserialize<JsonElement>(errorData);
                    if (errorObject.TryGetProperty("message", out var messageProperty))
                    {
                        ModelState.AddModelError("Email", messageProperty.GetString());
                        return View(model);
                    }
                }
                catch { }
            }

            ModelState.AddModelError("", "Error creating student");
            return View(model);
        }

        // GET: /Student/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                TempData["Error"] = "Student not found";
                return RedirectToAction(nameof(Index));
            }

            var model = new EditStudentViewModel
            {
                StudentId = student.StudentId,
                FullName = student.FullName,
                Email = student.Email,
                Phone = student.Phone,
                Status = student.Status,
                JoinDate = student.JoinDate
            };

            return View(model);
        }

        // POST: /Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditStudentViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            HttpResponseMessage response = await _studentService.UpdateStudentAsync(id, model);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Student updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            // Handle error
            string errorData = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                try
                {
                    var errorObject = JsonSerializer.Deserialize<JsonElement>(errorData);
                    if (errorObject.TryGetProperty("message", out var messageProperty))
                    {
                        ModelState.AddModelError("Email", messageProperty.GetString());
                        return View(model);
                    }
                }
                catch { }
            }

            ModelState.AddModelError("", "Error updating student");
            return View(model);
        }

        // GET: /Student/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                TempData["Error"] = "Student not found";
                return RedirectToAction(nameof(Index));
            }

            return View(student);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await _studentService.DeleteStudentAsync(id);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Student deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Error deleting student";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
