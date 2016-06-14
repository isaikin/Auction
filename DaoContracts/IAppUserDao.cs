using System.Collections.Generic;
using Common;

namespace DaoContracts
{
    public interface IAppUserDao
    {
        void Add(string login, string password);

        bool CheckPassword(string login, string password);

        bool CheckLogin(string login);

        int GetId(string login);

        IEnumerable<Product> GetMyLots(int id);

        void AddProduct(int idUser, int idProduct);

        IEnumerable<AppUser> GetAppUser();
    }
}