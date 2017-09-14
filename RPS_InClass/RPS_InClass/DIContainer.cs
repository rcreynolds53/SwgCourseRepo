using System;
using Ninject;
using System.Configuration;
using RPS_InClass.ComputerPlayers;

namespace RPS_InClass
{
    public static class DIContainer
    {
        public static IKernel Kernel = new StandardKernel();
        static DIContainer()
        {
            string computerType = ConfigurationManager.AppSettings["Player"].ToString();

            switch (computerType)
            {
                case "RandomPlayer":
                    Kernel.Bind<IRPSPlayer>().To<RandomPlayer>().WithConstructorArgument("name", "Random Player");
                    break;
                case "AlwaysPaper":
                    Kernel.Bind<IRPSPlayer>().To<AlwaysPaper>().WithConstructorArgument("name", "Always Paper");
                    break;
                case "AlwaysRock":
                    Kernel.Bind<IRPSPlayer>().To<AlwaysRock>().WithConstructorArgument("name", "Always Rock");
                    break;
                case "AlwaysScissors":
                    Kernel.Bind<IRPSPlayer>().To<AlwaysScissors>().WithConstructorArgument("name", "Always Scissors");
                    break;
                default:
                    Kernel.Bind<IRPSPlayer>().To<BiasedPlayer>().WithConstructorArgument("name", "Baised Player");
                    break;
            }
        }
    }
}
