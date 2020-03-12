using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.ViewModels
{
    public class SearchUnitVM
    {
        public string OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string Telephone { get; set; }
        public string AnimalID { get; set; }
        public string AnimalName { get; set; }
    }
}