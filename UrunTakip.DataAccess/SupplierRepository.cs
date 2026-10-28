using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Entities;

namespace UrunTakip.DataAccess
{
    public class SupplierRepository
    {
        private readonly string _connectionString =
           @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";

        public bool Add(Supplier supplier)
        {
            String query = @"Insert into dbo.Suppliers (SupplierName, ContactPerson, Phone, Email, TaxOffice, TaxNumber, Address, Description)  Values (@SupplierName ,@ContactPerson, @Phone, @Email,@TaxOffice,@TaxNumber,@Address,@Description)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {


                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Parameters.Add("@SupplierName", SqlDbType.NVarChar, 100).Value = supplier.SupplierName;
                    command.Parameters.Add("@ContactPerson", SqlDbType.NVarChar, 100).Value = supplier.ContactPerson;
                    command.Parameters.Add("@Phone", SqlDbType.NVarChar, 14).Value = supplier.Phone;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = supplier.Email;
                    command.Parameters.Add("@TaxOffice", SqlDbType.NVarChar, 150).Value = supplier.TaxOffice;
                    command.Parameters.Add("@TaxNumber", SqlDbType.NVarChar, 50).Value = supplier.TaxNumber;
                    command.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = supplier.Address;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar, 700).Value = supplier.Description;

                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows == 1;
                }




            }
        }

        public bool UpdateSupplier(Supplier supplier)
        {
            string query = @"UPDATE dbo.Suppliers SET SupplierName = @SupplierName, ContactPerson = @ContactPerson, Phone = @Phone, Email = @Email, TaxOffice = @TaxOffice, TaxNumber = @TaxNumber, Address = @Address, Description = @Description WHERE Id = @Id";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = supplier.Id;
                    command.Parameters.Add("@SupplierName", SqlDbType.NVarChar, 100).Value = supplier.SupplierName;
                    command.Parameters.Add("@ContactPerson", SqlDbType.NVarChar, 100).Value = supplier.ContactPerson;
                    command.Parameters.Add("@Phone", SqlDbType.NVarChar, 14).Value = supplier.Phone;
                    command.Parameters.Add("@Email", SqlDbType.NVarChar, 100).Value = supplier.Email;
                    command.Parameters.Add("@TaxOffice", SqlDbType.NVarChar, 150).Value = supplier.TaxOffice;
                    command.Parameters.Add("@TaxNumber", SqlDbType.NVarChar, 50).Value = supplier.TaxNumber;
                    command.Parameters.Add("@Address", SqlDbType.NVarChar, 200).Value = supplier.Address;
                    command.Parameters.Add("@Description", SqlDbType.NVarChar, 700).Value = supplier.Description;
                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows == 1;
                }
            }

        }

        public bool DeActivateSupplier(int supplierId)
        {
            string query = @"UPDATE dbo.Suppliers SET IsActive = 0 WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = supplierId;
                    int affectedRows = command.ExecuteNonQuery();
                    return affectedRows == 1;
                }
            }


        }


        public List<Supplier> GetAllSupplier() 
        {
         
            List<Supplier> suppliers = new List<Supplier>();

            String query = @"SELECT * FROM dbo.Suppliers ";

            SqlConnection connection = new SqlConnection(_connectionString);
            using (SqlCommand command = new SqlCommand(query, connection)) 
            {
            connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                    
                        Supplier supplier = new Supplier
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            SupplierName = reader.GetString(reader.GetOrdinal("SupplierName")),
                            ContactPerson = reader.IsDBNull(reader.GetOrdinal("ContactPerson")) ? null : reader.GetString(reader.GetOrdinal("ContactPerson")),
                            Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                            TaxOffice = reader.IsDBNull(reader.GetOrdinal("TaxOffice")) ? null : reader.GetString(reader.GetOrdinal("TaxOffice")),
                            TaxNumber = reader.IsDBNull(reader.GetOrdinal("TaxNumber")) ? null : reader.GetString(reader.GetOrdinal("TaxNumber")),
                            Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description")),
                            CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt")),
                            IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                        };
                        suppliers.Add(supplier);




                    }
                     
                       
                    return suppliers;





                }


            }


        }





        public List<Supplier> GetWithSearch(String Name)
        {
            List<Supplier> suppliers = new List<Supplier>();

            String query = @"Select Id, SupplierName, ContactPerson, Phone, Email, TaxOffice, TaxNumber, Address, Description, CreatedAt, IsActive
            FROM dbo.Suppliers Where SupplierName Like @Name";



            using (SqlConnection connection = new SqlConnection(_connectionString))

            using (SqlCommand command_ = new SqlCommand(query, connection))
            {
                connection.Open();
                command_.Parameters.AddWithValue("@Name", "%" + Name + "%");


                using (SqlDataReader reader = command_.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        Supplier supplier = new Supplier();

                        supplier.Id = reader.GetInt32(
                               reader.GetOrdinal("Id"));

                        supplier.SupplierName = reader.GetString(
                            reader.GetOrdinal("SupplierName"));

                        supplier.ContactPerson = reader.IsDBNull(reader.GetOrdinal("ContactPerson")) ? null : reader.GetString(reader.GetOrdinal("ContactPerson"));
                        supplier.Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? null : reader.GetString(reader.GetOrdinal("Phone"));
                        supplier.Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email"));
                        supplier.TaxOffice = reader.IsDBNull(reader.GetOrdinal("TaxOffice")) ? null : reader.GetString(reader.GetOrdinal("TaxOffice"));
                        supplier.TaxNumber = reader.IsDBNull(reader.GetOrdinal("TaxNumber")) ? null : reader.GetString(reader.GetOrdinal("TaxNumber"));
                        supplier.Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address"));
                        supplier.Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? null : reader.GetString(reader.GetOrdinal("Description"));
                        supplier.CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));
                        supplier.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                        suppliers.Add(supplier);
                    }


                    return suppliers;




                }
            }






            return suppliers;

        }




    }






}
