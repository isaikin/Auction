using Common;

namespace DaoContracts
{
    public interface IimageProduct
    {
        bool Add(int id, ImageFile image);

        bool UpdateImage(int id, ImageFile image);

        ImageFile GetById(int id);
    }
}