using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class IoTData : BaseEntity
{
    public DateTime Timestamp { get; set; }
    public decimal Value { get; set; }
    public string DataType { get; set; }
    public string UnitOfMeasure { get; set; }
    public string Status { get; set; }
    public string AnomalyDetection { get; set; }
    public string PredictiveAlert { get; set; }
    
    // Foreign keys
    public Guid DeviceId { get; set; }
    public Guid AssetId { get; set; }
    
    // Navigation properties
    public virtual IoTDevice Device { get; set; }
    public virtual Asset Asset { get; set; }
    public virtual ICollection<MaintenanceLog> MaintenanceLogs { get; set; }
    public virtual ICollection<Report> Reports { get; set; }
} 