using CsvImporter.Data.Models;

namespace CsvImporter.Data.Interfaces
{
    public interface IUploadRepository
    {
        Task<bool> SaveCsvData(List<Vehicles> data); 
    }
}
