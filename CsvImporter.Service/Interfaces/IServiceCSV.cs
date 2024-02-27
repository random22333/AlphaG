using CsvImporter.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvImporter.Service.Interfaces
{
    internal interface IServicecsv 
    {
        List<Vehicles> ImportCsv();
        bool SaveToDatabase(List<Vehicles> records);
    }
}
