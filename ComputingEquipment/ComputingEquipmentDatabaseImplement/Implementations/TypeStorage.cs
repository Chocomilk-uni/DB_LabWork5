using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentBusinessLogic.ViewModels;
using ComputingEquipmentDatabaseImplement.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingEquipmentDatabaseImplement.Implementations
{
    class TypeStorage : ITypeStorage
    {
        public List<TypeViewModel> GetFullList()
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                return context.Type
                .Select(rec => new TypeViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name
                }).ToList();
            }
        }

        public List<TypeViewModel> GetFilteredList(TypeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                return context.Type
                    .Where(rec => rec.Name.Contains(model.Name))
                    .Select(rec => new TypeViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name
                    }).ToList();
            }
        }

        public TypeViewModel GetElement(TypeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                var type = context.Type
                .FirstOrDefault(rec => rec.Id == model.Id);
                return type != null ?
                new TypeViewModel
                {
                    Id = type.Id,
                    Name = type.Name,
                } : null;
            }
        }

        public void Insert(TypeBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                context.Type.Add(CreateModel(model, new Type()));
                context.SaveChanges();
            }
        }

        public void Update(TypeBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                var type = context.Type.FirstOrDefault(rec => rec.Id == model.Id);

                if (type == null)
                {
                    throw new Exception("Тип не найден");
                }
                CreateModel(model, type);
                context.SaveChanges();
            }
        }

        public void Delete(TypeBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                Models.Type type = context.Type.FirstOrDefault(rec => rec.Id == model.Id);

                if (type != null)
                {
                    context.Type.Remove(type);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Тип не найден");
                }
            }
        }

        private Models.Type CreateModel(TypeBindingModel model, Models.Type type)
        {
            type.Name = model.Name;

            return type;
        }
    }
}