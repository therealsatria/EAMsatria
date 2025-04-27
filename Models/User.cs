using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Role { get; set; }
    public string Department { get; set; }
    public string ContactInfo { get; set; }
    public DateTime LastLogin { get; set; }

    // Navigation properties
    public virtual ICollection<Asset> ResponsibleAssets { get; set; }
    public virtual ICollection<MaintenanceSchedule> AssignedSchedules { get; set; }
    public virtual ICollection<WorkOrder> AssignedWorkOrders { get; set; }
    public virtual ICollection<MaintenanceLog> PerformedMaintenanceLogs { get; set; }
    public virtual ICollection<KnowledgeBase> ContributedKnowledgeBases { get; set; }
    public virtual ICollection<Budget> ApprovedBudgets { get; set; }
    public virtual ICollection<Project> ManagedProjects { get; set; }
    public virtual ICollection<Report> CreatedReports { get; set; }
    public virtual ICollection<Document> UploadedDocuments { get; set; }
    public virtual ICollection<Contract> ManagedContracts { get; set; }
    public virtual ICollection<IoTDevice> ManagedIoTDevices { get; set; }
}