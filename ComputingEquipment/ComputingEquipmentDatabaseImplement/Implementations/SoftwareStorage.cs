using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentBusinessLogic.ViewModels;
using ComputingEquipmentDatabaseImplement.DatabaseContext;
using ComputingEquipmentDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputingEquipmentDatabaseImplement.Implementations
{
    public class SoftwareStorage : ISoftwareStorage
    {
        public List<SoftwareViewModel> GetFullList()
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                return context.Software
                .Select(rec => new SoftwareViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name,
                    License_type = rec.LicenseType
                }).ToList();
            }
        }

        public List<SoftwareViewModel> GetFilteredList(SoftwareBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                return context.Software
                    .Where(rec => rec.Name.Contains(model.Name))
                    .Select(rec => new SoftwareViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name
                    }).ToList();
            }
        }

        public SoftwareViewModel GetElement(SoftwareBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                var software = context.Software
                .FirstOrDefault(rec => rec.Id == model.Id);
                return software != null ?
                new SoftwareViewModel
                {
                    Id = software.Id,
                    Name = software.Name,
                } : null;
            }
        }

        public void Insert(SoftwareBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                context.Software.Add(CreateModel(model, new Software()));
                context.SaveChanges();
            }
        }

        public void Update(SoftwareBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                var software = context.Software.FirstOrDefault(rec => rec.Id == model.Id);

                if (software == null)
                {
                    throw new Exception("ПО не найдено");
                }
                CreateModel(model, software);
                context.SaveChanges();
            }
        }

        public void Delete(SoftwareBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                Software software = context.Software.FirstOrDefault(rec => rec.Id == model.Id);

                if (software != null)
                {
                    context.Software.Remove(software);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("ПО не найдено");
                }
            }
        }

        private Software CreateModel(SoftwareBindingModel model, Software software)
        {
            software.Name = model.Name;
            return software;
        }
    }
}