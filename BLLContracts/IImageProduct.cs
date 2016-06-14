using Common;

namespace BllContracts
{
    public interface IImageProduct
    {
        bool Add(int id, ImageFile image);

        ImageFile GetById(int id);

        bool Update(int id, ImageFile image);
    }
}