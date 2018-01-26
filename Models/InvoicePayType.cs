using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class InvoicePayType
    {
        public int SaleInvoiceId { get; set; }
        public int PaymentModeId { get; set; }

        public PaymentMode PaymentMode { get; set; }
        public SaleInvoice SaleInvoice { get; set; }
    }
}
