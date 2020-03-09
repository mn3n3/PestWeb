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
    public class CountryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountryController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            var AllCountry = _unitOfWork.NativeSql.GetAllCountryInfo(UserInfo.fCompanyId);
            var CountryFilter = new CountrySearchFilterVM
            {
                Country = AllCountry
            };
            return View(CountryFilter);
        }
        [HttpPost]
        public JsonResult GetAllCountry(CountrySearchFilterVM Obj)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var AllCountry = _unitOfWork.NativeSql.GetAllCountryInfo(UserInfo.fCompanyId);
                if (AllCountry == null)
                {
                    return Json(new List<CountrySearchFilterVM>(), JsonRequestBehavior.AllowGet);
                }
                if (Obj.CountryID != 0)
                {
                    AllCountry = AllCountry.Where(m => m.CountryID == Obj.CountryID).ToList();
                }
                return Json(AllCountry, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<CountrySearchFilterVM>(), JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult SaveCountry()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            Country Obj = new Country
            {
                CountryID = _unitOfWork.Country.GetMaxSerial(UserInfo.fCompanyId)
            };
            return PartialView(Obj);
        }
        [HttpPost]
        public JsonResult SaveCountry(Country ObjToSave)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                ObjToSave.CountryID = _unitOfWork.Country.GetMaxSerial(UserInfo.fCompanyId);
                ObjToSave.InsDateTime = DateTime.Now;
                ObjToSave.InsUserID = userId;
                ObjToSave.CompanyID = UserInfo.fCompanyId;
                if (String.IsNullOrEmpty(ObjToSave.EnglishName))
                    ObjToSave.EnglishName = ObjToSave.ArabicName;
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
                _unitOfWork.Country.Add(ObjToSave);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.Country.GetMaxSerial(UserInfo.fCompanyId).ToString();
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
        public ActionResult UpdateCountry(int id)
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
                    var Obj = _unitOfWork.Country.GetCountryByID(UserInfo.fCompanyId, id);
                    return PartialView("UpdateCountry", Obj);
                }
                return PartialView("UpdateCountry", new Country());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult UpdateCountry(Country ObjUpdate)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                ObjUpdate.CompanyID = UserInfo.fCompanyId;
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
                _unitOfWork.Country.Update(ObjUpdate);
                _unitOfWork.Complete();

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
        public ActionResult DeleteCountry(int id)
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

                    var Obj = _unitOfWork.Country.GetCountryByID(UserInfo.fCompanyId, id);
                    return PartialView("DeleteCountry", Obj);
                }
                return PartialView("DeleteCountry", new Country());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult DeleteCountry(Country ObjDelete)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                ObjDelete.CompanyID = UserInfo.fCompanyId;
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
                _unitOfWork.Country.Delete(ObjDelete);
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
        public JsonResult RefillAllCountry()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var AllCountry = _unitOfWork.NativeSql.GetAllCountryInfo(UserInfo.fCompanyId);
                if (AllCountry == null)
                {
                    return Json(new List<Country>(), JsonRequestBehavior.AllowGet);
                }

                return Json(AllCountry, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<Country>(), JsonRequestBehavior.AllowGet);
            }

        }
    }
}