using AuctionDaoSql;
using DaoContracts;

namespace AuctionBll
{
    internal static class CommonBll
    {
        private static IProductDao productDao = new ProductDao();

        private static IimageProduct imagedao = new AuctionDaoSql.ImageProduct();

        private static IDescriptionProduct descriptionProductBll = new DescriptionProduct();

        private static IAppUserDao appUserDao = new AuctionDaoSql.AppUserDao();

        private static IRateUser rateUserDao = new RateUser();

        private static IUserRole roleUserDao = new UserRole();

        private static IRoles rolesDao = new Roles();

        public static IProductDao ProductDao
        {
            get
            {
                return productDao;
            }
        }

        public static IimageProduct Imagedao
        {
            get
            {
                return imagedao;
            }
        }

        public static IDescriptionProduct DescriptionProductBll
        {
            get
            {
                return descriptionProductBll;
            }
        }

        public static IAppUserDao AppUserDao
        {
            get
            {
                return appUserDao;
            }
        }

        public static IRateUser RateUserDao
        {
            get
            {
                return rateUserDao;
            }
        }

        public static IUserRole RoleUserDao
        {
            get
            {
                return roleUserDao;
            }
        }

        public static IRoles RolesDao
        {
            get
            {
                return rolesDao;
            }
        }
    }
}