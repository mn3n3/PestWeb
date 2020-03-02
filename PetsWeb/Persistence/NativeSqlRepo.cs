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
                    " C.CompanyID = @CompanyID " +
                    " Order By C.CountryID "
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
                    " C.CompanyID = @CompanyID " +
                    " Order By C.CountryID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<CountrySearchFilterVM>();
                }
            }
        }
        public IEnumerable<BreedSearchFilterVM> GetAllBreedInfo(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<BreedSearchFilterVM>(
                    " Select B.ArabicName As BreedName, B.BreedID, A.UserName " +
                    " From Breeds B, AspNetUsers A " +
                    " Where " +
                    " B.CompanyID = A.fCompanyId " +
                    " And " +
                    " B.InsUserID = A.Id " +
                    " And " +
                    " B.CompanyID = @CompanyID " +
                    " Order By B.BreedID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<BreedSearchFilterVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<BreedSearchFilterVM>(
                    " Select B.EnglishName As BreedName, B.BreedID, A.UserName " +
                    " From Breeds B, AspNetUsers A " +
                    " Where " +
                    " B.CompanyID = A.fCompanyId " +
                    " And " +
                    " B.InsUserID = A.Id " +
                    " And " +
                    " B.CompanyID = @CompanyID " +
                    " Order By B.BreedID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<BreedSearchFilterVM>();
                }
            }
        }
        public IEnumerable<CoatColourSearchFilterVM> GetAllCoatColourInfo(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<CoatColourSearchFilterVM>(
                    " Select CC.ArabicName As CoatColourName, CC.CoatColourID, A.UserName " +
                    " From CoatColours CC, AspNetUsers A " +
                    " Where " +
                    " CC.CompanyID = A.fCompanyId " +
                    " And " +
                    " CC.InsUserID = A.Id " +
                    " And " +
                    " CC.CompanyID = @CompanyID " +
                    " Order By CC.CoatColourID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<CoatColourSearchFilterVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<CoatColourSearchFilterVM>(
                    " Select CC.EnglishName As CoatColourName, CC.CoatColourID, A.UserName " +
                    " From CoatColours CC, AspNetUsers A " +
                    " Where " +
                    " CC.CompanyID = A.fCompanyId " +
                    " And " +
                    " CC.InsUserID = A.Id " +
                    " And " +
                    " CC.CompanyID = @CompanyID " +
                    " Order By CC.CoatColourID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<CoatColourSearchFilterVM>();
                }
            }
        }
        public IEnumerable<AnimalTypeSearchFilterVM> GetAllAnimalTypeInfo(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<AnimalTypeSearchFilterVM>(
                    " Select AT.ArabicName As AnimalTypeName, AT.AnimalTypeID, A.UserName " +
                    " From AnimalTypes AT, AspNetUsers A " +
                    " Where " +
                    " AT.CompanyID = A.fCompanyId " +
                    " And " +
                    " AT.InsUserID = A.Id " +
                    " And " +
                    " AT.CompanyID = @CompanyID " +
                    " Order By AT.AnimalTypeID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<AnimalTypeSearchFilterVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<AnimalTypeSearchFilterVM>(
                    " Select AT.English As AnimalTypeName, AT.AnimalTypeID, A.UserName " +
                    " From AnimalTypes AT, AspNetUsers A " +
                    " Where " +
                    " AT.CompanyID = A.fCompanyId " +
                    " And " +
                    " AT.InsUserID = A.Id " +
                    " And " +
                    " AT.CompanyID = @CompanyID " +
                    " Order By AT.AnimalTypeID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<AnimalTypeSearchFilterVM>();
                }
            }
        }
        public IEnumerable<LocationOfMicrochipSearchFilterVM> GetAllLocationOfMicrochipInfo(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<LocationOfMicrochipSearchFilterVM>(
                    " Select LOM.ArabicName As LocationOfMicrochipName, LOM.LocationOfMicrochipID, A.UserName " +
                    " From LocationOfMicrochips LOM, AspNetUsers A " +
                    " Where " +
                    " LOM.CompanyID = A.fCompanyId " +
                    " And " +
                    " LOM.InsUserID = A.Id " +
                    " And " +
                    " LOM.CompanyID = @CompanyID " +
                    " Order By LOM.LocationOfMicrochipID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<LocationOfMicrochipSearchFilterVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<LocationOfMicrochipSearchFilterVM>(
                    " Select LOM.EnglishName As LocationOfMicrochipName, LOM.LocationOfMicrochipID, A.UserName " +
                    " From LocationOfMicrochips LOM, AspNetUsers A " +
                    " Where " +
                    " LOM.CompanyID = A.fCompanyId " +
                    " And " +
                    " LOM.InsUserID = A.Id " +
                    " And " +
                    " LOM.CompanyID = @CompanyID " +
                    " Order By LOM.LocationOfMicrochipID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<LocationOfMicrochipSearchFilterVM>();
                }
            }
        }
        public IEnumerable<CitySearchFilterVM> GetAllCityInfo(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<CitySearchFilterVM>(
                    " Select C.ArabicName As CityName, CO.ArabicName As CountryName,C.CountryID,C.CityID, A.UserName " +
                    " From Cities C, Countries CO, AspNetUsers A " +
                    " Where " +
                    " C.CompanyID = A.fCompanyId " +
                    " And " +
                    " C.CompanyID = CO.CompanyID " +
                    " And " +
                    " C.InsUserID = A.Id " +
                    " And " +
                    " C.CompanyID = @CompanyID " +
                    " And " +
                    " C.CountryID = Co.CountryID " +
                    " Order By C.CountryID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<CitySearchFilterVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<CitySearchFilterVM>(
                    " Select C.EnglishName As CityName, CO.EnglishName As CountryName,C.CountryID,C.CityID,A.UserName " +
                    " From Cities C, Countries CO, AspNetUsers A " +
                    " Where " +
                    " C.CompanyID = A.fCompanyId " +
                    " And " +
                    " C.CompanyID = CO.CompanyID " +
                    " And " +
                    " C.InsUserID = A.Id " +
                    " And " +
                    " C.CompanyID = @CompanyID " +
                    " And " +
                    " C.CountryID = Co.CountryID " +
                    " Order By C.CountryID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<CitySearchFilterVM>();
                }
            }
        }
    }
}