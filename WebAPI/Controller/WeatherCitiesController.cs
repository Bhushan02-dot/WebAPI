using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weather;
using WebAPI.Client.Models;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherCitiesController : ControllerBase
    {
        private readonly ebAPIContext _context;

        public WeatherCitiesController(ebAPIContext context)
        {
            _context = context;
        }

        // GET: api/WeatherCities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetWeatherCity()
        {
            return await _context.WeatherCity.ToListAsync();
        }

        // GET: api/WeatherCities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetWeatherCity(int id)
        {
            var weatherCity = await _context.WeatherCity.FindAsync(id);

            if (weatherCity == null)
            {
                return NotFound();
            }

            return weatherCity;
        }

        // PUT: api/WeatherCities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherCity(int id, City weatherCity)
        {
            if (id != weatherCity.Id)
            {
                return BadRequest();
            }

            _context.Entry(weatherCity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherCityExists(id))
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

        // POST: api/WeatherCities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<City>> PostWeatherCity(City weatherCity)
        {
            _context.WeatherCity.Add(weatherCity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherCity", new { id = weatherCity.Id }, weatherCity);
        }

        // DELETE: api/WeatherCities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherCity(int id)
        {
            var weatherCity = await _context.WeatherCity.FindAsync(id);
            if (weatherCity == null)
            {
                return NotFound();
            }

            _context.WeatherCity.Remove(weatherCity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherCityExists(int id)
        {
            return _context.WeatherCity.Any(e => e.Id == id);
        }
    }
}
