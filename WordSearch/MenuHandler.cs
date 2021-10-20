﻿namespace WordSearch
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using WordSearch.Datastructure;
    using WordSearch.DocumentHandler;
    using WordSearch.Helpers;
    using WordSearch.SearchHandlers;
    using WordSearch.Seeder;

    /// <summary>
    /// Starts the menu system
    /// </summary>
    internal class MenuHandler
    {
        /// <summary>
        /// Global variables containing lists and paths
        /// </summary>
        private List<string> cowList = default;
        private List<string> chickenList = default;
        private List<string> sheepList = default;

        private string _cowPath = @"\cow.txt";
        private string _chickenPath = @"\Chicken.txt";
        private string _sheepPath = @"\Sheep.txt";
        private InputHandler helperPointer = new InputHandler();
        private SearchHandler searchPointer = new SearchHandler();

        /// <summary>
        /// Main menu presented to user when program is started
        /// </summary>
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
                        SearchWord();
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

        private void SearchWord()
        {
            BinaryTree binaryTree = new BinaryTree();

            int counter = default;
            string document = default;
            Console.WriteLine("What word would you like to search for?");
            string userInput = Console.ReadLine();

            var listOfDocuments = new List<List<string>>()
            {
                cowList,
                chickenList,
                sheepList,
            };

            foreach(var list in listOfDocuments)
            {
                if (list.Contains(userInput))
                {
                    if(list == cowList)
                    {
                        document = "cow.txt";
                    }
                    if (list == chickenList)
                    {
                        document = "chicken.txt";
                    }
                    if (list == sheepList)
                    {
                        document = "sheep.txt";
                    }
                    foreach (var item in list)
                    {
                        if (item == userInput)
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine($"we found {counter} matches in {document} to your search word\nWould you like to save the output?");
            Console.WriteLine("[Y] for yes, [N] for no");
            var userChoice = Console.ReadLine().ToLower();
            if(userChoice == "y")
            {
                binaryTree.Insert(counter, userInput, document);
            }

        }

        /// <summary>
        /// User can decide what document and number of words they would like to see
        /// </summary>
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
            searchPointer.PrintNumberOfWords(userInput, sortedList);
        }

        /// <summary>
        /// Calls upon seeder forwarding the paths wanted
        /// </summary>
        private void Seed()
        {
            ListSeeder seederPointer = new ListSeeder();
            cowList = seederPointer.Seeder(_cowPath);
            chickenList = seederPointer.Seeder(_chickenPath);
            sheepList = seederPointer.Seeder(_sheepPath);
        }
    }
}