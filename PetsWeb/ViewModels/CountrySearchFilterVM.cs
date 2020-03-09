using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsWeb.ViewModels
{
    public class CountrySearchFilterVM
    {
        [Display(Name = "CountryName", ResourceType = typeof(Resources.Resource))]
        public string CountryName { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }
        public int CountryID { get; set; }
        public IEnumerable<CountrySearchFilterVM> Country { get; set; }
        public int Used { get; set; }
    }
}