using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OnlineStore.Ado.Configurations;
using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Models;

namespace OnlineStore.Ado.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public Product GetById(Guid id)
        {
            Product product = new Product();

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_PRODUCT_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product.Id = reader.GetFieldValue<Guid>("Id");
                            product.Name = reader.GetFieldValue<string>("Name");
                            product.Stock = reader.GetFieldValue<int>("Stock");
                            product.CategoryId = reader.GetFieldValue<Guid>("Category_Id");
                        }
                    }
                }
            }

            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = new List<Product>();

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_PRODUCTS_SQL, conn))
                {
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                Name = reader.GetFieldValue<string>("Name"),
                                Stock = reader.GetFieldValue<int>("Stock"),
                                CategoryId = reader.GetFieldValue<Guid>("Category_Id")
                            });
                        }
                    }
                }
            }

            return products;
        }

        public Product Add(Product entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.INSERT_PRODUCT_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Stock", entity.Stock);
                    cmd.Parameters.AddWithValue("@Category_Id", entity.CategoryId);

                    cmd.ExecuteNonQuery();
                }
            }

            return entity;
        }

        public Product Update(Product entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.UPDATE_PRODUCT_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);
                    cmd.Parameters.AddWithValue("@Stock", entity.Stock);
                    cmd.Parameters.AddWithValue("@Category_Id", entity.CategoryId);

                    cmd.ExecuteNonQuery();
                }
            }

            return entity;
        }

        public Product Delete(Product entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.DELETE_PRODUCT_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.ExecuteNonQuery();
                }
            }

            return entity;
        }
    }
}