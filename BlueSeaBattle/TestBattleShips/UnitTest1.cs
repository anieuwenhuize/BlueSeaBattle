using System;
using BlueSeaBattle;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBattleShips
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBattleshipCanAcceptMissile()
        {
            // Arrange
            var c1 = new Coordinate(0, 1);
            var c2 = new Coordinate(1, 1);
            var c3 = new Coordinate(2, 1);
            var c4 = new Coordinate(3, 1);
            var c5 = new Coordinate(4, 1);

            var location = new Location(c1, c2, c3, c4, c5);
            BattleShip ship = new TestShip("", location);

            // Act
            var missile1 = new Missile(c1, ship);
            ship.AcceptMissile(missile1);

            // Assert
            Assert.IsFalse(ship.IsSunk());
        }

        [TestMethod]
        public void TestBattleshipCanNearlySurvive()
        {
            // Arrange
            var c1 = new Coordinate(0, 1);
            var c2 = new Coordinate(1, 1);
            var c3 = new Coordinate(2, 1);
            var c4 = new Coordinate(3, 1);
            var c5 = new Coordinate(4, 1);

            var location = new Location(c1, c2, c3, c4, c5);
            BattleShip ship = new TestShip("", location);

            // Act
            var missile1 = new Missile(c1, ship);
            ship.AcceptMissile(missile1);

            var missile2 = new Missile(c2, ship);
            ship.AcceptMissile(missile2);

            var missile3 = new Missile(c3, ship);
            ship.AcceptMissile(missile3);

            var missile4 = new Missile(c4, ship);
            ship.AcceptMissile(missile4);

            // Assert
            Assert.IsFalse(ship.IsSunk());
        }

        [TestMethod]
        public void TestBattleshipCanSink()
        {
            // Arrange
            var c1 = new Coordinate(0, 1);
            var c2 = new Coordinate(1, 1);
            var c3 = new Coordinate(2, 1);
            var c4 = new Coordinate(3, 1);
            var c5 = new Coordinate(4, 1);

            var location = new Location(c1, c2, c3, c4, c5);
            BattleShip ship = new TestShip("", location);

            // Act
            var missile1 = new Missile(c1, ship);
            ship.AcceptMissile(missile1);

            var missile2 = new Missile(c2, ship);
            ship.AcceptMissile(missile2);

            var missile3 = new Missile(c3, ship);
            ship.AcceptMissile(missile3);

            var missile4 = new Missile(c4, ship);
            ship.AcceptMissile(missile4);

            var missile5 = new Missile(c5, ship);
            ship.AcceptMissile(missile5);

            // Assert
            Assert.IsTrue(ship.IsSunk());
        }
    }
}
