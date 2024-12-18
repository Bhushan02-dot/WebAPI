﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Client.Models;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDatasController : ControllerBase
    {
        private readonly WeatherDB _context;

        public WeatherDatasController(WeatherDB context)
        {
            _context = context;
        }

        // GET: api/WeatherDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client.Models.Weather>>> GetWeatherData()
        {
            return await _context.WeatherData.ToListAsync();
        }

        // GET: api/WeatherDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client.Models.Weather>> GetWeatherData(int id)
        {
            var weatherData = await _context.WeatherData.FindAsync(id);

            if (weatherData == null)
            {
                return NotFound();
            }

            return weatherData;
        }
        // Controller method to get weather data for a specific city
        [HttpGet("city/{id}")]
        public async Task<ActionResult<List<Client.Models.Weather>>> GetWeatherDataByCity(int id)
        {
            var weatherData = await _context.WeatherData
                .Where(w => w.Id == id) // Filter by city ID
                .ToListAsync();

            if (weatherData == null || !weatherData.Any())
            {
                return NotFound();
            }

            return weatherData;
        }


        // PUT: api/WeatherDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherData(int id, Client.Models.Weather weatherData)
        {
            if (id != weatherData.WeatherId)
            {
                return BadRequest();
            }

            _context.Entry(weatherData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherDataExists(id))
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

        // POST: api/WeatherDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client.Models.Weather>> PostWeatherData(Client.Models.Weather weatherData)
        {
            _context.WeatherData.Add(weatherData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherData", new { id = weatherData.WeatherId }, weatherData);
        }

        // DELETE: api/WeatherDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherData(int id)
        {
            var weatherData = await _context.WeatherData.FindAsync(id);
            if (weatherData == null)
            {
                return NotFound();
            }

            _context.WeatherData.Remove(weatherData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherDataExists(int id)
        {
            return _context.WeatherData.Any(e => e.WeatherId == id);
        }
    }
}
