//Written by Zach Lifferth
//Final Project CS 1400
//Coach Emailer Program

using System;
using System.Text;
using System.Diagnostics;

namespace FinalProject
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Please enter a school name: ");
            string? schoolName = Console.ReadLine();

            var fileContents = LoadFile();

            List<string> searchResults = CoachSearch(schoolName, fileContents);

            Console.WriteLine($"{searchResults.Count} coaches found.");

            foreach (var coach in searchResults)
            {
                //Console.WriteLine(coach);
                FormatOutput(coach);
            }
        }
        //This method will be able to go through the file
        //After this is done it will return the coaches from the certain school
        static List<string> CoachSearch(string school, IEnumerable<string> fileContents)
        {
            Debug.Assert(school.Length > 0, "No school Entered");

            List<string> searchResults = new List<string>();

            foreach (var item in fileContents)
            {
                if (item.ToLower().IndexOf(school.ToLower()) > -1)
                {
                    searchResults.Add(item);
                }
            }

            searchResults.Sort();
            return searchResults;
        }

        static IEnumerable<string> LoadFile()
        {
            string path = "COACHES.csv";
            return File.ReadLines(path, Encoding.UTF8);
        }

        static void FormatOutput(string resultLine)
        {
            string[] resultSplit = resultLine.Split("|");
            Console.WriteLine($"NAME:\t{resultSplit[3]}");
            Console.WriteLine($"EMAIL:\t{resultSplit[4]}");
            Console.WriteLine($"SCHOOL:\t{resultSplit[0]}");
            Console.WriteLine($"SHORT:\t{resultSplit[1]}");
            Console.WriteLine();
        }
    }
}

/*
Requirements for question two

I will use a flow chart for the search of the head coach method.

pseudo code will be used for the file load method we will be doing 

use cases: user searches for coach by school name, user searches for assistant coach by school name


10 required elements 

1. reading from a text file: coaches and schools in a text file [x]

2. List: list of all coaches and schools [x]

3. for each: show results of searches [x]

4. two methods:  SearchDivision, SearchSchool []

5. two methods: FormatOutput, LoadFile(find file load from directory, put everything into memory) [x]

6. arrays: load the contents of the text file to array and then search the array [x]

7. if/else: to figure out logic in our search [x]

8: input from user: ask for a school and what type of coach they are looking for [x]

9. string formatting: we can format the coach results [x]

10. switch: determine the type of search the user may want. []
*/