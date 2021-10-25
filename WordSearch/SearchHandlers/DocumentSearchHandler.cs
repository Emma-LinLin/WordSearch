namespace WordSearch.SearchHandlers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Class for handeling requests from user
    /// </summary>
    internal class DocumentSearchHandler
    {
        /// <summary>
        /// Sorts incoming list in alphabetical order
        /// </summary>
        /// <param name="unOrdered">un sorted list</param>
        /// <returns>sorted list</returns>
        public List<string> SortList(List<string> unOrdered)
        {
            unOrdered.Sort();
            var sortedList = unOrdered;
            return sortedList;
        }

        /// <summary>
        /// Prints the number of words chosed by the user from the relevant list containing txt document
        /// </summary>
        /// <param name="userInput">number of words</param>
        /// <param name="sortedList">list sorted in alpabethical order</param>
        public void PrintNumberOfWords(int userInput, List<string> sortedList)
        {
            for (int i = 0; i < userInput; i++)
            {
                Console.WriteLine(sortedList[i]);
            }
        }
    }
}