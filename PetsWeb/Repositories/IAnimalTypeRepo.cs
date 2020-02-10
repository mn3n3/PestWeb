using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PetsWeb.Repositories
{
    public interface IAnimalTypeRepo
    {
        IEnumerable<AnimalType> GetAllAnimalType(int CompanyID);
        AnimalType GetAnimalTypeByID(int CompanyID, int AnimalTypeID);
        void Add(AnimalType ObjSave);
        void Update(AnimalType ObjUpdate);
        void Delete(AnimalType ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}