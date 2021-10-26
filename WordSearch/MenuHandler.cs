namespace WordSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        // Global variables containing lists and paths.
        /// </summary>
        private BinaryTree binaryTree = new BinaryTree();

        private InputHandler helperPointer = new InputHandler();
        private DocumentSearchHandler searchPointer = new DocumentSearchHandler();
        private ListSeeder seederPointer = new ListSeeder();
        private SearchResultController resultContPointer = new SearchResultController();

        /// <summary>
        /// Main menu presented to user when program is started.
        /// </summary>
        public void Menu()
        {
            seederPointer.Seed();
            Console.WriteLine("Welcome to WordSearch, the word search engine!\n");
            while (true)
            {
                Console.WriteLine(@"What would you like to do?
1. Search word
2. Order document and search for x number of words
3. Print datastructure
4. Exit");
                Console.Write("\n> ");
                int userInput = helperPointer.ParseUserInput();
                switch (userInput)
                {
                    case 1:
                        SearchWord();
                        break;

                    case 2:
                        DocumentSearch();
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
                    var listsOfResults = resultContPointer.GetList();

                    SaveToDataStructure(listsOfResults);
                }
            }
            Thread.Sleep(650);
            Console.Clear();
        }

        /// <summary>
        /// Allows the user to save searched word to data structure.
        /// </summary>
        /// <param name="listsOfResults">List of search results</param>
        private void SaveToDataStructure(List<SearchResult> listsOfResults)
        {
            foreach (var list in listsOfResults)
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
                foreach (var list in listsOfResults)
                {
                    binaryTree.Insert(list.Repeats, list.SearchWord, list.FileName);
                }
                Console.WriteLine("The output was saved");
            }
            resultContPointer.ClearList();
        }

        /// <summary>
        /// Check how many times the word searched for occures inside document.
        /// Time complexity: O(1) + O(n + 2) + (O(1)) + O(1) = O(n + 4) + (O(1))
        /// Asymptotic analysis: O(n)
        /// </summary>
        /// <param name="userInput">User input</param>
        /// <param name="document">Name of file</param>
        /// <param name="wordList">Document list containing words from read file.</param>
        public int WordCount(string userInput, string document, List<string> wordList)
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
        /// Time Complexity : O(1) + O(1) + O(n + 2 + (O())) O(N + 7)
        /// With .contain-method included: (O(N^2 + 7))
        /// Asymptotic analysis: O(N^2)
        /// </summary>
        /// <param name="userInput">User input</param>
        public bool ListCheck(string userInput)
        {
            bool success = false;

            var listOfDocuments = new List<List<string>>() { seederPointer.cowList, seederPointer.chickenList, seederPointer.sheepList };

            foreach (var list in listOfDocuments)
            {
                if (list.Contains(userInput))
                {
                    success = DoesWordExist(userInput, list);
                }
            }
            if (!success)
            {
                Console.WriteLine($"No match found for \"{userInput}\" inside the files\n");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks for how many times specific word occures in list from file.
        /// </summary>
        /// <param name="userInput">User input</param>
        /// <param name="list"></param>
        /// <returns>Counter</returns>
        private bool DoesWordExist(string userInput, List<string> list)
        {
            int counter = default;
            string document = default;
            if (list == seederPointer.cowList)
            {
                document = "Cow.txt";
                counter += WordCount(userInput, document, list);
            }
            if (list == seederPointer.chickenList)
            {
                document = "Chicken.txt";
                counter += WordCount(userInput, document, list);
            }
            if (list == seederPointer.sheepList)
            {
                document = "Sheep.txt";
                counter += WordCount(userInput, document, list);
            }
            if (counter != 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// User can decide what document and number of words they would like to see.
        /// </summary>
        private void DocumentSearch()
        {
            List<string> sortedList = new List<string>();
            Console.WriteLine("What document would you like to search?");
            Console.WriteLine("1. Cow.txt\n2. Chicken.txt\n3. Sheep.txt ");
            Console.Write("> ");
            int userInput = helperPointer.ParseUserInput();

            switch (userInput)
            {
                case 1:
                    sortedList = searchPointer.SortList(seederPointer.cowList);
                    break;

                case 2:
                    sortedList = searchPointer.SortList(seederPointer.chickenList);
                    break;

                case 3:
                    sortedList = searchPointer.SortList(seederPointer.sheepList);
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
    }
}