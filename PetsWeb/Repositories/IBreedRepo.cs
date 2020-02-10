using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Repositories
{
    public interface IBreedRepo
    {
        IEnumerable<Breed> GetAllBreed(int CompanyID);
        Breed GetBreedByID(int CompanyID, int BreedID);
        void Add(Breed ObjSave);
        void Update(Breed ObjUpdate);
        void Delete(Breed ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}