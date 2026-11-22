using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.Business
{
    public class DimensionsService
    {
        public string GetValidationError(Dimensions dimensions)
        {
            if (dimensions == null)
            {
                return "Tür bilgisi boş olamaz.";
            }

            if (string.IsNullOrWhiteSpace(dimensions.DimensionName))
            {
                return "Tür adı boş olamaz.";
            }
            if (string.IsNullOrWhiteSpace(dimensions.DimensionCode))
            {
                return "Tür kodu boş olamaz.";
            }
            


            return "";
        }




        public string AddDimensions(Dimensions dimensions)
        {
            
            string error = GetValidationError(dimensions);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            try
            {

                DımensionsRepository repository = new DımensionsRepository();

               
                bool saved = repository.AddDimensions(dimensions);

                
                if (saved)
                {
                    return "Tür başarıyla kaydedildi.";
                }

                return "Tür kaydedilemedi.";
            }
            catch (Exception ex)
            {
                return "Kayıt sırasında hata oluştu: " + ex.Message;
            }
        }
        public String UpdateDimensions(Dimensions dimensions) 
        {
            string error = GetValidationError(dimensions);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            try 
            {
                DımensionsRepository repository = new DımensionsRepository();


                bool updated = repository.UpdateDimensions(dimensions);


                if (updated)
                {
                    return "Tür başarıyla Tür Güncellendi.";
                }

                return "Tür Güncellenemedi.";
            }
            catch (Exception ex)
            {
                return "Güncelleme sırasında hata oluştu: " + ex.Message;
            }
        }

        public List<Dimensions> GetDimensions() 
        {

            DımensionsRepository repository = new DımensionsRepository();
          return repository.GetDimensions();
        
        }

        public List<UnitOfMeasure> GetActiveUnitOfMeasure()
        {

            DımensionsRepository repository = new DımensionsRepository();
            return repository.GetActiveUnitOfMeasures();

        }
    }
}
