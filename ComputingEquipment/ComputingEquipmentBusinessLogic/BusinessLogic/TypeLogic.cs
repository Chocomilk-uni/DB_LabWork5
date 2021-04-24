using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;

namespace ComputingEquipmentBusinessLogic.BusinessLogic
{
    public class TypeLogic
    {
        private readonly ITypeStorage typeStorage;

        public TypeLogic(ITypeStorage typeStorage)
        {
            this.typeStorage = typeStorage;
        }

        public List<TypeViewModel> Read(TypeBindingModel model)
        {
            if (model == null)
            {
                return typeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TypeViewModel> { typeStorage.GetElement(model) };
            }
            return typeStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(TypeBindingModel model)
        {
            var element = typeStorage.GetElement(new TypeBindingModel { Name = model.Name });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть тип с таким названием");
            }
            if (model.Id.HasValue)
            {
                typeStorage.Update(model);
            }
            else
            {
                typeStorage.Insert(model);
            }
        }

        public void Delete(TypeBindingModel model)
        {
            var element = typeStorage.GetElement(new TypeBindingModel { Id = model.Id });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            typeStorage.Delete(model);
        }
    }
}