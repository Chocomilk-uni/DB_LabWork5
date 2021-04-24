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
    public class SupplierStorage : ISupplierStorage
    {
        public List<SupplierViewModel> GetFullList()
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                return context.Supplier
                .Select(rec => new SupplierViewModel
                {
                    Id = rec.Id,
                    OrganizationName = rec.OrganizationName,
                    EmployeeName = rec.EmployeeName,
                    Address = rec.Address,
                    PhoneNumber = rec.PhoneNumber
                }).ToList();
            }
        }

        public List<SupplierViewModel> GetFilteredList(SupplierBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                return context.Supplier
                    .Where(rec => rec.OrganizationName.Contains(model.OrganizationName))
                    .Select(rec => new SupplierViewModel
                    {
                        Id = rec.Id,
                        OrganizationName = rec.OrganizationName,
                        EmployeeName = rec.EmployeeName,
                        Address = rec.Address,
                        PhoneNumber = rec.PhoneNumber
                    }).ToList();
            }
        }

        public SupplierViewModel GetElement(SupplierBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                var supplier = context.Supplier
                .FirstOrDefault(rec => rec.Id == model.Id);
                return supplier != null ?
                new SupplierViewModel
                {
                    Id = supplier.Id,
                    OrganizationName = supplier.OrganizationName,
                    EmployeeName = supplier.EmployeeName,
                    Address = supplier.Address,
                    PhoneNumber = supplier.PhoneNumber
                } : null;
            }
        }

        public void Insert(SupplierBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                context.Supplier.Add(CreateModel(model, new Supplier()));
                context.SaveChanges();
            }
        }

        public void Update(SupplierBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                var supplier = context.Supplier.FirstOrDefault(rec => rec.Id == model.Id);

                if (supplier == null)
                {
                    throw new Exception("Поставщик не найден");
                }
                CreateModel(model, supplier);
                context.SaveChanges();
            }
        }

        public void Delete(SupplierBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                Supplier supplier = context.Supplier.FirstOrDefault(rec => rec.Id == model.Id);

                if (supplier != null)
                {
                    context.Supplier.Remove(supplier);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Поставщик не найден");
                }
            }
        }

        private Employee CreateModel(SupplierBindingModel model, Supplier supplier)
        {
            supplier.Or = model.Name;

            return supplier;
        }
    }
}