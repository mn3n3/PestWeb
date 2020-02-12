using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetsWeb.Models
{
    public class DetailsOfOwnership
    {
        public Company Company { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CompanyID { get; set; }
        [Key]
        [Column(Order = 2)]
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
        [Display(Name = "PosCode", ResourceType = typeof(Resources.Resource))]
        public string PosCode { get; set; }
        [Display(Name = "Telephone", ResourceType = typeof(Resources.Resource))]
        public string Telephone { get; set; }
        [Display(Name = "CountyName", ResourceType = typeof(Resources.Resource))]
        public int CountryID { get; set; }
        public City City { get; set; }
        [Display(Name = "CityName", ResourceType = typeof(Resources.Resource))]
        public int CityID { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string InsUserID { get; set; }
        [Display(Name = "InsDateTime", ResourceType = typeof(Resources.Resource))]
        public DateTime InsDateTime { get; set; }
    }
}