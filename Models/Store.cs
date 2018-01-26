using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class Store
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime CreateDate { get; set; }
        public string StockOwner { get; set; }
        public int Status { get; set; }
        public string StoreName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
