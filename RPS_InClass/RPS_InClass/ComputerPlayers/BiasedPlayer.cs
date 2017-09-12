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
            return RPSChoice.Nuke;
        }
    }
}
