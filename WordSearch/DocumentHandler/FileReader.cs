namespace WordSearch.DocumentHandler
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Takes care of reading and sorting content of files
    /// </summary>
    internal class FileReader
    {
        /// <summary>
        /// Reads the txt file based off path
        /// </summary>
        /// <param name="path">file path</param>
        /// <returns>string with the content of the txt file</returns>
        public string ReadFile(string path)
        {
            string fileString = File.ReadAllText(path).ToLower();

            return fileString;
        }

        /// <summary>
        /// Splits the content of the file based of the spaces in the file
        /// </summary>
        /// <param name="fileText">text within the txt file</param>
        /// <returns>a list with separated words</returns>
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