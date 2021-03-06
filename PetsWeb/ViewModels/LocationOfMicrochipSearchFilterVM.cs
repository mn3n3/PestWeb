﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsWeb.ViewModels
{
    public class LocationOfMicrochipSearchFilterVM
    {
        [Display(Name = "LocationOfMicrochipName", ResourceType = typeof(Resources.Resource))]
        public string LocationOfMicrochipName { get; set; }
        [Display(Name = "InsUserName", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }
        public int LocationOfMicrochipID { get; set; }
        public IEnumerable<LocationOfMicrochipSearchFilterVM> LocationOfMicrochip { get; set; }
        public int Used { get; set; }
    }
}