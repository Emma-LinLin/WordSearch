using System;
using System.Collections.Generic;
using WordSearch.Seeder;

namespace WordSearch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MenuHandler MenuPointer = new MenuHandler();
            MenuPointer.Menu();
        }
    }
}