using System;
using System.Collections.Generic;

namespace EAMsatria.Models
{
    public class WorkOrder : BaseEntity
    {
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public decimal ActualHours { get; set; }
        public decimal LaborCost { get; set; }
        public string WorkType { get; set; }
        public string ApprovalStatus { get; set; }
        public string SafetyIncidents { get; set; }
        public string QualityCheckResults { get; set; }
        
        // Foreign keys
        public Guid ScheduleId { get; set; }
        public Guid AssignedToUserId { get; set; }
        
        // Navigation properties
        public virtual MaintenanceSchedule Schedule { get; set; }
        public virtual User AssignedToUser { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; }
        public virtual ICollection<IoTData> IoTData { get; set; }
    }
}