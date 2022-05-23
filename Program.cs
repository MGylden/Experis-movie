using System;
using Experis_movie.Models;
using Experis_movie.Operations;

namespace Experis_movie
{
    public class Movie
    {
        public static void Main(string[] args)
        {
            //Initialize Variables
           List<Products> products = new List<Products>();
            List<Users> users = new List<Users>();
            List<CurrentUserSession> currentUserSessions = new List<CurrentUserSession>();
            Dictionary<string, int> listOfMostPopularMovies = new();
            Dictionary<string, double> listmostPopularMoviesByRating = new Dictionary<string, double>();
            List<Products> ListOfRecommendedMoviesByUnitsSoldAndUserReviews = new List<Products>();
            Dictionary<string, List<Products>> RecommendedMoviesOnUserSession = new Dictionary<string, List<Products>>();

            //The following Parse our .txt to objects
            try
            {
                users = CsvOperations.ParseTxtToUsers();
                products = CsvOperations.ParseToProducts();
                currentUserSessions = CsvOperations.ParseToUserssession();
            }
            catch (Exception e)
            {
                //Catch errors and exit
                Console.WriteLine("Something failed.... \n" + e.Message);
                Console.WriteLine("Exiting after any button pressed....");
                Console.ReadKey();
                Environment.Exit(0);
            }
            
           
            //1.
            //Prints 3 most popular movies by units sold (purchased movies)
            listOfMostPopularMovies = mostPopularMovies.mostPopularMoviesPurchased(users, products);
            Console.WriteLine("Movie recommendations based on units sold:");
            //Take can be changed if desired to show more from the list (etc. the 5 most popular movies instead of 3)
            foreach (var item in listOfMostPopularMovies.Take(3))
            {
                Console.WriteLine($"Movie: {item.Key}, Sold amount: {item.Value}");
            }
            Console.ReadKey();
            Console.WriteLine("\n");

            //Prints 3 highest rated movies descending
            listmostPopularMoviesByRating = mostPopularMovies.mostPopularMoviesByRating(products);
            Console.WriteLine("\n\nMovie recommendations based on user ratings:");
            //Take can be changed if desired to show more from the list (etc. the 5 highest rated movies instead of 3)
            foreach (var item in listmostPopularMoviesByRating.Take(3))
            {
                Console.WriteLine($"Movie: {item.Key}, user rating: {item.Value}");
            }

            Console.ReadKey();
            Console.WriteLine("\n");

            //2.
            //Prints movie recommendations for each user.
            RecommendedMoviesOnUserSession = mostPopularMovies.RecommendedMoviesOnUserSession(users, products, currentUserSessions);
            foreach (var recommendation in RecommendedMoviesOnUserSession.Keys)
            {
                Console.WriteLine($"Movie recommendations for: {recommendation}");
                foreach (var product in RecommendedMoviesOnUserSession[recommendation])
                {
                    Console.WriteLine($"Movie: {product.ProductName}");
                }
                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }


    }
}