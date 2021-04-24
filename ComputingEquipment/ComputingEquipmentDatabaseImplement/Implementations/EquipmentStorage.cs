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
    public class EquipmentStoragecs : IEquipmentStorage
    {
        public List<EquipmentViewModel> GetFullList()
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                return context.Equipment
                    .Include(rec => rec.Employee)
                    .Include(rec => rec.Supplier)
                    .Include(rec => rec.Type)
                    .Select(rec => new EquipmentViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name,
                        Specifications = rec.Specifications,
                        ReceiptDate = rec.ReceiptDate,
                        State = rec.State,
                        TypeName = rec.Type.Name,
                        EmployeeName = rec.EmployeeId.HasValue ? rec.Employee.Name : string.Empty,
                        SupplierOrganizationName = rec.Supplier.OrganizationName
                    }).ToList();
            }
        }

        public List<EquipmentViewModel> GetFilteredList(EquipmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                return context.Equipment
                    .Include(rec => rec.Employee)
                    .Include(rec => rec.Supplier)
                    .Include(rec => rec.Type)
                    .Where(rec => rec.Name.Contains(model.Name))
                    .Select(rec => new EquipmentViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name,
                        Specifications = rec.Specifications,
                        ReceiptDate = rec.ReceiptDate,
                        State = rec.State,
                        TypeName = rec.Type.Name,
                        EmployeeName = rec.EmployeeId.HasValue ? rec.Employee.Name : string.Empty,
                        SupplierOrganizationName = rec.Supplier.OrganizationName
                    }).ToList();
            }
        }

        public EquipmentViewModel GetElement(EquipmentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                var equipment = context.Equipment
                    .Include(rec => rec.Employee)
                    .Include(rec => rec.Supplier)
                    .Include(rec => rec.Type)
                    .FirstOrDefault(rec => rec.Id == model.Id);
                return equipment != null ?
                new EquipmentViewModel
                {
                    Id = equipment.Id,
                    Name = equipment.Name,
                    Specifications = equipment.Specifications,
                    ReceiptDate = equipment.ReceiptDate,
                    State = equipment.State,
                    TypeName = equipment.Type.Name,
                    EmployeeName = equipment.EmployeeId.HasValue ? equipment.Employee.Name : string.Empty,
                    SupplierOrganizationName = equipment.Supplier.OrganizationName
                } : null;
            }
        }

        public void Insert(EquipmentBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                context.Equipment.Add(CreateModel(model, new Equipment()));
                context.SaveChanges();
            }
        }

        public void Update(EquipmentBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                var equipment = context.Equipment.FirstOrDefault(rec => rec.Id == model.Id);

                if (equipment == null)
                {
                    throw new Exception("Сотрудник не найден");
                }
                CreateModel(model, equipment);
                context.SaveChanges();
            }
        }

        public void Delete(EquipmentBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                Equipment equipment = context.Equipment.FirstOrDefault(rec => rec.Id == model.Id);

                if (equipment != null)
                {
                    context.Equipment.Remove(equipment);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Техника не найдена");
                }
            }
        }

        private Equipment CreateModel(EquipmentBindingModel model, Equipment equipment, ComputingEquipmentDatabase context)
        {
            equipment.Name = model.Name;
            equipment.Specifications = model.Specifications;
            equipment.ReceiptDate = model.ReceiptDate;
            equipment.State = model.State;
            equipment.TypeId = model.TypeId;
            equipment.EmployeeId = model.EmployeeId;
            equipment.SupplierId = model.SupplierId;

            if (equipment.Id == 0)
            {
                context.Equipment.Add(equipment);
                context.SaveChanges();
            }

            if (model.Id.HasValue)
            {
                List<TravelTour> travelTours = context.TravelTours
                    .Where(rec => rec.TravelID == model.ID.Value).ToList();
                context.TravelTours.RemoveRange(travelTours
                    .Where(rec => !model.TravelTours.ContainsKey(rec.TourID)).ToList());

                List<TravelExcursion> travelExcursions = context.TravelExcursions
                    .Where(rec => rec.TravelID == model.ID.Value).ToList();
                context.TravelExcursions.RemoveRange(travelExcursions
                    .Where(rec => !model.TravelExcursions.ContainsKey(rec.ExcursionID)).ToList());

                context.SaveChanges();

                // Убираем повторы
                foreach (var travelTour in travelTours)
                {
                    if (model.TravelTours.ContainsKey(travelTour.TourID))
                    {
                        model.TravelTours.Remove(travelTour.TourID);
                    }
                }

                foreach (var travelExcursion in travelExcursions)
                {
                    if (model.TravelExcursions.ContainsKey(travelExcursion.ExcursionID))
                    {
                        model.TravelTours.Remove(travelExcursion.ExcursionID);
                    }
                }
                context.SaveChanges();
            }

            foreach (var tt in model.TravelTours)
            {
                context.TravelTours.Add(new TravelTour
                {
                    TravelID = travel.ID,
                    TourID = tt.Key,
                });
                context.SaveChanges();
            }

            foreach (var te in model.TravelExcursions)
            {
                context.TravelExcursions.Add(new TravelExcursion
                {
                    TravelID = travel.ID,
                    ExcursionID = te.Key,
                });
                context.SaveChanges();
            }
            return travel;
        }
    }
}