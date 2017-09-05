using System;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Requests;
using System.Diagnostics.Contracts;

namespace BattleShip.UI
{
    internal class ConsoleOutput
    {
        public static Board DrawBoard(GameState state)
        {
            //Coordinate coordToCheck = new Coordinate();
            Board toDraw = state.IsPlayer1Turn ? state.P2.PlayerBoard : state.P1.PlayerBoard;
			if (!state.IsPlayer1Turn)
			{
				ConsoleInput.WhoseTurn(state.P2);
			}
			else
			{
				ConsoleInput.WhoseTurn(state.P1);
			}
            for (int y = 1; y < 11; y++)
            {
				for (int x = 1; x < 11; x++)
                {
                    ShotHistory currentHistory = toDraw.CheckCoordinate(new Coordinate(y, x));
					switch (currentHistory)
                    {
                        case ShotHistory.Unknown:
                            Console.Write(" ");
							break;
                        case ShotHistory.Hit:
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write("H");
							Console.ResetColor();
							break;
                        case ShotHistory.Miss:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
							Console.Write("M");
							Console.ResetColor();
							break;
                    }
					Console.Write(" | ");

				}
				Console.WriteLine();
				Console.WriteLine("---------------------------------------");
			}
            return toDraw;
		}

        internal static bool PlayAgain()
        {
            string wantToPlay = "";
            bool gameOVer = false;
            while (!gameOVer)
            {
				ConsoleInput.PlayAgainPrompt();
                wantToPlay = Console.ReadLine();

                if (wantToPlay == "")
                    continue;
                else if (wantToPlay == "Y" || wantToPlay == "y")
                {
                    gameOVer = false;
                    return gameOVer;
                }
                else 
                {
                    gameOVer = true;
                    return gameOVer;
                }
            }
            return gameOVer;
        }

        internal static ShipDirection GetDirection()
		{
			ShipDirection toReturn = ShipDirection.Up;
			bool isValidDirection = false;
			while (!isValidDirection)
			{
				Console.ForegroundColor = ConsoleColor.White;
				ConsoleInput.PromptForDirection();
                string userDirection = Console.ReadLine().ToUpper();
                if (userDirection == "")
                    continue;

				switch (userDirection)
				{
					case "U":
						toReturn = ShipDirection.Up;
						isValidDirection = true;
						break;
					case "D":
						toReturn = ShipDirection.Down;
						isValidDirection = true;
						break;
					case "L":
						toReturn = ShipDirection.Left;
						isValidDirection = true;
						break;
					case "R":
						toReturn = ShipDirection.Right;
						isValidDirection = true;
						break;
				}
			}

			return toReturn;
		}

		public static Coordinate GetCoordinate()
		{
            Coordinate toReturn = null;

			bool isValidInput = false;
            //ConsoleInput.PromptPlayerForCoordinate();

            while (!isValidInput)
			{
				ConsoleInput.PromptPlayerForCoordinate();

                string userCoordinate = Console.ReadLine();

				int CordX = 0;
                if (userCoordinate == "" || userCoordinate.Length < 2)
                    continue;
                char yPart = userCoordinate[0];
				int y = (yPart - 'a' + 1);
				string x = userCoordinate.Substring(1);
				bool canParse = int.TryParse(x, out CordX);
                if (canParse && (CordX > 0 && CordX < 11) && (y > 0 && y < 11))
				{
                    toReturn = new Coordinate(y, CordX);
					isValidInput = true;
				}
                //Console.ForegroundColor = ConsoleColor.Red;
			}
			return toReturn;
		}
        public static Coordinate GetCoordinate(string userCoordinate)
        {
            Coordinate toReturn = null;

            bool isValidInput = false;
            //ConsoleInput.PromptPlayerForCoordinate();
            while (!isValidInput)
            {
                if (userCoordinate == "" || userCoordinate.Length < 2)
                    break;
                int CordX = 0;
                char yPart = userCoordinate[0];
                int y = (yPart - 'a' + 1);
                string x = userCoordinate.Substring(1);
                bool canParse = int.TryParse(x, out CordX);
                if (canParse && (CordX > 0 && CordX < 11) && (y > 0 && y < 11))
                {
                    toReturn = new Coordinate(y, CordX);
                    isValidInput = true;
                }
            }
            //Console.ForegroundColor = ConsoleColor.Red;
            return toReturn;
        }
		internal static bool IsDirectionValid(string userDirection)
		{
			bool isValidDirection = false;
			while (!isValidDirection)
			{
				if (userDirection == "")
					break;

                switch (userDirection.ToUpper())
				{
					case "U":
						isValidDirection = true;
						break;
					case "D":
						isValidDirection = true;
						break;
					case "L":
						isValidDirection = true;
						break;
					case "R":
						isValidDirection = true;
						break;
				}
                return isValidDirection;
			}

            return isValidDirection;
		}
        internal static ShipDirection GetDirection(string userDirection)
		{
			ShipDirection toReturn = ShipDirection.Up;
			bool isValidDirection = false;
			while (!isValidDirection)
			{
				if (userDirection == "")
					break;

				switch (userDirection.ToUpper())
				{
					case "U":
						toReturn = ShipDirection.Up;
						isValidDirection = true;
						break;
					case "D":
						toReturn = ShipDirection.Down;
						isValidDirection = true;
						break;
					case "L":
						toReturn = ShipDirection.Left;
						isValidDirection = true;
						break;
					case "R":
						toReturn = ShipDirection.Right;
						isValidDirection = true;
						break;
				}
			}

            return toReturn;
		}
    }
}