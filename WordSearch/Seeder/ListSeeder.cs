namespace WordSearch.Seeder
{
    using System.Collections.Generic;
    using System.IO;
    using WordSearch.DocumentHandler;

    /// <summary>
    /// class for handeling start data
    /// </summary>
    internal class ListSeeder
    {
        public List<string> cowList = default;
        public List<string> chickenList = default;
        public List<string> sheepList = default;

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
        /// Calls upon seeder forwarding the paths wanted.
        /// </summary>
        public void Seed()
        {
            cowList = Seeder(@"\Cow.txt");
            chickenList = Seeder(@"\Chicken.txt");
            sheepList = Seeder(@"\Sheep.txt");
        }

        /// <summary>
        /// Reads the file based of file path and splits the file into separated words
        /// </summary>
        /// <param name="filePath">full path</param>
        /// <returns>list of separated words</returns>
        private static List<string> Fetch(string filePath)
        {
            FileReader fileReaderPointer = new FileReader();
            string documentText = fileReaderPointer.ReadFile(filePath).ToLower();
            string fixedDocument = fileReaderPointer.RemoveSymbols(documentText);
            return fileReaderPointer.SplitLine(fixedDocument);
        }
    }
}