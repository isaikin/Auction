using System;
using System.Collections.Generic;
using System.Linq;
using BllContracts;
using Common;

namespace AuctionBll
{
    public class Products : IProductsBLL
    {
        public int Add(Product item)
        {
            try
            {
                return CommonBll.ProductDao.Add(item);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return CommonBll.ProductDao.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetProductsActive()
        {
            try
            {
                return CommonBll.ProductDao.GetProducts().ToList()?.Where(a => DateTime.Compare(a.Completion, DateTime.Now) == 1).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> GetProductsFinisf()
        {
            try
            {
                return CommonBll.ProductDao.GetProducts()?.Where(a => DateTime.Compare(a.Completion, DateTime.Now) == -1).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> SeachActive(string name)
        {
            try
            {
                return CommonBll.ProductDao.GetProducts().Where(a => this.Seach(name, a.Name) && DateTime.Compare(a.Completion, DateTime.Now) == 1).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Product> SeachFinish(string name)
        {
            try
            {
                return CommonBll.ProductDao.GetProducts()?.Where(a => this.Seach(name, a.Name) && DateTime.Compare(a.Completion, DateTime.Now) == -1).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void UpdateRate(int id, double rate)
        {
            try
            {
                CommonBll.ProductDao.UpdateRate(id, rate);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool Seach(string a, string b)
        {
            try
            {
                var temp = b?.Split(' ').ToArray();

                foreach (var item in temp)
                {
                    if (string.Compare(a, 0, item, 0, Math.Min(a.Length, b.Length), StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}