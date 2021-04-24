using System.ComponentModel;

namespace ComputingEquipmentBusinessLogic.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [DisplayName("ФИО")]
        public string Name { get; set; }
    }
}