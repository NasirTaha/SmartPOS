using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            Item = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Category { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string EnglishName { get; set; }
        public string PrinterName { get; set; }
        public string ImagePath { get; set; }

        public ICollection<Item> Item { get; set; }
    }
}
