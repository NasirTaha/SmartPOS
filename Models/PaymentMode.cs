using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class PaymentMode
    {
        public PaymentMode()
        {
            InvoicePayType = new HashSet<InvoicePayType>();
        }

        public int Id { get; set; }
        public string Mode { get; set; }

        public ICollection<InvoicePayType> InvoicePayType { get; set; }
    }
}
