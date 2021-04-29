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
    public class EquipmentStorage : IEquipmentStorage
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
                        TypeId = rec.TypeId,
                        EmployeeId = rec.EmployeeId,
                        SupplierId = rec.SupplierId,
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
                    .Where(rec => model.DateFrom.HasValue && model.DateTo.HasValue && rec.ReceiptDate >= model.DateFrom.Value.Date && rec.ReceiptDate <= model.DateTo.Value.Date)
                    .Select(rec => new EquipmentViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name,
                        Specifications = rec.Specifications,
                        ReceiptDate = rec.ReceiptDate,
                        State = rec.State,
                        TypeId = rec.TypeId,
                        EmployeeId = rec.EmployeeId,
                        SupplierId = rec.SupplierId,
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
                    TypeId = equipment.TypeId,
                    SupplierId = equipment.SupplierId,
                    EmployeeId = equipment.EmployeeId,
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

        private Equipment CreateModel(EquipmentBindingModel model, Equipment equipment)
        {
            equipment.Name = model.Name;
            equipment.Specifications = model.Specifications;
            equipment.ReceiptDate = model.ReceiptDate;
            equipment.State = model.State;
            equipment.TypeId = model.TypeId;
            equipment.EmployeeId = model.EmployeeId;
            equipment.SupplierId = model.SupplierId;

            return equipment;
        }
    }
}