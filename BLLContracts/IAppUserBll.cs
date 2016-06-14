using System.Collections.Generic;
using Common;

namespace BllContracts
{
    public interface IAppUserBll
    {
        void Add(string login, string password);

        bool CheckPassword(string login, string password);

        bool CheckLogin(string login);

        int GetId(string login);

        void AddProduct(int idUser, int idProduct);

        IEnumerable<Product> GetMyLotsAcrive(int id);

        IEnumerable<Product> GetMyLotsFinish(int id);

        IEnumerable<AppUser> GetAppUser();
    }
}