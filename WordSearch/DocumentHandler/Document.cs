namespace WordSearch.DocumentHandler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Document
    {
        public string FileName { get; set; }
        public string SearchWord { get; set; }
        public int Repeats { get; set; }

        public Document(string fileName, string searchWord, int repeats)
        {
            FileName = fileName;
            SearchWord = searchWord;
            Repeats = repeats;
        }
    }
}