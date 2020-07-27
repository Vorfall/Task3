using Task3.Enums;
using Task3.TypesFigures.PaperFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAMTask3Test.FiguresTest.PaperFiguresTest
{

    [TestClass]
    public class PaperRectangleTest
    {

        [TestMethod]
        public void PaperRectangleWhenOldAreaMoreNewAreaCreatePaperCircle()
        {
            var paperCircle = new CirclePaper(6, Color.Red);
            var result = new RectanglePaper(new List<double> { 3, 5 }, paperCircle);
            var actualResult = new RectanglePaper(new List<double> { 3, 5 }, Color.Red);

            Assert.AreEqual(result, actualResult);
        }

 
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PaperCircleWhenOldAreaLessNewAreaGetArgumentException()
        {
            var paperCircle = new CirclePaper(7, Color.Red);
            var result = new RectanglePaper(new List<double> { 14, 17 }, paperCircle);
        }

 
        [TestMethod]
        public void TestGetArea()
        {
            var sidesList = new List<double> { 6, 8, 6, 8 };
            var rectangle = new RectanglePaper(sidesList, Color.Red);
            double result = rectangle.GetArea();
            double actualResult = 48;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

    
        [TestMethod]
        public void TestGetPerimeter()
        {
            var sidesList = new List<double> { 7, 14 };
            var rectangle = new RectanglePaper(sidesList, Color.Red);
            double result = rectangle.GetPerimeter();
            double actualResult = 21;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }


        [TestMethod]
        public void RecolorFigureWhenFigureIsRecolorForFirstTimeNewColor()
        {
            var sidesList = new List<double> { 7, 9 };
            var rectangle = new RectanglePaper(sidesList, Color.Red);
            rectangle.RecolorFigure(Color.Green);
            Color result = rectangle.Color;
            Color actualResult = Color.Green;
            Assert.AreEqual(result, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RecolorFigureWhenFigureIsRecolorNotForFirstTimeGetArgumentException()
        {
            var sidesList = new List<double> { 7, 17 };
            var rectangle = new RectanglePaper(sidesList, Color.Red);
            rectangle.RecolorFigure(Color.Green);
            rectangle.RecolorFigure(Color.Black);
        }
    }
}
