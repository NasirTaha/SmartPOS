using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class SaleInvoice
    {
        public SaleInvoice()
        {
            InvoicePayType = new HashSet<InvoicePayType>();
            SaleInvoiceDetail = new HashSet<SaleInvoiceDetail>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Discount { get; set; }
        public decimal InvoiceTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal SubTotal { get; set; }
        public int? CustomerId { get; set; }
        public string UserId { get; set; }
        public int? CurrencyId { get; set; }

        public Currency Currency { get; set; }
        public Customer Customer { get; set; }
        public ICollection<InvoicePayType> InvoicePayType { get; set; }
        public ICollection<SaleInvoiceDetail> SaleInvoiceDetail { get; set; }
    }
}
