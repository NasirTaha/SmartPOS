using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            SaleInvoice = new HashSet<SaleInvoice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public ICollection<SaleInvoice> SaleInvoice { get; set; }
    }
}
