using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Demo_2.Models
{
    public class SelectListItemModel:SelectListItem
    {
        [Key]
        public int ID { get; set; }
    }
}