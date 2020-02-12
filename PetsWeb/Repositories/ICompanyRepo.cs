using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetsWeb.Repositories
{
    public interface ICompanyRepo
    {
        Company  GetForAdminCompany(string UserId);
        Company GetCompanyById(int CoId);
        void Add(Company  ObjToSave);
        void Update(Company  ObjToSave);
    }
}