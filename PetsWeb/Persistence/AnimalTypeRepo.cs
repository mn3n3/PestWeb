using Pets_Web.Persistence;
using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PetsWeb.Persistence
{
    public class AnimalTypeRepo : IAnimalTypeRepo
    {
        private readonly ApplicationDbContext _context;

        public AnimalTypeRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(AnimalType ObjSave)
        {
            _context.AnimalTypes.Add(ObjSave);
        }

        public void Delete(AnimalType ObjDelete)
        {
            var ObjToDelete = _context.AnimalTypes.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.AnimalTypeID == ObjDelete.AnimalTypeID);
            if (ObjToDelete != null)
            {
                _context.AnimalTypes.Remove(ObjToDelete);
            }
        }

        public IEnumerable<AnimalType> GetAllAnimalType(int CompanyID)
        {
            return _context.AnimalTypes.Where(m => m.CompanyID == CompanyID).ToList();
        }

        public AnimalType GetAnimalTypeByID(int CompanyID, int AnimalTypeID)
        {
            return _context.AnimalTypes.FirstOrDefault(m => m.CompanyID == CompanyID && m.AnimalTypeID == AnimalTypeID);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.AnimalTypes.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.AnimalTypes.Where(m => m.CompanyID == CompanyID).Max(p => p.AnimalTypeID) + 1;
            }
        }

        public void Update(AnimalType ObjUpdate)
        {
            var ObjToUpdate = _context.AnimalTypes.FirstOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.AnimalTypeID == ObjUpdate.AnimalTypeID);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.ArabicName = ObjUpdate.ArabicName;
                ObjToUpdate.EnglishName = ObjUpdate.EnglishName;
            }
        }
    }
}