using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.Business
{
    public class ProductUnitsService
    {
        public string GetValidationError(ProductUnits productUnit)
        {
            if (productUnit == null)
            {
                return "Ürün birim bilgisi boş olamaz.";
            }

            if (productUnit.ProductId <= 0)
            {
                return "Lütfen bir ürün seçin.";
            }

            if (productUnit.UnitId <= 0)
            {
                return "Lütfen alternatif birim seçin.";
            }

            if (productUnit.Numerator <= 0)
            {
                return "Dönüşüm payı sıfırdan büyük olmalıdır.";
            }

            if (productUnit.Denominator <= 0)
            {
                return "Dönüşüm paydası sıfırdan büyük olmalıdır.";
            }

            if (!productUnit.IsPurchaseUnit && !productUnit.IsSalesUnit)
            {
                return "Birim en azından satın alma veya satış işleminde kullanılmalıdır.";
            }

            return "";
        }


        // ADD
        public string AddProductUnit(ProductUnits productUnit)
        {
            string error = GetValidationError(productUnit);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            try
            {
                ProductUnitsRepository repository = new ProductUnitsRepository();

                bool saved = repository.AddProductUnit(productUnit);

                if (saved)
                {
                    return "Ürün alternatifi başarıyla kaydedildi.";
                }

                return "Ürün alternatifi kaydedilemedi.";
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                return "Bu ürün için seçilen alternatif birim zaten tanımlanmış.";
            }
            catch (Exception ex)
            {
                return "Kayıt sırasında hata oluştu: " + ex.Message;
            }
        }


        // UPDATE
        public string UpdateProductUnit(ProductUnits productUnit)
        {
            string error = GetValidationError(productUnit);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            if (productUnit.Id <= 0)
            {
                return "Güncellenecek ürün birimi seçilmedi.";
            }

            try
            {
                ProductUnitsRepository repository = new ProductUnitsRepository();

                bool updated = repository.UpdateProductUnit(productUnit);

                if (updated)
                {
                    return "Ürün alternatifi başarıyla güncellendi.";
                }

                return "Ürün alternatifi güncellenemedi.";
            }
            catch (SqlException ex) when (ex.Number == 2601 || ex.Number == 2627)
            {
                return "Bu ürün için seçilen alternatif birim zaten tanımlanmış.";
            }
            catch (Exception ex)
            {
                return "Güncelleme sırasında hata oluştu: " + ex.Message;
            }
        }


        // GET ALL / FILTER BY PRODUCT
        public List<ProductUnits> GetProductUnits(int? productId)
        {
            ProductUnitsRepository repository = new ProductUnitsRepository();

            if (productId.HasValue && productId.Value <= 0)
            {
                productId = null;
            }

            return repository.GetProductUnits(productId);
        }


        // GET PRODUCTS WITH MAIN UNIT
        public List<Product> GetProductsWithMainUnit()
        {
            ProductUnitsRepository repository = new ProductUnitsRepository();

            return repository.GetActiveProducts();
        }


        // GET ALTERNATIVE UNITS
        public List<UnitOfMeasure> GetAlternativeUnits(int productId, int? currentProductUnitId = null)
        {
            if (productId <= 0)
            {
                return new List<UnitOfMeasure>();
            }

            ProductUnitsRepository repository = new ProductUnitsRepository();

            return repository.GetAlternativeUnits(productId, currentProductUnitId);
        }
    }

}
