using CsvHelper.Configuration;
using CsvImporter.Data.Models;

namespace CsvImporter.Service
{
    public class VehiclesMap : ClassMap<Vehicles>
    {
        public VehiclesMap()
        {
            // Ignore the 'Id' column in the Model when parsing the csv
            Map(m => m.Id).Ignore();
            Map(m => m.Make).Name("Make");
            Map(m => m.Model).Name("Model");
            Map(m => m.Colour).Name("Colour");
            Map(m => m.Registration).Name("Registration");
        }
    }
}

