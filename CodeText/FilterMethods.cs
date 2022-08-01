using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeText
{
    public class FilterMethods
    {
        //I need to 1) read the contents of the text file, 2) perhaps put every word into a List of items<words> 3) remove words from the list 4)put things back into one 
        //big string

        //Areas of focus include a) implementing the features correctly, b) being efficient memory-wise and time-wise, c) being able to read large files without crashing
        //d) allowing for scaling of the application

        public static string RemoveWordsWithVowelInMiddle(string lineOfWords)
        {
            List<string> individualWordsList = lineOfWords.Split().ToList();
            List<string> filteredIndividualWordsList = new List<string>();
            foreach (string word in individualWordsList)
            {
                if (word.Length % 2 == 1)
                {
                    char centreLetter = word[(word.Length / 2)];
                    if ("aeiou".IndexOf(centreLetter.ToString(), StringComparison.InvariantCultureIgnoreCase) < 0) //returns -1 if no match
                    {
                        filteredIndividualWordsList.Add(word);
                    }
                }
                if (word.Length % 2 == 0)
                {
                    char firstCentreLetter = word[(word.Length / 2) - 1];
                    char secondCentreLetter = word[(word.Length / 2)];
                    if (("aeiou".IndexOf(firstCentreLetter.ToString(), StringComparison.InvariantCultureIgnoreCase) < 0) &&
                        ("aeiou".IndexOf(secondCentreLetter.ToString(), StringComparison.InvariantCultureIgnoreCase) < 0)) //returns -1 if no match
                    {
                        filteredIndividualWordsList.Add(word);
                    }
                }
            }
            string newLineOfWords = "";
            foreach (string word in filteredIndividualWordsList)
            {
                newLineOfWords += word + " ";
            }
            return newLineOfWords;
        }
        public static string RemoveWordsShorterThanThree(string lineOfWords)
        {
            List<string> individualWordsList = lineOfWords.Split().ToList();
            List<string> filteredIndividualWordsList = new List<string>();
            foreach (string word in individualWordsList)
            {
                if (word.Length >= 3)
                {
                    filteredIndividualWordsList.Add(word);
                };
            }
            string newLineOfWords = "";
            foreach (string word in filteredIndividualWordsList)
            {
                newLineOfWords += word + " ";
            }
            return newLineOfWords;
        }

        public static string RemoveWordsWithLetterT(string lineOfWords)
        {
            string regexStrExpression = "^(?!.*t).*$";
            Regex r = new Regex(regexStrExpression, RegexOptions.IgnoreCase);
            List<string> individualWordsList = lineOfWords.Split().ToList();
            List<string> filteredIndividualWordsList = new List<string>();
            foreach (string word in individualWordsList)
            {
                Match matchRegex = r.Match(word);
                if (matchRegex.Success)
                {
                    filteredIndividualWordsList.Add(word);
                };
            }
            string newLineOfWords = "";
            foreach (string word in filteredIndividualWordsList)
            {
                newLineOfWords += word + " ";
            }
            return newLineOfWords;
        }
        
    }
}
