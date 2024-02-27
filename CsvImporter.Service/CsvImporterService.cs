// CsvImporterService.cs in CsvImporter.Service
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvImporter.Data.Interfaces;
using CsvImporter.Data.Models;
using CsvImporter.Service.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CsvImporter.Service
{
    public class CsvImporterService(IConfiguration configuration, IUploadRepository uploadRepository) : IServicecsv
    {
        private readonly IConfiguration _configuration = configuration;
        private readonly IUploadRepository _uploadRepository = uploadRepository;

        /// <summary>
        /// Parses the given CSV to a List.
        /// </summary>
        public List<Vehicles> ImportCsv()
        {
            try
            {
                CsvConfiguration csvConfiguration = new(CultureInfo.InvariantCulture);

                string? csvFilePath = _configuration["CsvFilePath"];
                List<Vehicles> records;

                using (StreamReader reader = new(csvFilePath))
                using (CsvReader csv = new(reader, csvConfiguration))
                {
                    csv.Context.RegisterClassMap<VehiclesMap>();
                    records = csv.GetRecords<Vehicles>().ToList();
                }

                Console.WriteLine($"Successfully parsed.");
                Console.WriteLine($"Number of records in the CSV file: {records.Count}");

                return records;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading CSV data: {ex.Message}");
                throw;
                //return [];
            }
        }

        public bool SaveToDatabase(List<Vehicles> records)
        {
            return _uploadRepository.SaveCsvData(records).Result;
        }

    }
}
