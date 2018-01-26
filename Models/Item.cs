using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class Item
    {
        public Item()
        {
            SaleInvoiceDetail = new HashSet<SaleInvoiceDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal SalePrice { get; set; }
        public string EnglishName { get; set; }
        public string Color { get; set; }
        public string ImagePath { get; set; }
        public string Code { get; set; }
        public bool Taxable { get; set; }

        public ItemCategory Category { get; set; }
        public ICollection<SaleInvoiceDetail> SaleInvoiceDetail { get; set; }
    }
}
