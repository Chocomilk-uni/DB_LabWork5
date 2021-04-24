using System.ComponentModel;

namespace ComputingEquipmentBusinessLogic.ViewModels
{
    public class SoftwareViewModel
    {
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Тип лицензии")]
        public string License_type { get; set; }
    }
}