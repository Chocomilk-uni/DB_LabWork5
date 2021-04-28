namespace ComputingEquipmentBusinessLogic.BindingModels
{
    public class EquipmentSoftwareBindingModel
    {
        public int? Id { get; set; }
        public int EquipmentId { get; set; }
        public int SoftwareId { get; set; }
    }
}