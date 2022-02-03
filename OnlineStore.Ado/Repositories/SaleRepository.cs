using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OnlineStore.Ado.Configurations;
using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Models;

namespace OnlineStore.Ado.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        public Sale Add(Sale entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.INSERT_SALE_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Order_Id", entity.OrderId);
                    cmd.Parameters.AddWithValue("@Customer_Id", entity.CustomerId);
                    cmd.Parameters.AddWithValue("@Date", entity.Date);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public Sale Delete(Sale entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.DELETE_SALE_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public IEnumerable<Sale> GetAll()
        {
            var sales = new List<Sale>();

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_SALES_SQL, conn))
                {
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            sales.Add(new Sale
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                OrderId = reader.GetFieldValue<Guid>("Order_Id"),
                                CustomerId = reader.GetFieldValue<Guid>("Customer_Id"),
                                Date = reader.GetFieldValue<DateTime>("Date")
                            });
                        }
                    }
                }
            }

            return sales;
        }

        public Sale GetById(Guid id)
        {
            Sale sale = null;

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_SALE_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            sale = new Sale
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                OrderId = reader.GetFieldValue<Guid>("Order_Id"),
                                CustomerId = reader.GetFieldValue<Guid>("Customer_Id"),
                                Date = reader.GetFieldValue<DateTime>("Date")
                            };
                        }
                    }
                }
            }

            return sale;
        }

        public Sale Update(Sale entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.UPDATE_SALE_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Order_Id", entity.OrderId);
                    cmd.Parameters.AddWithValue("@Customer_Id", entity.CustomerId);
                    cmd.Parameters.AddWithValue("@Date", entity.Date);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }
    }
}