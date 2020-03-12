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
            throw new NotImplementedException();
        }

        public PhysicalExamination GetPhysicalExamination(int COID, int OwnerID, int AnimalID)
        {
            throw new NotImplementedException();
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