namespace WordSearch.DocumentHandler
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class responsible for adding search results to temporary list, and also removing results when not needed
    /// </summary>
    internal class SearchResultController
    {
        private List<SearchResult> ListOfSearchResults = new List<SearchResult>();

        /// <summary>
        /// Adds a new search result to the list
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="searchWord">search word</param>
        /// <param name="repeats">number of times search word occurs</param>
        public void AddItemToList(string fileName, string searchWord, int repeats)
        {
            ListOfSearchResults.Add(new SearchResult(fileName, searchWord, repeats));
        }

        /// <summary>
        /// Gets the list and orders it based of the number of repeats
        /// </summary>
        /// <returns>the list in order</returns>
        public List<SearchResult> GetList()
        {
            return ListOfSearchResults.OrderByDescending(v => v.Repeats).ToList();
        }

        /// <summary>
        /// Clear list from used content in order to make it ready for next search.
        /// </summary>
        public void ClearList()
        {
            ListOfSearchResults.Clear();
        }
    }
}