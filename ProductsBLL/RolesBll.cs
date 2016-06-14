using System;
using System.Collections.Generic;
using System.Linq;
using BllContracts;
using Common;

namespace AuctionBll
{
    public class RolesBll : IRolesBll
    {
        public List<Role> GetRole()
        {
            try
            {
                return CommonBll.RolesDao.GetRole().ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}