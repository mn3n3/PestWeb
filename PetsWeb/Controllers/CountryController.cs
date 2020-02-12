using Microsoft.AspNet.Identity;
using PetsWeb.Controllers;
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
            var CountryFilter = new CountrySearchFilterVM
            {

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
                var AllAllCountry = _unitOfWork.NativeSql.GetAllCountryInfo(UserInfo.fCompanyId);
                if (AllAllCountry == null)
                {
                    return Json(new List<CountrySearchFilterVM>(), JsonRequestBehavior.AllowGet);
                }
                if (!String.IsNullOrEmpty(Obj.CounryName))
                {
                    AllAllCountry = AllAllCountry.Where(m => m.CounryName.Contains(Obj.CounryName)).ToList();
                }
                return Json(AllAllCountry, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<CountrySearchFilterVM>(), JsonRequestBehavior.AllowGet);
            }

        }
    }
}