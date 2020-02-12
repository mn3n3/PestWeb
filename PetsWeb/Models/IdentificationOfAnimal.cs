using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace PetsWeb.Models
{
    public class IdentificationOfAnimal
    {
    
        [Key]
        [Column(Order = 1)]
        public int CompanyID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Display(Name = "Serial", ResourceType = typeof(Resources.Resource))]
        public int SerialID { get; set; }
        public DiscriptionOfAnimal DiscriptionOfAnimal { get; set; }
        [Display(Name = "AnimalName", ResourceType = typeof(Resources.Resource))]
        public int AnimalID { get; set; }
        [Required]
        [Display(Name = "MicrochipNumber", ResourceType = typeof(Resources.Resource))]
        public string MicrochipNumber { get; set; }
        [Display(Name = "DateOfMicrochipping", ResourceType = typeof(Resources.Resource))]
        public DateTime DateOfMicrochipping { get; set; }
        public LocationOfMicrochip LocationOfMicrochip { get; set; }
        [Display(Name = "LocationOfMicrochip", ResourceType = typeof(Resources.Resource))]
        public int LocationOfMicrochipID { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string InsUserID { get; set; }
        [Display(Name = "InsDateTime", ResourceType = typeof(Resources.Resource))]
        public DateTime InsDateTime { get; set; }
    }
}