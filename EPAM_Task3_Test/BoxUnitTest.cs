using Task3;
using Task3.Enums;
using Task3.TypesFigures.PaperFigures;
using Task3.TypesFigures.PellicleFigures;
using Task3.Base.BaseFigures;
using Task3.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace EPAMTask3Test
{

    [TestClass]
    public class BoxUnitTest
    {

        [TestMethod]
        public void AddFigureWhenFigureIsInBoxAddNewFigure()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 5 }, Color.Blue)
            };

            var box = new Box(figures);
            var figure = new CirclePellicle(7);

            box.AddFigure(figure);

            IFigure[] result = box.Figures;
            var actualResult = new IFigure[20];

            for (var i = 0; i < actualResult.Length; i++)
            {
                if (i == figures.Count)
                {
                    actualResult[i] = figure;
                    break;
                }

                actualResult[i] = figures[i];
            }

            CollectionAssert.AreEqual(result, actualResult);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddFigureWhenFigureIsNotInBoxGetArgumentException()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);
            var figure = new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue);

            box.AddFigure(figure);
        }

        [TestMethod]
        public void ShowFigureWhenIndexIsNotOutsideArrayGetFigure()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);

            IFigure result = box.ShowFigure(1);
            var actualResult = new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue);

            Assert.AreEqual(result, actualResult);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShowFigureWhenIndexIsOutsideArrayGetArgumentOutOfRangeException()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);

            box.ShowFigure(21);
        }


        [TestMethod]
        public void GetFigureWhenIndexIsNotOutsideArrayGetFigureAndDeleteThisFigure()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);
            box.GetFigure(0);

            int result = box.GetCountFigures();
            int actualResult = 1;

            Assert.AreEqual(result, actualResult);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void GetFigureWhenIndexIsOutsideArrayGetArgumentOutOfRangeException()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue),
            };

            var box = new Box(figures);

            box.GetFigure(21);
        }

        [TestMethod]
        public void SetFigureWhenIndexIsNotOutsideArrayChangeChosenFigure()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);
            var figure = new CirclePellicle(7);
            box.SetFigure(0, figure);

            IFigure result = box.ShowFigure(0);
            var actualResult = new CirclePellicle(7);

            Assert.AreEqual(result, actualResult);
        }


        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void SetFigureWhenIndexIsOutsideArrayGetArgumentOutOfRangeException()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue),
            };

            var box = new Box(figures);
            var figure = new CirclePellicle(7);
            box.SetFigure(-10, figure);
        }


        [TestMethod]
        public void SearchFigureWhenFigureIsInBoxGetFigure()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);
            var figure = new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue);

            IFigure result = box.SearchFigure(figure);
            var actualResult = new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue);

            Assert.AreEqual(result, actualResult);
        }

        [TestMethod]
        public void SearchFigureWhenFigureIsNotInBoxGetNull()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);
            var figure = new CirclePellicle(7);

            IFigure result = box.SearchFigure(figure);
            IFigure actualResult = null;

            Assert.AreEqual(result, actualResult);
        }


        [TestMethod]
        public void TestGetCountFigures()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);

            int result = box.GetCountFigures();
            int actualResult = 2;

            Assert.AreEqual(result, actualResult);
        }

        [TestMethod]
        public void TestGetTotalPerimeter()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue)
            };

            var box = new Box(figures);

            double result = box.GetTotalPerimeter();
            double actualResult = 19;

            Assert.AreEqual(result, actualResult);
        }

   
        [TestMethod]
        public void TestGetTotalArea()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 5 }, Color.Blue)
            };

            var box = new Box(figures);

            double result = box.GetTotalArea();
            double actualResult = 11.799671;

            Assert.AreEqual(result, actualResult, 0.0000001);
        }


        [TestMethod]
        public void TestGetCircles()
        {
            var figures = new IFigure[]
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue),
                new CirclePaper(4, Color.Red),
                new CirclePellicle(3),
                new RectanglePellicle(new List<double> { 3, 6 })
            };

            var box = new Box(figures);

            var result = box.GetCircles();
            var actualResult = new List<Circle>()
            {
                new CirclePaper(4, Color.Red),
                new CirclePellicle(3)
            };

            CollectionAssert.AreEqual(result, actualResult);
        }

        [TestMethod]
        public void TestGetSkinFigures()
        {
            var figures = new IFigure[]
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 7 }, Color.Blue),
                new CirclePaper(4, Color.Red),
                new CirclePellicle(3),
                new RectanglePellicle(new List<double> { 3, 6 })
            };

            var box = new Box(figures);

            var result = box.GetSkinFigures();
            var actualResult = new List<IPellicleFigure>()
            {
                new CirclePellicle(3),
                new RectanglePellicle(new List<double> { 3, 6 })
            };

            CollectionAssert.AreEqual(result, actualResult);
        }
    }
}
