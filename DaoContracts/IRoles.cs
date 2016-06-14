using System.Collections.Generic;
using Common;

namespace DaoContracts
{
    public interface IRoles
    {
        IEnumerable<Role> GetRole();
    }
}