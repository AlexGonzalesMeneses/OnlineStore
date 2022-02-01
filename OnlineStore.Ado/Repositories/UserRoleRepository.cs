using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OnlineStore.Ado.Configurations;
using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Models;

namespace OnlineStore.Ado.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        public UserRole Add(UserRole entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.INSERT_USER_ROLE_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@User_Id", entity.RoleId);
                    cmd.Parameters.AddWithValue("@Role_Id", entity.RoleId);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public UserRole Delete(UserRole entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.DELETE_USER_ROLE_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public IEnumerable<UserRole> GetAll()
        {
            var userRoles = new List<UserRole>();

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_USER_ROLES_SQL, conn))
                {
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var userRole = new UserRole
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                UserId = reader.GetFieldValue<Guid>("User_Id"),
                                RoleId = reader.GetFieldValue<Guid>("Role_Id")
                            };

                            userRoles.Add(userRole);
                        }
                    }
                }
            }

            return userRoles;
        }

        public UserRole GetById(Guid id)
        {
            UserRole userRole = null;

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_USER_ROLE_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                        {
                            userRole = new UserRole
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                UserId = reader.GetFieldValue<Guid>("User_Id"),
                                RoleId = reader.GetFieldValue<Guid>("Role_Id")
                            };
                        }
                    }
                }
            }

            return userRole;
        }

        public UserRole Update(UserRole entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.UPDATE_USER_ROLE_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@User_Id", entity.UserId);
                    cmd.Parameters.AddWithValue("@Role_Id", entity.RoleId);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }
    }
}