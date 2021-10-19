﻿namespace WordSearch.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Checks if input from user is valid
    /// </summary>
    internal class InputHandler
    {
        /// <summary>
        /// Tries to parse the user input to an int, if no valid input is given
        /// the user will be asked to try again
        /// </summary>
        /// <returns>the integer input</returns>
        public int ParseUserInput()
        {
            int userInput;

            while (true)
            {
                try
                {
                    userInput = int.Parse(Console.ReadLine());
                    return userInput;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Not a valid option with following error: {ex.Message}");
                }
            }
        }
    }
}