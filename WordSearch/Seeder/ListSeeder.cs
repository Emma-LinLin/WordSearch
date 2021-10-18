namespace WordSearch.Seeder
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using WordSearch.DocumentHandler;

    internal class ListSeeder
    {
        public List<string> Seeder(string fileName)
        {
            return Fetch(GetPath(fileName));
        }

        private string GetPath(string fileName)
        {
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string path = $"{dir}{fileName}";

            return path;
        }

        private static List<string> Fetch(string filePath)
        {
            FileReader fileReaderPointer = new FileReader();
            string documentText = fileReaderPointer.ReadFile(filePath);
            return fileReaderPointer.SplitLine(documentText);
        }
    }
}