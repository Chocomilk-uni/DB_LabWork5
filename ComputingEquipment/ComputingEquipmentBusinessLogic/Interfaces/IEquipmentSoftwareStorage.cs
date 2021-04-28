using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.Interfaces
{
    public interface IEquipmentSoftwareStorage
    {
        List<EquipmentSoftwareViewModel> GetFullList();
        List<EquipmentSoftwareViewModel> GetFilteredList(EquipmentSoftwareBindingModel model);
        EquipmentSoftwareViewModel GetElement(EquipmentSoftwareBindingModel model);
        void Insert(EquipmentSoftwareBindingModel model);
        void Update(EquipmentSoftwareBindingModel model);
        void Delete(EquipmentSoftwareBindingModel model);
    }
}