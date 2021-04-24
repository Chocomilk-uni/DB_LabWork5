using System;
using System.Collections.Generic;

namespace ComputingEquipmentDatabaseImplement.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            EquipmentSoftware = new HashSet<EquipmentSoftware>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Specifications { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string State { get; set; }
        public int TypeId { get; set; }
        public int? EmployeeId { get; set; }
        public int SupplierId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<EquipmentSoftware> EquipmentSoftware { get; set; }
    }
}