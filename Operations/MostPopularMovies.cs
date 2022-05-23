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

        /// <summary>
        /// The following method takes a list of Users and Products, and returns a dictionary based on purchases from Users.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public static Dictionary<string, int> mostPopularMoviesPurchased(List<Users> users, List<Products> products)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (Users user in users)
            {
                foreach (Products movie in products)
                {
                    foreach (string value in user.listOfPurchasedMovieIds())
                    {
                        // .txt had whitespaces, replace them and equals our split purchased list to ProductId.
                        if (value.Replace(" ", "").Equals(movie.ProductId.ToString()))
                        {
                            //Check to see if products exist, if it does update+1, if not add to dictionary.
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
            //Sorts dictionary descending and converts back to dictionary
            var sortedDict = from entry in dict orderby entry.Value descending select entry;
            return dict = sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        /// The following method takes a list of Products, and returns a dictionary based on Rating.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
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
            //Sorts dictionary descending and converts back to dictionary
            var sortedDict = from entry in dict orderby entry.Value descending select entry;
            return dict = sortedDict.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        /// The following method takes a list of Users and Products, and returns a list with rating >3.5 and movies that have been purchased most amount of times. 
        /// </summary>
        /// <param name="users"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        public static List<Products> listOfRecommendedMoviesByMostPurchasedAndUserReviews(List<Users> users, List<Products> products)
        { 
            List<Products> moviesOnlyWithHighRating = new List<Products>();
            List<Products> moviesWithUnitsSold = new List<Products>();

            //Following makes a list containing productRating > 3.5
            for (int y = 0; y < products.Count; y++)
            {
                if (products.ElementAt(y).ProductRating > 3.5)
                {
                    moviesOnlyWithHighRating.Add(products.ElementAt(y));
                }
            }
            //Following makes a list of most purchased movies
            users.ForEach(user =>
            {
                //Using split method from Users to split data (loaded in as x;y;K)
                user.listOfPurchasedMovieIds().ForEach(productId =>
                {
                    products.ForEach(product =>
                    {
                        // .txt had whitespaces, replace them and equals our split list to ProductId.
                        if (productId.Replace(" ", "").Equals(product.ProductId))
                        {
                            moviesWithUnitsSold.Add(product);
                        }
                    });
                });
            });
            //Links list with a product rating >3.5 and movies that have been purchased the most amount of times and returns that list.
            List<Products> movieRecommendationList = moviesWithUnitsSold.Union(moviesOnlyWithHighRating).ToList();
            return movieRecommendationList;
        }

        /// <summary>
        /// The following method takes a list of Users and Products and CurrentUserSession, and returns a dictionary with movie recommendations for each User.
        /// </summary>
        /// <param name="users"></param>
        /// <param name="products"></param>
        /// <param name="currentUserSession"></param>
        /// <returns></returns>
        public static Dictionary<string,List<Products>> recommendedMoviesOnUserSession(List<Users> users, List<Products> products, List<CurrentUserSession> currentUserSession)
        {
            Dictionary<string, List<Products>> dict = new Dictionary<string,List<Products>>();

            currentUserSession.ForEach(userSession =>
            {
                Products currentProduct = new();
                Users currentUser = new();
                List<Products> tempProducts = new List<Products>();

                //The following gets product data.
                users.ForEach(user =>
                {
                    if (userSession.currentUserId.Equals(user.UserId))
                    {
                        currentUser = user;
                    }
                });
                //The following gets product data.
                products.ForEach(product =>
                {
                    if (userSession.currentProductId.Equals(product.ProductId))
                    {
                        currentProduct = product;
                    }
                });
                //The following checks all keywords and adds to counter if it already exist.
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
                    //Adds movie to list if 2 or more keywords match.
                    if(counter >= 2)
                    {
                        tempProducts.Add(product);
                    }
                });
                //Add our lists to dictionary and return dictionary.
                dict.Add(currentUser.UserName, tempProducts);
            });
            return dict;
        }
    }
}

