using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.BusinessLogic
{
    public class SupplierLogic
    {
        private readonly ISupplierStorage supplierStorage;

        public SupplierLogic(ISupplierStorage supplierStorage)
        {
            this.supplierStorage = supplierStorage;
        }

        public List<SupplierViewModel> Read(SupplierBindingModel model)
        {
            if (model == null)
            {
                return supplierStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<SupplierViewModel> { supplierStorage.GetElement(model) };
            }
            return supplierStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(SupplierBindingModel model)
        {
            var element = supplierStorage.GetElement(new SupplierBindingModel { Id = model.Id });

            if (element != null)
            {
                supplierStorage.Update(model);
            }
            else
            {
                supplierStorage.Insert(model);
            }
        }

        public void Delete(SupplierBindingModel model)
        {
            var element = supplierStorage.GetElement(new SupplierBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            supplierStorage.Delete(model);
        }
    }
}