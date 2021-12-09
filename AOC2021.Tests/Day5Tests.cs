using AOC2021.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace AOC2021.Tests
{
    [TestClass]
    public class Day5Tests
    {
        [TestMethod]
        public void HydrothermalMapTest1()
        {
            var map = new HydrothermalMap();

            map.AddPoint(new Point(1, 2));
            map.AddPoint(new Point(1, 2));

            int numOfOverlaps = map.GetNumOfTwoOrMoreOverlap();

            Assert.AreEqual(numOfOverlaps, 1);
        }
    }
}
