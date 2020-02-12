using PetsWeb.Persistence;
using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Persistence
{
    public class CityRepo : ICityRepo
    {
        private readonly ApplicationDbContext _context;

        public CityRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(City ObjSave)
        {
            _context.Cities.Add(ObjSave);
        }

        public void Delete(City ObjDelete)
        {
            var ObjToDelete = _context.Cities.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.CityID == ObjDelete.CityID);
            if (ObjToDelete != null)
            {
                _context.Cities.Remove(ObjToDelete);
            }
        }

        public IEnumerable<City> GetAllCity(int CompanyID)
        {
            return _context.Cities.Where(m => m.CompanyID == CompanyID).ToList();
        }

        public City GetCityByID(int CompanyID, int CityID)
        {
            return _context.Cities.FirstOrDefault(m => m.CompanyID == CompanyID && m.CityID == CityID);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.Cities.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Cities.Where(m => m.CompanyID == CompanyID).Max(p => p.CityID) + 1;
            }
        }

        public void Update(City ObjUpdate)
        {
            var ObjToUpdate = _context.Cities.FirstOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.CityID == ObjUpdate.CityID);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.ArabicName = ObjUpdate.ArabicName;
                ObjToUpdate.EnglishName = ObjUpdate.EnglishName;
                ObjToUpdate.CountryID = ObjUpdate.CountryID;
            }
        }
    }
}