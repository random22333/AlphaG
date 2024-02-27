using CsvImporter.Data.Interfaces;
using CsvImporter.Data.Models;

namespace CsvImporter.Data
{
    public class UploadRepository(CsvDbContext dbContext) : IUploadRepository
    {
        private readonly CsvDbContext _dbContext = dbContext;

        /// <summary>
        /// Saves the given List type.
        /// </summary>
        /// <param name="data">The vehicle class.</param>
     
        public async Task<bool> SaveCsvData(List<Vehicles> data) 
        {
            try
            {
                await _dbContext.Set<Vehicles>().AddRangeAsync(data);
                await _dbContext.SaveChangesAsync();
                Console.WriteLine("Data successfully imported to the database.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading CSV data: {ex.Message}");
                throw;
            }
        }

    }

}


