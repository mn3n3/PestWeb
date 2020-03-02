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
    public class CoatColourController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CoatColourController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            var CoatColourFilter = new CoatColourSearchFilterVM
            {

            };
            return View(CoatColourFilter);
        }
        [HttpPost]
        public JsonResult GetAllCoatColour(CoatColourSearchFilterVM Obj)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var AllCoatColour = _unitOfWork.NativeSql.GetAllCoatColourInfo(UserInfo.fCompanyId);
                if (AllCoatColour == null)
                {
                    return Json(new List<CoatColourSearchFilterVM>(), JsonRequestBehavior.AllowGet);
                }
                if (!String.IsNullOrEmpty(Obj.CoatColourName))
                {
                    AllCoatColour = AllCoatColour.Where(m => m.CoatColourName.ToUpper().Contains(Obj.CoatColourName) ||
                                                        m.CoatColourName.ToLower().Contains(Obj.CoatColourName)).ToList();
                }
                return Json(AllCoatColour, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<CoatColourSearchFilterVM>(), JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult SaveCoatColour()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            CoatColour Obj = new CoatColour
            {
                CoatColourID = _unitOfWork.CoatColour.GetMaxSerial(UserInfo.fCompanyId)
            };
            return PartialView(Obj);
        }
        [HttpPost]
        public JsonResult SaveCoatColour(CoatColour ObjToSave)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                ObjToSave.CoatColourID = _unitOfWork.CoatColour.GetMaxSerial(UserInfo.fCompanyId);
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
                _unitOfWork.CoatColour.Add(ObjToSave);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.CoatColour.GetMaxSerial(UserInfo.fCompanyId).ToString();
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
        public ActionResult UpdateCoatColour(int id)
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
                    var Obj = _unitOfWork.CoatColour.GetCoatColourByID(UserInfo.fCompanyId, id);
                    return PartialView("UpdateCoatColour", Obj);
                }
                return PartialView("UpdateCoatColour", new CoatColour());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult UpdateCoatColour(CoatColour ObjUpdate)
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
                _unitOfWork.CoatColour.Update(ObjUpdate);
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
        public ActionResult DeleteCoatColour(int id)
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

                    var Obj = _unitOfWork.CoatColour.GetCoatColourByID(UserInfo.fCompanyId, id);
                    return PartialView("DeleteCoatColour", Obj);
                }
                return PartialView("DeleteCoatColour", new CoatColour());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult DeleteCoatColour(CoatColour ObjDelete)
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
                _unitOfWork.CoatColour.Delete(ObjDelete);
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