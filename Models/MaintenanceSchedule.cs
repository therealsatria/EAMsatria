using System;
using System.Collections.Generic;

namespace EAMsatria.Models
{
    public class MaintenanceSchedule : BaseEntity
    {
        public string ScheduleType { get; set; }
        public string Frequency { get; set; }
        public DateTime NextDueDate { get; set; }
        public string MaintenanceType { get; set; }
        public string PriorityLevel { get; set; }
        public string RequiredTools { get; set; }
        public string SafetyPrecautions { get; set; }
        
        // Foreign keys
        public Guid AssetId { get; set; }
        public Guid AssignedToUserId { get; set; }
        
        // Navigation properties
        public virtual Asset Asset { get; set; }
        public virtual User AssignedToUser { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public DateTime NextMaintenanceDate { get; internal set; }
    }
}