using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.Entities;
using UrunTakip.DataAccess;


namespace UrunTakip.Business
{
    public class StockMovementService
    {



        public string GetValidationError(StockMovement movement)
        {
            if (movement == null)
            {
                return "Stok hareketi bilgisi boş olamaz.";
            }

            if (string.IsNullOrWhiteSpace(movement.Description))
            {
                return "İşlem açıklaması boş olamaz.";
            }

            if (movement.Quantity <= 0)
            {
                return "Stok miktarı sıfır veya negatif olamaz.";
            }

            if (movement.MovementType != "IN" && movement.MovementType != "OUT")
            {
                return "Hareket türü IN veya OUT olmalıdır.";
            }

            return "";
        }


        public String AddStockMovement(StockMovement movement)
        {
            string error = GetValidationError(movement);

            if (!string.IsNullOrEmpty(error))
            {
                return error;
            }

            try
            {


                StockMovementRepository repository = new StockMovementRepository();

                bool added = repository.AddStockMovement(movement);

                if (added)
                {
                    return "Stok hareketi başarıyla eklendi.";
                }
                return "Stok hareketi eklenemedi.";


            }
            catch (Exception ex)
            {
                return "Stok hareketi eklenirken bir hata oluştu: " + ex.Message;


            }


        }



        public string UpdateStockMovement(StockMovement movement)
        {
            string error = GetValidationError(movement);

            if (!string.IsNullOrEmpty(error))
                return error;

            try
            {
                StockMovementRepository repository =
                    new StockMovementRepository();

                bool updated = repository.UpdateStockMovement(movement);

                return updated
                    ? "Stok hareketi başarıyla güncellendi."
                    : "Stok hareketi güncellenemedi.";
            }
            catch (Exception ex)
            {
                return "Stok hareketi güncellenirken hata oluştu: "
                    + ex.Message;
            }
        }

        public string DeleteStockMovement(StockMovement stockMovement)
        {
            try
            {
                StockMovementRepository stockMovementRepository = new StockMovementRepository();
              
                bool delete = stockMovementRepository.DeleteStockMovement(stockMovement);

                if (delete)
                {
                    return "Kayıt Başarıyla Silindi.";
                }
                else return "Kayıt Silinemedi";

            }
            catch (Exception ex)
            {
                return "Stok hareketi silinirken hata oluştu: "
                    + ex.Message;
            }
        }

        public List<StockMovement> GetAllStockMovements()
        {
            try
            {
                StockMovementRepository repository = new StockMovementRepository();
                return repository.GetStockMovements();
            }
            catch (Exception ex)
            {
                throw new Exception("Stok hareketleri getirilirken hata oluştu: " + ex.Message);
            }
        }

    }
}
