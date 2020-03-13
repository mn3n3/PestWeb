using PetsWeb.Models;
using PetsWeb.Repositories;
using PetsWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;

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
                    " Select Distinct C.ArabicName As CountryName, C.CountryID, A.UserName, " +
                    " Case WHEN C.CountryID = CC.CountryID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,Countries C " +
                    " Left join Cities CC On " +
                    " C.CountryID = CC.CountryID " +
                    " And " +
                    " C.CompanyID = CC.CompanyID " +
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
                    " Select Distinct C.EnglishName As CountryName, C.CountryID, A.UserName, " +
                    " Case WHEN C.CountryID = CC.CountryID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,Countries C " +
                    " Left join Cities CC On " +
                    " C.CountryID = CC.CountryID " +
                    " And " +
                    " C.CompanyID = CC.CompanyID " +
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
                    " Select Distinct B.ArabicName As BreedName, B.BreedID, A.UserName, " +
                    " Case WHEN B.BreedID = DA.BreedID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,Breeds B " +
                    " Left join DiscriptionOfAnimals DA On " +
                    " B.BreedID = DA.BreedID " +
                    " And " +
                    " B.CompanyID = DA.CompanyID " +
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
                    " Select Distinct B.EnglishName As BreedName, B.BreedID, A.UserName, " +
                    " Case WHEN B.BreedID = DA.BreedID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,Breeds B " +
                    " Left join DiscriptionOfAnimals DA On " +
                    " B.BreedID = DA.BreedID " +
                    " And " +
                    " B.CompanyID = DA.CompanyID " +
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
                    " Select Distinct CC.ArabicName As CoatColourName,CC.CoatColourID, A.UserName, " +
                    " Case WHEN CC.CoatColourID = DA.CoatColourID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,CoatColours CC " +
                    " Left join DiscriptionOfAnimals DA On " +
                    " CC.CoatColourID = DA.CoatColourID " +
                    " And " +
                    " CC.CompanyID = DA.CompanyID " +
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
                    " Select Distinct CC.EnglishName As CoatColourName,CC.CoatColourID, A.UserName, " +
                    " Case WHEN CC.CoatColourID = DA.CoatColourID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,CoatColours CC " +
                    " Left join DiscriptionOfAnimals DA On " +
                    " CC.CoatColourID = DA.CoatColourID " +
                    " And " +
                    " CC.CompanyID = DA.CompanyID " +
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
                    " Select Distinct AT.ArabicName As AnimalTypeName,AT.AnimalTypeID, A.UserName, " +
                    " Case WHEN AT.AnimalTypeID = DA.AnimalTypeID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,AnimalTypes AT " +
                    " Left join DiscriptionOfAnimals DA On " +
                    " AT.AnimalTypeID = DA.AnimalTypeID " +
                    " And " +
                    " AT.CompanyID = DA.CompanyID " +
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
                    " Select Distinct AT.EnglishName As AnimalTypeName,AT.AnimalTypeID, A.UserName, " +
                    " Case WHEN AT.AnimalTypeID = DA.AnimalTypeID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,AnimalTypes AT " +
                    " Left join DiscriptionOfAnimals DA On " +
                    " AT.AnimalTypeID = DA.AnimalTypeID " +
                    " And " +
                    " AT.CompanyID = DA.CompanyID " +
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
                    " Select Distinct LOM.ArabicName As LocationOfMicrochipName,LOM.LocationOfMicrochipID, A.UserName, " +
                    " Case WHEN LOM.LocationOfMicrochipID = DA.LocationOfMicrochipID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,LocationOfMicrochips LOM " +
                    " Left join DiscriptionOfAnimals DA On " +
                    " LOM.LocationOfMicrochipID = DA.LocationOfMicrochipID " +
                    " And " +
                    " LOM.CompanyID = DA.CompanyID " +
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
                    " Select Distinct LOM.EnglishName As LocationOfMicrochipName,LOM.LocationOfMicrochipID, A.UserName, " +
                    " Case WHEN LOM.LocationOfMicrochipID = DA.LocationOfMicrochipID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,LocationOfMicrochips LOM " +
                    " Left join DiscriptionOfAnimals DA On " +
                    " LOM.LocationOfMicrochipID = DA.LocationOfMicrochipID " +
                    " And " +
                    " LOM.CompanyID = DA.CompanyID " +
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
                    " Select Distinct C.ArabicName As CityName, CO.ArabicName As CountryName,C.CountryID,C.CityID, A.UserName, " +
                    " Case WHEN C.CityID = D.CityID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,Cities C " +
                    " Left join Countries CO On " +
                    " C.CountryID = Co.CountryID " +
                    " And " +
                    " C.CompanyID = CO.CompanyID " +
                    " Left join DetailsOfOwnerships D On " +
                    " C.CityID = D.CityID " +
                    " And " +
                    " C.CompanyID = D.CompanyID " +
                    " Where " +
                    " C.CompanyID = A.fCompanyId " +
                    " And " +
                    " C.InsUserID = A.Id " +
                    " And " +
                    " C.CompanyID = @CompanyID " +
                    " Order By C.CityID "
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
                    " Select Distinct C.EnglishName As CityName, CO.EnglishName As CountryName,C.CountryID,C.CityID, A.UserName, " +
                    " Case WHEN C.CityID = D.CityID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A,Cities C " +
                    " Left join Countries CO On " +
                    " C.CountryID = Co.CountryID " +
                    " And " +
                    " C.CompanyID = CO.CompanyID " +
                    " Left join DetailsOfOwnerships D On " +
                    " C.CityID = D.CityID " +
                    " And " +
                    " C.CompanyID = D.CompanyID " +
                    " Where " +
                    " C.CompanyID = A.fCompanyId " +
                    " And " +
                    " C.InsUserID = A.Id " +
                    " And " +
                    " C.CompanyID = @CompanyID " +
                    " Order By C.CityID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<CitySearchFilterVM>();
                }
            }
        }
        public IEnumerable<DetailsOfOwnershipSearchFilterVM> GetAllDetailsOfOwnershipInfo(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<DetailsOfOwnershipSearchFilterVM>(
                    " Select Distinct C.ArabicName As CityName, CO.ArabicName As CountryName, CO.CountryID, C.CityID, A.UserName, " +
                    " Concat(Concat(D.Surname, ' '), D.FirstName) As OwnerName, D.OwnerID, D.Telephone, D.PosCode, D.Address, " +
                    " Case WHEN D.OwnerID = DA.OwnerID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From  AspNetUsers A, DetailsOfOwnerships D " +
                    " left Join Cities C On " +
                    " D.CompanyID = C.CompanyID " +
                    " And " +
                    " D.CityID = C.CityID " +
                    " left Join Countries CO On " +
                    " D.CompanyID = CO.CompanyID " +
                    " And " +
                    " D.CountryID = CO.CountryID " +
                    " left Join DiscriptionOfAnimals DA On " +
                    " D.CompanyID = DA.CompanyID " +
                    " And " +
                    " D.OwnerID = DA.OwnerID " +
                    " Where " +
                    " D.CompanyID = A.fCompanyId " +
                    " And " +
                    " D.InsUserID = A.Id " +
                    " And " +
                    " D.CompanyID = @CompanyID " +
                    " Order By D.OwnerID " 
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<DetailsOfOwnershipSearchFilterVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<DetailsOfOwnershipSearchFilterVM>(
                    " Select Distinct C.EnglishName As CityName, CO.EnglishName As CountryName, CO.CountryID, C.CityID, A.UserName, " +
                    " Concat(Concat(D.Surname, ' '), D.FirstName) As OwnerName, D.OwnerID, D.Telephone, D.PosCode, D.Address, " +
                    " Case WHEN D.OwnerID = DA.OwnerID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From  AspNetUsers A, DetailsOfOwnerships D " +
                    " left Join Cities C On " +
                    " D.CompanyID = C.CompanyID " +
                    " And " +
                    " D.CityID = C.CityID " +
                    " left Join Countries CO On " +
                    " D.CompanyID = CO.CompanyID " +
                    " And " +
                    " D.CountryID = CO.CountryID " +
                    " left Join DiscriptionOfAnimals DA On " +
                    " D.CompanyID = DA.CompanyID " +
                    " And " +
                    " D.OwnerID = DA.OwnerID " +
                    " Where " +
                    " D.CompanyID = A.fCompanyId " +
                    " And " +
                    " D.InsUserID = A.Id " +
                    " And " +
                    " D.CompanyID = @CompanyID " +
                    " Order By D.OwnerID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch
                {
                    return new List<DetailsOfOwnershipSearchFilterVM>();
                }
            }
        }
        public CitySearchFilterVM GetCountryName(int CompanyID, int CityID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<CitySearchFilterVM>(
                    " Select CO.ArabicName As CountryName " +
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
                    " C.CityID = @CityID " +
                    " And " +
                    " C.CountryID = Co.CountryID "
                    , new SqlParameter("@CompanyID", CompanyID)
                    , new SqlParameter("@CityID", CityID)

                ).FirstOrDefault();
                }
                catch
                {
                    return new CitySearchFilterVM();
                }
            }
            else 
            {
                try
                {
                    return _context.Database.SqlQuery<CitySearchFilterVM>(
                    " Select CO.EnglishName As CountryName " +
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
                    " C.CityID = @CityID " +
                    " And " +
                    " C.CountryID = Co.CountryID "
                    , new SqlParameter("@CompanyID", CompanyID)
                    , new SqlParameter("@CityID", CityID)

                ).FirstOrDefault();
                }
                catch
                {
                    return new CitySearchFilterVM();
                }
            }
        }
        public CitySearchFilterVM GetCountryID(int CompanyID, int CityID)
        {
            try
            {
                return _context.Database.SqlQuery<CitySearchFilterVM>(
                " Select CO.CountryID " +
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
                " C.CityID = @CityID " +
                " And " +
                " C.CountryID = Co.CountryID "
                , new SqlParameter("@CompanyID", CompanyID)
                , new SqlParameter("@CityID", CityID)

            ).FirstOrDefault();
            }
            catch
            {
                return new CitySearchFilterVM();
            }
        }
        public int GetFirstCityID(int CompanyID)
        {
            int CityID = _context.Database.SqlQuery<int>(
                " Select Top 1 C.CityID " +
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
                " Order By C.CityID "
                , new SqlParameter("@CompanyID", CompanyID)
                ).First();

            return CityID;
        }
        public IEnumerable<DiscriptionOfAnimalSearchFilterVM> GetAllDiscriptionOfAnimalInfo(int CompanyID)
        {
            if (Resources.Resource.CurLang == "Arb")
            {
                try
                {
                    return _context.Database.SqlQuery<DiscriptionOfAnimalSearchFilterVM>(
                    " Select Distinct DA.AnimalID, DA.AnimalName, DA.DateOfBirth, DA.GenderID,A.UserName,DA.MicrochipNumber,DA.DateOfMicrochipping, " +
                    " Case When DA.GenderID = 1 " +
                    " Then N'ذكر' " +
                    " Else N'انثى' " +
                    " End As GenderName, " +
                    " Concat(Concat(D.Surname, ' '), D.FirstName) As OwnerName, D.OwnerID, D.Telephone, " +
                    " B.ArabicName As BreedName, B.BreedID, " +
                    " CC.ArabicName As CoatColourName, CC.CoatColourID, " +
                    " ATY.ArabicName As AnimalTypeName, ATY.AnimalTypeID, " +
                    " LOM.ArabicName As LocationOfMicrochipName, LOM.LocationOfMicrochipID, " +
                    " Case WHEN DA.AnimalID = PE.AnimalID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A, DiscriptionOfAnimals DA " +
                    " Left Join DetailsOfOwnerships D On " +
                    " DA.CompanyID = D.CompanyID " +
                    " And " +
                    " DA.OwnerID = D.OwnerID " +
                    " Left Join Breeds B On " +
                    " DA.CompanyID = B.CompanyID " +
                    " And " +
                    " DA.BreedID = B.BreedID " +
                    " Left Join CoatColours CC On " +
                    " DA.CompanyID = CC.CompanyID " +
                    " And " +
                    " DA.CoatColourID = CC.CoatColourID " +
                    " Left Join AnimalTypes ATY On " +
                    " DA.CompanyID = ATY.CompanyID " +
                    " And " +
                    " DA.AnimalTypeID = ATY.AnimalTypeID " +
                    " Left Join LocationOfMicrochips LOM On " +
                    " DA.CompanyID = LOM.CompanyID " +
                    " And " +
                    " DA.LocationOfMicrochipID = LOM.LocationOfMicrochipID " +
                    " left Join PhysicalExaminations PE On " +
                    " DA.CompanyID = PE.CompanyID " +
                    " And " +
                    " DA.AnimalID = PE.AnimalID " +
                    " Where " +
                    " DA.CompanyID = A.fCompanyId " +
                    " And " +
                    " DA.InsUserID = A.Id " +
                    " And " +
                    " DA.CompanyID = @CompanyID " +
                    " Order By DA.AnimalID " 
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return new List<DiscriptionOfAnimalSearchFilterVM>();
                }
            }
            else
            {
                try
                {
                    return _context.Database.SqlQuery<DiscriptionOfAnimalSearchFilterVM>(
                    " Select Distinct DA.AnimalID, DA.AnimalName, DA.DateOfBirth, DA.GenderID,A.UserName,DA.MicrochipNumber,DA.DateOfMicrochipping, " +
                    " Case When DA.GenderID = 1 " +
                    " Then 'Male' " +
                    " Else 'Female' " +
                    " End As GenderName, " +
                    " Concat(Concat(D.Surname, ' '), D.FirstName) As OwnerName, D.OwnerID, D.Telephone, " +
                    " B.EnglishName As BreedName, B.BreedID, " +
                    " CC.EnglishName As CoatColourName, CC.CoatColourID, " +
                    " ATY.EnglishName As AnimalTypeName, ATY.AnimalTypeID, " +
                    " LOM.EnglishName As LocationOfMicrochipName, LOM.LocationOfMicrochipID, " +
                    " Case WHEN DA.AnimalID = PE.AnimalID " +
                    " Then 1 " +
                    " ELSE 0 " +
                    " END as Used " +
                    " From AspNetUsers A, DiscriptionOfAnimals DA " +
                    " Left Join DetailsOfOwnerships D On " +
                    " DA.CompanyID = D.CompanyID " +
                    " And " +
                    " DA.OwnerID = D.OwnerID " +
                    " Left Join Breeds B On " +
                    " DA.CompanyID = B.CompanyID " +
                    " And " +
                    " DA.BreedID = B.BreedID " +
                    " Left Join CoatColours CC On " +
                    " DA.CompanyID = CC.CompanyID " +
                    " And " +
                    " DA.CoatColourID = CC.CoatColourID " +
                    " Left Join AnimalTypes ATY On " +
                    " DA.CompanyID = ATY.CompanyID " +
                    " And " +
                    " DA.AnimalTypeID = ATY.AnimalTypeID " +
                    " Left Join LocationOfMicrochips LOM On " +
                    " DA.CompanyID = LOM.CompanyID " +
                    " And " +
                    " DA.LocationOfMicrochipID = LOM.LocationOfMicrochipID " +
                    " left Join PhysicalExaminations PE On " +
                    " DA.CompanyID = PE.CompanyID " +
                    " And " +
                    " DA.AnimalID = PE.AnimalID " +
                    " Where " +
                    " DA.CompanyID = A.fCompanyId " +
                    " And " +
                    " DA.InsUserID = A.Id " +
                    " And " +
                    " DA.CompanyID = @CompanyID " +
                    " Order By DA.AnimalID "
                    , new SqlParameter("@CompanyID", CompanyID)

                ).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    return new List<DiscriptionOfAnimalSearchFilterVM>();
                }
            }
        }
        public DetailsOfOwnershipSearchFilterVM GetOwnerName(int CompanyID, int OwnerID)
        {
            try
            {
                return _context.Database.SqlQuery<DetailsOfOwnershipSearchFilterVM>(
                " Select Concat(Concat(D.Surname, ' '), D.FirstName) As OwnerName " +
                " From AspNetUsers A,DetailsOfOwnerships D " +
                " Where " +
                " D.CompanyID = A.fCompanyId " +
                " And " +
                " D.InsUserID = A.Id " +
                " And " +
                " D.CompanyID = @CompanyID " +
                " And " +
                " D.OwnerID = @OwnerID "
                , new SqlParameter("@CompanyID", CompanyID)
                , new SqlParameter("@OwnerID", OwnerID)

            ).FirstOrDefault();
            }
            catch
            {
                return new DetailsOfOwnershipSearchFilterVM();
            }
        }
    }
}