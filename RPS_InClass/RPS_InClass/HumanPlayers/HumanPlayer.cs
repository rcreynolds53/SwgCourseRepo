using System;
namespace RPS_InClass.HumanPlayers
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name) : base(name)
        {
            
        }

        public override RPSChoice GetChoice()
        {
            string input = ConsoleInput.GetHumanChoice().ToUpper();
            switch (input)
            {
                case "R":
                    return RPSChoice.Rock;
                case "P":
                    return RPSChoice.Paper;
                default:
                    return RPSChoice.Scissors;
            }
        }
    }
}
