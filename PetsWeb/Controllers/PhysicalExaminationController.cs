using PetsWeb.Models;
using PetsWeb.Persistence;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetsWeb.Controllers
{
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
            PhysicalExamination Obj = new PhysicalExamination
            {
                DateOfBirth=DateTime.Now

            };

            return View(Obj);
        }
    }
}