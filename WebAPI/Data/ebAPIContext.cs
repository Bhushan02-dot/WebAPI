using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Client.Models;

namespace Weather
{
    public class ebAPIContext : DbContext
    {
        public ebAPIContext (DbContextOptions<ebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.Client.Models.City> WeatherCity { get; set; } = default!;
    }
}
