using System;
using System.Collections.Generic;

namespace ComputingEquipmentDatabaseImplement.Models
{
    public partial class Software
    {
        public Software()
        {
            EquipmentSoftware = new HashSet<EquipmentSoftware>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseType { get; set; }

        public virtual ICollection<EquipmentSoftware> EquipmentSoftware { get; set; }
    }
}