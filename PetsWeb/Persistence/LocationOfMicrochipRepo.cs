using Pets_Web.Persistence;
using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace PetsWeb.Persistence
{
    public class LocationOfMicrochipRepo : ILocationOfMicrochipRepo
    {
        private readonly ApplicationDbContext _context;

        public LocationOfMicrochipRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(LocationOfMicrochip ObjSave)
        {
            _context.LocationOfMicrochips.Add(ObjSave);
        }

        public void Delete(LocationOfMicrochip ObjDelete)
        {
            var ObjToDelete = _context.LocationOfMicrochips.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.LocationOfMicrochipID == ObjDelete.LocationOfMicrochipID);
            if (ObjToDelete != null)
            {
                _context.LocationOfMicrochips.Remove(ObjToDelete);
            }
        }

        public IEnumerable<LocationOfMicrochip> GetAllCountry(int CompanyID)
        {
            return _context.LocationOfMicrochips.Where(m => m.CompanyID == CompanyID).ToList();
        }

        public LocationOfMicrochip GetCountryByID(int CompanyID, int LocationOfMicrochipID)
        {
            return _context.LocationOfMicrochips.FirstOrDefault(m => m.CompanyID == CompanyID && m.LocationOfMicrochipID == LocationOfMicrochipID);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.LocationOfMicrochips.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.LocationOfMicrochips.Where(m => m.CompanyID == CompanyID).Max(p => p.LocationOfMicrochipID) + 1;
            }
        }

        public void Update(LocationOfMicrochip ObjUpdate)
        {
            var ObjToUpdate = _context.LocationOfMicrochips.FirstOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.LocationOfMicrochipID == ObjUpdate.LocationOfMicrochipID);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.ArabicName = ObjUpdate.ArabicName;
                ObjToUpdate.EnglishName = ObjUpdate.EnglishName;
            }
        }
    }
}