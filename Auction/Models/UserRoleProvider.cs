using System;
using System.Web.Security;

namespace Auction.Models
{
    public class UserRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            var roleUser = CommonPl.UserRoleBll.GetUserRole(CommonPl.AppUserLogic.GetId(username));

            if (roleUser.Contains(roleName))
            {
                return true;
            }

            return false;
        }

        public override string[] GetRolesForUser(string username)
        {
            return CommonPl.UserRoleBll.GetUserRole(CommonPl.AppUserLogic.GetId(username)).ToArray();
        }

        #region Not implemented
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion Not implemented
    }
}