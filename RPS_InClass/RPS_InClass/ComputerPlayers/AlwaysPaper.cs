using System;
namespace RPS_InClass.ComputerPlayers
{
    public class AlwaysPaper : Player
    {
        public AlwaysPaper(string name) : base(name)
        {
        }

        public override RPSChoice GetChoice()
        {
            return RPSChoice.Paper;
        }
    }
}
