using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using Common;
using DaoContracts;
using DAOSQLSERVER;

namespace AuctionDaoSql
{
    public class AppUserDao : IAppUserDao
    {
        private static string conSqlr = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void Add(string login, string password)
        {
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "app_user_add";

                    SHA256 mySHA256 = SHA256Managed.Create();
                    var temnpaswotrs = password.ToCharArray().Select(n => (byte)n).ToArray();

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", temnpaswotrs);

                    con.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public bool CheckLogin(string login)
        {
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "get_login";

                    var templogins = new List<string>();

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    con.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        if ((string)reader["login"] == login)
                        {
                            return false;
                        }
                    }

                    return true;
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public int GetId(string login)
        {
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "get_id";

                    var templogins = new List<string>();

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@login", login);

                    con.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return (int)reader["id"];
                    }
                    else
                    {
                        return -1;
                    }
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public bool CheckPassword(string login, string password)
        {
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "app_user_get";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@login", login);

                    con.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        var passwordthis = (byte[])reader["password"];
                        SHA256 mySHA256 = SHA256Managed.Create();
                        var temnpaswotrs = password.ToCharArray().Select(n => (byte)n).ToArray();
                        return AppUserDao.Compare(passwordthis, temnpaswotrs);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public void AddProduct(int idUser, int idProduct)
        {
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "add_user_product";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id_user", idUser);
                    command.Parameters.AddWithValue("@id_product", idProduct);

                    con.Open();

                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public IEnumerable<Product> GetMyLots(int id)
        {
            var products = new List<Product>();

            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "get_my_product";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id_user", id);
                    con.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var tempproduct = new Product();
                        tempproduct.Id = (int)reader["id"];
                        tempproduct.Name = (string)reader["name"];
                        tempproduct.CurrentRate = (double)(decimal)reader["current_rate"];
                        tempproduct.Completion = (DateTime)reader["completion"];
                        products.Add(tempproduct);
                    }

                    return products;
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public IEnumerable<AppUser> GetAppUser()
        {
            var appUsers = new List<AppUser>();

            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "get_app_user";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    con.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var tempAppUser = new AppUser();
                        tempAppUser.Id = (int)reader["id"];
                        tempAppUser.Login = (string)reader["login"];
                        appUsers.Add(tempAppUser);
                    }

                    return appUsers;
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        private static bool Compare(byte[] a, byte[] b)
        {
            if (a != null && b != null && a.Length != b.Length)
            {
                return false;
            }

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}