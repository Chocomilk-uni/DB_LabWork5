using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.Interfaces
{
    public interface ITypeStorage
    {
        List<TypeViewModel> GetFullList();
        List<TypeViewModel> GetFilteredList(TypeBindingModel model);
        TypeViewModel GetElement(TypeBindingModel model);
        void Insert(TypeBindingModel model);
        void Update(TypeBindingModel model);
        void Delete(TypeBindingModel model);
    }
}