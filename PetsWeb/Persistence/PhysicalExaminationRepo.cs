using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Persistence
{
    public class PhysicalExaminationRepo : IPhysicalExaminationRepo
    {
        private readonly ApplicationDbContext _context;

        public PhysicalExaminationRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(PhysicalExamination ObjToSave)
        {
            var Data=_context.PhysicalExaminations.FirstOrDefault(m => m.CompanyID == ObjToSave.CompanyID && m.OwnerID == ObjToSave.OwnerID &&  m.AnimalID== ObjToSave.AnimalID);
            if(Data!=null)
             _context.PhysicalExaminations.Remove(Data);
            
            _context.PhysicalExaminations.Add(ObjToSave);
        }

        public PhysicalExamination GetPhysicalExamination(int COID, string OwnerID, int AnimalID)
        {
            return _context.PhysicalExaminations.FirstOrDefault(m => m.CompanyID == COID && m.OwnerID== OwnerID && m.AnimalID == AnimalID);
        }

        public IEnumerable<PhysicalExamination> GetPhysicalExaminations(int COID)
        {
            throw new NotImplementedException();
        }

        public void Update(PhysicalExamination ObjToSave)
        {
            throw new NotImplementedException();
        }
    }
}