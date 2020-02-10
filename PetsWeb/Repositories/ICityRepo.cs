using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Repositories
{
    public interface ICityRepo
    {
        IEnumerable<City> GetAllCity(int CompanyID);
        City GetCityByID(int CompanyID, int CityID);
        void Add(City ObjSave);
        void Update(City ObjUpdate);
        void Delete(City ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}