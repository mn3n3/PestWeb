using PetsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace PetsWeb.Repositories
{
    public interface ICoatColourRepo
    {
        IEnumerable<CoatColour> GetAllCoatColour(int CompanyID);
        CoatColour GetCoatColourByID(int CompanyID, int CoatColourID);
        void Add(CoatColour ObjSave);
        void Update(CoatColour ObjUpdate);
        void Delete(CoatColour ObjDelete);
        int GetMaxSerial(int CompanyID);
    }
}