using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experis_movie
{
    public class Products
    {



        public Products(int id, string name, int year, string keyword1, string keyword2, string keyword3, string keyword4, string keyword5, double rating, double price)
        {

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(@"F:\CSV\Products.txt"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Products>();
            }




            this.ProductId = Convert.ToInt32(id);
            this.ProductName = name;
            this.ProductYear = Convert.ToInt32(year);
            this.ProductKeyword1 = keyword1;
            this.ProductKeyword2 = keyword2;
            this.ProductKeyword3 = keyword3;
            this.ProductKeyword4 = keyword4;
            this.ProductKeyword5 = keyword5;
            this.ProductRating = Convert.ToDouble(rating);
            this.ProductPrice = Convert.ToDouble(price);
        }
        [Index(0)]
        public int ProductId { get; set; }
        [Index(1)]
        public string ProductName { get; set; }
        [Index(2)]
        public int ProductYear { get; set; }
        [Index(3)]
        public string ProductKeyword1 { get; set; }
        [Index(4)]
        public string ProductKeyword2 { get; set; }
        [Index(5)]
        public string ProductKeyword3 { get; set; }
        [Index(6)]
        public string ProductKeyword4 { get; set; }
        [Index(7)]
        public string ProductKeyword5 { get; set; }
        [Index(8)]
        public double ProductRating { get; set; }
        [Index(9)]
        public double ProductPrice { get; set; }



        //int id, string name, int year, string keyword1, string keyword2, string keyword3, string keyword4, string keyword5, double rating, double price



        /* public int id, year;
     public double rating, price;
     public string name, keyword1, keyword2, keyword3, keyword4, keyword5;
     public Products(string data)
     {

         string[] data = rowData.Split(",");

         this.id = data[0];
         this.name = data[1];
         this.year = data[2]);
         this.keyword1 = data[3]; */



        /* public static List<Products> listProducts()
         {
             string[] reader = System.IO.File.ReadAllLines(@"F:\CSV\Products.txt");
             List<Products> productList = new List<Products>();

             for (int i = 0; i < reader.Length; i++)
             {
                 Products pl = new(reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3), reader.GetValue(4), reader.GetValue(5), reader.GetValue(6), reader.GetValue(7), reader.GetValue(8), reader.GetValue(9));
                 productList.Add(pl);


             }

             return productList; 
         }*/


    }
}
