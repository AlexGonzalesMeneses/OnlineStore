using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OnlineStore.Ado.Configurations;
using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Models;

namespace OnlineStore.Ado.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User Add(User entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.INSERT_USER_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@User_Name", entity.Username);
                    cmd.Parameters.AddWithValue("@Password", entity.Password);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public User Delete(User entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.DELETE_USER_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_USERS_SQL, conn))
                {
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                Id = reader.GetGuid(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Email = reader.GetString(3)
                            };

                            users.Add(user);
                        }
                    }
                }
            }

            return users;
        }

        public User GetById(Guid id)
        {
            User user = null;

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_USER_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            user = new User
                            {
                                Id = reader.GetGuid(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                Email = reader.GetString(3)
                            };
                        }
                    }
                }
            }

            return user;
        }

        public User Update(User entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.UPDATE_USER_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@User_Name", entity.Username);
                    cmd.Parameters.AddWithValue("@Password", entity.Password);
                    cmd.Parameters.AddWithValue("@Email", entity.Email);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }
    }
}