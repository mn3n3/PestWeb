﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetsWeb.Models
{
    public class AnimalType
    {
        [Column(Order = 1)]
        public int CompanyID { get; set; }
        [Key]
        [Column(Order = 2)]
        [Display(Name = "Serial", ResourceType = typeof(Resources.Resource))]
        public int AnimalTypeID { get; set; }
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