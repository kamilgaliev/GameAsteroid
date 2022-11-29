using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebStoreDuble.Data;
using WebStoreDuble.Models;

namespace WebStoreDuble.Controllers
{
    public class EmployeesController : Controller
    {
        private List<Employee> _Employees;

        public EmployeesController()
        {
            _Employees = TestData.Employees;
        }
        public IActionResult Index() => View(_Employees);

        public IActionResult Details(int id)
        {
            var employee = _Employees.FirstOrDefault(empl => empl.Id==id);

            if (employee is not null)
                return View(employee);

            return NotFound();
        }
    }
}
