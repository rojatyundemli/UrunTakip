using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.Business
{
    public class UnitOfMeasureService
    {

        public string GetValidationError(UnitOfMeasure unitOfMeasure)
        {
            if (unitOfMeasure == null)
            {
                return "Birim bilgisi boş olamaz.";
            }

            if (string.IsNullOrWhiteSpace(unitOfMeasure.UnitName))
            {
                return "Birim adı boş olamaz.";
            }
            if (string.IsNullOrWhiteSpace(unitOfMeasure.UnitCode))
            {
                return "Birim kodu boş olamaz.";
            }



            return "";
        }




        public string AddUnitOfMeasure(UnitOfMeasure UnitOfMeasure)
        {

            string error = GetValidationError(UnitOfMeasure);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            try
            {

                UnitOfMeasureRepository repository = new UnitOfMeasureRepository();


                bool saved = repository.AddMeasure(UnitOfMeasure);


                if (saved)
                {
                    return "Birim başarıyla kaydedildi.";
                }

                return "Birim kaydedilemedi.";
            }
            catch (Exception ex)
            {
                return "Kayıt sırasında hata oluştu: " + ex.Message;
            }
        }
        public String UpdateUnitOfMeasure(UnitOfMeasure UnitOfMeasure)
        {
            string error = GetValidationError(UnitOfMeasure);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            try
            {
                UnitOfMeasureRepository repository = new UnitOfMeasureRepository();


                bool updated = repository.UpdateMeasure(UnitOfMeasure);


                if (updated)
                {
                    return "Birim başarıyla Birim Güncellendi.";
                }

                return "Birim Güncellenemedi.";
            }
            catch (Exception ex)
            {
                return "Güncelleme sırasında hata oluştu: " + ex.Message;
            }
        }

        public List<UnitOfMeasure> GetUnitOfMeasure()
        {

            UnitOfMeasureRepository repository = new UnitOfMeasureRepository();
            return repository.GetUnitOfMeasures();

        }

        public List<Dimensions> GetActiveDimension() 
        {
            UnitOfMeasureRepository repository = new UnitOfMeasureRepository();
            return repository.GetActiveDimensions();
        }

        public List<UnitOfMeasure> GetActiveBaseUnits()
        {
            UnitOfMeasureRepository repository = new UnitOfMeasureRepository();

            return repository.GetActiveBaseUnits();
        }
    }
}
