using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsWeb.ViewModels
{
    public class CitySearchFilterVM
    {
        public int CompanyID { get; set; }
        [Display(Name = "CityName", ResourceType = typeof(Resources.Resource))]
        public string CityName { get; set; }
        [Display(Name = "CountryName", ResourceType = typeof(Resources.Resource))]
        public string CountryName { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }
        [Display(Name = "Serial", ResourceType = typeof(Resources.Resource))]
        public int CityID { get; set; }
        public int CountryID{ get; set; }
        public IEnumerable<CountrySearchFilterVM> Country { get; set; }
        [Required]
        [Display(Name = "ArabicName", ResourceType = typeof(Resources.Resource))]
        public string ArabicName { get; set; }
        [Display(Name = "EnglishName", ResourceType = typeof(Resources.Resource))]
        public string EnglishName { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string InsUserID { get; set; }
        [Display(Name = "InsDateTime", ResourceType = typeof(Resources.Resource))]
        public DateTime InsDateTime { get; set; }
    }
}