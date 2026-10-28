using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.Business
{
    public class SupplierService
    {

        public string GetValidationError(Supplier supplier)
        {
            if (supplier == null)
            {
                return "Tedarikçi bilgisi boş olamaz.";
            }

            if (string.IsNullOrWhiteSpace(supplier.SupplierName))
            {
                return "Tedarikçi adı boş olamaz.";
            }

            return "";
        }

        public String AddSupplier(Supplier supplier)
        {

            string validationError = GetValidationError(supplier);
            if (!string.IsNullOrEmpty(validationError))
            {
                return validationError;
            }

            SupplierRepository supplierRepository = new SupplierRepository();
            supplierRepository.Add(supplier);


            return "Tedarikçi başarıyla eklendi.";


        }

        public string UpdateSupplier(Supplier supplier)
        {
            string validationError = GetValidationError(supplier);
            if (!string.IsNullOrEmpty(validationError))
            {
                return validationError;
            }
            SupplierRepository supplierRepository = new SupplierRepository();
            bool updated = supplierRepository.UpdateSupplier(supplier);
            if (updated)
            {
                return "Tedarikçi başarıyla güncellendi.";
            }
            else
            {
                return "Tedarikçi güncellenirken bir hata oluştu.";
            }
        }

        public string DeleteSupplier(int id)
        {
            try
            {
                SupplierRepository supplierRepository = new SupplierRepository();
                supplierRepository.DeActivateSupplier(id);
                return "Tedarikçi başarıyla Pasif hale getirildi.";
            }
            catch
            {
                return "Tedarikçi pasif hale getirilirken bir hata oluştu.";

            }

        }



        public List<Supplier> GetAllSuppliers()
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            return supplierRepository.GetAllSupplier();

        }

        public List<Supplier> GetWithSearch(string searchTerm)
        {
            SupplierRepository supplierRepository = new SupplierRepository();
            return supplierRepository.GetWithSearch(searchTerm);
        }
    }
}
