using System.Collections.Generic;

namespace ComputingEquipmentDatabaseImplement.Models
{
    public partial class Type
    {
        public Type()
        {
            Equipment = new HashSet<Equipment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Equipment> Equipment { get; set; }
    }
}