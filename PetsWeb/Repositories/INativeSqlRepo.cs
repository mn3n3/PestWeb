using PetsWeb.Models;
using PetsWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Repositories
{
    public interface INativeSqlRepo
    {
        IEnumerable<CountrySearchFilterVM> GetAllCountryInfo(int CompanyID);
        IEnumerable<BreedSearchFilterVM> GetAllBreedInfo(int CompanyID);
        IEnumerable<CoatColourSearchFilterVM> GetAllCoatColourInfo(int CompanyID);
        IEnumerable<AnimalTypeSearchFilterVM> GetAllAnimalTypeInfo(int CompanyID);
        IEnumerable<LocationOfMicrochipSearchFilterVM> GetAllLocationOfMicrochipInfo(int CompanyID);
        IEnumerable<CitySearchFilterVM> GetAllCityInfo(int CompanyID);
        IEnumerable<DetailsOfOwnershipSearchFilterVM> GetAllDetailsOfOwnershipInfo(int CompanyID);
        IEnumerable<DiscriptionOfAnimalSearchFilterVM> GetAllDiscriptionOfAnimalInfo(int CompanyID);
        CitySearchFilterVM GetCountryName(int CompanyID, int CityID);
        CitySearchFilterVM GetCountryID(int CompanyID, int CityID);
        int GetFirstCityID(int CompanyID);
        DetailsOfOwnershipSearchFilterVM GetOwnerName(int CompanyID, int OwnerID);
    }
}