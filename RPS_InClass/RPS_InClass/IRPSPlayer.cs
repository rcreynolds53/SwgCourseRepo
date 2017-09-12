namespace RPS_InClass
{
    public interface IRPSPlayer
    {
        string PlayerName { get; }
        RPSChoice GetChoice();
    }
}
