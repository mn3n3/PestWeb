using Pets_Web.Models;
using System.Collections.Generic;

namespace Pets_Web.Repositories
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
        //  void ChangePassowrd(ApplicationUser ObjToSave);
        //int GetMaxSerial(int CoId);
        void DeActivate(ApplicationUser ObjToSave);



        void Delete(ApplicationUser ObjToSave);

        ApplicationUser GetUserByEmailAndPassword(string Email, string Passord);
    }
}