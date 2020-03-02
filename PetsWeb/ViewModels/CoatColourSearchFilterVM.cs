using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsWeb.ViewModels
{
    public class CoatColourSearchFilterVM
    {
        [Display(Name = "CoatColourName", ResourceType = typeof(Resources.Resource))]
        public string CoatColourName { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }
        public int CoatColourID { get; set; }
    }
}