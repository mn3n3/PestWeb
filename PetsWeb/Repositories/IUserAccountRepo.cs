using PetsWeb.Models;
using System.Collections.Generic;

namespace PetsWeb.Repositories
{
    public interface IUserAccountRepo
    {
        ApplicationUser GetUserByIDAndCo(int CoId, string UId);

        ApplicationUser GetUserByEmpIdAndCo(int CoId, string UId);


        ApplicationUser GetUserByID(string UId);

        ApplicationUser GetUserEmailID(string UId);

        ApplicationUser GetUserEmailIDForEmailValidation(string UId, string Email);

        IEnumerable<ApplicationUser> GetAllUsers(int CoId);
        void AddModify(ApplicationUser ObjToSave);
        void AddModifyFromCreateCompnay(ApplicationUser ObjToSave);

        void DeActivate(ApplicationUser ObjToSave);

        

        bool CheckDomain(string Domain);

        void Delete(ApplicationUser ObjToSave);
        void ChangePass(ApplicationUser ObjToSave);
        ApplicationUser GetUserByEmailAndPassword(string Email, string Passord);
    }
}