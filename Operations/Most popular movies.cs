﻿using System;
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

namespace Experis_movie
{
    internal class mostPopularMovies
    {
        public static Dictionary<string, int> mostPopularMoviesPurchased(List<Users> users)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (Users purchase in users)
            {
                string[] purchasedByUser = users.userPurchased.Split(";")


                    .Split(";")

                for (int j = 0; j < stringArray.Length - 1; j++)
                {

                    Users users = new(Convert.ToInt32(stringArray[0]), stringArray[1], stringArray[2], stringArray[3]);
                    userList.Add(users);

                    List<Users> userPurchased = userList[3];

                    //string[] stringArray2 = stringArray[2].Split(";");

                    for (int y = 0; y < userPurchased.Length - 1; y++)
                    {
                        userPurchased.Sort();
                    }
                }
            }
        }
    } 
}
