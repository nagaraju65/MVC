using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC_Demo_2.Models
{
    public class Company
    {
        [Key]
        public string SelectedDepartment { get; set; }
        public IEnumerable<Department> Departments
        {
            get
            {
                DBContext DB = new DBContext();
                return DB.Departments.ToList();
            }
        }
    }
}