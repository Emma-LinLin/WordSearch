namespace WordSearch.DocumentHandler
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;

    internal class FileReader
    {
        //@"D:\Utbildning\Datalogi\Testning\BinaryTreeTest\cow.txt"
        public string ReadFile(string path)
        {
            string fileString = File.ReadAllText(path);

            return fileString;
        }

        public List<string> SplitLine(string fileText)
        {
            List<string> wordList = new List<string>();

            string[] wordCollection = fileText.Split(' ');

            foreach (var sub in wordCollection)
            {
                wordList.Add(sub);
            }

            return wordList;
        }
    }
}