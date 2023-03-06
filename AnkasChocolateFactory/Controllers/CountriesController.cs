﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnkasChocolateFactory.Data;
using AnkasChocolateFactory.Models.Country;
using AnkasChocolateFactory.Configurations;
using AutoMapper;
using AnkasChocolateFactory.Contracts;
using Microsoft.AspNetCore.Authorization;

namespace AnkasChocolateFactory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class CountriesController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly ICountriesRepository _countriesRepository;

        public CountriesController(IMapper mapper, ICountriesRepository countriesRepository )
        {
            
            this._mapper = mapper;
            this._countriesRepository = countriesRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountry>>> GetCountries()
        {
            var countries = await _countriesRepository.GetAllAsync();
            var records = _mapper.Map<List<GetCountry>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCountryDetails>> GetCountry(int id)
        {
            var country = await _countriesRepository.GetDetails(id);
                

            if (country == null)
            {
                return NotFound();
            }
            var results = _mapper.Map<GetCountryDetails>(country);
            return Ok(results);
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountry updateCountry)
        {

            if (id != updateCountry.Id)
            {
                return BadRequest();
            }


            var country = await _countriesRepository.GetAsync(id);
            if(country == null)
            {
                return NotFound();
            }
           

            _mapper.Map(updateCountry, country);
            try
            {
                await _countriesRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
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

        // POST: api/Countries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(CreateCountry createCountry)
        {
            var country = _mapper.Map<Country>(createCountry);
           await _countriesRepository.AddAsync(country);
        
            return CreatedAtAction("GetCountry", new { id = country.Id }, country);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesRepository.GetAsync(id);
            if(country == null)
            {
                return NotFound();
            }
            await _countriesRepository.DeleteAsync(id);
           
            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _countriesRepository.Exists(id);
        }
    }
}
