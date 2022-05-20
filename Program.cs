using System;

namespace movie_recommendations
{
    public class Movie
    {
        public static void Main(string[] args)
        {
            {
                string[] reader = System.IO.File.ReadAllLines(@"F:\CSV\Users.txt");
                List<Users.Users> userList = new List<Users.Users>();



                for (int i = 0; i < reader.Length; i++)
                {
                    string[] stringArray = reader[i].Split(',');

                    for (int j = 0; j < stringArray.Length - 1; j++)
                    {

                        Users.Users users = new(Convert.ToInt32(stringArray[0]), stringArray[1], stringArray[2], stringArray[3]);
                        userList.Add(users);
                        
                        List<Users.Users> userPurchased = userList
                        
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
}