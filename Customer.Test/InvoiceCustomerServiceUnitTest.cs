using KihoonShopApp.DataAccess;
using KihoonShopApp.Services;
using KihoonShopes.Entities;
using Microsoft.EntityFrameworkCore;

namespace KihoonShop.Test
{
    public class InvoiceCustomerServiceUnitTest
    {
       
        [Fact]
        public void AddingCustomer_AddInKihoonDbContext()
        {
            var options = new DbContextOptionsBuilder<KihoonShopDbContext>()
                .UseInMemoryDatabase(databaseName: "AddingCustomerTest")
                .Options;

            using (var ct = new KihoonShopDbContext(options))
            {
                CustomerService customerService = new CustomerService(ct);

                customerService.AddNewCustomer(new Customer { CustomerId = 1, Name = "Kihoon", Address1 = "Kihoon", City ="WATERLOO", ContactFirstName ="KIHOON", ContactLastName="kim",Phone="647-000-0000",ZipOrPostalCode="ON", ProvinceOrState = "n2v-3t4" });

                Customer tempCustomer = ct.Customers.Find(1);
                Assert.NotNull(tempCustomer);
                Assert.Equal("Kihoon", tempCustomer.Address1);
            }
        }

        [Fact]
        public void GetCustomerById_GetCustomerObject()
        {
            var options = new DbContextOptionsBuilder<KihoonShopDbContext>()
                .UseInMemoryDatabase(databaseName: "GetCustomerByIdTest")
                .Options;

            using (var ct = new KihoonShopDbContext(options))
            {
                CustomerService customerService = new CustomerService(ct);
                customerService.AddNewCustomer(new Customer { CustomerId = 1, Name = "kihoon", Address1 = "Kihoon", City = "WATERLOO", ContactFirstName = "KIHOON", ContactLastName = "kim", Phone = "647-000-0000", ZipOrPostalCode = "ON", ProvinceOrState = "n2v-3t4" });

                Customer testCustomer = customerService.GetCustomerById(1);

                Assert.NotNull(testCustomer);
                Assert.Equal("kihoon", testCustomer.Name);
            }
        }


        [Fact]
        public void AddInvoice_AddsInDbContext()
        {

            var options = new DbContextOptionsBuilder<KihoonShopDbContext>()
                .UseInMemoryDatabase(databaseName: "AddInvoiceTest")
                .Options;

            using (var context = new KihoonShopDbContext(options))
            {
                InvoiceService invoiceService = new InvoiceService(context);

                invoiceService.AddNewInvoice(
                    new Invoice { InvoiceId = 1, CustomerId = 1, InvoiceDate = DateTime.Now }
                    );

                Invoice tempdInvoice = context.Invoices.Find(1);
                Assert.NotNull(tempdInvoice);
                Assert.Equal(1, tempdInvoice.InvoiceId);
            }
        }
    }
}