using System;
using NUnit.Framework;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;
namespace BattleShip.UI
{
    [TestFixture]
    public class UiTests
    {

        [Test]
        public void InputToCoordinate()
        {
            string userCoordinate = "a10";
            Coordinate actual = ConsoleInput.GetCoordinate(userCoordinate);
            Coordinate coordinate = new Coordinate(1, 10);


            Assert.AreEqual(coordinate, actual);
        }
        [Test]
        public void IsCoordinateValid()
        {
            string userCoordinate = "";
            Coordinate actual = ConsoleInput.GetCoordinate(userCoordinate);
            Coordinate coordinate = null;
            Assert.AreEqual(coordinate, actual);

        }
        [Test]
        public void ValidateDirection()
        {
            string userDirection = "e";
            bool actual = ConsoleInput.IsDirectionValid(userDirection);
            bool isValid = false;

            Assert.AreEqual(isValid, actual);
        }
        [Test]
        public void InvalidDirection()
        {
            string userDirection = "d";
            ShipDirection actual = ConsoleInput.GetDirection(userDirection);
            ShipDirection direction = ShipDirection.Down;

            Assert.AreEqual(direction, actual);

        }
    }
}