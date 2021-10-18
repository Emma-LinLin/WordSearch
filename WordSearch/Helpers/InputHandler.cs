namespace WordSearch.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class InputHandler
    {
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