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
    public class DımensionsRepository
    {
        private readonly string _connectionString =
            @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";


        public bool AddDimensions (Dimensions dimensions)
        {
            String query = @"Insert Into dbo.Dimensions (DimensionCode,DimensionName,BaseUnitId,Description,IsActive,CreatedAt) VALUES (@DimensionCode, @DimensionName, @BaseUnitId, @Description, @IsActive, @CreatedAt)";
            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
             connection.Open();
                using (SqlCommand command = new SqlCommand(query,connection)) 
                {
                 command.Parameters.Add("@DimensionCode", SqlDbType.NVarChar).Value =dimensions.DimensionCode;
                 command.Parameters.Add("@DimensionName", SqlDbType.NVarChar).Value = dimensions.DimensionName;


                    command.Parameters.Add("@BaseUnitId", SqlDbType.Int).Value = dimensions.BaseUnitId.HasValue ? (object)dimensions.BaseUnitId.Value : DBNull.Value;

                    command.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value =dimensions.Description == null ? (object)DBNull.Value : dimensions.Description;


                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = dimensions.IsActive;
                 command.Parameters.Add("@CreatedAt", SqlDbType.DateTime2).Value = dimensions.CreatedAt;

                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows == 1;

                }
            
            
            }
        
        
        
        }


        public bool UpdateDimensions(Dimensions dimensions) 
        {
            String query = @"Update  dbo.Dimensions Set DimensionCode =@DimensionCode,DimensionName=@DimensionName,BaseUnitId=@BaseUnitId,Description=@Description,IsActive=@IsActive Where Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = dimensions.Id;

                    command.Parameters.Add("@DimensionCode", SqlDbType.NVarChar).Value = dimensions.DimensionCode;
                    command.Parameters.Add("@DimensionName", SqlDbType.NVarChar).Value = dimensions.DimensionName;


                    command.Parameters.Add("@BaseUnitId", SqlDbType.Int).Value = dimensions.BaseUnitId.HasValue ? (object)dimensions.BaseUnitId.Value : DBNull.Value;

                    command.Parameters.Add("@Description", SqlDbType.NVarChar, 250).Value = dimensions.Description == null ? (object)DBNull.Value : dimensions.Description;


                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = dimensions.IsActive;
                   

                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows == 1;

                }


            }



        }

        public List<Dimensions> GetDimensions() 
        {
            List<Dimensions> dimensions = new List<Dimensions>();
            string query = @"SELECT D.Id, D.DimensionCode, D.DimensionName, D.BaseUnitId, D.Description, D.IsActive, D.CreatedAt, D.CreatedBy, U.UnitName AS BaseUnitName FROM dbo.Dimensions D LEFT JOIN dbo.UnitsOfMeasure U ON D.BaseUnitId = U.Id";

            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query,connection)) 
                {
                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                         Dimensions dimension = new Dimensions();

                            int baseUnitOrdinal = reader.GetOrdinal("BaseUnitId");
                            int baseUnitNameOrdinal = reader.GetOrdinal("BaseUnitName");
                            int CreatedByOrdinal = reader.GetOrdinal("CreatedBy");


                            dimension.BaseUnitName = reader.IsDBNull(baseUnitNameOrdinal)? null: reader.GetString(baseUnitNameOrdinal);
                            dimension.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            dimension.DimensionCode = reader.GetString(reader.GetOrdinal("DimensionCode"));
                            dimension.DimensionName = reader.GetString(reader.GetOrdinal("DimensionName"));
                            dimension.Description = reader.GetString(reader.GetOrdinal("Description"));
                            dimension.BaseUnitId = reader.IsDBNull(baseUnitOrdinal) ? null : reader.GetInt32(baseUnitOrdinal);
                            dimension.CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));
                            dimension.CreatedBy = reader.IsDBNull(CreatedByOrdinal) ? null : reader.GetInt32(CreatedByOrdinal);
                            dimension.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));

                            dimensions.Add(dimension);

                        }
                    }
                
                }
            
            }

            return dimensions;
        }
        public List<UnitOfMeasure> GetActiveUnitOfMeasures() 
        {
         List<UnitOfMeasure> unitOfMeasures = new List<UnitOfMeasure>();

            String query = @"SELECT Id, UnitName  FROM dbo.UnitsOfMeasure Where IsActive = 1 ORDER BY UnitName";
           

            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query,connection)) 
                {

                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        while (reader.Read()) 
                        {
                          UnitOfMeasure measure = new UnitOfMeasure();
                            measure.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            measure.UnitName =reader.GetString(reader.GetOrdinal("UnitName"));
                        
                            unitOfMeasures.Add(measure);
                        }
                    
                    
                    }

                }
              return unitOfMeasures;
            }
        }

    }
}
