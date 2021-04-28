using ComputingEquipmentBusinessLogic.BusinessLogic;
using ComputingEquipmentBusinessLogic.Interfaces;
using ComputingEquipmentDatabaseImplement.Implementations;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace ComputingEquipmentView
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IEmployeeStorage, EmployeeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEquipmentStorage, EquipmentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISoftwareStorage, SoftwareStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ISupplierStorage, SupplierStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ITypeStorage, TypeStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEquipmentSoftwareStorage, EquipmentSoftwareStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<EmployeeLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<EquipmentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<SoftwareLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<SupplierLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<TypeLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<EquipmentSoftwareLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}