using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OnlineStore.Ado.Configurations;
using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Models;

namespace OnlineStore.Ado.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public Category Add(Category entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.INSERT_CATEGORY_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", entity.Name);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public Category Delete(Category entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.DELETE_CATEGORY_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = new List<Category>();

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_CATEGORIES_SQL, conn))
                {
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            categories.Add(new Category
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                Name = reader.GetFieldValue<string>("Name")
                            });
                        }
                    }
                }
            }

            return categories;
        }

        public Category GetById(Guid id)
        {
            Category category = null;

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_CATEGORY_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                        {
                            category.Id = reader.GetFieldValue<Guid>("Id");
                            category.Name = reader.GetFieldValue<string>("Name");
                        }
                    }
                }
            }

            return category;
        }

        public Category Update(Category entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.UPDATE_CATEGORY_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@Name", entity.Name);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }
    }
}