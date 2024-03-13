using KihoonShopes.Entities;
using Microsoft.EntityFrameworkCore;

namespace KihoonShopApp.DataAccess
{
    public class KihoonShopDbContext : DbContext
    {
        public KihoonShopDbContext(DbContextOptions<KihoonShopDbContext> options) : base(options)
        {
        }

        public DbSet<PaymentTerms> PaymentTerms { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>().HasOne(i => i.Customer).WithMany(v => v.Invoices).HasForeignKey(i => i.CustomerId);
            modelBuilder.Entity<Invoice>().HasOne(i => i.PaymentTerms).WithMany(v => v.Invoices).HasForeignKey(i => i.PaymentTermsId);

            modelBuilder.Entity<PaymentTerms>().HasData(
                            new PaymentTerms() { PaymentTermsId = 1, Description = "Net due 10 days", DueDays = 10 },
                            new PaymentTerms() { PaymentTermsId = 2, Description = "Net due 20 days", DueDays = 20 },
                            new PaymentTerms() { PaymentTermsId = 3, Description = "Net due 30 days", DueDays = 30 },
                            new PaymentTerms() { PaymentTermsId = 4, Description = "Net due 60 days", DueDays = 60 },
                            new PaymentTerms() { PaymentTermsId = 5, Description = "Net due 90 days", DueDays = 90 }
                            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer()
                {
                    CustomerId = 1,
                    Name = "AKihoon",
                    Address1 = "549 Bluebeech BLVD",
                    City = "Waterloo",
                    ProvinceOrState = "CA",
                    ZipOrPostalCode = "N2V2TR",
                    Phone = "000-000-0000",
                    ContactEmail = "1@gmail.comm",
                    ContactFirstName = "kihoon",
                    ContactLastName = "kim"
                },
				 new Customer()
				 {
					 CustomerId = 2,
					 Name = "DKihoon",
					 Address1 = "649 Bluebeech BLVD",
					 City = "Toronto",
					 ProvinceOrState = "CA",
					 ZipOrPostalCode = "N2V2T2",
					 Phone = "111-000-0000",
					 ContactEmail = "2@gmail.comm",
					 ContactFirstName = "jihoon",
					 ContactLastName = "lim"
				 },
				  new Customer()
				  {
					  CustomerId = 3,
					  Name = "EKihoon",
					  Address1 = "59 Bluebeech BLVD",
					  City = "Cambridge",
					  ProvinceOrState = "CA",
					  ZipOrPostalCode = "B2V2TR",
					  Phone = "000-000-2222",
					  ContactEmail = "3@gmail.comm",
					  ContactFirstName = "FFFoon",
					  ContactLastName = "Smith"
				  },
				   new Customer()
				   {
					   CustomerId = 4,
					   Name = "HKihoon",
					   Address1 = "366 Bluebeech BLVD",
					   City = "Waterloo",
					   ProvinceOrState = "CA",
					   ZipOrPostalCode = "N2V2TR",
					   Phone = "444-000-0000",
					   ContactEmail = "4@gmail.comm",
					   ContactFirstName = "stefan",
					   ContactLastName = "Siwert"
				   },
					new Customer()
					{
						CustomerId = 5,
						Name = "NKihoon",
						Address1 = "236 BlNuebeech BLVD",
						City = "Waterloo",
						ProvinceOrState = "CA",
						ZipOrPostalCode = "N2V2TR",
						Phone = "555-555-5555",
						ContactEmail = "5@gmail.comm",
						ContactFirstName = "Noah",
						ContactLastName = "Lee"
					},
					 new Customer()
					 {
						 CustomerId = 6,
						 Name = "YKihoon",
						 Address1 = "7 Bluebeech BLVD",
						 City = "Seoul",
						 ProvinceOrState = "KR",
						 ZipOrPostalCode = "N2V2SR",
						 Phone = "666-666-7777",
						 ContactEmail = "6@gmail.comm",
						 ContactFirstName = "jimyung",
						 ContactLastName = "jeong"
					 },
					  new Customer()
					  {
						  CustomerId = 7,
						  Name = "JKihoon",
						  Address1 = "123 Bluebeech BLVD",
						  City = "Kitchener",
						  ProvinceOrState = "CA",
						  ZipOrPostalCode = "M2V2TR",
						  Phone = "898-000-1254",
						  ContactEmail = "7@gmail.comm",
						  ContactFirstName = "kihoon",
						  ContactLastName = "kim"
					  },
					   new Customer()
					   {
						   CustomerId = 8,
						   Name = "LKihoon",
						   Address1 = "275 Bluebeech BLVD",
						   City = "Waterloo",
						   ProvinceOrState = "CA",
						   ZipOrPostalCode = "N2V2TR",
						   Phone = "888-000-0120",
						   ContactEmail = "8@gmail.comm",
						   ContactFirstName = "kurt",
						   ContactLastName = "park"
					   }

				);
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice() { InvoiceId = 1, InvoiceDate = new DateTime(2022, 8, 5), PaymentTermsId = 3, CustomerId = 1 },
                new Invoice() { InvoiceId = 2, InvoiceDate = new DateTime(2022, 8, 17), PaymentTermsId = 3, CustomerId = 1 },
                new Invoice() { InvoiceId = 3, InvoiceDate = new DateTime(2022, 9, 7), PaymentTermsId = 3, CustomerId = 2 },
                new Invoice() { InvoiceId = 4, InvoiceDate = new DateTime(2022, 9, 28), PaymentTermsId = 4, CustomerId = 2 },
                new Invoice() { InvoiceId = 5, InvoiceDate = new DateTime(2022, 10, 8), PaymentTermsId = 3, CustomerId = 3 },
                new Invoice() { InvoiceId = 6, InvoiceDate = new DateTime(2022, 10, 31), PaymentTermsId = 4, CustomerId = 3 },
                new Invoice() { InvoiceId = 7, InvoiceDate = new DateTime(2022, 11, 11), PaymentTermsId = 3, CustomerId = 4 },
                new Invoice() { InvoiceId = 8, InvoiceDate = new DateTime(2022, 11, 12), PaymentTermsId = 5, CustomerId = 4 },
                new Invoice() { InvoiceId = 9, InvoiceDate = new DateTime(2022, 11, 24), PaymentTermsId = 3, CustomerId = 5 },
                new Invoice() { InvoiceId = 10, InvoiceDate = new DateTime(2022, 12, 8), PaymentTermsId = 3, CustomerId = 6 },
                new Invoice() { InvoiceId = 11, InvoiceDate = new DateTime(2022, 12, 21), PaymentTermsId = 2, CustomerId = 7 },
                new Invoice() { InvoiceId = 12, InvoiceDate = new DateTime(2022, 12, 23), PaymentTermsId = 3, CustomerId = 8 }
                );
            modelBuilder.Entity<InvoiceLineItem>().HasData(
                new InvoiceLineItem() { InvoiceLineItemId = 1, Description = "Kimchi", Amount = 70.99, InvoiceId = 1 },
                new InvoiceLineItem() { InvoiceLineItemId = 2, Description = "Normal Gimbab", Amount = 10.5, InvoiceId = 1 },
                new InvoiceLineItem() { InvoiceLineItemId = 3, Description = "Bulgogi Gimbab", Amount = 12.5, InvoiceId = 2 },
                new InvoiceLineItem() { InvoiceLineItemId = 4, Description = "Vegi Gimbab", Amount = 11.5, InvoiceId = 2 },
                new InvoiceLineItem() { InvoiceLineItemId = 5, Description = "Red Chicken", Amount = 15.5, InvoiceId = 3 },
                new InvoiceLineItem() { InvoiceLineItemId = 6, Description = "White Chicken", Amount = 16.9, InvoiceId = 3 },
                new InvoiceLineItem() { InvoiceLineItemId = 7, Description = "Honey Chicken", Amount = 17.5, InvoiceId = 4 },
                new InvoiceLineItem() { InvoiceLineItemId = 8, Description = "Tuna Sushi", Amount = 20.5, InvoiceId = 4 },
                new InvoiceLineItem() { InvoiceLineItemId = 9, Description = "Salmon Sushi", Amount = 18.5, InvoiceId = 5 },
                new InvoiceLineItem() { InvoiceLineItemId = 10, Description = "Sushi Set", Amount = 40.5, InvoiceId = 5 },
                new InvoiceLineItem() { InvoiceLineItemId = 11, Description = "Ramen", Amount = 22.9, InvoiceId = 6 },
                new InvoiceLineItem() { InvoiceLineItemId = 12, Description = "Kimchi Soup", Amount = 19.5, InvoiceId = 6 },
                new InvoiceLineItem() { InvoiceLineItemId = 13, Description = "Soybean Soup", Amount = 18.5, InvoiceId = 7 },
                new InvoiceLineItem() { InvoiceLineItemId = 14, Description = "Milkis", Amount = 6.5, InvoiceId = 8 },
                new InvoiceLineItem() { InvoiceLineItemId = 15, Description = "Bibimbab", Amount = 15.5, InvoiceId = 9 },
                new InvoiceLineItem() { InvoiceLineItemId = 16, Description = "Vegi Bibimbab", Amount = 16.9, InvoiceId = 9 },
                new InvoiceLineItem() { InvoiceLineItemId = 17, Description = "Mandu(10pc)", Amount = 11.5, InvoiceId = 10 },
                new InvoiceLineItem() { InvoiceLineItemId = 18, Description = "Bulgogi Bao", Amount = 9.5, InvoiceId = 10 },
                new InvoiceLineItem() { InvoiceLineItemId = 19, Description = "YangYum Bao", Amount = 8.5, InvoiceId = 11 },
                new InvoiceLineItem() { InvoiceLineItemId = 20, Description = "Bulgogi LunchBox", Amount = 20.5, InvoiceId = 11 },
                new InvoiceLineItem() { InvoiceLineItemId = 21, Description = "Pork Belly", Amount = 26.5, InvoiceId = 12 },
                new InvoiceLineItem() { InvoiceLineItemId = 22, Description = "Top Sironin", Amount = 35.5, InvoiceId = 12 }
                );
        }
    }
}
