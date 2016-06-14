using System;
using System.Linq;
using BllContracts;

namespace AuctionBll
{
    public class DescriptionProductBll : IDescriptionProductBll
    {
        public void Add(int id, string description)
        {
            try
            {
                CommonBll.DescriptionProductBll.Add(id, description);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string Get(int id)
        {
            try
            {
                var text = CommonBll.DescriptionProductBll.Get(id);
                return text == null || text?.Length == 0 ? "not description" : text;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(int idUser, int idProduct, string description)
        {
            try
            {
                if (CommonBll.AppUserDao.GetMyLots(idUser).First(n => n.Id == idProduct) != null)
                {
                    CommonBll.DescriptionProductBll.Update(idProduct, description);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}