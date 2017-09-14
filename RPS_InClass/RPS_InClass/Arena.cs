using System;
using Ninject;
using RPS_InClass.HumanPlayers;

namespace RPS_InClass
{
    public class Arena
    {
        private IRPSPlayer _player;
        public Arena(IRPSPlayer player)
        {
            _player = player;      
        }

        public void PlayAgainstComputer()
        {
            HumanPlayer human = new HumanPlayer(ConsoleInput.GetPlayerName());
            PlayGame(human, _player);
        }
        public void PlayGame(IRPSPlayer p1, IRPSPlayer p2)
        {
            RPSChoice p1Choice = p1.GetChoice();
            RPSChoice p2Choice = p2.GetChoice();

            if(p1Choice == p2Choice)
            {
                ConsoleOutput.TieMessage(p1, p2);
            }
            else if(p1Choice == RPSChoice.Rock && p2Choice == RPSChoice.Scissors
                    || p1Choice == RPSChoice.Paper && p2Choice == RPSChoice.Rock
                    || p1Choice == RPSChoice.Scissors && p2Choice == RPSChoice.Paper)
            {
                ConsoleOutput.P1WinMessage(p1);
			}
            //else if(p2Choice == RPSChoice.Nuke)
            //{
            //    ConsoleOutput.P1NukedMessage(p1);
            //}
            else
            {
				ConsoleOutput.P2WinMessage(p2);
			}
		}
    }
}
