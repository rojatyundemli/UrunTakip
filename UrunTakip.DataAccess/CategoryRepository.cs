using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Entities;

namespace UrunTakip.DataAccess
{
    public class CategoryRepository
    {
        private readonly string _connectionString =
         @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";

        public bool AddCategory(Category category)
        {
            String query = @"Insert Into dbo.Category (Name,UpCategoryId, UpCategoryName, Description, isActive, CategoryCode,CategoryLevel) Values (@Name, @UpCategoryId, @UpCategoryName, @Description, @isActive, @CategoryCode, @CategoryLevel)";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = category.Name;
                        command.Parameters.Add("@UpCategoryId", SqlDbType.Int).Value = (object)category.UpCategoryId ?? DBNull.Value;
                        command.Parameters.Add("@UpCategoryName", SqlDbType.NVarChar).Value = (object)category.UpCategoryName ?? DBNull.Value;
                        command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = category.Description;
                        command.Parameters.Add("@isActive", SqlDbType.Bit).Value = category.isActive;
                        command.Parameters.Add("@CategoryCode", SqlDbType.NVarChar).Value = category.CategoryCode;
                        command.Parameters.Add("@CategoryLevel", SqlDbType.Int).Value = category.CategoryLevel;



                        int affactedRow = command.ExecuteNonQuery();

                        if (affactedRow > 0) return true;
                        else return false;

                    }



                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool UpdateCategory(Category category)
        {
            String query = @"Update dbo.Category Set Name = @Name,UpCategoryId= @UpCategoryId, UpCategoryName = @UpCategoryName,Description= @Description, isActive= @isActive ,CategoryCode = @CategoryCode, CategoryLevel= @CategoryLevel WHERE Id = @Id ";
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = category.Name;


                        command.Parameters.Add("@UpCategoryId", SqlDbType.Int).Value = (object)category.UpCategoryId ?? DBNull.Value;

                        command.Parameters.Add("@UpCategoryName", SqlDbType.NVarChar).Value = (object)category.UpCategoryName ?? DBNull.Value;

                        command.Parameters.Add("@Description", SqlDbType.NVarChar).Value = category.Description;

                        command.Parameters.Add("@isActive", SqlDbType.Bit).Value = category.isActive;

                        command.Parameters.Add("@CategoryCode", SqlDbType.NVarChar).Value = category.CategoryCode;

                        command.Parameters.Add("@CategoryLevel", SqlDbType.Int).Value = category.CategoryLevel;

                        command.Parameters.Add("@Id", SqlDbType.Int).Value = category.Id;

                        int affactedRow = command.ExecuteNonQuery();

                        if (affactedRow > 0) { return true; }
                        return false;
                    }

                }

            } catch (Exception) { throw; }
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            String query = @"Select * from dbo.Category";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Category category = new Category();

                            category.Id = reader.GetInt32(reader.GetOrdinal("Id"));

                            int upCategoryIdOrdinal = reader.GetOrdinal("UpCategoryId");
                            int upCategoryNameOrdinal = reader.GetOrdinal("UpCategoryName");

                            category.UpCategoryId = reader.IsDBNull(upCategoryIdOrdinal) ? (int?)null : reader.GetInt32(upCategoryIdOrdinal);
                            category.UpCategoryName = reader.IsDBNull(upCategoryNameOrdinal) ? null : reader.GetString(upCategoryNameOrdinal);
                            category.CategoryCode = reader.GetString(reader.GetOrdinal("CategoryCode"));
                            category.CategoryLevel = reader.GetInt32(reader.GetOrdinal("CategoryLevel"));
                            category.Name = reader.GetString(reader.GetOrdinal("Name"));
                            category.isActive = reader.GetBoolean(reader.GetOrdinal("isActive"));
                            category.Description = reader.GetString(reader.GetOrdinal("Description"));

                            categories.Add(category);

                        }

                    }
                }



            }
            return categories;
        }
        public String GetUpCategoryName(int UpCategoryId)
        {

            string query = @"Select Name from dbo.Category WHERE Id = @Id";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = UpCategoryId;


                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToString(result);
                    }

                    return "-- YOK --";
                }


            }

        }

    }
}

    


