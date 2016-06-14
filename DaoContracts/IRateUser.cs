using System.Collections.Generic;
using Common;

namespace DaoContracts
{
    public interface IRateUser
    {
        void Add(int id_user, int id_product, double rate);

        IEnumerable<Product> GetUserLots(int id);
    }
}