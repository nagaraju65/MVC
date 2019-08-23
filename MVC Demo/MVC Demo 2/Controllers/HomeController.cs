using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Demo_2.Models;

namespace MVC_Demo_2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Company company = new Company();
            ViewBag.Departments = new SelectList(company.Departments, "DepartmentId", "DepartmentName");
            return View(company);
        }

        [HttpPost]
        [ActionName("Index")]
        public string Index_post(Company company)
        {
            if (string.IsNullOrEmpty(company.SelectedDepartment))
            {
                return "you have not selected any department";
            }
            else
            {
                return "You have selected the department :" + company.SelectedDepartment;
            }
        }
    }
}