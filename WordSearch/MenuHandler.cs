namespace WordSearch
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using WordSearch.DocumentHandler;
    using WordSearch.Seeder;

    internal class MenuHandler
    {
        private List<string> cowList = default;
        private List<string> chickenList = default;
        private List<string> sheepList = default;
        private string _cowPath = @"\cow.txt";
        private string _chickenPath = @"\Chicken.txt";
        private string _sheepPath = @"\Sheep.txt";

        public void Menu()
        {
            ListSeeder seederPointer = new ListSeeder();
            cowList = seederPointer.Seeder(_cowPath);
            chickenList = seederPointer.Seeder(_chickenPath);
            sheepList = seederPointer.Seeder(_sheepPath);
            Console.WriteLine("Welcome!");
        }
    }
}