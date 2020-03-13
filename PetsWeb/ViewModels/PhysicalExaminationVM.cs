using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetsWeb.ViewModels
{
    public class PhysicalExaminationVM
    {

        public int Id { get; set; }

        public int CompanyID { get; set; }
        public int AnimalID { get; set; }
        [Display(Name = "AnimalName", ResourceType = typeof(Resources.Resource))]
        public string AnimalName { get; set; }

        [Display(Name = "Breed", ResourceType = typeof(Resources.Resource))]
        public string BreedName { get; set; }
        [Display(Name = "OwnerName", ResourceType = typeof(Resources.Resource))]
        public string OwnerName { get; set; }

        public string OwnerID { get; set; }

        [Display(Name = "Species", ResourceType = typeof(Resources.Resource))]
        public string AnimalTypeName { get; set; }
        [Display(Name = "Gender", ResourceType = typeof(Resources.Resource))]
        public string GenderName { get; set; }

        [Display(Name = "CoatColourName", ResourceType = typeof(Resources.Resource))]
        public string CoatColourName { get; set; }

        [Display(Name = "DateOfBirth", ResourceType = typeof(Resources.Resource))]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "MicrochipNumber", ResourceType = typeof(Resources.Resource))]
        public string MicrochipNumber { get; set; }
        [Display(Name = "DateOfMicrochipping", ResourceType = typeof(Resources.Resource))]
        public DateTime DateOfMicrochipping { get; set; }
        [Display(Name = "LocationOfMicrochip", ResourceType = typeof(Resources.Resource))]
        public string LocationOfMicrochipName { get; set; }
        [Display(Name = "Telephone", ResourceType = typeof(Resources.Resource))]
        public string Telephone { get; set; }

        public bool Ch1 { get; set; }
        public string Tx1 { get; set; }



        public bool Ch2 { get; set; }
        public string Tx2 { get; set; }


        public bool Ch3 { get; set; }
        public string Tx3 { get; set; }

        public bool Ch4 { get; set; }
        public string Tx4 { get; set; }

        public bool Ch5 { get; set; }
        public string Tx5 { get; set; }

        public bool Ch6 { get; set; }
        public string Tx6 { get; set; }

        public bool Ch7 { get; set; }
        public string Tx7 { get; set; }

        public bool Ch8 { get; set; }
        public string Tx8 { get; set; }

        public bool Ch9 { get; set; }
        public string Tx9 { get; set; }

        public bool Ch10 { get; set; }
        public string Tx10 { get; set; }

        public bool Ch11 { get; set; }
        public string Tx11 { get; set; }

        public bool Ch12 { get; set; }
        public string Tx12 { get; set; }

        public bool Ch13 { get; set; }
        public string Tx13 { get; set; }

        public bool Ch14 { get; set; }
        public string Tx14 { get; set; }

        public bool Ch15 { get; set; }
        public string Tx15 { get; set; }

        public bool Ch16 { get; set; }
        public string Tx16 { get; set; }

        public bool Ch17 { get; set; }
        public string Tx17 { get; set; }

        public bool Ch18 { get; set; }
        public string Tx18 { get; set; }

        public bool Ch19 { get; set; }
        public string Tx19 { get; set; }

        public bool Ch20 { get; set; }
        public string Tx20 { get; set; }

        public bool Ch21 { get; set; }
        public string Tx21 { get; set; }

        public bool Ch22 { get; set; }
        public string Tx22 { get; set; }


        public bool Ch23 { get; set; }
        public string Tx23 { get; set; }




        public bool Ch24 { get; set; }
        public string Tx24 { get; set; }

        public bool Ch25 { get; set; }
        public string Tx25 { get; set; }

        public bool Ch26 { get; set; }
        public string Tx26 { get; set; }

        public bool Ch27 { get; set; }
        public string Tx27 { get; set; }

        public bool Ch28 { get; set; }
        public string Tx28 { get; set; }

        public bool Ch29 { get; set; }
        public string Tx29 { get; set; }

        public bool Ch30 { get; set; }
        public string Tx30 { get; set; }




        public bool Ch31 { get; set; }
        public string Tx31 { get; set; }

        public bool Ch32 { get; set; }
        public string Tx32 { get; set; }

        public bool Ch33 { get; set; }
        public string Tx33 { get; set; }



        public bool Ch34 { get; set; }
        public string Tx34 { get; set; }

        public bool Ch35 { get; set; }
        public string Tx35 { get; set; }

        public bool Ch36 { get; set; }
        public string Tx36 { get; set; }

        public bool Ch37 { get; set; }
        public string Tx37 { get; set; }

        public bool Ch38 { get; set; }
        public string Tx38 { get; set; }

        public bool Ch39 { get; set; }
        public string Tx39 { get; set; }


        public bool Ch40 { get; set; }
        public string Tx40 { get; set; }


        public bool Ch41 { get; set; }
        public string Tx41 { get; set; }


        public bool Ch42 { get; set; }
        public string Tx42 { get; set; }



        public bool Ch43 { get; set; }
        public string Tx43 { get; set; }



        public bool Ch44 { get; set; }
        public string Tx44 { get; set; }



        public bool Ch45 { get; set; }
        public string Tx45 { get; set; }


        public bool Ch46 { get; set; }
        public string Tx46 { get; set; }


        public bool Ch47 { get; set; }
        public string Tx47 { get; set; }


        public bool Ch48 { get; set; }
        public string Tx48 { get; set; }


        public bool Ch49 { get; set; }
        public string Tx49 { get; set; }


        public bool Ch50 { get; set; }
        public string Tx50 { get; set; }


        public bool Ch51 { get; set; }
        public string Tx51 { get; set; }

        public bool Ch52 { get; set; }
        public string Tx52 { get; set; }


        public bool Ch53 { get; set; }
        public string Tx53 { get; set; }


        public bool Ch54 { get; set; }
        public string Tx54 { get; set; }


        public bool Ch55 { get; set; }
        public string Tx55 { get; set; }


        public bool Ch56 { get; set; }
        public string Tx56 { get; set; }


        public bool Ch57 { get; set; }
        public string Tx57 { get; set; }


        public bool Ch58 { get; set; }
        public string Tx58 { get; set; }


        public bool Ch59 { get; set; }
        public string Tx59 { get; set; }


        public bool Ch60 { get; set; }
        public string Tx60 { get; set; }


        public bool Ch61 { get; set; }
        public string Tx61 { get; set; }

        public bool Ch62 { get; set; }
        public string Tx62 { get; set; }

        public bool Ch63 { get; set; }
        public string Tx63 { get; set; }

        public bool Ch64 { get; set; }
        public string Tx64 { get; set; }

        public bool Ch65 { get; set; }
        public string Tx65 { get; set; }

        public bool Ch66 { get; set; }
        public string Tx66 { get; set; }

        public bool Ch67 { get; set; }
        public string Tx67 { get; set; }

        public bool Ch68 { get; set; }
        public string Tx68 { get; set; }

        public bool Ch69 { get; set; }
        public string Tx69 { get; set; }

        public bool Ch70 { get; set; }
        public string Tx70 { get; set; }


        public bool Ch71 { get; set; }
        public string Tx71 { get; set; }

        public bool Ch72 { get; set; }
        public string Tx72 { get; set; }
        public bool Ch73 { get; set; }
        public string Tx73 { get; set; }
        public bool Ch74 { get; set; }
        public string Tx74 { get; set; }
        public bool Ch75 { get; set; }
        public string Tx75 { get; set; }
        public bool Ch76 { get; set; }
        public string Tx76 { get; set; }
        public bool Ch77 { get; set; }
        public string Tx77 { get; set; }
        public bool Ch78 { get; set; }
        public string Tx78 { get; set; }
        public bool Ch79 { get; set; }
        public string Tx79 { get; set; }

        public bool Ch80 { get; set; }
        public string Tx80 { get; set; }

        public bool Ch81 { get; set; }
        public string Tx81 { get; set; }


        public bool Ch82 { get; set; }
        public string Tx82 { get; set; }


        public bool Ch83 { get; set; }
        public string Tx83 { get; set; }


        public bool Ch84 { get; set; }
        public string Tx84 { get; set; }


        public bool Ch85 { get; set; }
        public string Tx85 { get; set; }


        public bool Ch86 { get; set; }
        public string Tx86 { get; set; }


        public bool Ch87 { get; set; }
        public string Tx87 { get; set; }


        public bool Ch88 { get; set; }
        public string Tx88 { get; set; }


        public bool Ch89 { get; set; }
        public string Tx89 { get; set; }


        public bool Ch90 { get; set; }
        public string Tx90 { get; set; }


        public bool Ch91 { get; set; }
        public string Tx91 { get; set; }


        public bool Ch92 { get; set; }
        public string Tx92 { get; set; }


        public bool Ch93 { get; set; }
        public string Tx93 { get; set; }


        public bool Ch94 { get; set; }
        public string Tx94 { get; set; }


        public bool Ch95 { get; set; }
        public string Tx95 { get; set; }


        public bool Ch96 { get; set; }
        public string Tx96 { get; set; }


        public bool Ch97 { get; set; }
        public string Tx97 { get; set; }


        public bool Ch98 { get; set; }
        public string Tx98 { get; set; }



    }
}