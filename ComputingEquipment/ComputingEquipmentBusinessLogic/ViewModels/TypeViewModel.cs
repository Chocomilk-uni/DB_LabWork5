using System.ComponentModel;

namespace ComputingEquipmentBusinessLogic.ViewModels
{
    public class TypeViewModel
    {
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }
    }
}