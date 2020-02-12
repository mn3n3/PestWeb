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
    }
}