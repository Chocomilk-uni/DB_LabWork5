using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.Interfaces
{
    public interface ISupplierStorage
    {
        List<SupplierViewModel> GetFullList();
        List<SupplierViewModel> GetFilteredList(SupplierBindingModel model);
        SupplierViewModel GetElement(SupplierBindingModel model);
        void Insert(SupplierBindingModel model);
        void Update(SupplierBindingModel model);
        void Delete(SupplierBindingModel model);
    }
}