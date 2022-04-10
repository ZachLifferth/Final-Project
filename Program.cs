//Written by Zach Lifferth
//Final Project CS 1400
//Coach Emailer Program

using System;
using System.Diagnostics;

namespace FinalProject 
{
    internal class Program
    {
        static void Main()
        {
            List<string> searchResults = CoachSearch("Snow College");
            foreach (var coach in searchResults)
            {
                Console.WriteLine(coach);
            }
        }
        //This method will be able to go through the file
        //After this is done it will return the coaches from the certain school
        static List<string> CoachSearch(string school)
        {
            Debug.Assert(school.Length > 0, "No school Found");
            return new List<string> {"Coach Long"};
        }
    }
}