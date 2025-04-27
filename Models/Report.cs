using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class Report : BaseEntity
{
    public string ReportName { get; set; }
    public string ReportType { get; set; }
    public DateTime GeneratedDate { get; set; }
    public string Format { get; set; }
    public string DistributionList { get; set; }
    public string Schedule { get; set; }
    public string Parameters { get; set; }
    public string DataSource { get; set; }
    public string VisualizationType { get; set; }
    public string AccessPermissions { get; set; }
    
    // Foreign keys
    public Guid CreatedById { get; set; }
    
    // Navigation properties
    public virtual User CreatedBy { get; set; }
    public virtual ICollection<Asset> ReportedAssets { get; set; }
    public virtual ICollection<WorkOrder> SummarizedWorkOrders { get; set; }
    public virtual ICollection<IoTData> IncludedIoTData { get; set; }
    public virtual ICollection<Budget> AnalyzedBudgets { get; set; }
    public virtual ICollection<Project> EvaluatedProjects { get; set; }
} 