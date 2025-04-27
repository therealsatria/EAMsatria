using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class Contract : BaseEntity
{
    public string ContractNumber { get; set; }
    public string Title { get; set; }
    public DateTime EffectiveDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string TermsAndConditions { get; set; }
    public decimal TotalValue { get; set; }
    public string PaymentSchedule { get; set; }
    public string RenewalTerms { get; set; }
    public string TerminationClause { get; set; }
    public string ComplianceRequirements { get; set; }
    
    // Foreign keys
    public Guid SupplierId { get; set; }
    public Guid? ManagedById { get; set; }
    
    // Navigation properties
    public virtual Supplier Supplier { get; set; }
    public virtual User ManagedBy { get; set; }
    public virtual ICollection<Asset> CoveredAssets { get; set; }
    public virtual ICollection<InventoryItem> IncludedInventoryItems { get; set; }
    public virtual ICollection<Document> Documents { get; set; }
} 