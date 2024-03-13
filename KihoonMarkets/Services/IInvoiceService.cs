using KihoonShopes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KihoonShopes.Services
{
    public interface IInvoiceService
    {
        public List<Invoice> GetInvoicesByCustomerId(int customerId);

        public Invoice? GetInvoiceByInvoiceId(int invoiceId);

        public List<InvoiceLineItem> GetInvoiceLinestemsByInvoiceId(int invoiceId);

        public List<PaymentTerms> GetPaymentTerms();

        public InvoiceLineItem AddNewInvoiceLineItem(InvoiceLineItem invoiceLineItem);

        public  void AddNewInvoice(Invoice invoice);



    }
}
