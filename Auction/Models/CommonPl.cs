using AuctionBll;
using BllContracts;

namespace Auction
{
    public static class CommonPl
    {
        private static IProductsBLL productBll = new Products();

        private static IImageProduct imagePrLogic = new ImageProduct();

        private static IDescriptionProductBll descriptionProductLogic = new DescriptionProductBll();

        private static IAppUserBll appUserLogic = new AppUserBll();

        private static IUserRateBll rateBll = new UserRateBll();

        private static IUserRoleBll userRoleBll = new UserRoleBll();

        private static IRolesBll roleBll = new RolesBll();

        public static IProductsBLL ProductBll
        {
            get
            {
                return productBll;
            }
        }

        public static IImageProduct ImagePrLogic
        {
            get
            {
                return imagePrLogic;
            }
        }

        public static IDescriptionProductBll DescriptionProductLogic
        {
            get
            {
                return descriptionProductLogic;
            }
        }

        public static IAppUserBll AppUserLogic
        {
            get
            {
                return appUserLogic;
            }
        }

        public static IUserRateBll RateBll
        {
            get
            {
                return rateBll;
            }
        }

        public static IUserRoleBll UserRoleBll
        {
            get
            {
                return userRoleBll;
            }
        }

        public static IRolesBll RoleBll
        {
            get
            {
                return roleBll;
            }
        }
    }
}