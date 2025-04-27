using System;
using System.Collections.Generic;

namespace EAMsatria.Models;
public class Project : BaseEntity
{
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
    public string ProjectType { get; set; }
    public decimal BudgetAllocation { get; set; }
    public string Stakeholders { get; set; }
    public string RiskAssessment { get; set; }
    public string QualityAssurance { get; set; }
    
    // Foreign keys
    public Guid? ManagedById { get; set; }
    
    // Navigation properties
    public virtual User ManagedBy { get; set; }
    public virtual ICollection<Asset> InvolvedAssets { get; set; }
    public virtual ICollection<WorkOrder> GeneratedWorkOrders { get; set; }
    public virtual ICollection<Budget> LinkedBudgets { get; set; }
    public virtual ICollection<Document> Documents { get; set; }
} 