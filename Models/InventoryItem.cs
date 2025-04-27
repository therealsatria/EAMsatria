using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class InventoryItem : BaseEntity
{
    public string ItemName { get; set; }
    public string Category { get; set; }
    public int QuantityOnHand { get; set; }
    public int ReorderLevel { get; set; }
    public decimal UnitCost { get; set; }
    public string StorageLocation { get; set; }
    public DateTime LastPurchaseDate { get; set; }
    public string ItemCondition { get; set; }
    public string TrackingMethod { get; set; }
    
    // Foreign keys
    public Guid SupplierId { get; set; }
    
    // Navigation properties
    public virtual Supplier Supplier { get; set; }
    public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    public virtual ICollection<Asset> Assets { get; set; }
    public virtual ICollection<Contract> Contracts { get; set; }
} 