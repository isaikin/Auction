using System.Collections.Generic;
using Common;

namespace BllContracts
{
    public interface IProductsBLL
    {
        int Add(Product item);

        bool Delete(int id);

        IEnumerable<Product> GetProductsActive();

        IEnumerable<Product> GetProductsFinisf();

        void UpdateRate(int id, double rate);

        IEnumerable<Product> SeachActive(string name);

        IEnumerable<Product> SeachFinish(string name);
    }
}