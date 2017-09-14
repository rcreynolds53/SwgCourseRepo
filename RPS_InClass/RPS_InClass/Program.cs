using System;
using Ninject;
using RPS_InClass.ComputerPlayers;
using RPS_InClass.HumanPlayers;

namespace RPS_InClass
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //IRPSPlayer p1 = new HumanPlayer(ConsoleInput.GetPlayerName());
            //IRPSPlayer p2 = new BiasedPlayer("Nuke");
            Arena gameArena = DIContainer.Kernel.Get<Arena>();

            gameArena.PlayAgainstComputer();

		}
    }
}
