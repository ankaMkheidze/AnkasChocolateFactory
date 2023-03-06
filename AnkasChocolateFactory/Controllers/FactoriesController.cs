using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnkasChocolateFactory.Data;
using AnkasChocolateFactory.Contracts;
using AutoMapper;
using AnkasChocolateFactory.Models.Factory;

namespace AnkasChocolateFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoriesController : ControllerBase
    {
        
        private readonly IFactoriesRepository _factoriesRepository;
        private readonly IMapper _mapper;

        public FactoriesController(IFactoriesRepository factoriesRepository, IMapper mapper)
        {
            
            this._factoriesRepository = factoriesRepository;
            this._mapper = mapper;
        }

        // GET: api/Factories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FactoryDto>>> GetFactories()
        {
            var factories =  await _factoriesRepository.GetAllAsync();
            return Ok(_mapper.Map<List<FactoryDto>>(factories));
        }

        // GET: api/Factories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FactoryDto>> GetFactory(int id)
        {
            var factory = await _factoriesRepository.GetAsync(id);

            if (factory == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<FactoryDto>(factory));
        }

        // PUT: api/Factories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactory(int id, FactoryDto factoryDto)
        {
            if (id != factoryDto.Id)
            {
                return BadRequest();
            }
            var factory = await _factoriesRepository.GetAsync(id);
            _mapper.Map(factoryDto, factory);
            try
            {
                await _factoriesRepository.UpdateAsync(factory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await FactoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Factories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Factory>> PostFactory(CreateFactory createFactory)
        {
            var factory = _mapper.Map<Factory>(createFactory);
           await _factoriesRepository.AddAsync(factory);
           
            return CreatedAtAction("GetFactory", new { id = factory.Id }, factory);
        }

        // DELETE: api/Factories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFactory(int id)
        {
            var factory = await _factoriesRepository.GetAsync(id);
            if (factory == null)
            {
                return NotFound();
            }


            await _factoriesRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> FactoryExists(int id)
        {
            return await _factoriesRepository.Exists(id);
        }
    }
}
