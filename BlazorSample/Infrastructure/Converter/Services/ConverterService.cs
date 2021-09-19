using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace BlazorSample.Converter.Services
{
    public static class ConverterService
    {
        public static IEnumerable<T> ToCsv<T>(TextReader reader)
        {
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<T>().ToList();
        }
    }
}
