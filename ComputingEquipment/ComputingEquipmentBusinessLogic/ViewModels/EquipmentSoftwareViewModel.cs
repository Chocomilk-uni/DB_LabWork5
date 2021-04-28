using System.ComponentModel;

namespace ComputingEquipmentBusinessLogic.ViewModels
{
    public class EquipmentSoftwareViewModel
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public int SoftwareId { get; set; }

        [DisplayName("Тип техники")]
        public string EquipmentType { get; set; }

        [DisplayName("Техника")]
        public string EquipmentName { get; set; }

        [DisplayName("ПО")]
        public string SoftwareName { get; set; }
    }
}