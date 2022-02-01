using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OnlineStore.Ado.Configurations;
using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Models;

namespace OnlineStore.Ado.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public Order Add(Order entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.INSERT_ORDER_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Item_Id", entity.ItemId);
                    cmd.Parameters.AddWithValue("@Total_Price", entity.Total);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public Order Delete(Order entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.DELETE_ORDER_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public IEnumerable<Order> GetAll()
        {
            var orders = new List<Order>();

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_ORDERS_SQL, conn))
                {
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                ItemId = reader.GetFieldValue<Guid>("Item_Id"),
                                Total = reader.GetFieldValue<decimal>("Total_Price")
                            });
                        }
                    }
                }
            }

            return orders;
        }

        public Order GetById(Guid id)
        {
            Order order = null;

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_ORDER_BY_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            order = new Order
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                ItemId = reader.GetFieldValue<Guid>("Item_Id"),
                                Total = reader.GetFieldValue<decimal>("Total_Price")
                            };
                        }
                    }
                }
            }

            return order;
        }

        public Order Update(Order entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.UPDATE_ORDER_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Item_Id", entity.ItemId);
                    cmd.Parameters.AddWithValue("@Total_Price", entity.Total);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }
    }
}