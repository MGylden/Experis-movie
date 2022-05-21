using CsvHelper;
using CsvHelper.Configuration;
using Experis_movie.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Experis_movie.Operations
{
     static class CsvOperations
     {
        public static CsvConfiguration Config()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null
            };
            return config;
        }

        public static List<Users> ParseCsvToUsers()
        {
            CsvConfiguration config = Config();
            using (var reader = new StreamReader(@"C:\Users\Mathi\source\repos\rigtige\Experis movie\Resources\Users.txt"))

            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Users>();
                return records.ToList();
            }
        }
        public static List<Products> ParseToProducts()
        {
            CsvConfiguration config = Config();
            using (var reader = new StreamReader(@"C:\Users\Mathi\source\repos\rigtige\Experis movie\Resources\Products.txt"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Products>();
                return records.ToList();
            }

        }
        public static List<CurrentUserSession> ParseToUserssession()
        {
            CsvConfiguration config = Config();
            using (var reader = new StreamReader(@"C:\Users\Mathi\source\repos\rigtige\Experis movie\Resources\CurrentUserSession.txt"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<CurrentUserSession>();
                return records.ToList();
            }

        }


    }
}
