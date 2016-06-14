using System;
using System.Configuration;
using System.Data.SqlClient;
using DaoContracts;
using DAOSQLSERVER;

namespace AuctionDaoSql
{
    public class DescriptionProduct : IDescriptionProduct
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void Add(int id, string description)
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    var query = "add_description";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@text", description);
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

        public string Get(int id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    var query = "get_description";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", id);

                    con.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        return (string)reader["text"];
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public void Update(int id, string description)
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    var query = "update_product_description";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@description", description);
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
    }
}