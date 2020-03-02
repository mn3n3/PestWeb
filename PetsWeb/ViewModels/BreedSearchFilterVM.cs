using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PetsWeb.ViewModels
{
    public class BreedSearchFilterVM
    {
        [Display(Name = "BreedName", ResourceType = typeof(Resources.Resource))]
        public string BreedName { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }
        public int BreedID { get; set; }
    }
}