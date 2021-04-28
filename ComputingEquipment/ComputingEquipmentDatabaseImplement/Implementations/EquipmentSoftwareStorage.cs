using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentBusinessLogic.ViewModels;
using ComputingEquipmentDatabaseImplement.DatabaseContext;
using ComputingEquipmentDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputingEquipmentDatabaseImplement.Implementations
{
    public class EquipmentSoftwareStorage : IEquipmentSoftwareStorage
    {
        public List<EquipmentSoftwareViewModel> GetFullList()
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                return context.EquipmentSoftware
                    .Include(rec => rec.Software)
                    .Include(rec => rec.Equipment)
                    .ThenInclude(rec => rec.Type)
                    .Select(rec => new EquipmentSoftwareViewModel
                    {
                        Id = rec.Id,
                        EquipmentId = rec.EquipmentId,
                        SoftwareId = rec.SoftwareId,
                        EquipmentName = rec.Equipment.Name,
                        SoftwareName = rec.Software.Name,
                        EquipmentType = rec.Equipment.Type.Name
                    }).ToList();
            }
        }

        public List<EquipmentSoftwareViewModel> GetFilteredList(EquipmentSoftwareBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                return context.EquipmentSoftware
                    .Include(rec => rec.Software)
                    .Include(rec => rec.Equipment)
                    .ThenInclude(rec => rec.Type)
                    .Where(rec => rec.SoftwareId == model.SoftwareId && rec.EquipmentId == model.EquipmentId)
                    .Select(rec => new EquipmentSoftwareViewModel
                    {
                        Id = rec.Id,
                        EquipmentId = rec.EquipmentId,
                        SoftwareId = rec.SoftwareId,
                        EquipmentName = rec.Equipment.Name,
                        SoftwareName = rec.Software.Name,
                        EquipmentType = rec.Equipment.Type.Name
                    }).ToList();
            }
        }

        public EquipmentSoftwareViewModel GetElement(EquipmentSoftwareBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                var eqSoft = context.EquipmentSoftware
                    .Include(rec => rec.Software)
                    .Include(rec => rec.Equipment)
                    .ThenInclude(rec => rec.Type)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return eqSoft != null ?
                new EquipmentSoftwareViewModel
                {
                    Id = eqSoft.Id,
                    SoftwareId = eqSoft.SoftwareId,
                    EquipmentId = eqSoft.EquipmentId,
                    SoftwareName = eqSoft.Software.Name,
                    EquipmentName = eqSoft.Equipment.Name,
                    EquipmentType = eqSoft.Equipment.Type.Name
                } : null;
            }
        }

        public void Insert(EquipmentSoftwareBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                context.EquipmentSoftware.Add(CreateModel(model, new EquipmentSoftware()));
                context.SaveChanges();
            }
        }

        public void Update(EquipmentSoftwareBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                var eqSoft = context.EquipmentSoftware.FirstOrDefault(rec => rec.Id == model.Id);

                if (eqSoft == null)
                {
                    throw new Exception("Данная пара \"Техника - ПО\" не найдена");
                }
                CreateModel(model, eqSoft);
                context.SaveChanges();
            }
        }

        public void Delete(EquipmentSoftwareBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                EquipmentSoftware eqSoft = context.EquipmentSoftware.FirstOrDefault(rec => rec.Id == model.Id);

                if (eqSoft != null)
                {
                    context.EquipmentSoftware.Remove(eqSoft);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Данная пара \"Техника - ПО\" не найдена");
                }
            }
        }

        private EquipmentSoftware CreateModel(EquipmentSoftwareBindingModel model, EquipmentSoftware eqSoft)
        {
            eqSoft.SoftwareId = model.SoftwareId;
            eqSoft.EquipmentId = model.EquipmentId;

            return eqSoft;
        }
    }
}