using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.BusinessLogic
{
    public class SoftwareLogic
    {
        private readonly ISoftwareStorage softwareStorage;

        public SoftwareLogic(ISoftwareStorage softwareStorage)
        {
            this.softwareStorage = softwareStorage;
        }

        public List<SoftwareViewModel> Read(SoftwareBindingModel model)
        {
            if (model == null)
            {
                return softwareStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SoftwareViewModel> { softwareStorage.GetElement(model) };
            }
            return softwareStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SoftwareBindingModel model)
        {
            var element = softwareStorage.GetElement(new SoftwareBindingModel { Id = model.Id });

            if (element != null)
            {
                softwareStorage.Update(model);
            }
            else
            {
                softwareStorage.Insert(model);
            }
        }

        public void Delete(SoftwareBindingModel model)
        {
            var element = softwareStorage.GetElement(new SoftwareBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            softwareStorage.Delete(model);
        }
    }
}