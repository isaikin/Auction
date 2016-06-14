using System.Collections.Generic;
using Common;

namespace BllContracts
{
    public interface IUserRateBll
    {
        void Add(int id_user, int id_product, double rate);

        IEnumerable<Product> GetUserLotsActive(int id);

        IEnumerable<Product> GetUserLotsFinish(int id);
    }
}