using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Common;
using DaoContracts;
using DAOSQLSERVER;

namespace AuctionDaoSql
{
    public class ProductDao : IProductDao
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public int Add(Product item)
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    var query = "add_product";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@name", item.Name);
                    command.Parameters.AddWithValue("@current_rate", item.CurrentRate);
                    command.Parameters.AddWithValue("@completion", item.Completion);
                    con.Open();

                    return (int)(decimal)command.ExecuteScalar();
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    var query = "delete_product";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", id);
                    con.Open();

                    return command.ExecuteNonQuery() == 1;
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            try
            {
                var products = new List<Product>();
                using (var con = new SqlConnection(connectionString))
                {
                    var query = "get_products";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
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
                }

                return products;
            }
            catch (Exception e)
            {
                Log.For(this).Error(e);
                throw e;
            }
        }

        public void UpdateRate(int id, double rate)
        {
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    var query = "update_product_rate";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", id);
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
    }
}