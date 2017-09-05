using System;
using System.Diagnostics.Contracts;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Gameflow
    {
        // What do I want the gameflow to do?
        // 1) Manages players turns (bool isp1Turn)
        // 2) Alternate FireShot () at enemy board 
        // 3) Shot history and track board 
        // 4) Check Coordinate()
        public void PlayGame(GameState state)
        {
            ShotStatus lastShot = ShotStatus.Invalid;
            /*
            if (!state.IsPlayer1Turn)
            {
                ConsoleInput.WhoseTurn(state.P2);
            }
            else
            {
                ConsoleInput.WhoseTurn(state.P1);
            }
            */
            while (lastShot != ShotStatus.Victory)
            {
                ConsoleOutput.DrawBoard(state);
                // prompt user for coordinate 
                lastShot = FireShot(state);
                if (lastShot == ShotStatus.Duplicate || lastShot == ShotStatus.Invalid)
                    continue;
                //ConsoleOutput.DrawBoard(state);
                state.IsPlayer1Turn = !state.IsPlayer1Turn;
                ConsoleInput.ToNextTurn();
            }

        }


        private ShotStatus FireShot(GameState state)
        {
            // ShipType ship = ShipType.Battleship;
            Board toFire = state.IsPlayer1Turn ? state.P2.PlayerBoard : state.P1.PlayerBoard;
            ShotStatus isVictory = ShotStatus.Miss;
            Coordinate FireAt = ConsoleOutput.GetCoordinate();
            FireShotResponse response = toFire.FireShot(FireAt);

            switch (response.ShotStatus)
            {
                case ShotStatus.Invalid:
                    ConsoleInput.IvalidResponse();
                    isVictory = ShotStatus.Invalid;
                    return isVictory;
                case ShotStatus.Duplicate:
                    ConsoleInput.DuplicateResponse();
                    isVictory = ShotStatus.Duplicate;
                    return isVictory;
                case ShotStatus.Hit:
                    ConsoleInput.HitResponse();
                    isVictory = ShotStatus.Hit;
                    return isVictory;
                case ShotStatus.HitAndSunk:
                    ConsoleInput.HitAndSunkResponse(response.ShipImpacted);
                    isVictory = ShotStatus.HitAndSunk;
                    return isVictory;
                case ShotStatus.Miss:
                    ConsoleInput.MissResponse();
                    isVictory = ShotStatus.Miss;
                    return isVictory;
                case ShotStatus.Victory:
                    ConsoleInput.VictoryResponse();
					isVictory = ShotStatus.Victory;
					return isVictory;
            }
            return isVictory;
        } 
    }
}
            /*
            if (response.ShotStatus == ShotStatus.Invalid)
            {
                ConsoleInput.IvalidResponse();
                isVictory = ShotStatus.Invalid;
                return isVictory;

            }

            if (response.ShotStatus == ShotStatus.Duplicate)
            {
                ConsoleInput.DuplicateResponse();
                isVictory = ShotStatus.Duplicate;
                return isVictory;

            }
            if (response.ShotStatus == ShotStatus.Hit)
            {
                ConsoleInput.HitResponse();
                isVictory = ShotStatus.Hit;
                return isVictory;
            }
            if (response.ShotStatus == ShotStatus.HitAndSunk)
            {
                ConsoleInput.HitAndSunkResponse(response.ShipImpacted);
                isVictory = ShotStatus.HitAndSunk;
                return isVictory;

            }
            if (response.ShotStatus == ShotStatus.Miss)
            {
                ConsoleInput.MissResponse();
                isVictory = ShotStatus.Miss;
                return isVictory;

            }
            else
            {
                if (state.IsPlayer1Turn)
                {
                    ConsoleInput.VictoryResponse(state.P1.Name);
                    isVictory = ShotStatus.Victory;
                    return isVictory;
                }
                else
                {
					ConsoleInput.VictoryResponse(state.P2.Name);
					isVictory = ShotStatus.Victory;
					return isVictory;
                }
            }

        }
    }
}
//draw board and get shots 
*/
