using Microsoft.AspNet.Identity;
using PetsWeb.Controllers;
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
    [Authorize]
    public class CountryController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public CountryController()
        {
           
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        // GET: Country
        public ActionResult Index()
        {
            return View();
        }
    }
}