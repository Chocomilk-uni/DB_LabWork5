using ComputingEquipmentBusinessLogic.BindingModels;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentBusinessLogic.ViewModels;
using ComputingEquipmentDatabaseImplement.DatabaseContext;
using ComputingEquipmentDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComputingEquipmentDatabaseImplement.Implementations
{
    public class EmployeeStorage : IEmployeeStorage
    {
        public List<EmployeeViewModel> GetFullList()
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                return context.Employee
                .Select(rec => new EmployeeViewModel
                {
                    Id = rec.Id,
                    Name = rec.Name
                }).ToList();
            }
        }

        public List<EmployeeViewModel> GetFilteredList(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                return context.Employee
                    .Where(rec => rec.Name.Contains(model.Name))
                    .Select(rec => new EmployeeViewModel
                    {
                        Id = rec.Id,
                        Name = rec.Name
                    }).ToList();
            }
        }

        public EmployeeViewModel GetElement(EmployeeBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new ComputingEquipmentDatabase())
            {
                var employee = context.Employee
                .FirstOrDefault(rec => rec.Id == model.Id);
                return employee != null ?
                new EmployeeViewModel
                {
                    Id = employee.Id,
                    Name = employee.Name,
                } : null;
            }
        }

        public void Insert(EmployeeBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                context.Employee.Add(CreateModel(model, new Employee()));
                context.SaveChanges();
            }
        }

        public void Update(EmployeeBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                var employee = context.Employee.FirstOrDefault(rec => rec.Id == model.Id);

                if (employee == null)
                {
                    throw new Exception("Сотрудник не найден");
                }
                CreateModel(model, employee);
                context.SaveChanges();
            }
        }

        public void Delete(EmployeeBindingModel model)
        {
            using (var context = new ComputingEquipmentDatabase())
            {
                Employee employee = context.Employee.FirstOrDefault(rec => rec.Id == model.Id);

                if (employee != null)
                {
                    context.Employee.Remove(employee);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Сотрудник не найден");
                }
            }
        }

        private Employee CreateModel(EmployeeBindingModel model, Employee employee)
        {
            employee.Name = model.Name;
            return employee;
        }
    }
}