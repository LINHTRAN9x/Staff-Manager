using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Staff_Management.Entities;
using System.Linq;

namespace Staff_Management.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        // Hiển thị form thêm mới nhân viên
        public IActionResult Create()
        {
            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // Xử lý thêm mới nhân viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction("Index", "Departments");
            }
            ViewBag.Departments = new SelectList(_context.Departments, "Id", "Name", employee.DepartmentId);
            return View(employee);
        }
    }
}
