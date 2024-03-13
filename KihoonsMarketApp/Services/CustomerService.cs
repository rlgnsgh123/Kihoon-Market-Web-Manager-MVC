using KihoonShopApp.DataAccess;
using KihoonShopes.Entities;
using KihoonShopes.Services;
using Microsoft.EntityFrameworkCore;

namespace KihoonShopApp.Services
{
    public class CustomerService : ICustomerService

    {

        public CustomerService(KihoonShopDbContext kihoonShopDbContext)
        {
            _kihoonShopDbContext = kihoonShopDbContext;
        }


        public List<Customer>? ListCustomerByInitial(string nameFrom = "A", string nameTo = "Z")
        {
            List<Customer> customerList = _kihoonShopDbContext.Customers
                .Where(customer =>
                string.Compare(customer.Name, nameFrom) >= 0 &&
                string.Compare(customer.Name, nameTo) <= 0 &&
                customer.IsDeleted == false
                ).ToList();
            return customerList;
        }

        public Customer? GetCustomerById(int customerId)
        {
            Customer customer = _kihoonShopDbContext.Customers
                .Include(v => v.Invoices)
                .ThenInclude(i => i.InvoiceLineItems)
                .Include(v => v.Invoices)
                .ThenInclude(i => i.PaymentTerms)
                .FirstOrDefault(customer => customer.CustomerId == customerId);
            return customer;
        }


        public void UpdateCustomerStatus(Customer customer)
        {
            customer.IsDeleted = !customer.IsDeleted;

            _kihoonShopDbContext.SaveChanges();
        }

        public void AddNewCustomer(Customer customer)
        {
            _kihoonShopDbContext.Customers.Add(customer);
            _kihoonShopDbContext.SaveChanges();
        }

        public void EditCustomer(Customer customer)
        {
            _kihoonShopDbContext.Customers.Update(customer);
            _kihoonShopDbContext.SaveChanges();
        }

        private readonly KihoonShopDbContext _kihoonShopDbContext;
    }
}
