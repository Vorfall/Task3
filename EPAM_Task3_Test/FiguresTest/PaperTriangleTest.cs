using Task3.Enums;
using Task3.TypesFigures.PaperFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAMTask3Test.FiguresTest.PaperFiguresTest
{

    [TestClass]
    public class PaperTriangleTest
    {
   
        [TestMethod]
        public void PaperTriangleWhenOldAreaMoreNewAreaCreatePaperCircle()
        {
            var paperCircle = new CirclePaper(8, Color.Red);
            var result = new TrianglePaper(new List<double> { 6, 7, 8 }, paperCircle);
            var actualResult = new TrianglePaper(new List<double> { 6, 7, 8 }, Color.Red);

            Assert.AreEqual(result, actualResult);
        }

 
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaperCircleWhenOldAreaLessNewAreaGetArgumentException()
        {
            var paperCircle = new CirclePaper(5, Color.Red);
            var result = new TrianglePaper(new List<double> { 14, 14, 14 }, paperCircle);
        }

        [TestMethod]
        public void TestGetArea()
        {
            var sidesList = new List<double> { 3, 2, 3 };
            var rectangle = new TrianglePaper(sidesList, Color.Red);
            double result = rectangle.GetArea();
            double actualResult = 2.828;
            Assert.AreEqual(result, actualResult, 0.001);
        }


        [TestMethod]
        public void TestGetPerimeter()
        {
            var sidesList = new List<double> { 1, 2, 3 };
            var rectangle = new TrianglePaper(sidesList, Color.Red);
            double result = rectangle.GetPerimeter();
            double actualResult = 6;
            Assert.AreEqual(result, actualResult, 0.000001);
        }


        [TestMethod]
        public void RecolorFigureWhenFigureIsRecolorForFirstTimeNewColor()
        {
            var sidesList = new List<double> { 1, 2, 3 };
            var rectangle = new TrianglePaper(sidesList, Color.Red);
            rectangle.RecolorFigure(Color.Green);
            Color result = rectangle.Color;
            Color actualResult = Color.Green;
            Assert.AreEqual(result, actualResult);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RecolorFigureWhenFigureIsRecolorNotForFirstTimeGetArgumentException()
        {
            var sidesList = new List<double> { 1, 2, 3 };
            var rectangle = new TrianglePaper(sidesList, Color.Red);
            rectangle.RecolorFigure(Color.Green);
            rectangle.RecolorFigure(Color.Black);
        }
    }
}
