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
        /*
		[Test]
		public void InputToCoordinate(string input)
		{
			Coordinate actual = null;
			string userCoordinate = "a10";
            var coordinate = new Coordinate(1, 10);

			int CordX = 0;
			char yPart = userCoordinate[0];
			int y = (yPart - 'a' + 1);
			string x = userCoordinate.Substring(1);
			var canParse = int.TryParse(x, out CordX);
            if (canParse && (CordX > 0 && CordX < 11) && (y > 0 && y < 11))
            {
                actual = new Coordinate(y, CordX);
            }

            Assert.AreEqual(coordinate, actual);
		}
		*/
	}
}
