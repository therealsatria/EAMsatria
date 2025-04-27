using System;
using System.Collections.Generic;

namespace EAMsatria.Models
{
    public class Asset : BaseEntity
    {
        public string AssetType { get; set; }
        public string Manufacturer { get; set; }
        public string ModelNumber { get; set; }
        public DateTime InstallationDate { get; set; }
        public string SerialNumber { get; set; }
        public string Location { get; set; }
        public string ComplianceRequirements { get; set; }
        public decimal AcquisitionCost { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime WarrantyExpiration { get; set; }
        public string OperationalStatus { get; set; }
        public string OwnershipStatus { get; set; }

        // Navigation properties
        public Guid ResponsibleUserId { get; set; }
        public virtual User ResponsibleUser { get; set; }
        
        public virtual ICollection<MaintenanceSchedule> MaintenanceSchedules { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<ComplianceStandard> ComplianceStandards { get; set; }
        public virtual ICollection<IoTDevice> IoTDevices { get; set; }
        public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}