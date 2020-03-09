using Microsoft.AspNet.Identity;
using PetsWeb.Controllers;
using PetsWeb.Helpers;
using PetsWeb.Models;
using PetsWeb.Persistence;
using PetsWeb.Repositories;
using PetsWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsWeb.Controllers
{
    [Authorize]
    public class DetailsOfOwnershipController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public DetailsOfOwnershipController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            var AllCountry = _unitOfWork.NativeSql.GetAllCountryInfo(UserInfo.fCompanyId);
            var AllCity = _unitOfWork.NativeSql.GetAllCityInfo(UserInfo.fCompanyId);
            var DetailsOfOwnershipFilter = new DetailsOfOwnershipSearchFilterVM
            {
                City = AllCity,
                Country = AllCountry
            };
            return View(DetailsOfOwnershipFilter);
        }
        [HttpPost]
        public JsonResult GetAllDetailsOfOwnership(DetailsOfOwnershipSearchFilterVM Obj)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var AllDetailsOfOwnership = _unitOfWork.NativeSql.GetAllDetailsOfOwnershipInfo(UserInfo.fCompanyId);
                if (AllDetailsOfOwnership == null)
                {
                    return Json(new List<DetailsOfOwnershipSearchFilterVM>(), JsonRequestBehavior.AllowGet);
                }
                if (Obj.CityID != 0)
                {
                    AllDetailsOfOwnership = AllDetailsOfOwnership.Where(m => m.CityID == Obj.CityID).ToList();
                }
                if (Obj.CountryID != 0)
                {
                    AllDetailsOfOwnership = AllDetailsOfOwnership.Where(m => m.CountryID == Obj.CountryID).ToList();
                }
                if (!String.IsNullOrEmpty(Obj.OwnerName))
                {
                    AllDetailsOfOwnership = AllDetailsOfOwnership.Where(m => m.OwnerName.Contains(Obj.OwnerName)).ToList();
                }
                if (!String.IsNullOrEmpty(Obj.Telephone))
                {
                    AllDetailsOfOwnership = AllDetailsOfOwnership.Where(m => m.Telephone.Contains(Obj.Telephone)).ToList();
                }
                return Json(AllDetailsOfOwnership, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<DetailsOfOwnershipSearchFilterVM>(), JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult SaveDetailsOfOwnership()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            var AllCity = _unitOfWork.NativeSql.GetAllCityInfo(UserInfo.fCompanyId);
            int CityID = _unitOfWork.NativeSql.GetFirstCityID(UserInfo.fCompanyId);
            var CountryName = _unitOfWork.NativeSql.GetCountryName(UserInfo.fCompanyId, CityID);
            var CountryID = _unitOfWork.NativeSql.GetCountryID(UserInfo.fCompanyId, CityID);
            DetailsOfOwnershipSearchFilterVM Obj = new DetailsOfOwnershipSearchFilterVM
            {
                OwnerID = _unitOfWork.DetailsOfOwnership.GetMaxSerial(UserInfo.fCompanyId),
                City = AllCity,
                CountryName = CountryName.CountryName,
                CountryID = CountryID.CountryID,
                CityID = 1
            };
            return View(Obj);
        }
        [HttpPost]
        public JsonResult SaveDetailsOfOwnership(DetailsOfOwnershipSearchFilterVM ObjToSave)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var SavDetailsOfOwnership = new DetailsOfOwnership();
                ObjToSave.OwnerID = _unitOfWork.DetailsOfOwnership.GetMaxSerial(UserInfo.fCompanyId);
                ObjToSave.InsDateTime = DateTime.Now;
                ObjToSave.InsUserID = userId;
                ObjToSave.CompanyID = UserInfo.fCompanyId;

                SavDetailsOfOwnership.OwnerID = ObjToSave.OwnerID;
                SavDetailsOfOwnership.CityID = ObjToSave.CityID;
                SavDetailsOfOwnership.CountryID = ObjToSave.CountryID;
                SavDetailsOfOwnership.FirstName = ObjToSave.FirstName;
                SavDetailsOfOwnership.Surname = ObjToSave.Surname;
                SavDetailsOfOwnership.Telephone = ObjToSave.Telephone;
                SavDetailsOfOwnership.PosCode = ObjToSave.PosCode;
                SavDetailsOfOwnership.Address = ObjToSave.Address;
                SavDetailsOfOwnership.InsDateTime = ObjToSave.InsDateTime;
                SavDetailsOfOwnership.InsUserID = ObjToSave.InsUserID;
                SavDetailsOfOwnership.CompanyID = ObjToSave.CompanyID;

                if (!ModelState.IsValid)
                {
                    string Err = " ";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (ModelError error in errors)
                    {
                        Err = Err + error.ErrorMessage + " * ";
                    }

                    Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + Err;
                    Msg.Code = 0;
                    return Json(Msg, JsonRequestBehavior.AllowGet);

                }
                _unitOfWork.DetailsOfOwnership.Add(SavDetailsOfOwnership);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.DetailsOfOwnership.GetMaxSerial(UserInfo.fCompanyId).ToString();
                Msg.Code = 1;
                Msg.Msg = Resources.Resource.AddedSuccessfully;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + ex.Message.ToString();
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult SaveCity()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            var AllCountry = _unitOfWork.NativeSql.GetAllCountryInfo(UserInfo.fCompanyId);
            CitySearchFilterVM Obj = new CitySearchFilterVM
            {
                CityID = _unitOfWork.City.GetMaxSerial(UserInfo.fCompanyId),
                Country = AllCountry,
                CountryID = 1
            };
            return View(Obj);
        }
        [HttpPost]
        public JsonResult SaveCity(CitySearchFilterVM ObjToSave)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {

                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var SaveCity = new City();
                ObjToSave.CityID = _unitOfWork.City.GetMaxSerial(UserInfo.fCompanyId);
                ObjToSave.InsDateTime = DateTime.Now;
                ObjToSave.InsUserID = userId;
                ObjToSave.CompanyID = UserInfo.fCompanyId;
                if (String.IsNullOrEmpty(ObjToSave.EnglishName))
                    ObjToSave.EnglishName = ObjToSave.ArabicName;

                SaveCity.CityID = ObjToSave.CityID;
                SaveCity.CountryID = ObjToSave.CountryID;
                SaveCity.ArabicName = ObjToSave.ArabicName;
                SaveCity.EnglishName = ObjToSave.EnglishName;
                SaveCity.InsDateTime = ObjToSave.InsDateTime;
                SaveCity.InsUserID = ObjToSave.InsUserID;
                SaveCity.CompanyID = ObjToSave.CompanyID;

                if (!ModelState.IsValid)
                {
                    string Err = " ";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (ModelError error in errors)
                    {
                        Err = Err + error.ErrorMessage + " * ";
                    }

                    Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + Err;
                    Msg.Code = 0;
                    return Json(Msg, JsonRequestBehavior.AllowGet);

                }
                _unitOfWork.City.Add(SaveCity);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.City.GetMaxSerial(UserInfo.fCompanyId).ToString();
                Msg.Code = 1;
                Msg.Msg = Resources.Resource.AddedSuccessfully;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + ex.Message.ToString();
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult UpdateDetailsOfOwnership(int id)
        {
            try
            {
                if (id != 0)
                {
                    var userId = User.Identity.GetUserId();
                    var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                    if (UserInfo == null)
                    {
                        RedirectToAction("", "");
                    }
                    var AllCity = _unitOfWork.NativeSql.GetAllCityInfo(UserInfo.fCompanyId);
                    var DetailsOfOwnershipObj = _unitOfWork.DetailsOfOwnership.GetDetailsOfOwnershipByID(UserInfo.fCompanyId, id);
                    var CityID = DetailsOfOwnershipObj.CityID;
                    var CountryName = _unitOfWork.NativeSql.GetCountryName(UserInfo.fCompanyId, DetailsOfOwnershipObj.CityID);
                    var CountryID = _unitOfWork.NativeSql.GetCountryID(UserInfo.fCompanyId, DetailsOfOwnershipObj.CityID);
                    DetailsOfOwnershipSearchFilterVM Obj = new DetailsOfOwnershipSearchFilterVM
                    {
                        OwnerID = DetailsOfOwnershipObj.OwnerID,
                        FirstName = DetailsOfOwnershipObj.FirstName,
                        Surname = DetailsOfOwnershipObj.Surname,
                        Telephone = DetailsOfOwnershipObj.Telephone,
                        PosCode = DetailsOfOwnershipObj.PosCode,
                        Address = DetailsOfOwnershipObj.Address,
                        City = AllCity,
                        CityID = DetailsOfOwnershipObj.CityID,
                        CountryID = CountryID.CountryID,
                        CountryName = CountryName.CountryName
                    };
                    return View("UpdateDetailsOfOwnership", Obj);
                }
                return View("UpdateDetailsOfOwnership", new DetailsOfOwnershipSearchFilterVM());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult UpdateDetailsOfOwnership(DetailsOfOwnershipSearchFilterVM ObjUpdate)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var UpdateDetailsOfOwnership = new DetailsOfOwnership();
                ObjUpdate.InsDateTime = DateTime.Now;
                ObjUpdate.InsUserID = userId;
                ObjUpdate.CompanyID = UserInfo.fCompanyId;

                UpdateDetailsOfOwnership.OwnerID = ObjUpdate.OwnerID;
                UpdateDetailsOfOwnership.CityID = ObjUpdate.CityID;
                UpdateDetailsOfOwnership.CountryID = ObjUpdate.CountryID;
                UpdateDetailsOfOwnership.FirstName = ObjUpdate.FirstName;
                UpdateDetailsOfOwnership.Surname = ObjUpdate.Surname;
                UpdateDetailsOfOwnership.Telephone = ObjUpdate.Telephone;
                UpdateDetailsOfOwnership.PosCode = ObjUpdate.PosCode;
                UpdateDetailsOfOwnership.Address = ObjUpdate.Address;
                UpdateDetailsOfOwnership.InsDateTime = ObjUpdate.InsDateTime;
                UpdateDetailsOfOwnership.InsUserID = ObjUpdate.InsUserID;
                UpdateDetailsOfOwnership.CompanyID = ObjUpdate.CompanyID;
                if (!ModelState.IsValid)
                {
                    string Err = " ";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (ModelError error in errors)
                    {
                        Err = Err + error.ErrorMessage + " * ";
                    }

                    Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + Err;
                    Msg.Code = 0;
                    return Json(Msg, JsonRequestBehavior.AllowGet);

                }
                _unitOfWork.DetailsOfOwnership.Update(UpdateDetailsOfOwnership);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.DetailsOfOwnership.GetMaxSerial(UserInfo.fCompanyId).ToString();
                Msg.Code = 1;
                Msg.Msg = Resources.Resource.UpdatedSuccessfully;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + ex.Message.ToString();
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult DeleteDetailsOfOwnership(int id)
        {
            try
            {
                if (id != 0)
                {
                    var userId = User.Identity.GetUserId();
                    var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                    if (UserInfo == null)
                    {
                        RedirectToAction("", "");
                    }
                    var DetailsOfOwnershipObj = _unitOfWork.DetailsOfOwnership.GetDetailsOfOwnershipByID(UserInfo.fCompanyId, id);
                    var CityObj = _unitOfWork.City.GetCityByID(UserInfo.fCompanyId, DetailsOfOwnershipObj.CityID);
                    var CountryObj = _unitOfWork.Country.GetCountryByID(UserInfo.fCompanyId, DetailsOfOwnershipObj.CountryID);
                    DetailsOfOwnershipSearchFilterVM Obj = new DetailsOfOwnershipSearchFilterVM { };
                    Obj.CityID = DetailsOfOwnershipObj.CityID;
                    Obj.CountryID = DetailsOfOwnershipObj.CountryID;
                    Obj.OwnerID = DetailsOfOwnershipObj.OwnerID;
                    Obj.Surname = DetailsOfOwnershipObj.Surname;
                    Obj.FirstName = DetailsOfOwnershipObj.FirstName;
                    Obj.Telephone = DetailsOfOwnershipObj.Telephone;
                    Obj.PosCode = DetailsOfOwnershipObj.PosCode;
                    Obj.Address = DetailsOfOwnershipObj.Address;
                    if (Resources.Resource.CurLang == "Arb")
                    {
                        Obj.CountryName = CountryObj.ArabicName;
                        Obj.CityName = CityObj.ArabicName;
                    }
                    else
                    {
                        Obj.CountryName = CountryObj.EnglishName;
                        Obj.CityName = CityObj.EnglishName;
                    }
                    return View("DeleteDetailsOfOwnership", Obj);
                }
                return View("DeleteDetailsOfOwnership", new DetailsOfOwnershipSearchFilterVM());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult DeleteDetailsOfOwnership(DetailsOfOwnershipSearchFilterVM ObjDelete)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var DeleteDetailsOfOwnership = new DetailsOfOwnership();
                ObjDelete.CompanyID = UserInfo.fCompanyId;
                DeleteDetailsOfOwnership.CompanyID = ObjDelete.CompanyID;
                DeleteDetailsOfOwnership.OwnerID = ObjDelete.OwnerID;
                if (!ModelState.IsValid)
                {
                    string Err = " ";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (ModelError error in errors)
                    {
                        Err = Err + error.ErrorMessage + " * ";
                    }
                    Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + Err;
                    Msg.Code = 0;
                    return Json(Msg, JsonRequestBehavior.AllowGet);

                }
                _unitOfWork.DetailsOfOwnership.Delete(DeleteDetailsOfOwnership);
                _unitOfWork.Complete();
                Msg.Code = 1;
                Msg.Msg = Resources.Resource.DeletedSuccessfully;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + ex.Message.ToString();
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }
        }
    }
}