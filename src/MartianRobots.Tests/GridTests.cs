using System;

using MartianRobots.Core.Domain;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MartianRobots.Tests
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void GridCorrectSizeTest()
        {
            var grid = new Grid(1, 2);

            Assert.IsNotNull(grid);
            Assert.AreEqual(1, grid.Width);
            Assert.AreEqual(2, grid.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GridNegativeWidthTest()
        {
            new Grid(-1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GridNegativeHeightTest()
        {
            new Grid(1, -2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GridExceededWidthTest()
        {
            new Grid(51, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GridExceededHeightTest()
        {
            new Grid(1, 51);
        }
    }
}