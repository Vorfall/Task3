using Task3.Enums;
using Task3.TypesFigures.PaperFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAMTask3Test.FiguresTest.PaperFiguresTest
{
   
    [TestClass]
    public class PaperCircleTest
    {
     
        [TestMethod]
        public void CirclePaperOldAreaMoreNewAreaCreatePaperCircle()
        {
            var paperRectangle = new RectanglePaper(new List<double> { 19, 14 }, Color.Pink);
            var result = new CirclePaper(4, paperRectangle);
            var actualResult = new CirclePaper(4, Color.Pink);

            Assert.AreEqual(result, actualResult);
        }

       
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CirclePaperOldAreaLessNewAreaGetArgumentException()
        {
            var paperRectangle = new RectanglePaper(new List<double> { 4, 6 }, Color.Black);
            var result = new CirclePaper(5, paperRectangle);
        }

        [TestMethod]
        public void TestGetArea()
        {
            var circle = new CirclePaper(7, Color.Blue);
            double result = circle.GetArea();
            double actualResult = 153.938040;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }

        [TestMethod]
        public void TestGetPerimeter()
        {
            var circle = new CirclePaper(7, Color.Blue);
            double result = circle.GetPerimeter();
            double actualResult = 43.98229;
            Assert.AreEqual(result, actualResult, 0.00001);
        }

       
        [TestMethod]
        public void RecolorFigureFigureIsRecolorForFirstTimeNewColor()
        {
            var circle = new CirclePaper(7, Color.Blue);
            circle.RecolorFigure(Color.Green);
            Color result = circle.Color;
            Color actualResult = Color.Green;
            Assert.AreEqual(result, actualResult);
        }

     
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RecolorFigureFigureIsRecolorNotForFirstTimeGetArgumentException()
        {
            var circle = new CirclePaper(7, Color.Blue);
            circle.RecolorFigure(Color.Green);
            circle.RecolorFigure(Color.Red);
        }
    }
}
