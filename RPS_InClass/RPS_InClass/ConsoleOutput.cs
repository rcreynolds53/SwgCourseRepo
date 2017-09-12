using System;

namespace RPS_InClass
{
    internal class ConsoleOutput
    {
        internal static void InvalidChoice()
        {
            Console.WriteLine("Please enter a valid choice...");
        }

        internal static void TieMessage(IRPSPlayer p1, IRPSPlayer p2)
        {
            Console.WriteLine($"{p1.PlayerName} and {p2.PlayerName} have tied.");
        }

        internal static void P1WinMessage(IRPSPlayer p1)
        {
            Console.WriteLine($"Congrats {p1.PlayerName} you have won!");
        }
		internal static void P2WinMessage(IRPSPlayer p2)
		{
			Console.WriteLine($"Congrats {p2.PlayerName} you have won!");
		}

        internal static void P1NukedMessage(IRPSPlayer p1)
        {
            Console.WriteLine("");
            Console.WriteLine($"{p1.PlayerName}, it looks like you have been nuked.");

        }
    }
}