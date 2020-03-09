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
    public class CityController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            var AllCountry = _unitOfWork.NativeSql.GetAllCountryInfo(UserInfo.fCompanyId);
            var AllCity = _unitOfWork.NativeSql.GetAllCityInfo(UserInfo.fCompanyId);
            var CityFilter = new CitySearchFilterVM
            {
                Country = AllCountry,
                City = AllCity
            };
            return View(CityFilter);
        }
        [HttpPost]
        public JsonResult GetAllCity(CitySearchFilterVM Obj)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var AllCity = _unitOfWork.NativeSql.GetAllCityInfo(UserInfo.fCompanyId);
                if (AllCity == null)
                {
                    return Json(new List<CitySearchFilterVM>(), JsonRequestBehavior.AllowGet);
                }
                if (Obj.CityID != 0)
                {
                    AllCity = AllCity.Where(m => m.CityID == Obj.CityID).ToList();
                }
                if (Obj.CountryID != 0)
                {
                    AllCity = AllCity.Where(m => m.CountryID == Obj.CountryID).ToList();
                }
                return Json(AllCity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<CitySearchFilterVM>(), JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateCity(int id)
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
                    var AllCountry = _unitOfWork.NativeSql.GetAllCountryInfo(UserInfo.fCompanyId);
                    var CityObj = _unitOfWork.City.GetCityByID(UserInfo.fCompanyId, id);
                    var CountryID = CityObj.CountryID;
                    CitySearchFilterVM Obj = new CitySearchFilterVM
                    {
                        CityID = CityObj.CityID,
                        ArabicName = CityObj.ArabicName,
                        EnglishName = CityObj.EnglishName,
                        Country = AllCountry,
                        CountryID = CityObj.CountryID
                    };
                    return View("UpdateCity", Obj);
                }
                return View("UpdateCity", new CitySearchFilterVM());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult UpdateCity(CitySearchFilterVM ObjUpdate)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var UpdateCity = new City();
                ObjUpdate.InsDateTime = DateTime.Now;
                ObjUpdate.InsUserID = userId;
                ObjUpdate.CompanyID = UserInfo.fCompanyId;
                if (String.IsNullOrEmpty(ObjUpdate.EnglishName))
                    ObjUpdate.EnglishName = ObjUpdate.ArabicName;

                UpdateCity.CityID = ObjUpdate.CityID;
                UpdateCity.CountryID = ObjUpdate.CountryID;
                UpdateCity.ArabicName = ObjUpdate.ArabicName;
                UpdateCity.EnglishName = ObjUpdate.EnglishName;
                UpdateCity.InsDateTime = ObjUpdate.InsDateTime;
                UpdateCity.InsUserID = ObjUpdate.InsUserID;
                UpdateCity.CompanyID = ObjUpdate.CompanyID;

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
                _unitOfWork.City.Update(UpdateCity);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.City.GetMaxSerial(UserInfo.fCompanyId).ToString();
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
        public ActionResult DeleteCity(int id)
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
                    var CityObj = _unitOfWork.City.GetCityByID(UserInfo.fCompanyId, id);
                    var CountryObj = _unitOfWork.Country.GetCountryByID(UserInfo.fCompanyId, CityObj.CountryID);
                    CitySearchFilterVM Obj = new CitySearchFilterVM { };
                    Obj.CityID = CityObj.CityID;
                    Obj.ArabicName = CityObj.ArabicName;
                    Obj.EnglishName = CityObj.EnglishName;
                    Obj.CountryID = CityObj.CountryID;
                    if (Resources.Resource.CurLang == "Arb")
                    {
                        Obj.CountryName = CountryObj.ArabicName;
                    }
                    else
                    {
                        Obj.CountryName = CountryObj.EnglishName;
                    }
                    return View("DeleteCity", Obj);
                }
                return View("DeleteCity", new CitySearchFilterVM());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult DeleteCity(CitySearchFilterVM ObjDelete)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var DeleteCity = new City();
                ObjDelete.CompanyID = UserInfo.fCompanyId;
                DeleteCity.CompanyID = ObjDelete.CompanyID;
                DeleteCity.CityID = ObjDelete.CityID;
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
                _unitOfWork.City.Delete(DeleteCity);
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
        [HttpGet]
        public JsonResult RefillAllCity()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var AllCity = _unitOfWork.NativeSql.GetAllCityInfo(UserInfo.fCompanyId);
                if (AllCity == null)
                {
                    return Json(new List<City>(), JsonRequestBehavior.AllowGet);
                }

                return Json(AllCity, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<City>(), JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public JsonResult GetCountryName(int CityID)
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            if (CityID != 0)
            {
                var CountryName = _unitOfWork.NativeSql.GetCountryName(UserInfo.fCompanyId, CityID);
                if (CountryName == null)
                {
                    CountryName = new CitySearchFilterVM
                    {
                        CountryName = ""
                    };
                };

                return Json(CountryName.CountryName, JsonRequestBehavior.AllowGet);
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult GetCountryID(int CityID)
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            if (CityID != 0)
            {
                var CountryID = _unitOfWork.NativeSql.GetCountryID(UserInfo.fCompanyId, CityID);
                if (CountryID == null)
                {
                    CountryID = new CitySearchFilterVM
                    {
                        CountryID = 0
                    };
                };

                return Json(CountryID.CountryID, JsonRequestBehavior.AllowGet);
            }
            return Json(0, JsonRequestBehavior.AllowGet);
        }
    }
}