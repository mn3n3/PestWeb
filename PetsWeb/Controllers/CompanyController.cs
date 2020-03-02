using Microsoft.AspNet.Identity;
using PetsWeb.Helpers;
using PetsWeb.Models;
using PetsWeb.Persistence;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsWeb.Controllers
{
    [Authorize]
    public class CompanyController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CompanyController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        // GET: Company

        [HttpPost]
        public JsonResult Save(Company ObjToSave)
        {
            MsgUnit Msg = new MsgUnit();
            string UserID = User.Identity.GetUserId();
            ObjToSave.UserId = UserID;

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

            try
            {
             





                var CoData = _unitOfWork.Company.GetForAdminCompany(UserID);
                if (CoData != null)
                {
                    ObjToSave.Id = CoData.Id;

                    _unitOfWork.Company.Update(ObjToSave);
                    _unitOfWork.Complete();

                }
                else
                {
                    _unitOfWork.Company.Add(ObjToSave);
                    _unitOfWork.Complete();



                    var path = Server.MapPath("~/AnimalDoc/" + ObjToSave.Id.ToString());
                    Directory.CreateDirectory(path);

                    var path2 = Server.MapPath("~/AnimalImg/" + ObjToSave.Id.ToString());
                    Directory.CreateDirectory(path2);


                    string fileName = "noimage.png";
                    string sourcePath = Server.MapPath("~/Logos/Animal.png");
                    string targetPath = Server.MapPath("~/AnimalImg/" + ObjToSave.Id.ToString());

                    string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
                    string destFile = System.IO.Path.Combine(targetPath, "\\");


                    string fileToCopy = sourcePath;
                    string destinationDirectory = targetPath + "\\";

                    System.IO.File.Copy(fileToCopy, destinationDirectory + Path.GetFileName(fileToCopy));

                 

                }



              

                var UserInfo = _unitOfWork.UserAccount.GetUserByID(ObjToSave.UserId);
                UserInfo.fCompanyId = ObjToSave.Id;
                _unitOfWork.UserAccount.AddModifyFromCreateCompnay(UserInfo);

                _unitOfWork.Complete();


              
 


             
                
         


   

          
 




                return Json(Msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Msg.Msg = Resources.Resource.SomthingWentWrong + " : " + ex.Message.ToString();
                Msg.Code = 0;
                return Json(Msg, JsonRequestBehavior.AllowGet);
            }






        }


        public ActionResult Index()
        {
            try
            {



                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);

                if ((userId == null) || UserInfo == null)
                {
                    return RedirectToAction("Login", "Account");
                }
              


                var Company = _unitOfWork.Company.GetForAdminCompany(userId);

                if (Company == null)
                {
                    Company = new Company();




                    Company.CompanyLogo = "noimage.png";
                    Company.UserId = userId;
                    return View("CreateNew", Company);
                    



                }
                else
                {
                    
                   

                    if (String.IsNullOrEmpty(Company.CompanyLogo))
                        Company.CompanyLogo = "noimage.png";

                    return View("Update", Company);

                }



                
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }

        }
    }
}