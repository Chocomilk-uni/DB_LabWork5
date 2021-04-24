using System.ComponentModel;

namespace ComputingEquipmentBusinessLogic.ViewModels
{
    public class SupplierViewModel
    {
        public int Id { get; set; }

        [DisplayName("Название организации")]
        public string OrganizationName { get; set; }

        [DisplayName("ФИО работника")]
        public string EmployeeName { get; set; }

        [DisplayName("Адрес")]
        public string Address { get; set; }

        [DisplayName("Телефон")]
        public string PhoneNumber { get; set; }
    }
}