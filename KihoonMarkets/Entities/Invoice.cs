using System.ComponentModel.DataAnnotations;

namespace KihoonShopes.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public DateTime? InvoiceDueDate
        {
            get
            {
                return InvoiceDate?.AddDays(Convert.ToDouble(PaymentTerms?.DueDays));
            }
        }

        public double? PaymentTotal { get; set; } = 0.0;

        public DateTime? PaymentDate { get; set; }

        
        [Required(ErrorMessage = "Please specify the payment term.")]
        public int PaymentTermsId { get; set; }

        public PaymentTerms PaymentTerms { get; set; }

        // FK:
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<InvoiceLineItem>? InvoiceLineItems { get; set; }
    }
}
