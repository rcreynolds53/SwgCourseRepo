using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    public class GameflowSetup
    {
        public GameState SetupPlayersBoard()
        {
            ConsoleInput.DisplaySplash();
            string p1 = ConsoleInput.GetName(1);
            //string p2 = ConsoleInput.GetName(2);                      
            //skipping over instantiating the board for now 
            Board b1 = BuildBoard(p1);
			string p2 = ConsoleInput.GetName(2);

			Board b2 = BuildBoard(p2);
			Player player1 = new Player(p1,b1);
			Player player2 = new Player(p2,b2);
			bool isPlayer1Turn = DetermineWhoStarts();
            GameState game = new GameState(player1,player2,isPlayer1Turn);
            return game;
            //halt exectution 
            //problem is that you can only return 1 

			//string player1 = ConsoleInput.GetPlayer1Name();
			//string player2 = ConsoleInput.GetPlayer2Name();
			/*
			// for now just have their input be their name, but later one make it so that it must include a string of letters. 
			Console.WriteLine("Welcome to Battleship! Player 1, please start by entering your name.");
            player1 = Console.ReadLine();

            Console.WriteLine($"Welcome to Battleship {player1}, now player 2, please enter your name.");
            player2 = Console.ReadLine();
			Console.WriteLine($"Welcome to Battleship {player2}.");
            */
		}

        private Board BuildBoard(string name)
        {
            Board gameBoard = new Board();
            for (ShipType s = ShipType.Carrier; s >= ShipType.Destroyer; s--)
            {
                PlaceShipRequest shipRequest = new PlaceShipRequest();
				shipRequest.ShipType = s;
				ConsoleInput.ShipToPlace(shipRequest.ShipType);
                shipRequest.Coordinate = ConsoleOutput.GetCoordinate();
                shipRequest.Direction = ConsoleOutput.GetDirection();
                ShipPlacement shipPlaced = gameBoard.PlaceShip(shipRequest);

                switch(shipPlaced)
				{
                    case ShipPlacement.Overlap:
                        ConsoleInput.ShipOverlappedAlert(shipRequest.ShipType);
                        s++;
                        break;
                    case ShipPlacement.NotEnoughSpace:
                        ConsoleInput.ShipNoSpaceAlert(shipRequest.ShipType);
                        s++;
                        break;
                }
            }
            Console.Clear();
            return gameBoard;
            //ConsoleInput.GetCoordinate();


        }
        private bool DetermineWhoStarts()
        {
            return RNG.CoinFlip();
        } 

    }
}
