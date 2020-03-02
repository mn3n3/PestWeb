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
    }
}