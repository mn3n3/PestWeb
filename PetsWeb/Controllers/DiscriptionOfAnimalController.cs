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
    public class DiscriptionOfAnimalController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        public DiscriptionOfAnimalController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            var AllBreed = _unitOfWork.NativeSql.GetAllBreedInfo(UserInfo.fCompanyId);
            var AllCoatColour = _unitOfWork.NativeSql.GetAllCoatColourInfo(UserInfo.fCompanyId);
            var AllAnimalType = _unitOfWork.NativeSql.GetAllAnimalTypeInfo(UserInfo.fCompanyId);
            var DiscriptionOfAnimalFilter = new DiscriptionOfAnimalSearchFilterVM
            {
                Breed = AllBreed,
                CoatColour = AllCoatColour,
                AnimalType = AllAnimalType
            };
            return View(DiscriptionOfAnimalFilter);
        }
        [HttpPost]
        public JsonResult GetAllDiscriptionOfAnimal(DiscriptionOfAnimalSearchFilterVM Obj)
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var AllDiscriptionOfAnimal = _unitOfWork.NativeSql.GetAllDiscriptionOfAnimalInfo(UserInfo.fCompanyId);
                if (AllDiscriptionOfAnimal == null)
                {
                    return Json(new List<DiscriptionOfAnimalSearchFilterVM>(), JsonRequestBehavior.AllowGet);
                }
                if (Obj.BreedID != 0)
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.BreedID == Obj.BreedID).ToList();
                }
                if (Obj.AnimalTypeID != 0)
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.AnimalTypeID == Obj.AnimalTypeID).ToList();
                }
                if (Obj.CoatColourID != 0)
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.CoatColourID == Obj.CoatColourID).ToList();
                }
                if (!String.IsNullOrEmpty(Obj.OwnerName))
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.OwnerName.Contains(Obj.OwnerName)).ToList();
                }
                if (!String.IsNullOrEmpty(Obj.AnimalName))
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.AnimalName.Contains(Obj.AnimalName)).ToList();
                }
                if (!String.IsNullOrEmpty(Obj.Telephone))
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.Telephone.Contains(Obj.Telephone)).ToList();
                }
                return Json(AllDiscriptionOfAnimal, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return Json(new List<DiscriptionOfAnimalSearchFilterVM>(), JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult SaveDiscriptionOfAnimal()
        {
            var userId = User.Identity.GetUserId();
            var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
            var AllBreed = _unitOfWork.NativeSql.GetAllBreedInfo(UserInfo.fCompanyId);
            var AllAnimalType = _unitOfWork.NativeSql.GetAllAnimalTypeInfo(UserInfo.fCompanyId);
            var AllCoatColour = _unitOfWork.NativeSql.GetAllCoatColourInfo(UserInfo.fCompanyId);
            DiscriptionOfAnimalSearchFilterVM Obj = new DiscriptionOfAnimalSearchFilterVM
            {
                AnimalID = _unitOfWork.DiscriptionOfAnimal.GetMaxSerial(UserInfo.fCompanyId),
                Breed = AllBreed,
                BreedID = 1,
                AnimalType = AllAnimalType,
                AnimalTypeID = 1,
                CoatColour = AllCoatColour,
                CoatColourID = 1,
                DateOfBirth = DateTime.Now
            };
            return View(Obj);
        }
        [HttpPost]
        public JsonResult SaveDiscriptionOfAnimal(DiscriptionOfAnimalSearchFilterVM ObjToSave)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var SaveDiscriptionOfAnimal = new DiscriptionOfAnimal();
                ObjToSave.AnimalID = _unitOfWork.DiscriptionOfAnimal.GetMaxSerial(UserInfo.fCompanyId);
                ObjToSave.InsDateTime = DateTime.Now;
                ObjToSave.InsUserID = userId;
                ObjToSave.CompanyID = UserInfo.fCompanyId;

                SaveDiscriptionOfAnimal.AnimalID = ObjToSave.AnimalID;
                SaveDiscriptionOfAnimal.BreedID = ObjToSave.BreedID;
                SaveDiscriptionOfAnimal.AnimalTypeID = ObjToSave.AnimalTypeID;
                SaveDiscriptionOfAnimal.CoatColourID = ObjToSave.CoatColourID;
                SaveDiscriptionOfAnimal.OwnerID = ObjToSave.OwnerID;
                SaveDiscriptionOfAnimal.AnimalName = ObjToSave.AnimalName;
                SaveDiscriptionOfAnimal.DateOfBirth = ObjToSave.DateOfBirth;
                SaveDiscriptionOfAnimal.GenderID = ObjToSave.GenderID;
                SaveDiscriptionOfAnimal.InsDateTime = ObjToSave.InsDateTime;
                SaveDiscriptionOfAnimal.InsUserID = ObjToSave.InsUserID;
                SaveDiscriptionOfAnimal.CompanyID = ObjToSave.CompanyID;

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
                _unitOfWork.DiscriptionOfAnimal.Add(SaveDiscriptionOfAnimal);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.DiscriptionOfAnimal.GetMaxSerial(UserInfo.fCompanyId).ToString();
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
    }
}