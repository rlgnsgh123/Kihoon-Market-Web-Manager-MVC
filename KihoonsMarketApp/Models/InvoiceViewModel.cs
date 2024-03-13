using KihoonShopes.Entities;

namespace KihoonShopApp.Models
{
    public class InvoiceViewModel
    {
        public string ActivePage { get; set; } = "A-E";

        public Invoice SelectedInvoice { get; set; }

        public List<PaymentTerms> PaymentTerms { get; set; }

        public Invoice NewInvoice { get; set; }

        public InvoiceLineItem NewInvoiceLineItem { get; set; }

        public Customer Customer { get; set; }
    }
}
