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

namespace Users
{
    public class Users
    {


        public Users(int id, string name, string viewed, string purchased)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
            };
            using (var reader = new StreamReader(@"F:\CSV\Users.txt"))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Users>();
            }
                      
            this.UserId = id;
            this.UserName = name;
            this.UserViewed = viewed;
            this.UserPurchased = purchased;

        }

        [Index(0)]
        public int UserId { get; set; }
        [Index(1)]
        public string UserName { get; set; }
        [Index(2)]
        public string UserViewed { get; set; }
        [Index(3)]
        public string UserPurchased { get; set; }



       
    }
}


/*public static List<Users> Users1()
{
    string[] reader = System.IO.File.ReadAllLines(@"F:\CSV\Users.txt");
    List<Users> userList = new List<Users>();



    for (int i = 0; i < reader.Length; i++)
    {
        string[] stringArray = reader[i].Split(",");

        for (int y = 0; y < stringArray.Length - 1; y++)
        {

            Users users =new(Convert.ToInt32(stringArray[0]), stringArray[1], stringArray[2], stringArray[3]);
            userList.Add(users);
        }
    }
    return userList; } */



//reader.GetValue(0), reader.GetValue(1), reader.GetValue(2), reader.GetValue(3)):








