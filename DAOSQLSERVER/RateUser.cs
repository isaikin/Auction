using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Common;
using DaoContracts;
using DAOSQLSERVER;

namespace AuctionDaoSql
{
    public class RateUser : IRateUser
    {
        private static string conSqlr = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void Add(int id_user, int id_product, double rate)
        {
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "add_rate";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id_user", id_user);
                    command.Parameters.AddWithValue("@id_product", id_product);
                    command.Parameters.AddWithValue("@rate", rate);

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

        public IEnumerable<Product> GetUserLots(int id)
        {
            var products = new List<Product>();
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "get_user_lots";

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
    }
}