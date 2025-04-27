using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class ComplianceStandard : BaseEntity
{
    public string StandardName { get; set; }
    public string Description { get; set; }
    public string Requirements { get; set; }
    public string RegulatoryBody { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ReviewDate { get; set; }
    public bool IsMandatory { get; set; }
    public string ImplementationGuidelines { get; set; }
    
    // Navigation properties
    public virtual ICollection<Asset> Assets { get; set; }
    public virtual ICollection<Document> Documents { get; set; }
    public virtual ICollection<WorkOrder> WorkOrders { get; set; }
} 