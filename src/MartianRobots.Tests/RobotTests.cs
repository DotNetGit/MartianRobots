using System;

using MartianRobots.Core.Domain;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MartianRobots.Tests
{
    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotNegativeXPositionTest()
        {
            var grid = new Grid(5, 3);
            new Robot(grid, new Position(-1, 1, Orientation.E));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotNegativeYPositionTest()
        {
            var grid = new Grid(5, 3);
            new Robot(grid, new Position(1, -1, Orientation.E));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotExceededXPositionTest()
        {
            var grid = new Grid(5, 3);
            new Robot(grid, new Position(6, 1, Orientation.E));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotExceededYPositionTest()
        {
            var grid = new Grid(5, 3);
            new Robot(grid, new Position(1, 4, Orientation.E));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotWithoutGridTest()
        {
            new Robot(null, new Position(1, 4, Orientation.E));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RobotWithoutCommandHandlerFactoryTest()
        {
            var grid = new Grid(5, 3);
            new Robot(grid, new Position(1, 4, Orientation.E), null);
        }

        [TestMethod]
        public void CommandCorrectLengthTest()
        {
            var grid = new Grid(5, 3);
            var robot = new Robot(grid, new Position(1, 1, Orientation.E));
            var result = robot.ExecuteCommands(new string('L', 100));

            Assert.AreEqual("11 E", result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CommandExceededLengthTest()
        {
            var grid = new Grid(5, 3);
            var robot = new Robot(grid, new Position(1, 1, Orientation.E));

            robot.ExecuteCommands(new string('0', 101));
        }
    }
}