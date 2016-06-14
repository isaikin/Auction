using System;
using System.Collections.Generic;
using System.Linq;
using BllContracts;
using Common;

namespace AuctionBll
{
    public class AppUserBll : IAppUserBll
    {
        public void Add(string login, string password)
        {
            try
            {
                CommonBll.AppUserDao.Add(login, password);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AddProduct(int idUser, int idProduct)
        {
            try
            {
                CommonBll.AppUserDao.AddProduct(idUser, idProduct);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckLogin(string login)
        {
            try
            {
                return CommonBll.AppUserDao.CheckLogin(login);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CheckPassword(string login, string password)
        {
            try
            {
                return CommonBll.AppUserDao.CheckPassword(login, password);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<AppUser> GetAppUser()
        {
            try
            {
                return CommonBll.AppUserDao.GetAppUser();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int GetId(string login)
        {
            try
            {
                return CommonBll.AppUserDao.GetId(login);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetMyLotsAcrive(int id)
        {
            try
            {
                return CommonBll.AppUserDao.GetMyLots(id)?.Where(a => DateTime.Compare(a.Completion, DateTime.Now) == 1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetMyLotsFinish(int id)
        {
            try
            {
                return CommonBll.AppUserDao.GetMyLots(id)?.Where(a => DateTime.Compare(a.Completion, DateTime.Now) == -1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}