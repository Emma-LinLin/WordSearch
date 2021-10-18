namespace WordSearch
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using WordSearch.DocumentHandler;

    internal class MenuHandler
    {
        private string _cowPath = @"\cow.txt";
        private string _chickenPath = @"\Chicken.txt";
        private string _sheepPath = @"\Sheep.txt";

        public void Menu()
        {
            Console.WriteLine("Welcome!");
            //Fetch(_cowFile);

            string path = GetPath(_cowPath);
            Fetch(path);
        }

        private string GetPath(string fileName)
        {
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string path = $"{dir}{fileName}";

            return path;
        }

        private static void Fetch(string filePath)
        {
            FileReader testing = new FileReader();
            string test = testing.ReadFile(filePath);
            List<string> testing2 = testing.SplitLine(test);

            foreach (var item in testing2)
            {
                Console.WriteLine(item);
            }
        }
    }
}