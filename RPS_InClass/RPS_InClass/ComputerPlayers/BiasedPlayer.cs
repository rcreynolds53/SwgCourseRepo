using System;
namespace RPS_InClass.ComputerPlayers
{
    public class BiasedPlayer : Player
    {
        public BiasedPlayer(string name) : base(name)
        {
        }

        public override RPSChoice GetChoice()
        {
            Random rng = new Random();
            rng.Next(1, 101);

            if (rng.Next(1, 101) > 40)
            {
                return RPSChoice.Rock;

            }
            else if (rng.Next(1, 101) > 20)
            {
                return RPSChoice.Paper;
            }
            else
            {
                return RPSChoice.Scissors;
            }
        }
    }
}
