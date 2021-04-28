using System;
using System.ComponentModel;

namespace ComputingEquipmentBusinessLogic.ViewModels
{
    public class EquipmentViewModel
    {
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Характеристики")]
        public string Specifications { get; set; }

        [DisplayName("Дата получения")]
        public DateTime ReceiptDate { get; set; }

        [DisplayName("Состояние")]
        public string State { get; set; }

        [DisplayName("Тип")]
        public string TypeName { get; set; }

        [DisplayName("Ответственный сотрудник")]
        public string EmployeeName { get; set; }

        [DisplayName("Поставщик")]
        public string SupplierOrganizationName { get; set; }

        public int TypeId { get; set; }
        public int? EmployeeId { get; set; }
        public int SupplierId { get; set; }
    }
}