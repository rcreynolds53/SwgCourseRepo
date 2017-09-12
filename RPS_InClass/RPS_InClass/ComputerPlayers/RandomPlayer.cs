using System;
namespace RPS_InClass.ComputerPlayers
{
    public class RandomPlayer : Player
    {
        public RandomPlayer(string name) : base(name)
        {
            
        }

        public override RPSChoice GetChoice()
        {
            Random rng = new Random();
            switch(rng.Next(1, 4))
            {
                case 1:
                    return RPSChoice.Rock;
                   // break; if you are return some 
                case 2:
                    return RPSChoice.Paper;
                    //break;
                default:
                    return RPSChoice.Scissors;
                    //break;
            }
        }
    }
}
