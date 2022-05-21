using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;
using System.Globalization;
using System.Collections;


namespace Experis_movie
{
    internal class mostPopularMovies
    {
        public static Dictionary<string, int> mostPopularMoviesPurchased(List<Users> users, List<Products> products)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (Users user in users)
            {
                foreach (Products movie in products)
                {
                    foreach (string value in user.UserPurchasedSplit)
                    {
                        if (value.Replace(" ", "").Equals(movie.ProductId.ToString()))
                        {
                            if (dict.ContainsKey(movie.ProductName))
                            {
                                dict[movie.ProductName] = dict[movie.ProductName] + 1;
                            }
                            else
                            {
                                dict.Add(movie.ProductName, 1);
                            }
                        }
                    }
                }
            }
            var sortedDict = from entry in dict orderby entry.Value descending select entry;
            return dict = sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        public static Dictionary<string, double> mostPopularMoviesByRating(List<Products> products)
        {
            Dictionary<string, double> dict = new Dictionary<string, double>();

            foreach (Products product in products)
            {
                if (dict.ContainsKey(product.ProductName))
                {
                    dict[product.ProductName] = product.ProductRating;
                }
                else
                {
                    dict.Add(product.ProductName, product.ProductRating);
                }
            }
            var sortedDict = from entry in dict orderby entry.Value descending select entry;
            return dict = sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}

