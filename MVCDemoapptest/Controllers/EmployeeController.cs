using Microsoft.AspNetCore.Mvc;
using MVCDemoapptest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDemoapptest.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAcessLayer employeeDataAccess = new EmployeeDataAcessLayer();
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeDataAccess.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = employeeDataAccess.GetAllEmployee().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeDataAccess.GerEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                employeeDataAccess.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeDataAccess.GerEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = employeeDataAccess.GerEmployeeById(id);

            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            employeeDataAccess.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
