namespace WordSearch.DocumentHandler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Temporary object for saving results based of search word into documentlist
    /// </summary>
    internal class SearchResult
    {
        public string FileName { get; set; }
        public string SearchWord { get; set; }
        public int Repeats { get; set; }

        /// <summary>
        /// Creating a new search result containing temporary data
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="searchWord">search word</param>
        /// <param name="repeats">number of times search word is found</param>
        public SearchResult(string fileName, string searchWord, int repeats)
        {
            FileName = fileName;
            SearchWord = searchWord;
            Repeats = repeats;
        }
    }
}