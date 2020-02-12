using PetsWeb.Persistence;
using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Persistence
{
    public class CountryRepo : ICountryRepo
    {
        private readonly ApplicationDbContext _context;

        public CountryRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Country ObjSave)
        {
            _context.Countries.Add(ObjSave);
        }

        public void Delete(Country ObjDelete)
        {
            var ObjToDelete = _context.Countries.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.CountryID == ObjDelete.CountryID);
            if (ObjToDelete != null)
            {
                _context.Countries.Remove(ObjToDelete);
            }
        }
        public Country GetCountryByID(int CompanyID, int CountryID)
        {
            return _context.Countries.FirstOrDefault(m => m.CompanyID == CompanyID && m.CountryID == CountryID);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.Countries.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.Countries.Where(m => m.CompanyID == CompanyID).Max(p => p.CountryID) + 1;
            }
        }

        public void Update(Country ObjUpdate)
        {
            var ObjToUpdate = _context.Countries.FirstOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.CountryID == ObjUpdate.CountryID);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.ArabicName = ObjUpdate.ArabicName;
                ObjToUpdate.EnglishName = ObjUpdate.EnglishName;
            }
        }
    }
}