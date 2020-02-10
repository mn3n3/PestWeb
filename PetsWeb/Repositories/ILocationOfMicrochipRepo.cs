using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Repositories
{
    public interface ILocationOfMicrochipRepo
    {
        IEnumerable<LocationOfMicrochip> GetAllCountry(int CompanyID);
        LocationOfMicrochip GetCountryByID(int CompanyID, int LocationOfMicrochipID);
        void Add(LocationOfMicrochip ObjSave);
        void Update(LocationOfMicrochip ObjUpdate);
        void Delete(LocationOfMicrochip ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}