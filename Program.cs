using System;
using Experis_movie.Models;
using Experis_movie.Operations;

namespace Experis_movie
{
    public class Movie
    {
        public static void Main(string[] args)
        {
           List<Products> products = new List<Products>();
            List<Users> users = new List<Users>();
            List<CurrentUserSession> currentUserSessions = new List<CurrentUserSession>();
            Dictionary<string, int> listOfMostPopularMovies = new Dictionary<string, int>();
            Dictionary<string, double> listmostPopularMoviesByRating = new Dictionary<string, double>();
            List<Products> ListOfRecommendedMoviesByUnitsSoldAndUserReviews = new List<Products>();
            Dictionary<string, List<Products>> RecommendedMoviesOnUserSession = new Dictionary<string, List<Products>>();


            try
            {
                users = CsvOperations.ParseCsvToUsers();
                products = CsvOperations.ParseToProducts();
                currentUserSessions = CsvOperations.ParseToUserssession();
            }
            catch (Exception e)
            {
                //If this fails, exit no matter what...
                Console.WriteLine("Something failed.... \n" + e.Message);
                Console.WriteLine("Exiting after any button pressed....");
                Console.ReadKey();
                Environment.Exit(0);
            }
            foreach (var item in products)
            {
                Console.WriteLine(item.ProductRating);
            }
            foreach (var item in currentUserSessions)
            {
                Console.WriteLine(item.currentProductId);
            }

            listOfMostPopularMovies = mostPopularMovies.mostPopularMoviesPurchased(users, products);
            Console.WriteLine("Movie recommendations based on units sold:");
            foreach (var item in listOfMostPopularMovies.Take(4))
            {
                Console.WriteLine($"Movie: {item.Key}, Sold amount: {item.Value}");
            }
            Console.ReadKey();
            Console.WriteLine("\n");

            listmostPopularMoviesByRating = mostPopularMovies.mostPopularMoviesByRating(products);
            Console.WriteLine("\n\nMovie recommendations based on user ratings:");
            foreach (var item in listmostPopularMoviesByRating.Take(4))
            {
                Console.WriteLine($"Movie: {item.Key}, user rating: {item.Value}");
            }

            Console.ReadKey();
            Console.WriteLine("\n");

            RecommendedMoviesOnUserSession = mostPopularMovies.RecommendedMoviesOnUserSession(users, products, currentUserSessions);
            foreach (var recommendation in RecommendedMoviesOnUserSession.Keys)
            {
                Console.WriteLine($"Movie recommendations for: {recommendation}");
                foreach (var product in RecommendedMoviesOnUserSession[recommendation])
                {
                    Console.WriteLine($"{product}");
                }
                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }


    }
}