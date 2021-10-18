namespace WordSearch.SearchHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    internal class SearchHandler
    {
        public List<string> SortList(List<string> unOrdered)
        {
            unOrdered.Sort();
            var sortedList = unOrdered;
            return sortedList;
        }

        public void WordCount(int userInput, List<string> sortedList)
        {
            for (int i = 0; i < userInput; i++)
            {
                Console.WriteLine(sortedList[i]);
            }
        }
    }
}