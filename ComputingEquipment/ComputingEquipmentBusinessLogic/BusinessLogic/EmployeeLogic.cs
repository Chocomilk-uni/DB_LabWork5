using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.BusinessLogic
{
    public class EmployeeLogic
    {
        private readonly IEmployeeStorage employeeStorage;

        public EmployeeLogic(IEmployeeStorage employeeStorage)
        {
            this.employeeStorage = employeeStorage;
        }

        public List<EmployeeViewModel> Read(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return employeeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<EmployeeViewModel> { employeeStorage.GetElement(model) };
            }
            return employeeStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(EmployeeBindingModel model)
        {
            var element = employeeStorage.GetElement(new EmployeeBindingModel { Id = model.Id });

            if (element != null)
            {
                employeeStorage.Update(model);
            }
            else
            {
                employeeStorage.Insert(model);
            }
        }

        public void Delete(EmployeeBindingModel model)
        {
            var element = employeeStorage.GetElement(new EmployeeBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            employeeStorage.Delete(model);
        }
    }
}