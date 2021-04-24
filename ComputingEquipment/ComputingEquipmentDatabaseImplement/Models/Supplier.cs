using System.Collections.Generic;

namespace ComputingEquipmentDatabaseImplement.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string EmployeeName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}