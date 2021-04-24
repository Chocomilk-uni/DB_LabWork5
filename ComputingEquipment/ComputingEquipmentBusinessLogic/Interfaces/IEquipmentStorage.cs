using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.Interfaces
{
    public interface IEquipmentStorage
    {
        List<EquipmentViewModel> GetFullList();
        List<EquipmentViewModel> GetFilteredList(EquipmentBindingModel model);
        EquipmentViewModel GetElement(EquipmentBindingModel model);
        void Insert(EquipmentBindingModel model);
        void Update(EquipmentBindingModel model);
        void Delete(EquipmentBindingModel model);
    }
}