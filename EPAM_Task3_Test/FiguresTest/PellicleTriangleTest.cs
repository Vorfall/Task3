using Task3.TypesFigures.PellicleFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAMTask3Test.FiguresTest.SkinFiguresTest
{

    [TestClass]
    public class PellicleTriangleTest
    {

        [TestMethod]
        public void SkinTriangleWhenOldAreaMoreNewAreaCreatePaperCircle()
        {
            var skinCircle = new CirclePellicle(5);
            var result = new TrianglePellicle(new List<double> { 3, 4, 5 }, skinCircle);
            var actualResult = new TrianglePellicle(new List<double> { 3, 4, 5 });

            Assert.AreEqual(result, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaperCircleWhenOldAreaLessNewAreaGetArgumentException()
        {
            var paperCircle = new CirclePellicle(5);
            var result = new TrianglePellicle(new List<double> { 13, 14, 15 }, paperCircle);
        }


        [TestMethod]
        public void TestGetArea()
        {
            var sidesList = new List<double> { 3, 2, 3 };
            var rectangle = new TrianglePellicle(sidesList);
            double result = rectangle.GetArea();
            double actualResult = 2.828;
            Assert.AreEqual(result, actualResult, 0.001);
        }

 
        [TestMethod]
        public void TestGetPerimeter()
        {
            var sidesList = new List<double> { 2, 3, 3 };
            var rectangle = new TrianglePellicle(sidesList);
            double result = rectangle.GetPerimeter();
            double actualResult = 8;
            Assert.AreEqual(result, actualResult, 0.000001);
        }
    }
}
