using System;
namespace BattleShip.BLL.GameLogic
{
    public class RNG
    {
        static Random _rng = new Random();
        public static bool CoinFlip()
        {
            return _rng.NextDouble() < 0.5;
        }
    }
}
