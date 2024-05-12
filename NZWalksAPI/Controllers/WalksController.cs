using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using NZWalksAPI.CustomActionFilters;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Models.DTO;
using NZWalksAPI.Repositories;

namespace NZWalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository) 
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        // CREATE WALK
        // POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            // Map DTO to Domain Model
            var walkdomainModel = mapper.Map<Walk>(addWalkRequestDTO);

            await walkRepository.CreateAsync(walkdomainModel);

            // Map Domain model to DTO
            return Ok(mapper.Map<WalkDto>(walkdomainModel));
        }

        // GET WALKS
        // GET: /api/walks?filterOn=Name&filterQuery=Track
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery)
        {
            // Map DTO to Domain Model
            var walkdsDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery);

            // Map Domain Model to DTO
            return Ok(mapper.Map<List<WalkDto>>(walkdsDomainModel));
        }

        // Get Walk By Id
        // GET: /api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            // Return not found if null
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Update Walk By Id
        // PUT: /api/Walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto)
        {
            // Map dto to Walk Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {  
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // Delete a Walk By Id
        // DELETE: /api/Walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}
