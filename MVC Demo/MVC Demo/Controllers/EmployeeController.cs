using MVC_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace MVC_Demo.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Details(int id)
        {
            //Using employee object hard coding
            //Employee employee = new Employee() { Name = "Nagaraju", Age = 28, Gender = "Male" };

            //using Entity Framework connecting to Database
            EmployeeContext employeeContext = new EmployeeContext();
            List<MVC_Demo.Models.Employee> employees = employeeContext.Employees.Where(emp => emp.DepartmentID== id).ToList();

            return View(employees);
        }

        public ActionResult EmployeeDetails(int id)
        {
            //Using employee object hard coding
            //Employee employee = new Employee() { Name = "Nagaraju", Age = 28, Gender = "Male" };

            //using Entity Framework connecting to Database
            EmployeeContext employeeContext = new EmployeeContext();
            MVC_Demo.Models.Employee employee = employeeContext.Employees.Single(emp => emp.Id == id);

            return View(employee);
        }

        public ActionResult Index()
        {
            
            EmployeeContext employeeContext = new EmployeeContext();
            List<MVC_Demo.Models.Department> Departments = employeeContext.Departments.ToList();

            return View(Departments);

            
        }

        public ActionResult BO_Index()
        {

            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();

            List<BusinessLayer.BO_Employee> emps = employeeBusinessLayer.Employees.ToList();

            return View(emps);


        }

        [HttpGet]
        public ActionResult Create()
        {
           return View();
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    foreach (var key in formCollection.AllKeys)
        //    {
        //        Response.Write("Key = " + key + " ; Value = " + formCollection[key]);
        //        Response.Write("<br/>");
        //    }
        //    return View();
        //    //return RedirectToAction("BO_Index");
        //}

        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post(Models.Employee employee)
        //{
           
        //    Response.Write("Name : " + employee.Name + "<br/> Age : " + employee.Age.ToString() + "<br/> Gender : " + employee.Gender);
        //    return View();
        //    //return RedirectToAction("BO_Index");
        //}

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            Models.Employee employee = new Models.Employee();
            bool result = TryUpdateModel<Models.Employee>(employee);

            Response.Write(result.ToString() + "<br/> Name : " + employee.Name + "<br/> Age : " + employee.Age.ToString() + "<br/> Gender : " + employee.Gender);
            return View();
            //return RedirectToAction("BO_Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            BusinessLayer.BO_Employee employee = employeeBusinessLayer.Employees.Single(emp => emp.Id == id);
            return View(employee);
        }
    }
}