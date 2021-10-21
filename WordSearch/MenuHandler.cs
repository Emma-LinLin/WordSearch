namespace WordSearch
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
        private BinaryTree binaryTree = new BinaryTree();
        private string _cowPath = @"\cow.txt";
        private string _chickenPath = @"\Chicken.txt";
        private string _sheepPath = @"\Sheep.txt";
        private InputHandler helperPointer = new InputHandler();
        private SearchHandler searchPointer = new SearchHandler();
        private DocumentController documentContPointer = new DocumentController();

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
                        PrintStructure();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invaild option");
                        break;
                }
            }
        }

        /// <summary>
        /// Search for word based on user input through all document lists.
        /// </summary>
        private void SearchWord()
        {
            Console.WriteLine("What word would you like to search for?");
            string userInput = Console.ReadLine();

            ListCheck(userInput);

            var listsWithWord = documentContPointer.GetList();

            foreach (var list in listsWithWord)
            {
                Console.WriteLine($"we found {list.Repeats} matches in {list.FileName} to your search word\n");
            }
            Console.WriteLine("Would you like to save the output to the datastructure");
            Console.WriteLine("[Y] for yes, [N] for no");
            var userChoice = Console.ReadLine().ToLower();
            if (userChoice == "y")
            {
                foreach (var list in listsWithWord)
                {
                    binaryTree.Insert(list.Repeats, list.SearchWord, list.FileName);
                }
            }
            documentContPointer.ClearList();
        }

        /// <summary>
        /// Check how many times the word searched for occures inside document.
        /// </summary>
        /// <param name="userInput">User input</param>
        /// <param name="document">Name of file</param>
        /// <param name="wordList">Document list containing words from read file.</param>
        public void WordRepeatCheck(string userInput, string document, List<string> wordList)
        {
            int counter = default;

            foreach (var item in wordList)
            {
                if (item == userInput)
                {
                    counter++;
                }
            }
            documentContPointer.AddItemToList(document, userInput, counter);
        }

        /// <summary>
        /// Check if word exists in one or more of the text files.
        /// </summary>
        /// <param name="userInput">User input</param>
        public void ListCheck(string userInput)
        {
            var listOfDocuments = new List<List<string>>()
            {
                cowList,
                chickenList,
                sheepList,
            };

            foreach (var list in listOfDocuments)
            {
                if (list.Contains(userInput))
                {
                    string document = default;
                    if (list == cowList)
                    {
                        document = "cow.txt";
                        WordRepeatCheck(userInput, document, list);
                    }
                    if (list == chickenList)
                    {
                        document = "Chicken.txt";
                        WordRepeatCheck(userInput, document, list);
                    }
                    if (list == sheepList)
                    {
                        document = "Sheep.txt";
                        WordRepeatCheck(userInput, document, list);
                    }
                }
            }
        }

        /// <summary>
        /// User can decide what document and number of words they would like to see.
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
        /// Calls upon method for printing datastructure.
        /// </summary>
        public void PrintStructure()
        {
            binaryTree.PrintTree();
        }

        /// <summary>
        /// Calls upon seeder forwarding the paths wanted.
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