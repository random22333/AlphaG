using CsvImporter.Data;
using CsvImporter.Data.Interfaces;
using CsvImporter.Data.Models;
using CsvImporter.Service;
using Microsoft.Extensions.Configuration;
using Moq;
using VehicleTestProject;
using VehicleTestProject.Config;

namespace Vehicle.Tests
{
    [TestClass]
    public class CsvImporterServiceTests
    {
        [TestMethod]
        public void TestCsvParseSuccessful()
        {
            // Arrange
            IConfiguration configuration = ConfigurationDetails.GetConfiguration(); 
            IUploadRepository uploadRepository = new MockUploadRepository(); 
            var importerService = new CsvImporterService(configuration, uploadRepository);

            // Act
            var result = importerService.ImportCsv();

            // Assert
            Assert.AreEqual(24, result.Count);
        }


        [TestMethod]
        public void CSVShouldSaveToDatabase()  
        {
            // Arrange            
            IConfiguration configuration = ConfigurationDetails.GetConfiguration();
            CsvDbContext context = new(configuration);
            UploadRepository uploadRepository = new(context);
            var importerService = new CsvImporterService(configuration, uploadRepository);

            // Act
            var result = importerService.SaveToDatabase(importerService.ImportCsv());

            // Assert
            Assert.AreEqual(true, result);
        }
    }

}




