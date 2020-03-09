using PetsWeb.Persistence;
using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Persistence
{
    public class DetailsOfOwnershipRepo : IDetailsOfOwnershipRepo
    {
        private readonly ApplicationDbContext _context;

        public DetailsOfOwnershipRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(DetailsOfOwnership ObjSave)
        {
            _context.DetailsOfOwnerships.Add(ObjSave);
        }

        public void Delete(DetailsOfOwnership ObjDelete)
        {
            var ObjToDelete = _context.DetailsOfOwnerships.SingleOrDefault(m => m.CompanyID == ObjDelete.CompanyID && m.OwnerID == ObjDelete.OwnerID);
            if (ObjToDelete != null)
            {
                _context.DetailsOfOwnerships.Remove(ObjToDelete);
            }
        }

        public IEnumerable<DetailsOfOwnership> GetAllDetailsOfOwnership(int CompanyID)
        {
            return _context.DetailsOfOwnerships.Where(m => m.CompanyID == CompanyID).ToList();
        }

        public DetailsOfOwnership GetDetailsOfOwnershipByID(int CompanyID, int OwnerID)
        {
            return _context.DetailsOfOwnerships.FirstOrDefault(m => m.CompanyID == CompanyID && m.OwnerID == OwnerID);
        }

        public int GetMaxSerial(int CompanyID)
        {
            var Obj = _context.DetailsOfOwnerships.FirstOrDefault(m => m.CompanyID == CompanyID);
            if (Obj == null)
            {
                return 1;
            }
            else
            {
                return _context.DetailsOfOwnerships.Where(m => m.CompanyID == CompanyID).Max(p => p.OwnerID) + 1;
            }
        }

        public void Update(DetailsOfOwnership ObjUpdate)
        {
            var ObjToUpdate = _context.DetailsOfOwnerships.FirstOrDefault(m => m.CompanyID == ObjUpdate.CompanyID && m.OwnerID == ObjUpdate.OwnerID);
            if (ObjToUpdate != null)
            {
                ObjToUpdate.Surname = ObjUpdate.Surname;
                ObjToUpdate.FirstName = ObjUpdate.FirstName;
                ObjToUpdate.CountryID = ObjUpdate.CountryID;
                ObjToUpdate.CityID = ObjUpdate.CityID;
                ObjToUpdate.Telephone = ObjUpdate.Telephone;
                ObjToUpdate.PosCode = ObjUpdate.PosCode;
                ObjToUpdate.Address = ObjUpdate.Address;
            }
        }
    }
}