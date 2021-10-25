namespace WordSearch
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Threading;
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
        private string _cowPath = @"\Cow.txt";
        private string _chickenPath = @"\Chicken.txt";
        private string _sheepPath = @"\Sheep.txt";
        private InputHandler helperPointer = new InputHandler();
        private SearchHandler searchPointer = new SearchHandler();
        private ResultController resultContPointer = new ResultController();

        /// <summary>
        /// Main menu presented to user when program is started
        /// </summary>
        public void Menu()
        {
            Seed();
            Console.WriteLine("Welcome to WordSearch, the word search engine!\n");

            while (true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Search word");
                Console.WriteLine("2. Order document and search for x number of words");
                Console.WriteLine("3. Print datastructure");
                Console.WriteLine("4. Exit\n");
                Console.Write("> ");
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
            Console.Clear();
            Console.WriteLine("What word would you like to search for?\n");
            Console.Write("> ");
            string userInput = Console.ReadLine();
            if (userInput != string.Empty)
            {
                var response = ListCheck(userInput);

                if (response)
                {
                    var listsWithWord = resultContPointer.GetList();

                    foreach (var list in listsWithWord)
                    {
                        Console.WriteLine($"\nWe found {list.Repeats} matches in {list.FileName}\n");
                    }
                    Console.WriteLine("Would you like to save the output to the datastructure?\n");
                    Console.WriteLine("[Y] for yes, [N] for no\n");
                    Console.Write("> ");
                    var userChoice = Console.ReadLine().ToLower();
                    Console.WriteLine(" ");
                    if (userChoice == "y")
                    {
                        foreach (var list in listsWithWord)
                        {
                            binaryTree.Insert(list.Repeats, list.SearchWord, list.FileName);
                        }
                        resultContPointer.ClearList();
                        Console.WriteLine("The output was saved");
                    }
                }
            }
            Thread.Sleep(650);
            Console.Clear();
        }

        /// <summary>
        /// Check how many times the word searched for occures inside document.
        /// Time complexity O(1) + O(n + 2) + O(1) + O(1)= O(n + 5)
        /// Asymptotisk analys = O(n)
        /// </summary>
        /// <param name="userInput">User input</param>
        /// <param name="document">Name of file</param>
        /// <param name="wordList">Document list containing words from read file.</param>
        public int WordRepeatCheck(string userInput, string document, List<string> wordList)
        {
            int counter = default;

            foreach (var item in wordList)
            {
                if (item == userInput)
                {
                    counter++;
                }
            }
            resultContPointer.AddItemToList(document, userInput, counter);
            return counter;
        }

        /// <summary>
        /// Check if word exists in one or more of the text files.
        /// Time Complexity O(1) + O(1) + O(N^2 + 7) + O(1) + O(3) + O(1) = O(N^2 + 14)
        /// Asymptotisk analys = O(N^2)
        /// </summary>
        /// <param name="userInput">User input</param>
        public bool ListCheck(string userInput)
        {
            int counter = default;

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
                        document = "Cow.txt";
                        counter += WordRepeatCheck(userInput, document, list);
                    }
                    if (list == chickenList)
                    {
                        document = "Chicken.txt";
                        counter += WordRepeatCheck(userInput, document, list);
                    }
                    if (list == sheepList)
                    {
                        document = "Sheep.txt";
                        counter += WordRepeatCheck(userInput, document, list);
                    }
                }
            }

            if (counter == 0)
            {
                Console.WriteLine($"No match found for \"{userInput}\" inside the files\n");
                return false;
            }
            return true;
        }

        /// <summary>
        /// User can decide what document and number of words they would like to see.
        /// </summary>
        private void ListChoice()
        {
            List<string> sortedList = new List<string>();
            Console.WriteLine("What document would you like to search?");
            Console.WriteLine("1. cow.txt\n2. Chicken.txt\n3. Sheep.txt ");
            Console.Write("> ");
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