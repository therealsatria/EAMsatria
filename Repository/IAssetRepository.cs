using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EAMsatria.Models;

namespace EAMsatria.Repository
{
    public interface IAssetRepository
    {
        // Basic CRUD Operations
        Task<Asset> GetByIdAsync(Guid assetId);
        Task<IEnumerable<Asset>> GetAllAsync();
        Task AddAsync(Asset asset);
        Task UpdateAsync(Asset asset);
        Task DeleteAsync(Guid assetId);
        
        // Specific Query Operations
        Task<IEnumerable<Asset>> GetByLocationAsync(string location);
        Task<IEnumerable<Asset>> GetByStatusAsync(string operationalStatus);
        Task<IEnumerable<Asset>> GetByTypeAsync(string assetType);
        Task<IEnumerable<Asset>> GetAssetsDueForMaintenanceAsync();
        Task<IEnumerable<Asset>> GetAssetsUnderWarrantyAsync();
        
        // Related Data Operations
        Task<IEnumerable<MaintenanceLog>> GetMaintenanceHistoryAsync(Guid assetId);
        Task<IEnumerable<Document>> GetAssetDocumentsAsync(Guid assetId);
        // Task<IEnumerable<IotDevice>> GetConnectedIotDevicesAsync(int assetId);
        Task<IEnumerable<WorkOrder>> GetRelatedWorkOrdersAsync(Guid assetId);
        
        // Advanced Operations
        Task<bool> UpdateAssetStatus(Guid assetId, string newStatus);
        Task<decimal> CalculateTotalMaintenanceCost(Guid assetId);
        Task<IEnumerable<ComplianceStandard>> GetAssetComplianceStandardsAsync(Guid assetId);
        
        // Bulk Operations
        Task BulkUpdateLocationsAsync(Dictionary<Guid, string> assetLocations);
        Task BulkUpdateStatusAsync(IEnumerable<Guid> assetIds, string status);
    }
}