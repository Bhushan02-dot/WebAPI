using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Client.Models
{
    public class Weather
    {
        [Key]
        public int WeatherId { get; set; }

        // Foreign Key for WeatherCity
        [ForeignKey("WeatherCity")]
        public int Id { get; set; }  // This is the foreign key column

        // Navigation property (optional)


        public float Temp { get; set; }
        public int Humidity { get; set; }
        public string Description { get; set; }
    }
}
