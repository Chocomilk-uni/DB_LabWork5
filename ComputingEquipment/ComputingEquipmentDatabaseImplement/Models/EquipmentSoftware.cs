namespace ComputingEquipmentDatabaseImplement.Models
{
    public partial class EquipmentSoftware
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int SoftwareId { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Software Software { get; set; }
    }
}