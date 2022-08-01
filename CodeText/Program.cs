using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CodeText;

namespace CodeText
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //C:\Users\TunbakH\Downloads\AliceTextFile.txt
            Console.WriteLine("Hello There!\n Please specify the path of the text file");
            string inputPath = Console.ReadLine();
            Console.WriteLine("Please enter the filter value as an integer. \n 1 = RemoveWordsWithVowelInMiddle \n 2 = RemoveWordsShorterThanThree \n 3 = RemoveWordsWithLetterT ");
            Int32.TryParse( Console.ReadLine() , out int filterEnumType);
            IEnumerable<string> filteredLines = ReadTextFile(inputPath, filterEnumType);
            foreach (string filteredLine in filteredLines)
            {
                System.Console.WriteLine(filteredLine);
            }    

        }
       
        private static IEnumerable<string> ReadTextFile(string filePath, int filterEnumType)
        {          
            IEnumerable<string> linesOfString = System.IO.File.ReadLines(filePath);
            switch (filterEnumType)
            {
                case 1:
                    foreach (string lineOfString in linesOfString)
                    {
                        string lineWithVowelInMiddle = FilterMethods.RemoveWordsWithVowelInMiddle(lineOfString);
                        yield return lineWithVowelInMiddle;
                    }
                    break;
                case 2:
                    foreach (string lineOfString in linesOfString)
                    {
                        string lineWithWordsLongerThanThree = FilterMethods.RemoveWordsShorterThanThree(lineOfString);
                        yield return lineWithWordsLongerThanThree;
                    }
                    break;
                case 3:
                    foreach (string lineOfString in linesOfString)
                    {
                        string lineWithRemovedLetterT = FilterMethods.RemoveWordsWithLetterT(lineOfString);
                        yield return lineWithRemovedLetterT;
                    }
                    break;
                default:                    
                    throw new Exception("Invalid input");                  
            }

            //foreach (string lineOfString in linesOfString)
            //{
            //    string lineWithRemovedLetterT = FilterMethods.RemoveWordsWithLetterT(lineOfString);
            //    //string lineWithWordsLongerThanThree = FilterMethods.RemoveWordsShorterThanThree(lineOfString);
            //    //string lineWithVowelInMiddle = FilterMethods.RemoveWordsWithVowelInMiddle(lineOfString);
            //    yield return lineWithRemovedLetterT;
            //    //yield return lineWithWordsLongerThanThree;
            //    //yield return lineWithVowelInMiddle;
            //} 
        }

    }
}
