using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Repositories
{
    public interface IDetailsOfOwnershipRepo
    {
        IEnumerable<DetailsOfOwnership> GetAllDetailsOfOwnership(int CompanyID);
        DetailsOfOwnership GetDetailsOfOwnershipByID(int CompanyID, int OwnerID);
        void Add(DetailsOfOwnership ObjSave);
        void Update(DetailsOfOwnership ObjUpdate);
        void Delete(DetailsOfOwnership ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}