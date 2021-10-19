using System;
using System.Collections.Generic;
using WordSearch.Seeder;

namespace WordSearch
{
    internal class Program
    {
        /// <summary>
        /// Entry point for program
        /// </summary>
        private static void Main()
        {
            MenuHandler MenuPointer = new MenuHandler();
            MenuPointer.Menu();
        }
    }
}