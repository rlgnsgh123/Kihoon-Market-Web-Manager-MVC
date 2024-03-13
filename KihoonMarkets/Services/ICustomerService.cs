using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using KihoonShopes.Entities;
namespace KihoonShopes.Services
{
    public interface ICustomerService
    {
        public List<Customer>? ListCustomerByInitial(string nameFrom = "A", string nameTo = "Z");

        public Customer? GetCustomerById(int customerId);
        public void UpdateCustomerStatus(Customer customer);

        public void AddNewCustomer(Customer customer);

        public void EditCustomer(Customer customer);


    }
}
