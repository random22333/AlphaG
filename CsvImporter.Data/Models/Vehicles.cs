using System.ComponentModel.DataAnnotations;

namespace CsvImporter.Data.Models
{
    public class Vehicles
    {
        [Key]
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Colour { get; set; }
        public string? Registration { get; set; }

    }
}
