using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.BusinessLogic
{
    public class EquipmentLogic
    {
        private readonly IEquipmentStorage equipmentStorage;

        public EquipmentLogic(IEquipmentStorage equipmentStorage)
        {
            this.equipmentStorage = equipmentStorage;
        }

        public List<EquipmentViewModel> Read(EquipmentBindingModel model)
        {
            if (model == null)
            {
                return equipmentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EquipmentViewModel> { equipmentStorage.GetElement(model) };
            }
            return equipmentStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(EquipmentBindingModel model)
        {
            var element = equipmentStorage.GetElement(new EquipmentBindingModel { Id = model.Id });

            if (element != null)
            {
                equipmentStorage.Update(model);
            }
            else
            {
                equipmentStorage.Insert(model);
            }
        }

        public void Delete(EquipmentBindingModel model)
        {
            var element = equipmentStorage.GetElement(new EquipmentBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            equipmentStorage.Delete(model);
        }
    }
}