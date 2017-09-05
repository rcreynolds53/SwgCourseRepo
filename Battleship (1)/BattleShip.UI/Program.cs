using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isGameOver = false;
			while (!isGameOver)
            {
                GameflowSetup infoAndBoardSetup = new GameflowSetup();
                Gameflow game = new Gameflow();
                GameState state = infoAndBoardSetup.SetupPlayersBoard();
                game.PlayGame(state);
                isGameOver = ConsoleInput.PlayAgain();
            }

        }
    }
}
