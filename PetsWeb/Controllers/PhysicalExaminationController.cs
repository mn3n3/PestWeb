using Microsoft.AspNet.Identity;
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
    public class PhysicalExaminationController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhysicalExaminationController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        // GET: PhysicalExamination
        public ActionResult New()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            PhysicalExaminationVM Obj = new PhysicalExaminationVM
            {
                DateOfBirth=DateTime.Now,
                DateOfMicrochipping = DateTime.Now
            };

            return View(Obj);
        }

        [HttpPost]
        public JsonResult Save(PhysicalExamination ObjToSave)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                if (UserInfo == null)
                {
                    Msg.Msg = Resources.Resource.PleaseCreateYourCompanyProfileFisrt;
                    Msg.Code = 0;
                    return Json(Msg, JsonRequestBehavior.AllowGet);

                }
                ObjToSave.CompanyID = UserInfo.fCompanyId;
                
                if (UserInfo.fCompanyId == 0)
                {
                    Msg.Msg = Resources.Resource.PleaseCreateYourCompanyProfileFisrt;
                    Msg.Code = 0;
                    return Json(Msg, JsonRequestBehavior.AllowGet);

                }
                if (!ModelState.IsValid)
                {

                    string Err = " ";
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    foreach (ModelError error in errors)
                    {
                        Err = Err + error.ErrorMessage + "  ";
                    }

                    Msg.Msg = Resources.Resource.SomthingWentWrong + " " + Err;
                    Msg.Code = 0;
                    return Json(Msg, JsonRequestBehavior.AllowGet);

                }

                _unitOfWork.PhysicalExamination.Add(ObjToSave);
                _unitOfWork.Complete();
                Msg.Msg = Resources.Resource.AddedSuccessfully;
                Msg.Code = 1;
            }
            catch (Exception ex)
            {

                Msg.Msg = Resources.Resource.SomthingWentWrong + " " + ex.Message.ToString();
                Msg.Code = 0;

            }




            return Json(Msg, JsonRequestBehavior.AllowGet);



        }
    }
}