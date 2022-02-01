using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OnlineStore.Ado.Configurations;
using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Models;

namespace OnlineStore.Ado.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public Item Add(Item entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.INSERT_ITEM_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Price", entity.UnitPrice);
                    cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
                    cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public Item Delete(Item entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.DELETE_ITEM_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public IEnumerable<Item> GetAll()
        {
            var items = new List<Item>();

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_ITEMS_SQL, conn))
                {
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            items.Add(new Item
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                UnitPrice = reader.GetFieldValue<decimal>("Price"),
                                Quantity = reader.GetFieldValue<int>("Quantity"),
                                ProductId = reader.GetFieldValue<Guid>("Product_Id")
                            });
                        }
                    }
                }
            }

            return items;
        }

        public Item GetById(Guid id)
        {
            Item item = null;

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_ITEM_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                        {
                            item = new Item
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                UnitPrice = reader.GetFieldValue<decimal>("Price"),
                                Quantity = reader.GetFieldValue<int>("Quantity"),
                                ProductId = reader.GetFieldValue<Guid>("Product_Id")
                            };
                        }
                    }
                }
            }

            return item;
        }

        public Item Update(Item entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.UPDATE_ITEM_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Price", entity.UnitPrice);
                    cmd.Parameters.AddWithValue("@Quantity", entity.Quantity);
                    cmd.Parameters.AddWithValue("@ProductId", entity.ProductId);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }
    }
}