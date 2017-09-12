using System;
namespace RPS_InClass.ComputerPlayers
{
    public class AlwaysScissors : Player
    {
        public AlwaysScissors(string name) : base(name)
        {
        }

        public override RPSChoice GetChoice()
        {
            return RPSChoice.Scissors;
        }
    }
}
