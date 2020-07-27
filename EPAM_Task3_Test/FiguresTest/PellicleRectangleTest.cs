using Task3.TypesFigures.PellicleFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAMTask3Test.FiguresTest.SkinFiguresTest
{

    [TestClass]
    public class PellicleRectangleTest
    { 
        [TestMethod]
        public void SkinRectangleWhenOldAreaMoreNewAreaCreatePaperCircle()
        {
            var skinCircle = new CirclePellicle(6);
            var result = new RectanglePellicle(new List<double> { 3, 5 }, skinCircle);
            var actualResult = new RectanglePellicle(new List<double> { 3, 5 });

            Assert.AreEqual(result, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SkinRectangleWhenOldAreaLessNewAreaGetArgumentException()
        {
            var skinCircle = new CirclePellicle(7);
            var result = new RectanglePellicle(new List<double> { 14, 17 }, skinCircle);
        }


        [TestMethod]
        public void TestGetArea()
        {
            var sidesList = new List<double> { 1, 1, 1, 1 };
            var rectangle = new RectanglePellicle(sidesList);
            double result = rectangle.GetArea();
            double actualResult = 1;
            Assert.AreEqual(result, actualResult, 0.0001);
        }

        [TestMethod]
        public void TestGetPerimeter()
        {
            var sidesList = new List<double> { 1, 2 };
            var rectangle = new RectanglePellicle(sidesList);
            double result = rectangle.GetPerimeter();
            double actualResult = 3;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }
    }
}
