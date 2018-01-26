using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class Device
    {
        public Device()
        {
            DeviceSaleInvoice = new HashSet<DeviceSaleInvoice>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public string DeviceName { get; set; }
        public int? DeviceTypeId { get; set; }
        public int? ManufactoryId { get; set; }
        public string SerialNo { get; set; }

        public DeviceType DeviceType { get; set; }
        public Manufactory Manufactory { get; set; }
        public ICollection<DeviceSaleInvoice> DeviceSaleInvoice { get; set; }
    }
}
