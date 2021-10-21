namespace WordSearch.DocumentHandler
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    internal class DocumentController
    {
        private List<Document> ListOfDocuments = new List<Document>();

        public void AddItemToList(string fileName, string searchWord, int repeats)
        {
            ListOfDocuments.Add(new Document(fileName, searchWord, repeats));
        }

        public List<Document> GetList()
        {
            return ListOfDocuments;
        }

        /// <summary>
        /// Clear list from used content in order to make it ready for next search.
        /// </summary>
        public void ClearList()
        {
            ListOfDocuments.Clear();
        }
    }
}