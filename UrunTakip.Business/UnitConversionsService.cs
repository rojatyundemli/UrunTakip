using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.Business
{
    public class UnitConversionsService
    {
        public string GetValidationError(UnitConversions unitConversions)
        {
            if (unitConversions == null)
            {
                return "Birim dönüşüm bilgisi boş olamaz.";
            }

            if (unitConversions.UnitId <= 0)
            {
                return "Lütfen dönüştürülecek birimi seçin.";
            }

            if (unitConversions.Numerator <= 0)
            {
                return "Dönüşüm payı sıfırdan büyük olmalıdır.";
            }

            if (unitConversions.Denominator <= 0)
            {
                return "Dönüşüm paydası sıfırdan büyük olmalıdır.";
            }

            return "";
        }




        public string AddDimensAddConversionsions(UnitConversions unitConversions)
        {

            string error = GetValidationError(unitConversions);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            try
            {

              UnitConversionsRepository repository = new UnitConversionsRepository();


                bool saved = repository.AddConversion(unitConversions);


                if (saved)
                {
                    return "Dönüşüm başarıyla kaydedildi.";
                }

                return "Dönüşüm kaydedilemedi.";
            }
            catch (Exception ex)
            {
                return "Kayıt sırasında hata oluştu: " + ex.Message;
            }
        }

        public string UpdateConversion(UnitConversions conversion)
        {
            string error = GetValidationError(conversion);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            if (conversion.Id <= 0)
            {
                return "Geçerli bir dönüşüm kaydı seçin.";
            }

            try
            {
                UnitConversionsRepository repository = new UnitConversionsRepository();

                bool updated = repository.UpdateConversion(conversion);

                if (updated)
                {
                    return "Birim dönüşümü başarıyla güncellendi.";
                }

                return "Birim dönüşümü güncellenemedi.";
            }
            catch (Exception ex)
            {
                return "Güncelleme sırasında hata oluştu: " + ex.Message;
            }
        }

        public List<UnitConversions> GetUnitConverion()
        {
            UnitConversionsRepository repository = new UnitConversionsRepository();

            return repository.GetUnitConverion();
        }

        public List<UnitOfMeasure> GetUnitOfMeasures() 
        {
           UnitConversionsRepository repository = new UnitConversionsRepository();
            return repository.GetUnitOfMeasure();

        }


    }
}
