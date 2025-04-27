using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EAMsatria.Models;

namespace EAMsatria.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<ComplianceStandard> ComplianceStandards { get; set; }
        public DbSet<MaintenanceLog> MaintenanceLogs { get; set; }
        public DbSet<IoTDevice> IoTDevices { get; set; }
        public DbSet<IoTData> IoTData { get; set; }
        public DbSet<KnowledgeBase> KnowledgeBases { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // USER RELATIONSHIPS

            // User - Asset (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ResponsibleAssets)
                .WithOne(a => a.ResponsibleUser)
                .HasForeignKey(a => a.ResponsibleUserId);

            // User - MaintenanceSchedule (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.AssignedSchedules)
                .WithOne(ms => ms.AssignedToUser)
                .HasForeignKey(ms => ms.AssignedToUserId);

            // User - WorkOrder (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.AssignedWorkOrders)
                .WithOne(wo => wo.AssignedToUser)
                .HasForeignKey(wo => wo.AssignedToUserId);

            // User - MaintenanceLog (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.PerformedMaintenanceLogs)
                .WithOne(ml => ml.PerformedBy)
                .HasForeignKey(ml => ml.PerformedById);

            // User - KnowledgeBase (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ContributedKnowledgeBases)
                .WithOne(kb => kb.CreatedBy)
                .HasForeignKey(kb => kb.CreatedById);

            // User - Budget (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ApprovedBudgets)
                .WithOne(b => b.ApprovedBy)
                .HasForeignKey(b => b.ApprovedById);

            // User - Project (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ManagedProjects)
                .WithOne(p => p.ManagedBy)
                .HasForeignKey(p => p.ManagedById);

            // User - Report (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.CreatedReports)
                .WithOne(r => r.CreatedBy)
                .HasForeignKey(r => r.CreatedById);

            // User - Document (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.UploadedDocuments)
                .WithOne(d => d.UploadedBy)
                .HasForeignKey(d => d.UploadedById);

            // User - Contract (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ManagedContracts)
                .WithOne(c => c.ManagedBy)
                .HasForeignKey(c => c.ManagedById);

            // User - IoTDevice (one-to-many)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ManagedIoTDevices)
                .WithOne(d => d.ManagedBy)
                .HasForeignKey(d => d.ManagedById);

            // ASSET RELATIONSHIPS

            // Asset - MaintenanceSchedule (one-to-many)
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.MaintenanceSchedules)
                .WithOne(ms => ms.Asset)
                .HasForeignKey(ms => ms.AssetId);

            // Asset - WorkOrder (many-to-many)
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.WorkOrders)
                .WithMany()
                .UsingEntity(j => j.ToTable("AssetWorkOrders"));

            // Asset - Document (one-to-many)
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.Documents)
                .WithOne(d => d.Asset)
                .HasForeignKey(d => d.AssetId);

            // Asset - MaintenanceLog (one-to-many)
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.MaintenanceLogs)
                .WithOne(ml => ml.Asset)
                .HasForeignKey(ml => ml.AssetId);

            // Asset - IoTDevice (one-to-many)
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.IoTDevices)
                .WithOne(d => d.Asset)
                .HasForeignKey(d => d.AssetId);

            // Asset - ComplianceStandard (many-to-many)
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.ComplianceStandards)
                .WithMany(cs => cs.Assets)
                .UsingEntity(j => j.ToTable("AssetComplianceStandards"));

            // Asset - Project (many-to-many)
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.Projects)
                .WithMany(p => p.InvolvedAssets)
                .UsingEntity(j => j.ToTable("AssetProjects"));

            // Asset - InventoryItem (many-to-many)
            modelBuilder.Entity<Asset>()
                .HasMany(a => a.InventoryItems)
                .WithMany(ii => ii.Assets)
                .UsingEntity(j => j.ToTable("AssetInventoryItems"));

            // MAINTENANCE SCHEDULE RELATIONSHIPS

            // MaintenanceSchedule - WorkOrder (one-to-many)
            modelBuilder.Entity<MaintenanceSchedule>()
                .HasMany(ms => ms.WorkOrders)
                .WithOne(wo => wo.Schedule)
                .HasForeignKey(wo => wo.ScheduleId);

            // WORK ORDER RELATIONSHIPS

            // WorkOrder - InventoryItem (many-to-many)
            modelBuilder.Entity<WorkOrder>()
                .HasMany(wo => wo.InventoryItems)
                .WithMany(ii => ii.WorkOrders)
                .UsingEntity(j => j.ToTable("WorkOrderInventoryItems"));

            // WorkOrder - Document (one-to-many)
            modelBuilder.Entity<WorkOrder>()
                .HasMany(wo => wo.Documents)
                .WithOne(d => d.WorkOrder)
                .HasForeignKey(d => d.WorkOrderId);

            // WorkOrder - MaintenanceLog (one-to-many)
            modelBuilder.Entity<WorkOrder>()
                .HasMany(wo => wo.MaintenanceLogs)
                .WithOne(ml => ml.WorkOrder)
                .HasForeignKey(ml => ml.WorkOrderId);

            // WorkOrder - IoTData (many-to-many)
            modelBuilder.Entity<WorkOrder>()
                .HasMany(wo => wo.IoTData)
                .WithMany()
                .UsingEntity(j => j.ToTable("WorkOrderIoTData"));

            // INVENTORY ITEM RELATIONSHIPS

            // InventoryItem - Supplier (many-to-one)
            modelBuilder.Entity<InventoryItem>()
                .HasOne(ii => ii.Supplier)
                .WithMany(s => s.InventoryItems)
                .HasForeignKey(ii => ii.SupplierId);

            // InventoryItem - Contract (many-to-many)
            modelBuilder.Entity<InventoryItem>()
                .HasMany(ii => ii.Contracts)
                .WithMany(c => c.IncludedInventoryItems)
                .UsingEntity(j => j.ToTable("InventoryItemContracts"));

            // SUPPLIER RELATIONSHIPS

            // Supplier - Contract (one-to-many)
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Contracts)
                .WithOne(c => c.Supplier)
                .HasForeignKey(c => c.SupplierId);

            // DOCUMENT RELATIONSHIPS

            // Document - KnowledgeBase (many-to-many)
            modelBuilder.Entity<Document>()
                .HasMany(d => d.KnowledgeBases)
                .WithMany(kb => kb.Documents)
                .UsingEntity(j => j.ToTable("DocumentKnowledgeBases"));

            // COMPLIANCE STANDARD RELATIONSHIPS
            // (already defined in other entities)

            // MAINTENANCE LOG RELATIONSHIPS

            // MaintenanceLog - IoTData (many-to-many)
            modelBuilder.Entity<MaintenanceLog>()
                .HasMany(ml => ml.IoTData)
                .WithMany(id => id.MaintenanceLogs)
                .UsingEntity(j => j.ToTable("MaintenanceLogIoTData"));

            // IOT DEVICE RELATIONSHIPS

            // IoTDevice - IoTData (one-to-many)
            modelBuilder.Entity<IoTDevice>()
                .HasMany(d => d.IoTData)
                .WithOne(data => data.Device)
                .HasForeignKey(data => data.DeviceId);

            // IOT DATA RELATIONSHIPS

            // IoTData - Report (many-to-many)
            modelBuilder.Entity<IoTData>()
                .HasMany(id => id.Reports)
                .WithMany(r => r.IncludedIoTData)
                .UsingEntity(j => j.ToTable("IoTDataReports"));

            // KNOWLEDGE BASE RELATIONSHIPS

            // KnowledgeBase - Asset (many-to-many)
            modelBuilder.Entity<KnowledgeBase>()
                .HasMany(kb => kb.SupportedAssets)
                .WithMany()
                .UsingEntity(j => j.ToTable("KnowledgeBaseAssets"));

            // KnowledgeBase - WorkOrder (many-to-many)
            modelBuilder.Entity<KnowledgeBase>()
                .HasMany(kb => kb.GuidedWorkOrders)
                .WithMany()
                .UsingEntity(j => j.ToTable("KnowledgeBaseWorkOrders"));

            // BUDGET RELATIONSHIPS

            // Budget - Asset (many-to-many)
            modelBuilder.Entity<Budget>()
                .HasMany(b => b.AllocatedAssets)
                .WithMany()
                .UsingEntity(j => j.ToTable("BudgetAssets"));

            // Budget - WorkOrder (many-to-many)
            modelBuilder.Entity<Budget>()
                .HasMany(b => b.TrackedWorkOrders)
                .WithMany()
                .UsingEntity(j => j.ToTable("BudgetWorkOrders"));

            // Budget - InventoryItem (many-to-many)
            modelBuilder.Entity<Budget>()
                .HasMany(b => b.AccountedInventoryItems)
                .WithMany()
                .UsingEntity(j => j.ToTable("BudgetInventoryItems"));

            // Budget - Project (many-to-many)
            modelBuilder.Entity<Budget>()
                .HasMany(b => b.FundedProjects)
                .WithMany(p => p.LinkedBudgets)
                .UsingEntity(j => j.ToTable("BudgetProjects"));

            // PROJECT RELATIONSHIPS

            // Project - WorkOrder (many-to-many)
            modelBuilder.Entity<Project>()
                .HasMany(p => p.GeneratedWorkOrders)
                .WithMany()
                .UsingEntity(j => j.ToTable("ProjectWorkOrders"));

            // Project - Document (many-to-many)
            modelBuilder.Entity<Project>()
                .HasMany(p => p.Documents)
                .WithMany()
                .UsingEntity(j => j.ToTable("ProjectDocuments"));

            // REPORT RELATIONSHIPS

            // Report - Asset (many-to-many)
            modelBuilder.Entity<Report>()
                .HasMany(r => r.ReportedAssets)
                .WithMany()
                .UsingEntity(j => j.ToTable("ReportAssets"));

            // Report - WorkOrder (many-to-many)
            modelBuilder.Entity<Report>()
                .HasMany(r => r.SummarizedWorkOrders)
                .WithMany()
                .UsingEntity(j => j.ToTable("ReportWorkOrders"));

            // Report - Budget (many-to-many)
            modelBuilder.Entity<Report>()
                .HasMany(r => r.AnalyzedBudgets)
                .WithMany()
                .UsingEntity(j => j.ToTable("ReportBudgets"));

            // Report - Project (many-to-many)
            modelBuilder.Entity<Report>()
                .HasMany(r => r.EvaluatedProjects)
                .WithMany()
                .UsingEntity(j => j.ToTable("ReportProjects"));

            // CONTRACT RELATIONSHIPS

            // Contract - Asset (many-to-many)
            modelBuilder.Entity<Contract>()
                .HasMany(c => c.CoveredAssets)
                .WithMany()
                .UsingEntity(j => j.ToTable("ContractAssets"));

            // Contract - Document (many-to-many)
            modelBuilder.Entity<Contract>()
                .HasMany(c => c.Documents)
                .WithMany()
                .UsingEntity(j => j.ToTable("ContractDocuments"));
        }
    }
}
