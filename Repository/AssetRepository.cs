using EAMsatria.Data;
using EAMsatria.Models;
using Microsoft.EntityFrameworkCore;

namespace EAMsatria.Repository
{
    public class AssetRepository : IAssetRepository
    {
        // Implementation details
        private readonly AppDbContext _context;

        public AssetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Asset> GetByIdAsync(Guid assetId)
        {
            return await _context.Assets.FindAsync(assetId);
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task AddAsync(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
            await _context.SaveChangesAsync();
        }   

        public async Task UpdateAsync(Asset asset)
        {
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
        }       

        public async Task DeleteAsync(Guid assetId)
        {
            var asset = await GetByIdAsync(assetId);
            _context.Assets.Remove(asset);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Asset>> GetByLocationAsync(string location)
        {
            return await _context.Assets.Where(a => a.Location == location).ToListAsync();
        }

        public async Task<IEnumerable<Asset>> GetByStatusAsync(string operationalStatus)
        {
            return await _context.Assets.Where(a => a.OperationalStatus == operationalStatus).ToListAsync();
        }
        
        public async Task<IEnumerable<Asset>> GetByTypeAsync(string assetType)
        {
            return await _context.Assets.Where(a => a.AssetType == assetType).ToListAsync();
        }

        public async Task<IEnumerable<Asset>> GetAssetsDueForMaintenanceAsync()
        {
            var currentDate = DateTime.Now;
            return await _context.Assets
                .Where(a => a.MaintenanceSchedules.Any(m => m.NextMaintenanceDate <= currentDate))
                .ToListAsync();
        }   

        public async Task<IEnumerable<Asset>> GetAssetsUnderWarrantyAsync()
        {
            var currentDate = DateTime.Now;
            return await _context.Assets
                .Where(a => a.WarrantyExpiration >= currentDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<MaintenanceLog>> GetMaintenanceHistoryAsync(Guid assetId)
        {
            return await _context.MaintenanceLogs
                .Where(ml => ml.AssetId == assetId)
                .ToListAsync();
        }   

        public async Task<IEnumerable<Document>> GetAssetDocumentsAsync(Guid assetId)
        {
            return await _context.Documents
                .Where(d => d.AssetId == assetId)
                .ToListAsync();
        }   

        public async Task<IEnumerable<WorkOrder>> GetRelatedWorkOrdersAsync(Guid assetId)
        {
            return await _context.WorkOrders
                .Where(wo => wo.Schedule.AssetId == assetId)
                .ToListAsync();
        }   

        public async Task<bool> UpdateAssetStatus(Guid assetId, string newStatus)
        {
            var asset = await GetByIdAsync(assetId);
            if (asset == null) return false;
            asset.OperationalStatus = newStatus;
                await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> CalculateTotalMaintenanceCost(Guid assetId)
        {
            var maintenanceLogs = await GetMaintenanceHistoryAsync(assetId);
            return maintenanceLogs.Sum(ml => ml.LaborHours * ml.MaterialCost);
        }

        public async Task<IEnumerable<ComplianceStandard>> GetAssetComplianceStandardsAsync(Guid assetId)
        {
            return await _context.ComplianceStandards
                .Where(cs => cs.Assets.Any(a => a.Id == assetId))
                .ToListAsync();
        }   

        public async Task BulkUpdateLocationsAsync(Dictionary<Guid, string> assetLocations)
        {
            foreach (var (assetId, location) in assetLocations)
            {
                var asset = await GetByIdAsync(assetId);    
                if (asset != null)
                {
                    asset.Location = location;
                    await UpdateAsync(asset);
                }
            }
        }   

        public async Task BulkUpdateStatusAsync(IEnumerable<Guid> assetIds, string status)
        {
            foreach (var assetId in assetIds)
            {
                var asset = await GetByIdAsync(assetId);    
                if (asset != null)
                {
                    asset.OperationalStatus = status;
                    await UpdateAsync(asset);
                }
            }
        }   
        
    }
}