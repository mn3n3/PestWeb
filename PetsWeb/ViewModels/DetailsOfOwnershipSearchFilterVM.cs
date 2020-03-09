using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsWeb.ViewModels
{
    public class DetailsOfOwnershipSearchFilterVM
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
        public int CountryID { get; set; }
        public IEnumerable<CitySearchFilterVM> City { get; set; }
        public IEnumerable<CountrySearchFilterVM> Country { get; set; }
        [Display(Name = "Serial", ResourceType = typeof(Resources.Resource))]
        public int OwnerID { get; set; }
        [Required]
        [Display(Name = "Surname", ResourceType = typeof(Resources.Resource))]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resource))]
        public string FirstName { get; set; }
        [Display(Name = "Address", ResourceType = typeof(Resources.Resource))]
        public string Address { get; set; }
        [Display(Name = "PostCode", ResourceType = typeof(Resources.Resource))]
        public string PosCode { get; set; }
        [Display(Name = "Telephone", ResourceType = typeof(Resources.Resource))]
        public string Telephone { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string InsUserID { get; set; }
        [Display(Name = "InsDateTime", ResourceType = typeof(Resources.Resource))]
        public DateTime InsDateTime { get; set; }
        [Display(Name = "OwnerName", ResourceType = typeof(Resources.Resource))]
        public string OwnerName { get; set; }
    }
}