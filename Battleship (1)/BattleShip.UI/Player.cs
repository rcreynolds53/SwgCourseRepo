using System;
using BattleShip.BLL.GameLogic;
namespace BattleShip.UI
{
    public class Player
    {
		public string Name { get; set; }
		public Board PlayerBoard { get; set; }

		public Player(string name, Board playerboard)
        {
            PlayerBoard = playerboard;
            Name = name;
        }
   
    }
}
