using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_Demo_2.Models
{
    public class CityViewModel
    {
        [Key]
        public int ID { get; set; }

        public List<SelectListItemModel> ListSelectListItem { get; set; }
        public List<string> SelectedCities { get; set; }
    }
}