using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Common;
using DaoContracts;
using DAOSQLSERVER;

namespace AuctionDaoSql
{
    public class UserRole : IUserRole
    {
        private static string conSqlr = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void AddUserRole(int idUser, int idRole)
        {
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "add_user_role";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@id_user", idUser);
                    command.Parameters.AddWithValue("@id_role", idRole);

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

        public void DeleteUserRole(int idUser, int idRole)
        {
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "user_delete_role";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id_user", idUser);
                    command.Parameters.AddWithValue("@id_role", idRole);

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

        public IEnumerable<string> GetUserRole(int id)
        {
            var temp = new List<string>();

            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "get_user_role";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@id_user", id);
                    con.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        temp.Add((string)reader["name"]);
                    }

                    return temp;
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public IEnumerable<Role> GetUserRoleFull(int id)
        {
            var temp = new List<Role>();

            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "get_user_roleFull";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    command.Parameters.AddWithValue("@id_user", id);
                    con.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var tempRole = new Role();
                        tempRole.Name = (string)reader["name"];
                        tempRole.Id = (int)reader["id"];
                        temp.Add(tempRole);
                    }

                    return temp;
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }
    }
}