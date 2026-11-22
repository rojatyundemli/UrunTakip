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
    public class ProductUnitsRepository
    {

        private readonly string _connectionString =
       @"Server=localhost\SQLEXPRESS01;Database=UrunTakipDB;Integrated Security=True;TrustServerCertificate=True;";


        public bool AddProductUnit(ProductUnits productUnit)
        {
            string query = @"INSERT INTO dbo.ProductUnits
                     (ProductId, UnitId, Numerator, Denominator,
                      IsPurchaseUnit, IsSalesUnit, IsActive, CreatedAt)
                     VALUES
                     (@ProductId, @UnitId, @Numerator, @Denominator,
                      @IsPurchaseUnit, @IsSalesUnit, @IsActive, SYSDATETIME())";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ProductId", SqlDbType.Int).Value = productUnit.ProductId;
                    command.Parameters.Add("@UnitId", SqlDbType.Int).Value = productUnit.UnitId;

                    SqlParameter numerator = command.Parameters.Add("@Numerator", SqlDbType.Decimal);
                    numerator.Precision = 18;
                    numerator.Scale = 8;
                    numerator.Value = productUnit.Numerator;

                    SqlParameter denominator = command.Parameters.Add("@Denominator", SqlDbType.Decimal);
                    denominator.Precision = 18;
                    denominator.Scale = 8;
                    denominator.Value = productUnit.Denominator;

                    command.Parameters.Add("@IsPurchaseUnit", SqlDbType.Bit).Value = productUnit.IsPurchaseUnit;
                    command.Parameters.Add("@IsSalesUnit", SqlDbType.Bit).Value = productUnit.IsSalesUnit;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = productUnit.IsActive;

                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows == 1;
                }
            }
        }
        public bool UpdateProductUnit(ProductUnits productUnit)
        {
            string query = @"UPDATE dbo.ProductUnits
                     SET ProductId = @ProductId,
                         UnitId = @UnitId,
                         Numerator = @Numerator,
                         Denominator = @Denominator,
                         IsPurchaseUnit = @IsPurchaseUnit,
                         IsSalesUnit = @IsSalesUnit,
                         IsActive = @IsActive,
                         UpdatedAt = SYSDATETIME()
                     WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = productUnit.Id;
                    command.Parameters.Add("@ProductId", SqlDbType.Int).Value = productUnit.ProductId;
                    command.Parameters.Add("@UnitId", SqlDbType.Int).Value = productUnit.UnitId;

                    SqlParameter numerator = command.Parameters.Add("@Numerator", SqlDbType.Decimal);
                    numerator.Precision = 18;
                    numerator.Scale = 8;
                    numerator.Value = productUnit.Numerator;

                    SqlParameter denominator = command.Parameters.Add("@Denominator", SqlDbType.Decimal);
                    denominator.Precision = 18;
                    denominator.Scale = 8;
                    denominator.Value = productUnit.Denominator;

                    command.Parameters.Add("@IsPurchaseUnit", SqlDbType.Bit).Value = productUnit.IsPurchaseUnit;
                    command.Parameters.Add("@IsSalesUnit", SqlDbType.Bit).Value = productUnit.IsSalesUnit;
                    command.Parameters.Add("@IsActive", SqlDbType.Bit).Value = productUnit.IsActive;

                    int affectedRows = command.ExecuteNonQuery();

                    return affectedRows > 0;
                }
            }
        }

        public List<ProductUnits> GetProductUnits(int? productId)
        {
            List<ProductUnits> productUnits = new List<ProductUnits>();

            string query = @"SELECT
                        PU.Id,
                        PU.ProductId,
                        P.Name AS ProductName,
                        P.MainUnitId,
                        MU.UnitName AS MainUnitName,
                        PU.UnitId,
                        AU.UnitName AS AlternativeUnitName,
                        PU.Numerator,
                        PU.Denominator,
                        PU.IsPurchaseUnit,
                        PU.IsSalesUnit,
                        PU.IsActive,
                        PU.CreatedAt,
                        PU.UpdatedAt
                     FROM dbo.ProductUnits PU
                     INNER JOIN dbo.Products P ON PU.ProductId = P.Id
                     INNER JOIN dbo.UnitsOfMeasure MU ON P.MainUnitId = MU.Id
                     INNER JOIN dbo.UnitsOfMeasure AU ON PU.UnitId = AU.Id
                     WHERE (@ProductId IS NULL OR PU.ProductId = @ProductId)
                     ORDER BY P.Name";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ProductId", SqlDbType.Int).Value =
                        productId.HasValue ? (object)productId.Value : DBNull.Value;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductUnits productUnit = new ProductUnits();

                            int updatedAtOrdinal = reader.GetOrdinal("UpdatedAt");

                            productUnit.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            productUnit.ProductId = reader.GetInt32(reader.GetOrdinal("ProductId"));
                            productUnit.UnitId = reader.GetInt32(reader.GetOrdinal("UnitId"));

                            productUnit.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                            productUnit.MainUnitName = reader.GetString(reader.GetOrdinal("MainUnitName"));
                            productUnit.AlternativeUnitName = reader.GetString(reader.GetOrdinal("AlternativeUnitName"));

                            productUnit.Numerator = reader.GetDecimal(reader.GetOrdinal("Numerator"));
                            productUnit.Denominator = reader.GetDecimal(reader.GetOrdinal("Denominator"));

                            productUnit.IsPurchaseUnit = reader.GetBoolean(reader.GetOrdinal("IsPurchaseUnit"));
                            productUnit.IsSalesUnit = reader.GetBoolean(reader.GetOrdinal("IsSalesUnit"));
                            productUnit.IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"));

                            productUnit.CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"));

                            productUnit.UpdatedAt = reader.IsDBNull(updatedAtOrdinal)
                                ? (DateTime?)null
                                : reader.GetDateTime(updatedAtOrdinal);

                            productUnits.Add(productUnit);
                        }
                    }
                }
            }

            return productUnits;
        }

        public List<UnitOfMeasure> GetAlternativeUnits(int productId, int? currentProductUnitId = null)
        {
            List<UnitOfMeasure> units = new List<UnitOfMeasure>();

            string query = @"SELECT
                        U.Id,
                        U.UnitCode,
                        U.UnitName,
                        U.DimensionId
                     FROM dbo.Products P
                     INNER JOIN dbo.UnitsOfMeasure MU
                         ON P.MainUnitId = MU.Id
                     CROSS JOIN dbo.UnitsOfMeasure U
                     WHERE P.Id = @ProductId
                       AND U.IsActive = 1
                       AND U.Id <> P.MainUnitId
                       AND U.DimensionId = MU.DimensionId
                       AND NOT EXISTS
                       (
                           SELECT 1
                           FROM dbo.ProductUnits PU
                           WHERE PU.ProductId = P.Id
                             AND PU.UnitId = U.Id
                             AND (@CurrentProductUnitId IS NULL
                                  OR PU.Id <> @CurrentProductUnitId)
                       )
                     ORDER BY U.UnitName";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;

                    command.Parameters.Add("@CurrentProductUnitId", SqlDbType.Int).Value =
                        currentProductUnitId.HasValue
                            ? (object)currentProductUnitId.Value
                            : DBNull.Value;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UnitOfMeasure unit = new UnitOfMeasure();

                            unit.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            unit.UnitCode = reader.GetString(reader.GetOrdinal("UnitCode"));
                            unit.UnitName = reader.GetString(reader.GetOrdinal("UnitName"));
                            unit.DimensionId = reader.GetInt32(reader.GetOrdinal("DimensionId"));

                            units.Add(unit);
                        }
                    }
                }
            }

            return units;
        }

        public List<Product> GetActiveProducts()
        {
            List<Product> products = new List<Product>();

            string query = @"SELECT
                        P.Id,
                        P.Name,
                        P.MainUnitId,
                        U.UnitName AS MainUnitName
                     FROM dbo.Products P
                     INNER JOIN dbo.UnitsOfMeasure U
                         ON P.MainUnitId = U.Id
                     WHERE P.MainUnitId IS NOT NULL
                     ORDER BY P.Name";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product();

                            product.Id = reader.GetInt32(reader.GetOrdinal("Id"));
                            product.Name = reader.GetString(reader.GetOrdinal("Name"));
                            product.MainUnitId = reader.GetInt32(reader.GetOrdinal("MainUnitId"));
                            product.MainUnitName = reader.GetString(reader.GetOrdinal("MainUnitName"));

                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }
    }
}
