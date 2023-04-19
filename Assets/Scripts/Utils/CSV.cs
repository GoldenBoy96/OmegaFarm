using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeEditor;

namespace Assets.Scripts.Utils
{
    internal class CSV
    {
        public static void WriteFile<T>(string filePath, List<T> objects)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(objects);
            }
        }

        public static List<T> ReadFile<T>(string filePath)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };

            List<T> records;
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, configuration))
            {
                records = (List<T>)csv.GetRecords<T>();
            }
            return records;
        }
    }
}
