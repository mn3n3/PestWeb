using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Repositories
{
    public interface IPhysicalExaminationRepo
    {
        void Add(PhysicalExamination ObjToSave);

        void Update(PhysicalExamination ObjToSave);

        PhysicalExamination GetPhysicalExamination(int COID, string OwnerID, int AnimalID);

        IEnumerable<PhysicalExamination> GetPhysicalExaminations(int COID);
    }
}