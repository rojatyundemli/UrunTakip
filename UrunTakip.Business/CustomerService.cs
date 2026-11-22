using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrunTakip.DataAccess;
using UrunTakip.Entities;

namespace UrunTakip.Business
{
    public class CustomerService
    {

        public string AddCustommer(Customer customer)
        {
            try 
            {
                CustomerRepository repository = new CustomerRepository();
                bool isAdded = repository.AddCustomer(customer);
                if (isAdded)
                {
                    return "Müşteri başarıyla eklendi.";
                }
                return "Müşteri eklenirken bir hata oluştu.";
            } catch (Exception ex)
            {
                return "Müşteri eklenirken bir hata oluştu: " + ex.Message;
            }

        }

        public string updateCustomer(Customer customer)
        {
            try
            {
                CustomerRepository repository = new CustomerRepository();
                bool isUpdated = repository.updateCustomer(customer);
                if (isUpdated)
                {
                    return "Müşteri başarıyla güncellendi.";
                }
                return "Müşteri güncellenirken bir hata oluştu.";

            }
            catch (Exception ex)
            {
                return "Müşteri güncellenirken bir hata oluştu: " + ex.Message;

            }
        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                CustomerRepository repository = new CustomerRepository();
                return repository.GetAllCustomers();
            }
            catch (Exception ex)
            {
                
                return new List<Customer>();
            }
        }

    }
}
