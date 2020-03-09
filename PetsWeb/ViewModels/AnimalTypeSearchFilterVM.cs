using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace PetsWeb.ViewModels
{
    public class AnimalTypeSearchFilterVM
    {
        [Display(Name = "AnimalTypeName", ResourceType = typeof(Resources.Resource))]
        public string AnimalTypeName { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }
        public int AnimalTypeID { get; set; }
        public IEnumerable<AnimalTypeSearchFilterVM> AnimalType { get; set; }
    }
}
