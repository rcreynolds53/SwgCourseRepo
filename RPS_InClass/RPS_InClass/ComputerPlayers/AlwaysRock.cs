using System;
namespace RPS_InClass.ComputerPlayers
{
    public class AlwaysRock : Player
    {
        public AlwaysRock(string name) : base(name)
        {
            
        }

        public override RPSChoice GetChoice()
        {
            return RPSChoice.Rock;
        }
    }
}
