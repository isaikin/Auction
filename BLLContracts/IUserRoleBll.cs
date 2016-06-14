using System.Collections.Generic;
using Common;

namespace BllContracts
{
    public interface IUserRoleBll
    {
        void AddUserRole(int idUser, int idRole);

        void DeleteUserRole(int idUser, int idRole);

        List<string> GetUserRole(int id);

        List<Role> GetUserRoleFull(int id);
    }
}