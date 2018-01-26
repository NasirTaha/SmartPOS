using System;
using System.Collections.Generic;

namespace WebUI.Models
{
    public partial class Manufactory
    {
        public Manufactory()
        {
            Device = new HashSet<Device>();
        }

        public int Id { get; set; }
        public string ManufactoryName { get; set; }

        public ICollection<Device> Device { get; set; }
    }
}
