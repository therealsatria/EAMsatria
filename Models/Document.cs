using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class Document : BaseEntity
{
    public string DocumentType { get; set; }
    public string FilePath { get; set; }
    public DateTime UploadDate { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string VersionNumber { get; set; }
    public string ApprovalStatus { get; set; }
    public string Description { get; set; }
    
    // Foreign keys
    public Guid? AssetId { get; set; }
    public Guid? WorkOrderId { get; set; }
    public Guid UploadedById { get; set; }
    
    // Navigation properties
    public virtual Asset Asset { get; set; }
    public virtual WorkOrder WorkOrder { get; set; }
    public virtual User UploadedBy { get; set; }
    public virtual ICollection<KnowledgeBase> KnowledgeBases { get; set; }
} 