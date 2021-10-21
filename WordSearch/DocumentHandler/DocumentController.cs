namespace WordSearch.DocumentHandler
{
    using System;
    using System.Collections.Generic;
    using System.Text;

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
    }
}