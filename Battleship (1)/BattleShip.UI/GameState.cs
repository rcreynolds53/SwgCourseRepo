using System;
namespace BattleShip.UI
{
    public class GameState // we make a Gamestate calss so that we can return the output for
    //this  to the Gameflow class easier, and because only one piece of data 
    //can be returned in method.
    {
        public Player P1 { get; }
       public Player P2 { get; }
        public bool IsPlayer1Turn { get; set; }
        public GameState(Player p1, Player p2, bool isp1Turn)
        {
            P1 = p1;
            P2 = p2;
            IsPlayer1Turn = isp1Turn;
        }
        // put these as props!
        //goal of the set up workflow is to return a completed game state object 
        // we want to return this data to our Gameflow 
    }
}

//player 1 property 