using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Repositories
{
    public interface IDiscriptionOfAnimalRepo
    {
        IEnumerable<DiscriptionOfAnimal> GetAllDiscriptionOfAnimal(int CompanyID);
        DiscriptionOfAnimal GetDiscriptionOfAnimalByID(int CompanyID, int AnimalID);
        void Add(DiscriptionOfAnimal ObjSave);
        void Update(DiscriptionOfAnimal ObjUpdate);
        void Delete(DiscriptionOfAnimal ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}