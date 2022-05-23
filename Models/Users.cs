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
    public class Users
    {
        public Users(int id, string name, string viewed, string purchased)
        {
            this.UserId = id;
            this.UserName = name;
            this.UserViewed = viewed;
            this.UserPurchased = purchased;
        }
        public Users()
        {

        }

        [Index(0)]
        public int UserId { get; set; }
        [Index(1)]
        public string UserName { get; set; }
        [Index(2)]
        public string UserViewed { get; set; }
        [Index(3)]
        public string UserPurchased { get; set; }

        public List<string> UserPurchasedSplit { get; set; }

        //Method which split the values and returns as a list
        public List<string> listOfPurchasedMovieIds()
        {
            string[] tempArray = UserPurchased.Split(';');
            List<string> tempList = new List<string>();

            foreach (string movieId in tempArray)
            {
                tempList.Add(movieId.Replace(" ",""));
            }
            return tempList;
        }

    }
}