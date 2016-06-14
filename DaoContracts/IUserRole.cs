using System.Collections.Generic;
using Common;

namespace DaoContracts
{
    public interface IUserRole
    {
        void AddUserRole(int idUser, int idRole);

        void DeleteUserRole(int idUser, int idRole);

        IEnumerable<string> GetUserRole(int id);

        IEnumerable<Role> GetUserRoleFull(int id);
    }
}