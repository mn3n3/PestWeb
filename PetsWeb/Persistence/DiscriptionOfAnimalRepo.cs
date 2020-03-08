using PetsWeb.Persistence;
using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Persistence
{
    public class DiscriptionOfAnimalRepo : IDiscriptionOfAnimalRepo
    {
        private readonly ApplicationDbContext _context;

        public DiscriptionOfAnimalRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(DiscriptionOfAnimal ObjSave)
        {
            _context.DiscriptionOfAnimals.Add(ObjSave);
        }

        public void Delete(DiscriptionOfAnimal ObjDelete)
        {
            var ObjToDelete = _context.DiscriptionOfAnimals.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.AnimalID == ObjDelete.AnimalID);
            if (ObjToDelete != null)
            {
                _context.DiscriptionOfAnimals.Remove(ObjToDelete);
            }
        }

        public IEnumerable<DiscriptionOfAnimal> GetAllDiscriptionOfAnimal(int CompanyID)
        {
            return _context.DiscriptionOfAnimals.Where(m => m.CompanyID == CompanyID).ToList();
        }

        public DiscriptionOfAnimal GetDiscriptionOfAnimalByID(int CompanyID, int AnimalID)
        {
            return _context.DiscriptionOfAnimals.FirstOrDefault(m => m.CompanyID == CompanyID && m.AnimalID == AnimalID);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.DiscriptionOfAnimals.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.DiscriptionOfAnimals.Where(m => m.CompanyID == CompanyID).Max(p => p.AnimalID) + 1;
            }
        }

        public void Update(DiscriptionOfAnimal ObjUpdate)
        {
            var ObjToUpdate = _context.DiscriptionOfAnimals.FirstOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.AnimalID == ObjUpdate.AnimalID);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.AnimalName = ObjUpdate.AnimalName;
                ObjToUpdate.OwnerID = ObjUpdate.OwnerID;
                ObjToUpdate.AnimalTypeID = ObjUpdate.AnimalTypeID;
                ObjToUpdate.BreedID = ObjUpdate.BreedID;
                ObjToUpdate.CoatColourID = ObjUpdate.CoatColourID;
                ObjToUpdate.DateOfBirth = ObjUpdate.DateOfBirth;
                ObjToUpdate.GenderID = ObjUpdate.GenderID;
            }
        }
    }
}