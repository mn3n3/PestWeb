using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsWeb.ViewModels
{
    public class CountrySearchFilterVM
    {
        [Display(Name = "CounryName", ResourceType = typeof(Resources.Resource))]
        public string CounryName { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }
        public int CountryID { get; set; }
    }
}