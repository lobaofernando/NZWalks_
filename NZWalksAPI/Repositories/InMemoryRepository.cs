using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;

namespace NZWalksAPI.Repositories
{
    public class InMemoryRepository
    {
        public Task<bool> CreateAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public Task<Region> DeleteRegion(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return new List<Region> 
            {
                new Region()
                {
                    Id = Guid.Parse("C16F11A5-5BA4-4452-813A-08DB9112F1C4"),
                    Name = "Name",
                    RegionImageUrl = "teste",
                    Code = "code",
                }
            };
        }

        public Task<Region> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Region> UpdateRegion(Guid id, UpdateRegionRequestDto region)
        {
            throw new NotImplementedException();
        }
    }
}
