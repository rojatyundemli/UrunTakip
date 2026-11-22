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
    public class UnitConversionsRepository
    {
        private readonly string _connectionString =
         @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";

        public bool AddConversion(UnitConversions conversion)
        {
            string query = @"INSERT INTO dbo.UnitConversions
                     (UnitId, Numerator, Denominator, CreatedAt)
                     VALUES
                     (@UnitId, @Numerator, @Denominator, SYSDATETIME())";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@UnitId", SqlDbType.Int).Value = conversion.UnitId;

                    SqlParameter numeratorParameter = command.Parameters.Add("@Numerator", SqlDbType.Decimal);
                    numeratorParameter.Precision = 18;
                    numeratorParameter.Scale = 8;
                    numeratorParameter.Value = conversion.Numerator;

                    SqlParameter denominatorParameter = command.Parameters.Add("@Denominator", SqlDbType.Decimal);
                    denominatorParameter.Precision = 18;
                    denominatorParameter.Scale = 8;
                    denominatorParameter.Value = conversion.Denominator;

                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows == 1;
                }
            }
        }



        public bool UpdateConversion(UnitConversions conversion)
        {
            string query = @"UPDATE dbo.UnitConversions
                     SET UnitId = @UnitId,
                         Numerator = @Numerator,
                         Denominator = @Denominator,
                         UpdatedAt = SYSDATETIME()
                     WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = conversion.Id;
                    command.Parameters.Add("@UnitId", SqlDbType.Int).Value = conversion.UnitId;

                    SqlParameter numeratorParameter = command.Parameters.Add("@Numerator", SqlDbType.Decimal);
                    numeratorParameter.Precision = 18;
                    numeratorParameter.Scale = 8;
                    numeratorParameter.Value = conversion.Numerator;

                    SqlParameter denominatorParameter = command.Parameters.Add("@Denominator", SqlDbType.Decimal);
                    denominatorParameter.Precision = 18;
                    denominatorParameter.Scale = 8;
                    denominatorParameter.Value = conversion.Denominator;

                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows > 0;
                }
            }
        }

        public List<UnitConversions> GetUnitConverion()
        {
            List<UnitConversions> conversions = new List<UnitConversions>();

            string query = @"SELECT 
                        UC.Id,
                        UC.UnitId,
                        UC.Numerator,
                        UC.Denominator,
                        UC.CreatedAt,
                        UC.UpdatedAt,
                        U.UnitName,
                        D.DimensionName,
                        BU.UnitName AS BaseUnitName
                     FROM dbo.UnitConversions UC
                     INNER JOIN dbo.UnitsOfMeasure U ON UC.UnitId = U.Id
                     INNER JOIN dbo.Dimensions D ON U.DimensionId = D.Id
                     LEFT JOIN dbo.UnitsOfMeasure BU ON D.BaseUnitId = BU.Id
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
                            UnitConversions conversion = new UnitConversions();

                            int updatedAtOrdinal = reader.GetOrdinal("UpdatedAt");
                            int baseUnitOrdinal = reader.GetOrdinal("BaseUnitName");

                            conversion.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            conversion.UnitId = reader.GetInt32(reader.GetOrdinal("UnitId"));
                            conversion.Numerator = reader.GetDecimal(reader.GetOrdinal("Numerator"));
                            conversion.Denominator = reader.GetDecimal(reader.GetOrdinal("Denominator"));

                            conversion.UnitName = reader.GetString(reader.GetOrdinal("UnitName"));
                            conversion.DimensionName = reader.GetString(reader.GetOrdinal("DimensionName"));

                            conversion.BaseUnitName = reader.IsDBNull(baseUnitOrdinal)
                                ? null
                                : reader.GetString(baseUnitOrdinal);

                            conversion.CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));

                            conversion.UpdatedAt = reader.IsDBNull(updatedAtOrdinal)
                                ? (DateTime?)null
                                : reader.GetDateTime(updatedAtOrdinal);

                            conversions.Add(conversion);
                        }
                    }
                }
            }

            return conversions;
        }


        public List<UnitOfMeasure> GetUnitOfMeasure() 
        {
         List<UnitOfMeasure> unitOfMeasures = new List<UnitOfMeasure>();


            string query = @"SELECT 
                    U.Id,
                    U.UnitCode,
                    U.UnitName,
                    U.DimensionId,
                    D.DimensionName,
                    D.BaseUnitId,
                    BU.UnitName AS BaseUnitName,
                    U.DecimalPlaces,
                    U.IsActive,
                    U.CreatedAt,
                    U.UpdatedAt

                 FROM dbo.UnitsOfMeasure U

                 INNER JOIN dbo.Dimensions D ON U.DimensionId = D.Id

                 LEFT JOIN dbo.UnitsOfMeasure BU ON D.BaseUnitId = BU.Id

                 WHERE U.IsActive = 1
                   AND D.BaseUnitId IS NOT NULL
                   AND U.Id <> D.BaseUnitId
                 ORDER BY U.UnitName";



            using (SqlConnection connection = new SqlConnection(_connectionString)) 
            {
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        {
                            UnitOfMeasure measure = new UnitOfMeasure();

                            int updatedAtOrdinal = reader.GetOrdinal("UpdatedAt");
                            int baseUnitOrdinal = reader.GetOrdinal("BaseUnitName");

                            measure.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            measure.UnitCode = reader.GetString(reader.GetOrdinal("UnitCode"));
                            measure.UnitName = reader.GetString(reader.GetOrdinal("UnitName"));
                            measure.DimensionId = reader.GetInt32(reader.GetOrdinal("DimensionId"));

                            measure.DimensionName = reader.GetString(reader.GetOrdinal("DimensionName"));

                            measure.BaseUnitName = reader.IsDBNull(baseUnitOrdinal)? null: reader.GetString(baseUnitOrdinal);

                            measure.DecimalPlaces = Convert.ToInt32(reader["DecimalPlaces"]);
                            measure.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));
                            measure.CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));

                            measure.UpdatedAt = reader.IsDBNull(updatedAtOrdinal)
                                ? (DateTime?)null
                                : reader.GetDateTime(updatedAtOrdinal);

                            unitOfMeasures.Add(measure);

                        }
                    }


                }
            }
            return unitOfMeasures;
        }
    }
}
