using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Assets.Scripts.Utils
{
    internal class CSV
    {
        public static void WriteFile<T>(string filePath, List<T> objects)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                MissingFieldFound = null,
                Delimiter = ";",
                PrepareHeaderForMatch = args => args.Header.ToLowerInvariant(), 
            };

            using (StreamWriter writer = new StreamWriter(filePath))
            using (CsvWriter csv = new CsvWriter(writer, configuration))
            {
                csv.WriteRecords(objects);

            }
        }

        public static List<T> ReadFile<T>(string filePath)
        {
            List<T> records;
            try
            {
                CsvConfiguration configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    MissingFieldFound = null,
                    Delimiter = ";",
                    PrepareHeaderForMatch = args => args.Header.ToLowerInvariant(),
                    //Must put PrepareHeaderForMatch here because GetRecords convert header name to lowercase as first letter
                    //Ex: WriteRecord -> "NameName"
                    //    ReadRecord  -> "nameName"
                    //The latest version of CsvHelper change the way PrepareHeaderForMatch Work
                    //Solution: https://stackoverflow.com/questions/66199631/prepareheaderformatch-change-in-csvhelper-v23
                };


                using (StreamReader reader = new StreamReader(filePath)) 
                using (CsvReader csv = new CsvReader(reader, configuration))
                {

                    records = csv.GetRecords<T>().Cast<T>().ToList<T>();
                    
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
            
            return records;
        }
    }
}
