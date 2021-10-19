namespace WordSearch.Seeder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using WordSearch.DocumentHandler;

    /// <summary>
    /// class for handeling start data
    /// </summary>
    internal class ListSeeder
    {
        /// <summary>
        /// Forwards the response of filepath and fetches the sorted list from txt file
        /// </summary>
        /// <param name="fileName">name of the file wanted</param>
        /// <returns>sorted list</returns>
        public List<string> Seeder(string fileName)
        {
            return Fetch(GetPath(fileName));
        }

        /// <summary>
        /// Gets the path of wanted file
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>full path</returns>
        private string GetPath(string fileName)
        {
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string path = $"{dir}{fileName}";

            return path;
        }

        /// <summary>
        /// Reads the file based of file path and splits the file into separated words
        /// </summary>
        /// <param name="filePath">full path</param>
        /// <returns>list of separated words</returns>
        private static List<string> Fetch(string filePath)
        {
            FileReader fileReaderPointer = new FileReader();
            string documentText = fileReaderPointer.ReadFile(filePath);
            return fileReaderPointer.SplitLine(documentText);
        }
    }
}