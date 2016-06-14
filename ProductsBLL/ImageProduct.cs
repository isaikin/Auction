using System;
using BllContracts;
using Common;

namespace AuctionBll
{
    public class ImageProduct : IImageProduct
    {
        public bool Add(int id, ImageFile image)
        {
            try
            {
                return CommonBll.Imagedao.Add(id, image);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ImageFile GetById(int id)
        {
            try
            {
                return CommonBll.Imagedao.GetById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(int id, ImageFile image)
        {
            try
            {
                if (image.Content.Length != 0)
                {
                    return CommonBll.Imagedao.UpdateImage(id, image);
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