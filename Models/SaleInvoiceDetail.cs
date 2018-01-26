using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class SaleInvoiceDetail
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Qty { get; set; }
        public int SaleInvoiceId { get; set; }

        public Item Item { get; set; }
        public SaleInvoice SaleInvoice { get; set; }
    }
}
