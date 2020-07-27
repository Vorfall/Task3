using Task3.TypesFigures.PellicleFigures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAMTask3Test.FiguresTest.SkinFiguresTest
{

    [TestClass]
    public class PellicleCircleTest
    {

        [TestMethod]
        public void SkinCircleWhenOldAreaMoreNewAreaCreatePaperCircle()
        {
            var paperRectangle = new RectanglePellicle(new List<double> { 19, 14 });
            var result = new CirclePellicle(4, paperRectangle);
            var actualResult = new CirclePellicle(4);

            Assert.AreEqual(result, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SkinCircleWhenOldAreaLessNewAreaGetArgumentException()
        {
            var paperRectangle = new RectanglePellicle(new List<double> { 6, 8 });
            var result = new CirclePellicle(7, paperRectangle);
        }


        [TestMethod]
        public void TestGetArea()
        {
            var circle = new CirclePellicle(7);
            double result = circle.GetArea();
            double actualResult = 153.93804;
            Assert.AreEqual(result, actualResult, 0.0000001);
        }


        [TestMethod]
        public void TestGetPerimeter()
        {
            var circle = new CirclePellicle(7);
            double result = circle.GetPerimeter();
            double actualResult = 43.98229;
            Assert.AreEqual(result, actualResult, 0.001);
        }
    }
}
