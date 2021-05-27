using System;

using MartianRobots.Core.Commands;
using MartianRobots.Core.Commands.Handlers;
using MartianRobots.Core.Domain;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MartianRobots.Tests
{
    [TestClass]
    public class MainTests
    {
        [TestMethod]
        public void MainTest()
        {
            var grid = new Grid(5, 3);

            var robot1 = new Robot(grid, new Position(1, 1, Orientation.E));
            var robot2 = new Robot(grid, new Position(3, 2, Orientation.N));
            var robot3 = new Robot(grid, new Position(0, 3, Orientation.W));

            var result1 = robot1.ExecuteCommands("RFRFRFRF");
            var result2 = robot2.ExecuteCommands("FRRFLLFFRRFLL");
            var result3 = robot3.ExecuteCommands("LLFFFLFLFL");

            Assert.AreEqual("11 E", result1);
            Assert.AreEqual("33 N LOST", result2);
            Assert.AreEqual("23 S", result3);
        }

        [TestMethod]
        public void ExtendedCommandsTest()
        {
            var grid = new Grid(5, 3);

            var robot = new Robot(grid, new Position(1, 1, Orientation.E), new TestCommandHandlerFactory());
            var result = robot.ExecuteCommands(Guid.NewGuid().ToString("N"));

            Assert.AreEqual("00 N", result);
        }

        private class TestCommandHandlerFactory : ICommandHandlerFactory
        {
            public ICommandHandler Create(char command)
            {
                return new TestCommandHandler();
            }

            private class TestCommandHandler : ICommandHandler
            {
                public void Process(Position position)
                {
                    position.X = 0;
                    position.Y = 0;
                    position.Orientation = Orientation.N;
                }
            }
        }
    }
}