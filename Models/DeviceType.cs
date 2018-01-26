using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class DeviceType
    {
        public DeviceType()
        {
            Device = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }

        public ICollection<Device> Device { get; set; }
    }
}
