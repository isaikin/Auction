using System;
using System.Collections.Generic;
using System.Linq;
using BllContracts;
using Common;

namespace AuctionBll
{
    public class UserRoleBll : IUserRoleBll
    {
        public void AddUserRole(int idUser, int name)
        {
            try
            {
                CommonBll.RoleUserDao.AddUserRole(idUser, name);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeleteUserRole(int idUser, int idRole)
        {
            try
            {
                CommonBll.RoleUserDao.DeleteUserRole(idUser, idRole);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<string> GetUserRole(int id)
        {
            try
            {
                return CommonBll.RoleUserDao.GetUserRole(id).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Role> GetUserRoleFull(int id)
        {
            try
            {
                return CommonBll.RoleUserDao.GetUserRoleFull(id).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}