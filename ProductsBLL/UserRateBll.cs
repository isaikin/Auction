using System;
using System.Collections.Generic;
using System.Linq;
using BllContracts;
using Common;

namespace AuctionBll
{
    public class UserRateBll : IUserRateBll
    {
        public void Add(int id_user, int id_product, double rate)
        {
            try
            {
                CommonBll.RateUserDao.Add(id_user, id_product, rate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetUserLotsActive(int id)
        {
            try
            {
                return CommonBll.RateUserDao.GetUserLots(id)?.Where(a => DateTime.Compare(a.Completion, DateTime.Now) == 1).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetUserLotsFinish(int id)
        {
            try
            {
                return CommonBll.RateUserDao.GetUserLots(id)?.Where(a => DateTime.Compare(a.Completion, DateTime.Now) == -1).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}