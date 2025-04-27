using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class IoTDevice : BaseEntity
{
    public string DeviceType { get; set; }
    public string Manufacturer { get; set; }
    public string ModelNumber { get; set; }
    public string SerialNumber { get; set; }
    public string InstallationLocation { get; set; }
    public string CommunicationProtocol { get; set; }
    public string DataSamplingRate { get; set; }
    public DateTime LastCalibrationDate { get; set; }
    public string MaintenanceSchedule { get; set; }
    public bool IsActive { get; set; }
    
    // Foreign keys
    public Guid? AssetId { get; set; }
    public Guid? ManagedById { get; set; }
    
    // Navigation properties
    public virtual Asset Asset { get; set; }
    public virtual User ManagedBy { get; set; }
    public virtual ICollection<IoTData> IoTData { get; set; }
} 