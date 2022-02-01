using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OnlineStore.Ado.Configurations;
using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Models;

namespace OnlineStore.Ado.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer Add(Customer entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.INSERT_CUSTOMER_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@First_Name", entity.FirstName);
                    cmd.Parameters.AddWithValue("@Last_Name", entity.LastName);
                    cmd.Parameters.AddWithValue("@Address", entity.Address);
                    cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                    cmd.Parameters.AddWithValue("@Nit", entity.Nit);
                    cmd.Parameters.AddWithValue("@User_Id", entity.UserId);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public Customer Delete(Customer entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.DELETE_CUSTOMER_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = new List<Customer>();

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_CUSTOMERS_SQL, conn))
                {
                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            customers.Add(new Customer
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                FirstName = reader.GetFieldValue<string>("First_Name"),
                                LastName = reader.GetFieldValue<string>("Last_Name"),
                                Address = reader.GetFieldValue<string>("Address"),
                                Phone = reader.GetFieldValue<string>("Phone"),
                                Nit = reader.GetFieldValue<string>("Nit"),
                                UserId = reader.GetFieldValue<Guid>("User_Id")
                            });
                        }
                    }
                }
            }

            return customers;
        }

        public Customer GetById(Guid id)
        {
            Customer customer = null;

            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.GET_CUSTOMER_BY_ID_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.Read())
                        {
                            customer = new Customer
                            {
                                Id = reader.GetFieldValue<Guid>("Id"),
                                FirstName = reader.GetFieldValue<string>("First_Name"),
                                LastName = reader.GetFieldValue<string>("Last_Name"),
                                Address = reader.GetFieldValue<string>("Address"),
                                Phone = reader.GetFieldValue<string>("Phone"),
                                Nit = reader.GetFieldValue<string>("Nit"),
                                UserId = reader.GetFieldValue<Guid>("User_Id")
                            };
                        }
                    }
                }
            }

            return customer;
        }

        public Customer Update(Customer entity)
        {
            using (var conn = new SqlConnection(OnlineStoreContext.ConnectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(OnlineStoreContext.UPDATE_CUSTOMER_SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", entity.Id);
                    cmd.Parameters.AddWithValue("@First_Name", entity.FirstName);
                    cmd.Parameters.AddWithValue("@Last_Name", entity.LastName);
                    cmd.Parameters.AddWithValue("@Address", entity.Address);
                    cmd.Parameters.AddWithValue("@Phone", entity.Phone);
                    cmd.Parameters.AddWithValue("@Nit", entity.Nit);
                    cmd.Parameters.AddWithValue("@User_Id", entity.UserId);

                    entity = cmd.ExecuteNonQuery() > 0 ? entity : null;
                }
            }

            return entity;
        }
    }
}