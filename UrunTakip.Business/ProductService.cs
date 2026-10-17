using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Entities;
using UrunTakip.DataAccess;


namespace UrunTakip.Business
{
    public class ProductService
    {


        public string GetValidationError(Product product)
        {
            if (product == null)
            {
                return "Ürün bilgisi boş olamaz.";
            }

            if (string.IsNullOrWhiteSpace(product.Name))
            {
                return "Ürün adı boş olamaz.";
            }

            if (product.Price < 0)
            {
                return "Ürün fiyatı negatif olamaz.";
            }

            if (product.Stock < 0)
            {
                return "Stok miktarı negatif olamaz.";
            }

            return "";
        }




        public string AddProduct(Product product)
        {
            // 1. Önce ürünün geçerliliğini kontrol et.
            string error = GetValidationError(product);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            try
            {
                // 2. Veritabanı işlemlerini yapacak nesneyi oluştur.
                ProductRepository repository = new ProductRepository();

                // 3. Ürünü veritabanına kaydet.
                bool saved = repository.Add(product);

                // 4. Sonucu geri döndür.
                if (saved)
                {
                    return "Ürün başarıyla kaydedildi.";
                }

                return "Ürün kaydedilemedi.";
            }
            catch (Exception ex)
            {
                return "Kayıt sırasında hata oluştu: " + ex.Message;
            }
        }


        public String UpdateProductServise(Product product)
        {
            String error = GetValidationError(product);
            if (!String.IsNullOrEmpty(error))
            {
                return error;

            }

            try {
                ProductRepository repository = new ProductRepository();
                bool updated = repository.UpdateProduct(product);
                if (updated) { return "Ürün başarıyla Güncellendi."; }

                return "Ürün kaydedilemedi.";

            } catch(Exception ex) { return "Kayıt sırasında hata oluştu: " + ex.Message; }


        }



        public List<Product> GetAllProducts()
        {
            ProductRepository repository =
                new ProductRepository();

            return repository.GetAll();
        }

        public List<Product> SearchProducts (String Name) 
        {
            ProductRepository repository = new ProductRepository();

           return repository.GetWithSearch(Name);
        
        }


    }
}
