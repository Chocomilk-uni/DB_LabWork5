using System;

namespace ComputingEquipmentBusinessLogic.BindingModels
{
    public class EquipmentBindingModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Specifications { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string State { get; set; }
        public int TypeId { get; set; }
        public int? EmployeeId { get; set; }
        public int SupplierId { get; set; }

        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }
}