using CsvImporter.Data.Interfaces;
using CsvImporter.Data.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleTestProject
{
    public class MockUploadRepository : IUploadRepository
    {
        private readonly Mock<IUploadRepository> mockRepository;

        public MockUploadRepository()
        {
            mockRepository = new Mock<IUploadRepository>();
        }

        public void SaveCsvData(List<Vehicles> records)
        {
            // Mock the behavior of SaveCsvData method
            mockRepository.Setup(repo => repo.SaveCsvData(records));
        }

        // This method can be used to retrieve the mock object for assertions in tests
        public Mock<IUploadRepository> GetMockObject()
        {
            return mockRepository;
        }

        Task<bool> IUploadRepository.SaveCsvData(List<Vehicles> data)
        {
            throw new NotImplementedException();
        }
    }

}
