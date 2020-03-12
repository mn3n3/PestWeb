using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace PetsWeb.Models
{
    public class DiscriptionOfAnimal
    {
        [Key]
        [Column(Order = 1)]
        public int CompanyID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Display(Name = "Serial", ResourceType = typeof(Resources.Resource))]
        public int AnimalID { get; set; }
        [Required]
        [Display(Name = "AnimalName", ResourceType = typeof(Resources.Resource))]
        public string AnimalName { get; set; }
        [Required]
        [Display(Name = "OwnerName", ResourceType = typeof(Resources.Resource))]
        public int OwnerID { get; set; }
        [Display(Name = "Species", ResourceType = typeof(Resources.Resource))]
        public int AnimalTypeID { get; set; }
        [Display(Name = "Breed", ResourceType = typeof(Resources.Resource))]
        public int BreedID { get; set; }
        [Display(Name = "CoatColour", ResourceType = typeof(Resources.Resource))]
        public int CoatColourID { get; set; }
        [Display(Name = "Gender", ResourceType = typeof(Resources.Resource))]
        public int GenderID { get; set; }
        [Display(Name = "DateOfBirth", ResourceType = typeof(Resources.Resource))]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "MicrochipNumber", ResourceType = typeof(Resources.Resource))]
        public string MicrochipNumber { get; set; }
        [Display(Name = "DateOfMicrochipping", ResourceType = typeof(Resources.Resource))]
        public DateTime DateOfMicrochipping { get; set; }
        [Display(Name = "LocationOfMicrochip", ResourceType = typeof(Resources.Resource))]
        public int LocationOfMicrochipID { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string InsUserID { get; set; }
        [Display(Name = "InsDateTime", ResourceType = typeof(Resources.Resource))]
        public DateTime InsDateTime { get; set; }
    }
}