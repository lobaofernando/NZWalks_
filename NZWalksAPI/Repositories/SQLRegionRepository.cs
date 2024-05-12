using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        public NZWalksDbContext DbContext { get; }

        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await DbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetById(Guid id)
        {
            return await DbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await DbContext.Regions.AddAsync(region);
            await DbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, UpdateRegionRequestDto regionDTO)
        {
            // Map domain models to DTOs
            var region = await DbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
                return null;

            // Update Region
            region.Code = regionDTO.Code;
            region.Name = regionDTO.Name;
            region.RegionImageUrl = regionDTO.RegionImageUrl;

            await DbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region> DeleteRegion(Guid id)
        {
            // get the region from the database
            var region = await DbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            // check results
            if (region == null)
            {
                return region = null;
            }

            // remove instance from database
            DbContext.Regions.Remove(region);

            // save changes to database
            await DbContext.SaveChangesAsync();

            return region;
        }
    }
}
