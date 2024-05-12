using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region> GetById(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<Region> UpdateAsync(Guid id, UpdateRegionRequestDto region);
        Task<Region> DeleteRegion(Guid id);
    }
}
