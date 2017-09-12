using System;
namespace RPS_InClass
{
    public abstract class Player : IRPSPlayer
    {

        public string PlayerName { get; }

        public abstract RPSChoice GetChoice();

        public Player(string name)
        {
            PlayerName = name;
        }

    }
}
