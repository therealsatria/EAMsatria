using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class Budget : BaseEntity
{
    public string BudgetName { get; set; }
    public decimal Amount { get; set; }
    public string BudgetType { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Department { get; set; }
    public string ApprovalStatus { get; set; }
    public decimal ActualExpenditure { get; set; }
    public decimal RemainingBalance { get; set; }
    
    // Foreign keys
    public Guid? ApprovedById { get; set; }
    
    // Navigation properties
    public virtual User ApprovedBy { get; set; }
    public virtual ICollection<Asset> AllocatedAssets { get; set; }
    public virtual ICollection<WorkOrder> TrackedWorkOrders { get; set; }
    public virtual ICollection<InventoryItem> AccountedInventoryItems { get; set; }
    public virtual ICollection<Project> FundedProjects { get; set; }
} 