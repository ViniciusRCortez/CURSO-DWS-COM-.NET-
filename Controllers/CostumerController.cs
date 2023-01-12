using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AutoMapper;
using Dws.Note_one.Api.Domain.Models;
using Dws.Note_one.Api.Resource;
using Dws.Note_one.Api.Services.IServices;
using Dws.Note_one.Api.Resource;
using Dws.Note_one.Api.Extension;
using Microsoft.AspNetCore.Authorization;


namespace Dws.Note_one.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize()]
    public class CostumerController : ControllerBase
    {
        private readonly ICostumerService _costumerService;
        private readonly IMapper _mapper;

        public CostumerController(ICostumerService costumerService, IMapper mapper)
        {
            _costumerService = costumerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CostumerResource>> GetAllAsync()
        {
            var costumers = await _costumerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Costumer>, IEnumerable<CostumerResource>>(costumers);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var costumerResponse = await _costumerService.FindByIdAsync(id);
            var resource = _mapper.Map<Costumer,CostumerResource>(costumerResponse.Costumer);

             if (!costumerResponse.Success)
                return BadRequest(costumerResponse.Message);

            return Ok(resource);
        }

        [HttpGet("name/{name}")]
        public async Task<IActionResult>  GetByNameAsync(string name)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var costumerResponse = await _costumerService.FindByNameAsync(name);
            var resource = _mapper.Map<Costumer,CostumerResource>(costumerResponse.Costumer);

            if (!costumerResponse.Success)
                return BadRequest(costumerResponse.Message);

            return Ok(resource);
        }

        [HttpGet("positive/")]
        public async Task<IEnumerable<CostumerResource>> GetByPositiveCreditAsync()
        {
            var costumer = await _costumerService.ListByPositiveCreditAsync();
            var resources = _mapper.Map<IEnumerable<Costumer>, IEnumerable<CostumerResource>>(costumer);

            return resources;
        }

        [HttpGet("negative/")]
        public async Task<IEnumerable<CostumerResource>> GetByNegativeCreditAsync()
        {
            var costumer = await _costumerService.ListByNegativeCreditAsync();
            var resources = _mapper.Map<IEnumerable<Costumer>, IEnumerable<CostumerResource>>(costumer);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCostumerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var costumer = _mapper.Map<SaveCostumerResource, Costumer>(resource);
            var result = await _costumerService.SaveAsync(costumer);

            if (!result.Success)
                return BadRequest(result.Message);

            var costumerResource = _mapper.Map<Costumer, CostumerResource>(result.Costumer);
            return Ok(costumerResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCostumerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var costumer = _mapper.Map<SaveCostumerResource, Costumer>(resource);
            var result = await _costumerService.UpdateAsync(id, costumer);

            if (!result.Success)
                return BadRequest(result.Message);

            var costumerResource = _mapper.Map<Costumer, CostumerResource>(result.Costumer);
            return Ok(costumerResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _costumerService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var costumerResource = _mapper.Map<Costumer, CostumerResource>(result.Costumer);
            return Ok(costumerResource);
        }

    }

}