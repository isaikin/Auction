using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Common;
using DaoContracts;
using DAOSQLSERVER;

namespace AuctionDaoSql
{
    public class Roles : IRoles
    {
        private static string conSqlr = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public IEnumerable<Role> GetRole()
        {
            var temp = new List<Role>();

            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "get_roles";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    con.Open();

                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var temprole = new Role();
                        temprole.Name = (string)reader["name"];
                        temprole.Id = (int)reader["id"];
                        temp.Add(temprole);
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