using PetsWeb.Persistence;
using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Persistence
{
    public class CoatColourRepo : ICoatColourRepo
    {
        private readonly ApplicationDbContext _context;

        public CoatColourRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(CoatColour ObjSave)
        {
            _context.CoatColours.Add(ObjSave);
        }

        public void Delete(CoatColour ObjDelete)
        {
            var ObjToDelete = _context.CoatColours.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.CoatColourID == ObjDelete.CoatColourID);
            if (ObjToDelete != null)
            {
                _context.CoatColours.Remove(ObjToDelete);
            }
        }

        public IEnumerable<CoatColour> GetAllCoatColour(int CompanyID)
        {
            return _context.CoatColours.Where(m => m.CompanyID == CompanyID).ToList();
        }

        public CoatColour GetCoatColourByID(int CompanyID, int CoatColourID)
        {
            return _context.CoatColours.FirstOrDefault(m => m.CompanyID == CompanyID && m.CoatColourID == CoatColourID);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.CoatColours.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.CoatColours.Where(m => m.CompanyID == CompanyID).Max(p => p.CoatColourID) + 1;
            }
        }

        public void Update(CoatColour ObjUpdate)
        {
            var ObjToUpdate = _context.CoatColours.FirstOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.CoatColourID == ObjUpdate.CoatColourID);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.ArabicName = ObjUpdate.ArabicName;
                ObjToUpdate.EnglishName = ObjUpdate.EnglishName;
            }
        }
    }
}