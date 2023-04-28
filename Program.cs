//Written by Zach Lifferth
//Final Project: Website
//Coach Emailer Program

//This program will give you the ability to seach a school that you are interested in and will return
//the schools with the coaches names and emails so you have the ability to send recruitment emails to them.

using System;
using System.Text;
using System.Diagnostics;

namespace FinalProject
{
    internal class Program
    {
        //main method...where my other methods get called.
        static void Main()
        {
            //user input
            Console.WriteLine("Please select which division you would like to search (select a-c):");
            Console.WriteLine("\t[a] NCAA Divison 1");
            Console.WriteLine("\t[b] NCAA Divison 2");
            Console.WriteLine("\t[c] Both");

            Console.Write("Please enter your selection here: ");

            string divSelection = Console.ReadLine();

            if (ValidateDiv(divSelection) == false)
            {
                return;
            }

            string divisionKey = GetDivSearchKey(divSelection);

            Console.Write("Please enter a school name: ");
            string? schoolName = Console.ReadLine();

            var fileContents = LoadFile();

            List<string> searchResults = CoachSearch(divisionKey, schoolName, fileContents);

            Console.WriteLine($"{searchResults.Count} coaches found.");

            foreach (var coach in searchResults)
            {
                //Console.WriteLine(coach);
                FormatOutput(coach);
            }
        }

        //this method will make sure that the division you entered is valid. you are given a multiple choice
        //for the divison you would like to select and this makes sure you are in the boundries of those selections.
        static bool ValidateDiv(string divSelection)
        {
            // 1/2 tests used for my methods
            Debug.Assert(divSelection.Length > 0, "No divSelection entered.");
            Debug.Assert(divSelection.ToLower() == "a" ||
                         divSelection.ToLower() == "b" ||
                         divSelection.ToLower() == "c","Valid selection not entered.");

            //ToLower is so that everything will be formatted in lower case 
            if (divSelection.ToLower() == "a" ||
                divSelection.ToLower() == "b" ||
                divSelection.ToLower() == "c")
            {
                return true;
            }
            else
            {
                Console.WriteLine("Your entry is invalid...please enter a letter a-c");
                return false;
            }
        }

        //Get the search value from the user selection.
        //It is easier to ask for a-c and not NCAA_D1 for example because the odds of them typing it correctly
        //are not as high as they are for typing a-c.
        static string GetDivSearchKey(string divSelection)
        {
            string divisionKey = "";

            switch (divSelection.ToLower())
            {
                case "a":
                    divisionKey = "NCAA_D1";
                    break;

                case "b":
                    divisionKey = "NCAA_D2";
                    break;

                //default is for "c" it is both D1 and D2
                default:
                    divisionKey = "ALL";
                    break;
            }

            return divisionKey;
        }


        //This method will be able to go search through the file
        //After this is done it will return the search results from the certain school.
        static List<string> CoachSearch(string division, string school, IEnumerable<string> fileContents)
        {
            // 2/2 tests used for my methods
            Debug.Assert(school.Length > 0, "No school Entered");
            Debug.Assert(division.Length > 0, "No division Entered");
            Debug.Assert(fileContents != null, "fileContents is null");

            List<string> searchResults = new List<string>();

            //file contents are just the strings that are inside the file.
            //loops through each line. item is just the entire line
            foreach (var item in fileContents)
            {
                if (division == "ALL")
                {

                    if (item.ToLower().IndexOf(school.ToLower()) > -1)
                    {
                        searchResults.Add(item);
                    }

                }
                else
                {
                    if (item.ToLower().IndexOf(school.ToLower()) > -1 &&
                         item.IndexOf(division) > -1)
                    {
                        searchResults.Add(item);
                    }
                }

            }

            searchResults.Sort();
            return searchResults;
        }

        //This is where we open the text file and load all the contents into memory so we can load through it
        static IEnumerable<string> LoadFile()
        {
            string path = "COACHES.csv";
            //standard used for character recognition 
            return File.ReadLines(path, Encoding.UTF8);
        }

        //In this method it will put all the info returned from the search in a nice, neat order.
        //It splits everything from the text file and puts it in the order shown below.
        static void FormatOutput(string resultLine)
        {
            string[] resultSplit = resultLine.Split("|");
            Console.WriteLine($"NAME:\t{resultSplit[3]}");
            Console.WriteLine($"EMAIL:\t{resultSplit[4]}");
            Console.WriteLine($"SCHOOL:\t{resultSplit[1]}");
            Console.WriteLine($"SHORT:\t{resultSplit[2]}");
            Console.WriteLine($"DIV:\t{resultSplit[0]}");
            Console.WriteLine();
        }
    }
}

/*
10 required elements: 

1. reading from a text file: coaches and schools in a text file [x]
        -used on line 143 when i call it into memory

2. List: list of all coaches and schools [x]
        -used on line 105 when i use a list for CoachSearch

3. for each: show results of searches [x]
        -used on line 116, loops through each line and reads the item

4. two methods:  ValidateDiv, SearchSchool [x]
        -ValidateDiv(): this method will make sure that the division you entered is valid. line 54

5. two methods: FormatOutput, LoadFile(find file load from directory, put everything into memory) [x]
        -FormatOutput(): everything will be put into a nice order. Line 152

6. arrays: load the contents of the text file to array and then search the array [x]
        -Line 152 

7. if/else: to figure out logic in our search [x]
        -Line 63. Used to see if the user input is between a-c. Else try again.

8: input from user: ask for a school and what type of coach they are looking for [x]
        -used in line 20. Asks for which division they would like to search

9. string formatting: we can format the coach results [x]
        -line 154. use a split to format everything out from the line or item

10. switch: determine the type of search the user may want. [x]
        -used on line 83 to switch NCAA_D1 to "a" so the user input is easier to type.
*/

//Psuedo code user input:
//ask for them to type a-c for which division they would like to pursue
//print "please enter school name"
//print how many coaches found
//print the file contents in a certain format
//give all the information on the school and coach
