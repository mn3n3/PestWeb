using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Repositories
{
    public interface ICountryRepo
    {
        IEnumerable<Country> GetAllCountry(int CompanyID);
        Country GetCountryByID(int CompanyID, int CountryID);
        void Add(Country ObjSave);
        void Update(Country ObjUpdate);
        void Delete(Country ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}