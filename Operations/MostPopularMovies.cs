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
using Experis_movie.Models;


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

        public static List<Products> ListOfRecommendedMoviesByUnitsSoldAndUserReviews(List<Users> users, List<Products> products)
        { 
            List<Products> moviesOnlyWithHighRating = new List<Products>();
            List<Products> moviesWithUnitsSold = new List<Products>();

            for (int y = 0; y < products.Count; y++)
            {
                if (products.ElementAt(y).ProductRating > 3.5)
                {
                    moviesOnlyWithHighRating.Add(products.ElementAt(y));
                }
            }

            users.ForEach(user =>
            {
                user.SplitUserPurchased().ForEach(productId =>
                {
                    products.ForEach(product =>
                    {
                        if (productId.Replace(" ", "").Equals(product.ProductId))
                        {
                            moviesWithUnitsSold.Add(product);
                        }
                    });
                });
            });

            List<Products> movieRecommendationList = moviesWithUnitsSold.Union(moviesOnlyWithHighRating).ToList();
            return movieRecommendationList;
        }
        public static Dictionary<string,List<Products>> RecommendedMoviesOnUserSession(List<Users> users, List<Products> products, List<CurrentUserSession> currentUserSession)
        {
            Dictionary<string, List<Products>> dict = new Dictionary<string,List<Products>>();

            currentUserSession.ForEach(userSession =>
            {
                Products currentProduct = new();
                Users currentUser = new();
                List<Products> tempProducts = new List<Products>();

                users.ForEach(user =>
                {
                    if (userSession.currentUserId.Equals(user.UserId))
                    {
                        currentUser = user;
                    }
                    
                });
                products.ForEach(product =>
                {
                    if (userSession.currentProductId.Equals(product.ProductName))
                    {
                        currentProduct = product;
                        
                    }
                });
                
                products.ForEach(product =>
                {
                    int counter = 0;
                    currentProduct.getGenresToList().ForEach(genre =>
                    {
                        product.getGenresToList().ForEach(genreAllProducts =>
                        {
                            if(genre.Equals(genreAllProducts))
                            {
                               counter++; 
                            }

                        });
                    });

                    if(counter >= 3)
                    {
                        tempProducts.Add(product);
                    }
                });

                dict.Add(currentUser.UserName, tempProducts);
            });
            return dict;
        }
    }

}

