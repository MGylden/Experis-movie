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

        public List<string> getGenresToList()
        {
            List<string> genres = new List<string>();

            if (!string.IsNullOrWhiteSpace(this.ProductKeyword1)) genres.Add(this.ProductKeyword1);
            if (!string.IsNullOrWhiteSpace(this.ProductKeyword2)) genres.Add(this.ProductKeyword2);
            if (!string.IsNullOrWhiteSpace(this.ProductKeyword3)) genres.Add(this.ProductKeyword3);
            if (!string.IsNullOrWhiteSpace(this.ProductKeyword4)) genres.Add(this.ProductKeyword4);
            if (!string.IsNullOrWhiteSpace(this.ProductKeyword5)) genres.Add(this.ProductKeyword5);

            return genres;


        }

        public Products()
        {

        }
        public override string ToString()
        {
            string str = $"{ProductId}--{ProductName}--{ProductYear}-{ProductRating}--{ProductPrice}" + 
                $"{ProductKeyword1}-{ProductKeyword2}-{ProductKeyword3}-{ProductKeyword4}-{ProductKeyword5}";
            return str;
        }
    }
 
}
