namespace WordSearch
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using WordSearch.DocumentHandler;

    internal class MenuHandler
    {
        private string _cowFile = @"D:\Utbildning\Datalogi\Testning\BinaryTreeTest\cow.txt";
        private string _chickenFile = @"D:\Utbildning\Datalogi\Testning\BinaryTreeTest\Chicken.txt";
        private string _sheepFile = @"D:\Utbildning\Datalogi\Testning\BinaryTreeTest\Sheep.txt";

        public void Menu()
        {
            Console.WriteLine("Welcome!");
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