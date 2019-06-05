using MVC_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Demo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Details()
        {
            //Using employee object hard coding
            //Employee employee = new Employee() { Name = "Nagaraju", Age = 28, Gender = "Male" };

            //using Entity Framework connecting to Database
            EmployeeContext employeeContext = new EmployeeContext();
            Employee employees = employeeContext.Employees.Single(emp => emp.Id == 1);

            return View(employees);
        }
    }
}