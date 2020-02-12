using PetsWeb.Models;
using PetsWeb.Repositories;
using PetsWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace PetsWeb.Persistence
{
    public class NativeSqlRepo : INativeSqlRepo
    {
        private readonly ApplicationDbContext _context;

        public NativeSqlRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<CountrySearchFilterVM> GetAllCountryInfo(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<CountrySearchFilterVM>(
                    " Select C.ArabicName As CountryName, C.CountryID, A.UserName " +
                    " From Countries C, AspNetUsers A " +
                    " Where " +
                    " C.CompanyID = A.fCompanyId " +
                    " And " +
                    " C.InsUserID = A.Id " +
                    " And " +
                    " C.CompanyID = @CompanyID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<CountrySearchFilterVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<CountrySearchFilterVM>(
                    " Select C.EnglishName As CountryName, C.CountryID, A.UserName " +
                    " From Countries C, AspNetUsers A " +
                    " Where " +
                    " C.CompanyID = A.fCompanyId " +
                    " And " +
                    " C.InsUserID = A.Id " +
                    " And " +
                    " C.CompanyID = @CompanyID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<CountrySearchFilterVM>();
                }
            }
        }
    }
}