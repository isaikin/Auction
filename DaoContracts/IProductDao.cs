using System.Collections.Generic;
using Common;

namespace DaoContracts
{
    public interface IProductDao
    {
        int Add(Product item);

        bool Delete(int id);

        IEnumerable<Product> GetProducts();

        void UpdateRate(int id, double rate);
    }
}