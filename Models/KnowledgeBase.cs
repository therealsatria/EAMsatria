using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class KnowledgeBase : BaseEntity
{
    public string Topic { get; set; }
    public string Content { get; set; }
    public string Category { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ApprovalStatus { get; set; }
    public string RelatedAssets { get; set; }
    public string RelatedWorkOrders { get; set; }
    
    // Foreign keys
    public Guid CreatedById { get; set; }
    
    // Navigation properties
    public virtual User CreatedBy { get; set; }
    public virtual ICollection<Document> Documents { get; set; }
    public virtual ICollection<Asset> SupportedAssets { get; set; }
    public virtual ICollection<WorkOrder> GuidedWorkOrders { get; set; }
} 