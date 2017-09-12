using System;
using RPS_InClass.ComputerPlayers;
using RPS_InClass.HumanPlayers;

namespace RPS_InClass
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IRPSPlayer p1 = new HumanPlayer(ConsoleInput.GetPlayerName());
            IRPSPlayer p2 = new AlwaysRock("Nuke");
			Arena gameArena = new Arena();

            gameArena.PlayGame(p1, p2);

		}
    }
}
