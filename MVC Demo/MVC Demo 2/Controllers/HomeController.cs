using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Demo_2.Models;
using System.Text;

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

        [HttpGet]
        public ActionResult CheckBox()
        {
            DBContext db = new DBContext();
            return View(db.Cities);
        }

        [HttpPost]
        public string CheckBox(IEnumerable<City> Cities)
        {
            if (Cities.Count(c => c.isselected) == 0)
            {
                return "You have not selected any City";

            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("You have selected - ");
                foreach (var city in Cities.Where(c => c.isselected))
                {
                    sb.Append(city.name + ",");
                }
                sb.Remove(sb.ToString().LastIndexOf(","), 1);

                return sb.ToString();
            }

        }

        [HttpGet]
        public ActionResult ListBox()
        {
            DBContext db = new DBContext();
            CityViewModel CVM = new CityViewModel();
            List<SelectListItemModel> ListSelectListItem = new List<SelectListItemModel>();

            foreach (var City in db.Cities)
            {
                SelectListItemModel selectListItem = new SelectListItemModel()
                {
                    Text = City.name,
                    Value = City.id.ToString(),
                    Selected = City.isselected
                };
                ListSelectListItem.Add(selectListItem);
            }

            CVM.ListSelectListItem = ListSelectListItem;

            return View(CVM);
        }

        [HttpPost]
        public string ListBox(CityViewModel CVM)
        {
            if (CVM.SelectedCities == null)
            {
                return "You have not selected any City";
            }
            else
            {
                return "You have selected - " + string.Join(",", CVM.SelectedCities);
            }
            
        }
    }
}