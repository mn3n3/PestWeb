using PetsWeb.Persistence;
using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PetsWeb.Persistence
{
    public class BreedRepo : IBreedRepo
    {
        private readonly ApplicationDbContext _context;

        public BreedRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Breed ObjSave)
        {
            _context.Breeds.Add(ObjSave);
        }

        public void Delete(Breed ObjDelete)
        {
            var ObjToDelete = _context.Breeds.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.BreedID == ObjDelete.BreedID);
            if (ObjToDelete != null)
            {
                _context.Breeds.Remove(ObjToDelete);
            }
        }

        public IEnumerable<Breed> GetAllBreed(int CompanyID)
        {
            return _context.Breeds.Where(m => m.CompanyID == CompanyID).ToList();
        }

        public Breed GetBreedByID(int CompanyID, int BreedID)
        {
            return _context.Breeds.FirstOrDefault(m => m.CompanyID == CompanyID && m.BreedID == BreedID);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.Breeds.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Breeds.Where(m => m.CompanyID == CompanyID).Max(p => p.BreedID) + 1;
            }
        }

        public void Update(Breed ObjUpdate)
        {
            var ObjToUpdate = _context.Breeds.FirstOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.BreedID == ObjUpdate.BreedID);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.ArabicName = ObjUpdate.ArabicName;
                ObjToUpdate.EnglishName = ObjUpdate.EnglishName;
            }
        }
    }
}