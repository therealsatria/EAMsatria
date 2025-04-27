using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class Supplier : BaseEntity
{
    public string SupplierName { get; set; }
    public string ContactPerson { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PaymentTerms { get; set; }
    public string ServiceLevel { get; set; }
    public DateTime PartnershipStart { get; set; }
    public bool IsActive { get; set; }
    
    // Navigation properties
    public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; }
} 