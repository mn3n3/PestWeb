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
            var AllLocationOfMicrochip = _unitOfWork.NativeSql.GetAllLocationOfMicrochipInfo(UserInfo.fCompanyId);
            var DiscriptionOfAnimalFilter = new DiscriptionOfAnimalSearchFilterVM
            {
                Breed = AllBreed,
                CoatColour = AllCoatColour,
                AnimalType = AllAnimalType,
                LocationOfMicrochip = AllLocationOfMicrochip
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
                if (Obj.GenderID != 0)
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.GenderID == Obj.GenderID).ToList();
                }
                if (Obj.LocationOfMicrochipID != 0)
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.LocationOfMicrochipID == Obj.LocationOfMicrochipID).ToList();
                }
                if (!String.IsNullOrEmpty(Obj.OwnerName))
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.OwnerName.ToLower().Contains(Obj.OwnerName.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(Obj.AnimalName))
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.AnimalName.ToLower().Contains(Obj.AnimalName.ToLower())).ToList();
                }
                if (!String.IsNullOrEmpty(Obj.Telephone))
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.Telephone.Contains(Obj.Telephone)).ToList();
                }
                if (!String.IsNullOrEmpty(Obj.MicrochipNumber))
                {
                    AllDiscriptionOfAnimal = AllDiscriptionOfAnimal.Where(m => m.MicrochipNumber.Contains(Obj.MicrochipNumber)).ToList();
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
            var AllLocationOfMicrochip = _unitOfWork.NativeSql.GetAllLocationOfMicrochipInfo(UserInfo.fCompanyId);
            DiscriptionOfAnimalSearchFilterVM Obj = new DiscriptionOfAnimalSearchFilterVM
            {
                AnimalID = _unitOfWork.DiscriptionOfAnimal.GetMaxSerial(UserInfo.fCompanyId),
                Breed = AllBreed,
                BreedID = 1,
                AnimalType = AllAnimalType,
                AnimalTypeID = 1,
                CoatColour = AllCoatColour,
                CoatColourID = 1,
                DateOfBirth = DateTime.Now,
                LocationOfMicrochip = AllLocationOfMicrochip,
                LocationOfMicrochipID = 1,
                DateOfMicrochipping = DateTime.Now
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
                SaveDiscriptionOfAnimal.LocationOfMicrochipID = ObjToSave.LocationOfMicrochipID;
                SaveDiscriptionOfAnimal.MicrochipNumber = ObjToSave.MicrochipNumber;
                SaveDiscriptionOfAnimal.DateOfMicrochipping = ObjToSave.DateOfMicrochipping;
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
        public ActionResult UpdateDiscriptionOfAnimal(int id)
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
                    var AllBreed = _unitOfWork.NativeSql.GetAllBreedInfo(UserInfo.fCompanyId);
                    var AllCoatColour = _unitOfWork.NativeSql.GetAllCoatColourInfo(UserInfo.fCompanyId);
                    var AllAnimalType = _unitOfWork.NativeSql.GetAllAnimalTypeInfo(UserInfo.fCompanyId);
                    var AllLocationOfMicrochip = _unitOfWork.NativeSql.GetAllLocationOfMicrochipInfo(UserInfo.fCompanyId);
                    var DiscriptionOfAnimal = _unitOfWork.DiscriptionOfAnimal.GetDiscriptionOfAnimalByID(UserInfo.fCompanyId, id);
                    var OwnerName = _unitOfWork.NativeSql.GetOwnerName(UserInfo.fCompanyId, DiscriptionOfAnimal.OwnerID);
                    DiscriptionOfAnimalSearchFilterVM Obj = new DiscriptionOfAnimalSearchFilterVM
                    {
                        AnimalID = DiscriptionOfAnimal.AnimalID,
                        AnimalName = DiscriptionOfAnimal.AnimalName,
                        OwnerID = DiscriptionOfAnimal.OwnerID,
                        OwnerName = OwnerName.OwnerName,
                        DateOfBirth = DiscriptionOfAnimal.DateOfBirth,
                        Breed = AllBreed,
                        BreedID = DiscriptionOfAnimal.BreedID,
                        CoatColour = AllCoatColour,
                        CoatColourID = DiscriptionOfAnimal.CoatColourID,
                        AnimalType = AllAnimalType,
                        AnimalTypeID = DiscriptionOfAnimal.AnimalTypeID,
                        LocationOfMicrochip = AllLocationOfMicrochip,
                        LocationOfMicrochipID = DiscriptionOfAnimal.LocationOfMicrochipID,
                        MicrochipNumber = DiscriptionOfAnimal.MicrochipNumber,
                        DateOfMicrochipping = DiscriptionOfAnimal.DateOfMicrochipping
                    };
                    return View("UpdateDiscriptionOfAnimal", Obj);
                }
                return View("UpdateDiscriptionOfAnimal", new DiscriptionOfAnimalSearchFilterVM());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult UpdateDiscriptionOfAnimal(DiscriptionOfAnimalSearchFilterVM ObjUpdate)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var UpdateDiscriptionOfAnimal = new DiscriptionOfAnimal();
                ObjUpdate.InsDateTime = DateTime.Now;
                ObjUpdate.InsUserID = userId;
                ObjUpdate.CompanyID = UserInfo.fCompanyId;

                UpdateDiscriptionOfAnimal.AnimalID = ObjUpdate.AnimalID;
                UpdateDiscriptionOfAnimal.BreedID = ObjUpdate.BreedID;
                UpdateDiscriptionOfAnimal.AnimalTypeID = ObjUpdate.AnimalTypeID;
                UpdateDiscriptionOfAnimal.CoatColourID = ObjUpdate.CoatColourID;
                UpdateDiscriptionOfAnimal.OwnerID = ObjUpdate.OwnerID;
                UpdateDiscriptionOfAnimal.AnimalName = ObjUpdate.AnimalName;
                UpdateDiscriptionOfAnimal.DateOfBirth = ObjUpdate.DateOfBirth;
                UpdateDiscriptionOfAnimal.GenderID = ObjUpdate.GenderID;
                UpdateDiscriptionOfAnimal.LocationOfMicrochipID = ObjUpdate.LocationOfMicrochipID;
                UpdateDiscriptionOfAnimal.MicrochipNumber = ObjUpdate.MicrochipNumber;
                UpdateDiscriptionOfAnimal.DateOfMicrochipping = ObjUpdate.DateOfMicrochipping;
                UpdateDiscriptionOfAnimal.InsDateTime = ObjUpdate.InsDateTime;
                UpdateDiscriptionOfAnimal.InsUserID = ObjUpdate.InsUserID;
                UpdateDiscriptionOfAnimal.CompanyID = ObjUpdate.CompanyID;
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
                _unitOfWork.DiscriptionOfAnimal.Update(UpdateDiscriptionOfAnimal);
                _unitOfWork.Complete();
                Msg.LastID = _unitOfWork.DiscriptionOfAnimal.GetMaxSerial(UserInfo.fCompanyId).ToString();
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
        public ActionResult DeleteDiscriptionOfAnimal(int id)
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
                    var AllBreed = _unitOfWork.NativeSql.GetAllBreedInfo(UserInfo.fCompanyId);
                    var AllCoatColour = _unitOfWork.NativeSql.GetAllCoatColourInfo(UserInfo.fCompanyId);
                    var AllAnimalType = _unitOfWork.NativeSql.GetAllAnimalTypeInfo(UserInfo.fCompanyId);
                    var AllLocationOfMicrochip = _unitOfWork.NativeSql.GetAllLocationOfMicrochipInfo(UserInfo.fCompanyId);
                    var DiscriptionOfAnimal = _unitOfWork.DiscriptionOfAnimal.GetDiscriptionOfAnimalByID(UserInfo.fCompanyId, id);
                    var OwnerName = _unitOfWork.NativeSql.GetOwnerName(UserInfo.fCompanyId, DiscriptionOfAnimal.OwnerID);
                    var BreedName = _unitOfWork.Breed.GetBreedByID(UserInfo.fCompanyId, DiscriptionOfAnimal.BreedID);
                    var CoatColourName = _unitOfWork.CoatColour.GetCoatColourByID(UserInfo.fCompanyId, DiscriptionOfAnimal.CoatColourID);
                    var AnimalTypeName = _unitOfWork.AnimalType.GetAnimalTypeByID(UserInfo.fCompanyId, DiscriptionOfAnimal.AnimalTypeID);
                    var LocationOfMicrochipName = _unitOfWork.LocationOfMicrochip.GetLocationOfMicrochipByID(UserInfo.fCompanyId, DiscriptionOfAnimal.LocationOfMicrochipID);
                    DiscriptionOfAnimalSearchFilterVM Obj = new DiscriptionOfAnimalSearchFilterVM { };
                    Obj.AnimalID = DiscriptionOfAnimal.AnimalID;
                    Obj.AnimalName = DiscriptionOfAnimal.AnimalName;
                    Obj.OwnerID = DiscriptionOfAnimal.OwnerID;
                    Obj.OwnerName = OwnerName.OwnerName;
                    Obj.DateOfBirth = DiscriptionOfAnimal.DateOfBirth;
                    Obj.BreedID = DiscriptionOfAnimal.BreedID;
                    Obj.CoatColourID = DiscriptionOfAnimal.CoatColourID;
                    Obj.AnimalTypeID = DiscriptionOfAnimal.AnimalTypeID;
                    Obj.GenderID = DiscriptionOfAnimal.GenderID;
                    Obj.LocationOfMicrochipID = DiscriptionOfAnimal.LocationOfMicrochipID;
                    Obj.MicrochipNumber = DiscriptionOfAnimal.MicrochipNumber;
                    Obj.DateOfMicrochipping = DiscriptionOfAnimal.DateOfMicrochipping;
                    if (Resources.Resource.CurLang == "Arb")
                    {
                        Obj.BreedName = BreedName.ArabicName;
                        Obj.CoatColourName = CoatColourName.ArabicName;
                        Obj.AnimalTypeName = AnimalTypeName.ArabicName;
                        Obj.LocationOfMicrochipName = LocationOfMicrochipName.ArabicName;
                        if (Obj.GenderID == 1)
                        {
                            Obj.GenderName = "ذكر";
                        }
                        else 
                        {
                            Obj.GenderName = "انثى";
                        }
                    }
                    else
                    {
                        Obj.BreedName = BreedName.EnglishName;
                        Obj.CoatColourName = CoatColourName.EnglishName;
                        Obj.AnimalTypeName = AnimalTypeName.EnglishName;
                        Obj.LocationOfMicrochipName = LocationOfMicrochipName.EnglishName;
                        if (Obj.GenderID == 1)
                        {
                            Obj.GenderName = "Male";
                        }
                        else
                        {
                            Obj.GenderName = "Female";
                        }
                    }
                    return View("DeleteDiscriptionOfAnimal", Obj);
                }
                return View("DeleteDiscriptionOfAnimal", new DiscriptionOfAnimalSearchFilterVM());
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message.ToString();
                return View("Error");
            }
        }
        [HttpPost]
        public JsonResult DeleteDiscriptionOfAnimal(DiscriptionOfAnimalSearchFilterVM ObjDelete)
        {
            MsgUnit Msg = new MsgUnit();
            try
            {
                var userId = User.Identity.GetUserId();
                var UserInfo = _unitOfWork.UserAccount.GetUserByID(userId);
                var DeleteDiscriptionOfAnimal = new DiscriptionOfAnimal();
                ObjDelete.CompanyID = UserInfo.fCompanyId;
                DeleteDiscriptionOfAnimal.CompanyID = ObjDelete.CompanyID;
                DeleteDiscriptionOfAnimal.AnimalID = ObjDelete.AnimalID;
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
                _unitOfWork.DiscriptionOfAnimal.Delete(DeleteDiscriptionOfAnimal);
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