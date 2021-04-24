using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.Interfaces
{
    public interface ISoftwareStorage
    {
        List<SoftwareViewModel> GetFullList();
        List<SoftwareViewModel> GetFilteredList(SoftwareBindingModel model);
        SoftwareViewModel GetElement(SoftwareBindingModel model);
        void Insert(SoftwareBindingModel model);
        void Update(SoftwareBindingModel model);
        void Delete(SoftwareBindingModel model);
    }
}