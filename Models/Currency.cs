using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class Currency
    {
        public Currency()
        {
            SaleInvoice = new HashSet<SaleInvoice>();
            StoreSetting = new HashSet<StoreSetting>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<SaleInvoice> SaleInvoice { get; set; }
        public ICollection<StoreSetting> StoreSetting { get; set; }
    }
}
