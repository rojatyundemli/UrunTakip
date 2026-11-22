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
    public class UnitOfMeasureRepository
    {

        private readonly string _connectionString =
         @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";


        public bool AddMeasure(UnitOfMeasure unitOfMeasure) 
        {
            string query = @"INSERT INTO dbo.UnitsOfMeasure (UnitCode,UnitName,DimensionId,DecimalPlaces,IsActive,CreatedAt) VALUES (@UnitCode,@UnitName,@DimensionId,@DecimalPlaces,@IsActive,SYSDATETIME() )";

            using(SqlConnection connection = new SqlConnection(_connectionString)) 
            {
             connection.Open();

                using (SqlCommand command = new SqlCommand (query,connection)) 
                {
                  command.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = unitOfMeasure.UnitCode;
                  command.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = unitOfMeasure.UnitName;
                  command.Parameters.Add("@DimensionId", SqlDbType.Int).Value = unitOfMeasure.DimensionId;
                  command.Parameters.Add("@DecimalPlaces", SqlDbType.Int).Value = unitOfMeasure.DecimalPlaces;
                  command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = unitOfMeasure.IsActive;
                 
                

                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows == 1;

                }
            
            }

        }
        public bool UpdateMeasure(UnitOfMeasure unitOfMeasure) 
        {
            string query = @"UPDATE dbo.UnitsOfMeasure SET UnitCode = @UnitCode, UnitName = @UnitName, DimensionId = @DimensionId, DecimalPlaces = @DecimalPlaces, IsActive = @IsActive, UpdatedAt = SYSDATETIME()  WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = unitOfMeasure.Id;
                    command.Parameters.Add("@UnitCode", SqlDbType.NVarChar).Value = unitOfMeasure.UnitCode;
                    command.Parameters.Add("@UnitName", SqlDbType.NVarChar).Value = unitOfMeasure.UnitName;
                    command.Parameters.Add("@DimensionId", SqlDbType.Int).Value = unitOfMeasure.DimensionId;
                    command.Parameters.Add("@DecimalPlaces", SqlDbType.Int).Value = unitOfMeasure.DecimalPlaces;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = unitOfMeasure.IsActive;
                   
                   

                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows == 1;

                }

            }


        }

        public List<UnitOfMeasure> GetUnitOfMeasures() 
        {

            List<UnitOfMeasure> unitOfMeasures = new List<UnitOfMeasure>();

            String query = @"SELECT U.Id, U.UnitCode, U.UnitName, U.DimensionId,
                        D.DimensionName, U.DecimalPlaces, U.IsActive,
                        U.CreatedAt, U.UpdatedAt
                 FROM dbo.UnitsOfMeasure U
                 INNER JOIN dbo.Dimensions D ON U.DimensionId = D.Id";


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UnitOfMeasure unitOfMeasure = new UnitOfMeasure();

                            int updatedAtOrdinal = reader.GetOrdinal("UpdatedAt");

                            unitOfMeasure.DimensionName = reader.GetString(reader.GetOrdinal("DimensionName"));

                            unitOfMeasure.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            unitOfMeasure.UnitCode = reader.GetString(reader.GetOrdinal("UnitCode"));
                            unitOfMeasure.UnitName = reader.GetString(reader.GetOrdinal("UnitName"));
                            unitOfMeasure.DimensionId = reader.GetInt32(reader.GetOrdinal("DimensionId"));
                            unitOfMeasure.DecimalPlaces = Convert.ToInt32(reader["DecimalPlaces"]);
                            unitOfMeasure.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                            unitOfMeasure.CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));
                            

                            unitOfMeasure.UpdatedAt = reader.IsDBNull(updatedAtOrdinal)? (DateTime?)null: reader.GetDateTime(updatedAtOrdinal);
                            unitOfMeasure.DecimalPlaces = Convert.ToInt32(reader["DecimalPlaces"]);



                            unitOfMeasures.Add(unitOfMeasure);

                        }
                    }

                }

            }

            return unitOfMeasures;


        }

        public List<Dimensions> GetActiveDimensions()
        {
            List<Dimensions> dimensionsList = new List<Dimensions>();

            string query = @"SELECT Id, DimensionName FROM dbo.Dimensions WHERE IsActive = 1 ORDER BY DimensionName";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Dimensions dimension = new Dimensions()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                DimensionName = reader.GetString(reader.GetOrdinal("DimensionName"))
                            };

                            dimensionsList.Add(dimension);
                        }
                    }
                }
            }

            return dimensionsList;
        }

        public List<UnitOfMeasure> GetActiveBaseUnits()
        {
            List<UnitOfMeasure> units = new List<UnitOfMeasure>();

            string query = @"SELECT
                        U.Id,
                        U.UnitCode,
                        U.UnitName,
                        U.DimensionId
                     FROM dbo.UnitsOfMeasure U
                     INNER JOIN dbo.Dimensions D
                        ON U.DimensionId = D.Id
                     WHERE U.IsActive = 1
                       AND D.IsActive = 1
                       AND D.BaseUnitId = U.Id
                     ORDER BY U.UnitName";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UnitOfMeasure unit = new UnitOfMeasure();

                            unit.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            unit.UnitCode = reader.GetString(reader.GetOrdinal("UnitCode")).Trim();
                            unit.UnitName = reader.GetString(reader.GetOrdinal("UnitName"));
                            unit.DimensionId = reader.GetInt32(reader.GetOrdinal("DimensionId"));

                            units.Add(unit);
                        }
                    }
                }
            }

            return units;
        }


    }
}
