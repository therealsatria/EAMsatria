using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class MaintenanceLog : BaseEntity
{
    public DateTime MaintenanceDate { get; set; }
    public int? MeterReading { get; set; }
    public string IssuesFound { get; set; }
    public string ActionsTaken { get; set; }
    public decimal LaborHours { get; set; }
    public decimal MaterialCost { get; set; }
    public string QualityAssurance { get; set; }
    public string EnvironmentalConditions { get; set; }
    
    // Foreign keys
    public Guid AssetId { get; set; }
    public Guid? WorkOrderId { get; set; }
    public Guid PerformedById { get; set; }
    
    // Navigation properties
    public virtual Asset Asset { get; set; }
    public virtual WorkOrder WorkOrder { get; set; }
    public virtual User PerformedBy { get; set; }
    public virtual ICollection<IoTData> IoTData { get; set; }
} 