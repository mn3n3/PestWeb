using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Persistence
{
    public class CompanyRepo : ICompanyRepo
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(Company ObjToSave)
        {
            _context.Companies.Add(ObjToSave);
        }

        public Company GetCompanyById(int CoId)
        {
            return _context.Companies.SingleOrDefault(m => m.Id == CoId);
        }

        public Company GetForAdminCompany(string UserId)
        {
            return _context.Companies.SingleOrDefault(m => m.UserId == UserId);
        }

        public void Update(Company ObjToSave)
        {
            var Company = _context.Companies.SingleOrDefault(m => m.Id == ObjToSave.Id && m.UserId == ObjToSave.UserId);
            if (Company != null)
            {
            
                Company.COREFID = ObjToSave.COREFID;
            

   


            }
        }
    }
}