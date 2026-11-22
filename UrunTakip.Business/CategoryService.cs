using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.Business
{
    public class CategoryService
    {

        public string GetValidationError(Category category)
        {
            if (category == null)
            {
                return "Kategori bilgisi boş olamaz.";
            }

            if (string.IsNullOrWhiteSpace(category.Name))
            {
                return "Kategori adı boş olamaz.";
            }

            if (string.IsNullOrWhiteSpace(category.CategoryCode))
            {
                return "Kategori kodu boş olamaz.";
            }

           
            return "";
        }



        public String AddCategory(Category category)
        {

            
            string error = GetValidationError(category);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            try 
            {
            
                CategoryRepository categoryRepository = new CategoryRepository();
               bool saved = categoryRepository.AddCategory(category);

                if (saved) return "Yeni Kategori Kaydedildi";
                
                return "Kayıt sırasında hata oluştu";

            }
            catch (Exception ex) { return "Kayıt sırasında hata oluştu" + ex.Message; }


        }

        public String UpdateCategory (Category category) 
        {
            CategoryRepository repository = new CategoryRepository();
            string error = GetValidationError(category);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }


            try
            {
                Boolean result = repository.UpdateCategory(category);

                if (result) return "Kategori Başarıyla Güncellendi";
                return "Kategori Güncellenirken Bir Hata Oluştu";
            }
            catch (Exception ex) { return "Güncellenirken Bir Hata Oluştu " + ex; }


        }

        public List<Category> GetCategories() 
        {
         CategoryRepository repository = new CategoryRepository();
        
            return repository.GetCategories();
        
        }

        public String GetUpCategoryName(int UpCategoryId) 
        {

            CategoryRepository repository = new CategoryRepository();

            return repository.GetUpCategoryName(UpCategoryId);

        }

    }
}
