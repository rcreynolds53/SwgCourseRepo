using System;
namespace RPS_InClass
{
    internal static class ConsoleInput
    {
        internal static string GetHumanChoice()
		{
            string input = null;
            while (true)
            {
				Console.WriteLine("Please enter an object to throw:\nR - Rock,\nP - Paper\nS - Scissors");
                 input = Console.ReadLine().ToUpper();

                if(input == "" || input.Length > 1 || !(input == "R" || input == "P" || input == "S"))
                {
					ConsoleOutput.InvalidChoice();
                    continue;
                }
                break;

			}
            return input;
        }

        internal static string GetPlayerName()
        {
Console.WriteLine("Player 1, please enter your name.");
            string userName = Console.ReadLine();
            return userName;
        }
    }
}
