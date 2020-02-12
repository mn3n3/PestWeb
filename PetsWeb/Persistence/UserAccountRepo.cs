using PetsWeb.Models;
using PetsWeb.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetsWeb.Persistence
{
    public class UserAccountRepo : IUserAccountRepo
    {
        private readonly ApplicationDbContext _context;

        public UserAccountRepo(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public void AddModify(ApplicationUser ObjToSave)
        {//&& m.FCoID == ObjToSave.FCoID
            var User = _context.Users.FirstOrDefault(m => m.Id == ObjToSave.Id && (m.fCompanyId == ObjToSave.fCompanyId || m.fCompanyId == 0));
            if (User != null)
            {


                User.AccountStatus = ObjToSave.AccountStatus;
                User.fCompanyId = ObjToSave.fCompanyId;
                User.PasswordHash = ObjToSave.PasswordHash;



            }
            else
            {
                _context.Users.Add(ObjToSave);
                //  UserManager.AddToRole(user.Id, "CoUser");
            }
        }


        public void DeActivate(ApplicationUser ObjToSave)
        {
            if (_context.Users.SingleOrDefault(m => m.fCompanyId == ObjToSave.fCompanyId && m.Id == ObjToSave.Id) != null)
            {
                var User = _context.Users.FirstOrDefault(m => m.Id == ObjToSave.Id);
                if (User != null)
                {
                    User.AccountStatus = ObjToSave.AccountStatus;
                }
            }

        }

        public void Delete(ApplicationUser ObjToSave)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ApplicationUser> GetAllUsers(int CoId)
        {
            return _context.Users.Where(m => m.fCompanyId == CoId && m.UserType == 0).ToList();
        }

        public ApplicationUser GetUserByIDAndCo(int CoId, string UId)
        {
            return _context.Users.SingleOrDefault(m => m.fCompanyId == CoId && m.Id == UId);
        }
        public ApplicationUser GetUserByID(string UId)
        {
            return _context.Users.SingleOrDefault(m => m.Id == UId);
        }

        public ApplicationUser GetUserEmailID(string UId)
        {
            return _context.Users.SingleOrDefault(m => m.Email == UId);
        }

        public ApplicationUser GetUserByEmpIdAndCo(int CoId, string UId)
        {
            return _context.Users.SingleOrDefault(m => m.fCompanyId == CoId && m.EmployeeID == UId);
        }

        public ApplicationUser GetUserEmailIDForEmailValidation(string UId, string Email)
        {
            return _context.Users.SingleOrDefault(m => m.Email == Email && m.Id != UId);
        }

        public void AddModifyFromCreateCompnay(ApplicationUser ObjToSave)
        {
            var User = _context.Users.FirstOrDefault(m => m.Id == ObjToSave.Id);
            if (User != null)
            {


                User.AccountStatus = ObjToSave.AccountStatus;
                User.fCompanyId = ObjToSave.fCompanyId;
                User.PasswordHash = ObjToSave.PasswordHash;



            }
            else
            {
                _context.Users.Add(ObjToSave);
                //  UserManager.AddToRole(user.Id, "CoUser");
            }
        }

        public ApplicationUser GetUserByEmailAndPassword(string Email, string Passord)
        {
            return _context.Users.SingleOrDefault(m => m.Email == Email && m.PasswordHash == Passord);
        }
        public void ChangePass(ApplicationUser ObjToSave)
        {//&& m.FCoID == ObjToSave.FCoID
            var User = _context.Users.FirstOrDefault(m => m.Id == ObjToSave.Id);
            if (User != null)
            {


                User.PasswordHash = ObjToSave.PasswordHash;
                User.RealPass = ObjToSave.RealPass;


            }

        }

        public bool CheckDomain(string Domain)
        {
            var user = _context.Users.FirstOrDefault(m => m.CODOMAIN == Domain);
            if (user != null)
                return true;
            else

                return false;

        }

     
    }
}