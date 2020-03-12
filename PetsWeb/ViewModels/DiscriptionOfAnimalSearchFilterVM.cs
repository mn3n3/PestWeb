using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsWeb.ViewModels
{
    public class DiscriptionOfAnimalSearchFilterVM
    {
        public int CompanyID { get; set; }
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
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string InsUserID { get; set; }
        [Display(Name = "InsDateTime", ResourceType = typeof(Resources.Resource))]
        public DateTime InsDateTime { get; set; }
        [Display(Name = "OwnerName", ResourceType = typeof(Resources.Resource))]
        public string OwnerName { get; set; }

        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }
        
        [Display(Name = "Species", ResourceType = typeof(Resources.Resource))]
        public string AnimalTypeName { get; set; }
        [Display(Name = "BreedName", ResourceType = typeof(Resources.Resource))]
        public string BreedName { get; set; }
        [Display(Name = "CoatColourName", ResourceType = typeof(Resources.Resource))]
        public string CoatColourName { get; set; }
        [Display(Name = "LocationOfMicrochip", ResourceType = typeof(Resources.Resource))]
        public string LocationOfMicrochipName { get; set; }
        [Display(Name = "Telephone", ResourceType = typeof(Resources.Resource))]
        public string Telephone { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(Resources.Resource))]
        public string GenderName { get; set; }

        [Display(Name = "MicrochipNumber", ResourceType = typeof(Resources.Resource))]
        public string MicrochipNumber { get; set; }
        [Display(Name = "DateOfMicrochipping", ResourceType = typeof(Resources.Resource))]
        public DateTime DateOfMicrochipping { get; set; }
        [Display(Name = "LocationOfMicrochip", ResourceType = typeof(Resources.Resource))]
        public int LocationOfMicrochipID { get; set; }
        public IEnumerable<BreedSearchFilterVM> Breed { get; set; }
        public IEnumerable<AnimalTypeSearchFilterVM> AnimalType { get; set; }
        public IEnumerable<CoatColourSearchFilterVM> CoatColour { get; set; }
        public IEnumerable<LocationOfMicrochipSearchFilterVM> LocationOfMicrochip { get; set; }
        public int Used { get; set; }
    }
}