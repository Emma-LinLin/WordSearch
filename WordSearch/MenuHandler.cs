namespace WordSearch
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using WordSearch.DocumentHandler;
    using WordSearch.Helpers;
    using WordSearch.SearchHandlers;
    using WordSearch.Seeder;

    internal class MenuHandler
    {
        private List<string> cowList = default;
        private List<string> chickenList = default;
        private List<string> sheepList = default;

        private string _cowPath = @"\cow.txt";
        private string _chickenPath = @"\Chicken.txt";
        private string _sheepPath = @"\Sheep.txt";
        private InputHandler helperPointer = new InputHandler();
        private SearchHandler searchPointer = new SearchHandler();

        public void Menu()
        {
            Seed();
            Console.WriteLine("Welcome!");

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Search word");
                Console.WriteLine("2. Order document and search for x number of words");
                Console.WriteLine("3. Print datastructure");
                Console.WriteLine("4. Exit\n");
                int userInput = helperPointer.ParseUserInput();
                switch (userInput)
                {
                    case 1:

                        break;

                    case 2:
                        ListChoice();
                        break;

                    case 3:
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invaild option");
                        break;
                }
            }
        }

        private void ListChoice()
        {
            List<string> sortedList = new List<string>();
            Console.WriteLine("What document would you like to search?");
            Console.WriteLine("1. cow.txt\n2. Chicken.txt\n3. Sheep.txt ");
            int userInput = helperPointer.ParseUserInput();

            switch (userInput)
            {
                case 1:
                    sortedList = searchPointer.SortList(cowList);
                    break;

                case 2:
                    sortedList = searchPointer.SortList(chickenList);
                    break;

                case 3:
                    sortedList = searchPointer.SortList(sheepList);
                    break;

                default:
                    Console.WriteLine("Invaild option");
                    break;
            }

            Console.WriteLine("And how many words would you like to print?");
            userInput = helperPointer.ParseUserInput();
            searchPointer.WordCount(userInput, sortedList);
        }

        private void Seed()
        {
            ListSeeder seederPointer = new ListSeeder();
            cowList = seederPointer.Seeder(_cowPath);
            chickenList = seederPointer.Seeder(_chickenPath);
            sheepList = seederPointer.Seeder(_sheepPath);
        }
    }
}