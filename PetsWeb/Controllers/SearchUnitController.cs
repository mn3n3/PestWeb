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
    public class SearchUnitController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchUnitController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetOwners(int id)
        {
            try
            {
                string UserID = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(UserID);
                var model = _unitOfWork.NativeSql.GetAllDetailsOfOwnershipInfo(UserInfo.fCompanyId);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return Json(new List<SearchUnitVM>(), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SearchOwners(string ID)
        {
            ViewBag.ID = ID;
            return PartialView();
        }
        public JsonResult GetAnimals(int id)
        {
            try
            {
                string UserID = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(UserID);
                var model = _unitOfWork.NativeSql.GetAllDiscriptionOfAnimalInfo(UserInfo.fCompanyId);
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return Json(new List<SearchUnitVM>(), JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult SearchAnimals(string ID)
        {
            ViewBag.ID = ID;
            return PartialView();
        }
    }
}