using KihoonShopApp.DataAccess;
using KihoonShopes.Entities;
using KihoonShopes.Services;
using Microsoft.EntityFrameworkCore;

namespace KihoonShopApp.Services
{
    public class InvoiceService: IInvoiceService
    {
        public InvoiceService(KihoonShopDbContext kihoonShopDbContext)
        {
            _kihoonShopDbContext = kihoonShopDbContext;
        }
        public List<Invoice> GetInvoicesByCustomerId(int customerId)
        {
            List<Invoice> invoices = _kihoonShopDbContext.Invoices
                    .Where(i => i.CustomerId == customerId)
                    .OrderBy(i => i.InvoiceDate)
                    .ToList();

            return invoices;
        }

        public Invoice? GetInvoiceByInvoiceId(int invoiceId)
        {
            Invoice invoice = _kihoonShopDbContext.Invoices.Include(i => i.Customer)
                .Include(i => i.InvoiceLineItems)
                .Include(i => i.PaymentTerms)
                .Where(i => i.InvoiceId == invoiceId)
                .FirstOrDefault();
            return invoice;

        }

        public List<InvoiceLineItem> GetInvoiceLinestemsByInvoiceId(int invoiceId)
        {
            List<InvoiceLineItem> invoiceLineItems = _kihoonShopDbContext.InvoiceLineItems
                    .Include(i => i.Invoice)
                    .Where(i => i.InvoiceId == invoiceId)
                    .ToList();
            return invoiceLineItems;
        }

        public List<PaymentTerms> GetPaymentTerms()
        {
            List<PaymentTerms> paymentTerms = _kihoonShopDbContext.PaymentTerms
                .OrderBy(p => p.PaymentTermsId)
                .ToList();
            return paymentTerms;
        }

        public InvoiceLineItem AddNewInvoiceLineItem(InvoiceLineItem invoiceLineItem)
        {
            _kihoonShopDbContext.InvoiceLineItems.Add(invoiceLineItem);
            _kihoonShopDbContext.SaveChanges();
            return invoiceLineItem;
        }

        public void AddNewInvoice(Invoice invoice)
        {
            _kihoonShopDbContext.Invoices.Add(invoice);
            _kihoonShopDbContext.SaveChanges();
        }
        private readonly KihoonShopDbContext _kihoonShopDbContext;

       
    }
}
