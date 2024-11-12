using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Client.Models;

    public class WeatherDB : DbContext
    {
        public WeatherDB (DbContextOptions<WeatherDB> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.Client.Models.Weather> WeatherData { get; set; } = default!;
    }
