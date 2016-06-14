using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

using Common;
using DaoContracts;
using DAOSQLSERVER;

namespace AuctionDaoSql
{
    public class ImageProduct : IimageProduct
    {
        private static string conSqlr = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public ImageFile GetById(int id)
        {
            var temp = new Dictionary<int, ImageFile>();

            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "GetByid_image_product";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", id);

                    con.Open();

                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        var content = (byte[])reader["image"];
                        var contentType = (string)reader["content_type"];
                        var image = new ImageFile
                        {
                            Content = content,
                            ContentType = contentType,
                        };

                        return image;
                    }

                    return null;
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public bool Add(int id, ImageFile image)
        {
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var addImages = "add_image_product";

                    var commandImage = new SqlCommand(addImages, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };

                    commandImage.Parameters.AddWithValue("@id", id);
                    commandImage.Parameters.AddWithValue("@image", image.Content);
                    commandImage.Parameters.AddWithValue("@content_type", image.ContentType);
                    con.Open();

                    return (int)commandImage.ExecuteNonQuery() == 1;
                }
                catch (Exception e)
                {
                    Log.For(this).Error(e);
                    throw e;
                }
            }
        }

        public bool UpdateImage(int id, ImageFile image)
        {
            using (var con = new SqlConnection(conSqlr))
            {
                try
                {
                    var query = "update_image";

                    var command = new SqlCommand(query, con)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@content", image.Content);

                    con.Open();

                    if (command.ExecuteNonQuery() == 0)
                    {
                        this.Add(id, image);
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
    }
}