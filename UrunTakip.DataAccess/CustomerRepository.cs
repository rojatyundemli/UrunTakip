using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Entities;

namespace UrunTakip.DataAccess
{
    public class CustomerRepository
    {

        private readonly string _connectionString =
          @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";



        public bool AddCustomer(Customer customer)
        {
            String query = @"Insert Into dbo.Customers (CustomerName, ContactName, Phone, Email, TaxOffice, TaxNumber, City, District, Address, CreatedAt, IsActive) Values (@CustomerName, @ContactName, @Phone, @Email, @TaxOffice, @TaxNumber, @City, @District, @Address, @CreatedAt, @IsActive)";

            try 
            {

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@CustomerName", System.Data.SqlDbType.NVarChar).Value = customer.CustomerName;
                        command.Parameters.Add("@ContactName", System.Data.SqlDbType.NVarChar).Value = customer.ContactName;
                        command.Parameters.Add("@Phone", System.Data.SqlDbType.NVarChar).Value = customer.Phone;
                        command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = customer.Email;
                        command.Parameters.Add("@TaxOffice", System.Data.SqlDbType.NVarChar).Value = customer.TaxOffice;
                        command.Parameters.Add("@TaxNumber", System.Data.SqlDbType.NVarChar).Value = customer.TaxNumber;
                        command.Parameters.Add("@City", System.Data.SqlDbType.NVarChar).Value = customer.City;
                        command.Parameters.Add("@District", System.Data.SqlDbType.NVarChar).Value = customer.District;
                        command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar).Value = customer.Address;
                        command.Parameters.Add("@CreatedAt", System.Data.SqlDbType.DateTime).Value = customer.CreatedAt;
                        command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = customer.IsActive;

                        int rowsAffected = command.ExecuteNonQuery();
                        if(rowsAffected > 0)
                        {
                            return rowsAffected == 1; // Customer added successfully
                        }
                        else
                        {
                            return false; // No rows affected, customer not added
                        }

                    }
                }


            }
            catch(Exception ex) 
            {
                throw;
            }
           
        }

        public bool updateCustomer(Customer customer) 
        {
            String query = @"Update dbo.Customers Set CustomerName = @CustomerName, ContactName = @ContactName, Phone = @Phone, Email = @Email, TaxOffice = @TaxOffice, TaxNumber = @TaxNumber, City = @City, District = @District, Address = @Address, IsActive = @IsActive Where Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
             connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = customer.Id;
                    command.Parameters.Add("@CustomerName", System.Data.SqlDbType.NVarChar).Value = customer.CustomerName;
                    command.Parameters.Add("@ContactName", System.Data.SqlDbType.NVarChar).Value = customer.ContactName;
                    command.Parameters.Add("@Phone", System.Data.SqlDbType.NVarChar).Value = customer.Phone;
                    command.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar).Value = customer.Email;
                    command.Parameters.Add("@TaxOffice", System.Data.SqlDbType.NVarChar).Value = customer.TaxOffice;
                    command.Parameters.Add("@TaxNumber", System.Data.SqlDbType.NVarChar).Value = customer.TaxNumber;
                    command.Parameters.Add("@City", System.Data.SqlDbType.NVarChar).Value = customer.City;
                    command.Parameters.Add("@District", System.Data.SqlDbType.NVarChar).Value = customer.District;
                    command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar).Value = customer.Address;
                    command.Parameters.Add("@IsActive", System.Data.SqlDbType.Bit).Value = customer.IsActive;
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected == 1; 
                }

            }
       
        
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            String query = @"Select * From dbo.Customers";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection)) 
                    {
                        using (SqlDataReader reader = command.ExecuteReader()) 
                        {

                            while (reader.Read()) 
                            {
                                Customer customer = new Customer();

                                customer.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                                customer.CustomerName = reader["CustomerName"] != DBNull.Value ? reader["CustomerName"].ToString() : null;
                                customer.ContactName = reader["ContactName"] != DBNull.Value ? reader["ContactName"].ToString() : null;
                                customer.Phone = reader["Phone"] != DBNull.Value ? reader["Phone"].ToString() : null;
                                customer.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : null;
                                customer.TaxOffice = reader["TaxOffice"] != DBNull.Value ? reader["TaxOffice"].ToString() : null;
                                customer.TaxNumber = reader["TaxNumber"] != DBNull.Value ? reader["TaxNumber"].ToString() : null;
                                customer.City = reader["City"] != DBNull.Value ? reader["City"].ToString() : null;
                                customer.District = reader["District"] != DBNull.Value ? reader["District"].ToString() : null;
                                customer.Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : null;
                                customer.CreatedAt = reader["CreatedAt"] != DBNull.Value ? (DateTime)reader["CreatedAt"] : DateTime.MinValue;
                                customer.IsActive = reader["IsActive"] != DBNull.Value ? (bool)reader["IsActive"] : false;

                                customers.Add(customer);
                            }


                        
                        
                        }
                    
                    }

                    return customers;


                }
                catch (Exception ex)
                {
                    throw;

                }

            }
        }

    } 
}
