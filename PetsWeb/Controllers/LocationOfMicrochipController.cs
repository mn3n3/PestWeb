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
    public class LocationOfMicrochipController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public LocationOfMicrochipController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            var AllLocationOfMicrochip = _unitOfWork.NativeSql.GetAllLocationOfMicrochipInfo(UserInfo.fCompanyId);
            var LocationOfMicrochipFilter = new LocationOfMicrochipSearchFilterVM
            {
                LocationOfMicrochip = AllLocationOfMicrochip
            };
            return View(LocationOfMicrochipFilter);
        }
        [HttpPost]
        public JsonResult GetAllLocationOfMicrochip(LocationOfMicrochipSearchFilterVM Obj)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var AllLocationOfMicrochip = _unitOfWork.NativeSql.GetAllLocationOfMicrochipInfo(UserInfo.fCompanyId);
                if (AllLocationOfMicrochip == null)
                {
                    return Json(new List<LocationOfMicrochipSearchFilterVM>(), JsonRequestBehavior.AllowGet);
                }
                if (Obj.LocationOfMicrochipID != 0)
                {
                    AllLocationOfMicrochip = AllLocationOfMicrochip.Where(m => m.LocationOfMicrochipID == Obj.LocationOfMicrochipID).ToList();
                }
                return Json(AllLocationOfMicrochip, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<LocationOfMicrochipSearchFilterVM>(), JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult SaveLocationOfMicrochip()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            LocationOfMicrochip Obj = new LocationOfMicrochip
            {
                LocationOfMicrochipID = _unitOfWork.LocationOfMicrochip.GetMaxSerial(UserInfo.fCompanyId)
            };
            return PartialView(Obj);
        }
        [HttpPost]
        public JsonResult SaveLocationOfMicrochip(LocationOfMicrochip ObjToSave)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                ObjToSave.LocationOfMicrochipID = _unitOfWork.LocationOfMicrochip.GetMaxSerial(UserInfo.fCompanyId);
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
                _unitOfWork.LocationOfMicrochip.Add(ObjToSave);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.LocationOfMicrochip.GetMaxSerial(UserInfo.fCompanyId).ToString();
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
        public ActionResult UpdateLocationOfMicrochip(int id)
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
                    var Obj = _unitOfWork.LocationOfMicrochip.GetLocationOfMicrochipByID(UserInfo.fCompanyId, id);
                    return PartialView("UpdateLocationOfMicrochip", Obj);
                }
                return PartialView("UpdateLocationOfMicrochip", new LocationOfMicrochip());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult UpdateLocationOfMicrochip(LocationOfMicrochip ObjUpdate)
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
                _unitOfWork.LocationOfMicrochip.Update(ObjUpdate);
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
        public ActionResult DeleteLocationOfMicrochip(int id)
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

                    var Obj = _unitOfWork.LocationOfMicrochip.GetLocationOfMicrochipByID(UserInfo.fCompanyId, id);
                    return PartialView("DeleteLocationOfMicrochip", Obj);
                }
                return PartialView("DeleteLocationOfMicrochip", new LocationOfMicrochip());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult DeleteLocationOfMicrochip(LocationOfMicrochip ObjDelete)
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
                _unitOfWork.LocationOfMicrochip.Delete(ObjDelete);
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
        public JsonResult RefillAllLocationOfMicrochip()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var AllLocationOfMicrochip = _unitOfWork.NativeSql.GetAllLocationOfMicrochipInfo(UserInfo.fCompanyId);
                if (AllLocationOfMicrochip == null)
                {
                    return Json(new List<LocationOfMicrochip>(), JsonRequestBehavior.AllowGet);
                }

                return Json(AllLocationOfMicrochip, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<LocationOfMicrochip>(), JsonRequestBehavior.AllowGet);
            }

        }
    }
}