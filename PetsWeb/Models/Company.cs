using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetsWeb.Models
{
    public class Company
    {        
        public int Id { get; set; }
        [Display(Name = "ArabicName", ResourceType = typeof(Resources.Resource))]
        public string ArabicName { get; set; }
        [Display(Name = "EnglishName", ResourceType = typeof(Resources.Resource))]
        public string EnglishName { get; set; }
        [Display(Name = "Website", ResourceType = typeof(Resources.Resource))]
        public string Website { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }
        [Display(Name = "Telephone", ResourceType = typeof(Resources.Resource))]
        public string Telephone { get; set; }
        [Display(Name = "Mobile", ResourceType = typeof(Resources.Resource))]
        public string Mobile { get; set; }
        [Display(Name = "TeleFax", ResourceType = typeof(Resources.Resource))]
        public string TeleFax { get; set; }
        [Display(Name = "ArbAddress", ResourceType = typeof(Resources.Resource))]
        public string ArabicAddress { get; set; }
        [Display(Name = "EngAddress", ResourceType = typeof(Resources.Resource))]
        public string EnglishAddress { get; set; }
        [Display(Name = "LogoPath", ResourceType = typeof(Resources.Resource))]
        public string CompanyLogo { get; set; }
        public string UserId { get; set; }
        public string COREFID { get; set; }
        public int test { get; set; }
    }
}