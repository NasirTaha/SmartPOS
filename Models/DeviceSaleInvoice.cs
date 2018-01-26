using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class DeviceSaleInvoice
    {
        public int Id { get; set; }
        public int DevicId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerId { get; set; }
        public DateTime Date { get; set; }
        public string DeviceDesciption { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }
        public string UserId { get; set; }

        public Device Devic { get; set; }
        public AspNetUsers User { get; set; }
    }
}
