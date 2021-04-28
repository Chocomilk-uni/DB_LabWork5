using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.BusinessLogic
{
    public class EquipmentSoftwareLogic
    {
        private readonly IEquipmentSoftwareStorage eqSoftStorage;

        public EquipmentSoftwareLogic(IEquipmentSoftwareStorage eqSoftStorage)
        {
            this.eqSoftStorage = eqSoftStorage;
        }

        public List<EquipmentSoftwareViewModel> Read(EquipmentSoftwareBindingModel model)
        {
            if (model == null)
            {
                return eqSoftStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EquipmentSoftwareViewModel> { eqSoftStorage.GetElement(model) };
            }
            return eqSoftStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(EquipmentSoftwareBindingModel model)
        {
            var element = eqSoftStorage.GetElement(new EquipmentSoftwareBindingModel { Id = model.Id });

            var list = eqSoftStorage.GetFilteredList(new EquipmentSoftwareBindingModel
            {
                EquipmentId = model.EquipmentId,
                SoftwareId = model.SoftwareId
            });
            if (list != null && list[0].Id != model.Id)
            {
                throw new Exception("Данное ПО уже установлено на выбранный образец вычислительной техники");
            }

            if (element != null)
            {
                eqSoftStorage.Update(model);
            }
            else
            { 
                eqSoftStorage.Insert(model);
            }
        }

        public void Delete(EquipmentSoftwareBindingModel model)
        {
            var element = eqSoftStorage.GetElement(new EquipmentSoftwareBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            eqSoftStorage.Delete(model);
        }
    }
}