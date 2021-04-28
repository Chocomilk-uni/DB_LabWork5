using System;
using Microsoft.EntityFrameworkCore;
using ComputingEquipmentDatabaseImplement.Models;
using System.IO; 
using System.Text;


namespace ComputingEquipmentDatabaseImplement.DatabaseContext
{
    public partial class ComputingEquipmentDatabase : DbContext
    {
        const string CONFIG_FILE_ADDRESS = "C:/Users/Chocomilk/source/repos/DB_LabWork5/ComputingEquipment/config.txt";
        public ComputingEquipmentDatabase()
        {
        }

        public ComputingEquipmentDatabase(DbContextOptions<ComputingEquipmentDatabase> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentSoftware> EquipmentSoftware { get; set; }
        public virtual DbSet<Software> Software { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Models.Type> Type { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(GetConnectionString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasComment("Таблица для хранения информации о сотрудниках предприятия, отвечающих за вычислительную технику");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Суррогатный ключ");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .HasComment("ФИО");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.ToTable("equipment");

                entity.HasComment("Таблица для хранения информации о вычислительной технике");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Суррогатный ключ");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("employee_id")
                    .HasComment("Внешний ключ (сотрудник)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .HasComment("Наименование");

                entity.Property(e => e.ReceiptDate)
                    .HasColumnName("receipt_date")
                    .HasColumnType("date")
                    .HasDefaultValueSql("now()")
                    .HasComment("Дата получения");

                entity.Property(e => e.Specifications)
                    .IsRequired()
                    .HasColumnName("specifications")
                    .HasMaxLength(130)
                    .HasComment("Характеристики");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(12)
                    .HasDefaultValueSql("'На складе'::character varying")
                    .HasComment("Состояние");

                entity.Property(e => e.SupplierId)
                    .HasColumnName("supplier_id")
                    .HasComment("Внешний ключ (поставщик)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasComment("Внешний ключ (тип)");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("equipment_employee_id_fkey");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("equipment_supplier_id_fkey");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("equipment_type_id_fkey");
            });

            modelBuilder.Entity<EquipmentSoftware>(entity =>
            {
                entity.ToTable("equipment_software");

                entity.HasComment("Таблица для хранения информации об установленном на образцах вычислительной техники ПО");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Суррогатный ключ");

                entity.Property(e => e.EquipmentId)
                    .HasColumnName("equipment_id")
                    .HasComment("Внешний ключ (техника)");

                entity.Property(e => e.SoftwareId)
                    .HasColumnName("software_id")
                    .HasComment("Внешний ключ (ПО)");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.EquipmentSoftware)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("equipment_software_equipment_id_fkey");

                entity.HasOne(d => d.Software)
                    .WithMany(p => p.EquipmentSoftware)
                    .HasForeignKey(d => d.SoftwareId)
                    .HasConstraintName("equipment_software_software_id_fkey");
            });

            modelBuilder.Entity<Software>(entity =>
            {
                entity.ToTable("software");

                entity.HasComment("Таблица для хранения информации о ПО");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Суррогатный ключ");

                entity.Property(e => e.LicenseType)
                    .IsRequired()
                    .HasColumnName("license_type")
                    .HasMaxLength(20)
                    .HasComment("Тип лицензии");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(60)
                    .HasComment("Наименование");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.HasComment("Таблица для хранения информации о поставщиках вычислительной техники");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Суррогатный ключ");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .HasComment("Адрес");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasColumnName("employee_name")
                    .HasMaxLength(30)
                    .HasComment("ФИО работника");

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasColumnName("organization_name")
                    .HasMaxLength(30)
                    .HasComment("Название организации");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasColumnName("phone_number")
                    .HasMaxLength(12)
                    .HasComment("Номер телефона");
            });

            modelBuilder.Entity<Models.Type>(entity =>
            {
                entity.ToTable("type");

                entity.HasComment("Таблица для хранения информации о типах вычислительной техники");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Суррогатный ключ");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .HasComment("Наименование");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private string GetConnectionString()
        {
            if (File.Exists(CONFIG_FILE_ADDRESS))
            {
                if (!CheckConfigFile(CONFIG_FILE_ADDRESS))
                {
                    throw new Exception("Неверный формат файла конфигурации");
                }
                StringBuilder str = new StringBuilder();
                using (StreamReader sr = new StreamReader(CONFIG_FILE_ADDRESS))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        str.Append(line);
                    }
                }
                Console.WriteLine(str.ToString());
                return str.ToString();
            }
            else
            {
                throw new Exception("Файл конфигурации не найден");
            }
        }

        private bool CheckConfigFile(string fileAddress)
        {
            int count = 0;
            using (StreamReader sr = new StreamReader(fileAddress))
            {
                while (sr.ReadLine() != null)
                {
                    count++;
                }
            }
            return count == 5 ? true : false;
        }
    }
}