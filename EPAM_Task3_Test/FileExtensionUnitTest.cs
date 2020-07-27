using Task3.Enums;
using Task3.TypesFigures.PaperFigures;
using Task3.TypesFigures.PellicleFigures;
using Task3.FileWork;
using Task3.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace EPAM_Task3_Test.FileWork
{
   
    [TestClass]
    public class FileExtensionUnitTest
    {
       
        [TestMethod]
        public void WriteFiguresXmlTypeMaterialIsPelliclePellicleFigures()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 5 }, Color.Blue),
                new CirclePellicle(7),
                new RectanglePellicle(new List<double> { 3, 7 })
            };

            string filePath = @"..\..\..\..\EPAM_Task3\ResXML\Figures2.xml";
            FileExtension.WriteFiguresXmlWriter(figures, filePath, typeof(IPellicleFigure));

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                               "<Figures>\r\n" +
                               "  <CirclePellicle>\r\n" +
                               "    <Radius>7</Radius>\r\n" +
                               "  </CirclePellicle>\r\n" +
                               "  <RectanglePellicle>\r\n" +
                               "    <Sides>3 7</Sides>\r\n" +
                               "  </RectanglePellicle>\r\n" +
                               "</Figures>";
            }

            Assert.AreEqual(result, actualResult);
        }

        
        

       
        [TestMethod]
        public void TestReadFiguresXmlReader()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 3, 6 }, Color.Black),
                new TrianglePaper(new List<double> { 1, 2, 3 }, Color.Blue),
                new CirclePellicle(9),
                new RectanglePellicle(new List<double> { 7, 8 })
            };

            string filePath = @"..\..\..\..\EPAM_Task3\ResXML\Figures1.xml";
            List<IFigure> result = FileExtension.ReadFiguresXmlReader(filePath);
            List<IFigure> actualResult = figures;

            CollectionAssert.AreEqual(result, actualResult);
        }

       
        [TestMethod]
        public void WriteFiguresStreamWriterWhenTypeMaterialIsFigureWriteAllFigures()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 2, 4 }, Color.Black),
                new TrianglePaper(new List<double> { 2, 4, 5 }, Color.Blue),
                new CirclePellicle(7),
                new RectanglePellicle(new List<double> { 3, 7 })
            };

            string filePath = @"..\..\..\..\EPAM_Task3\ResXML\Figures2.xml";
            FileExtension.WriteFiguresStreamWriter(figures, filePath, typeof(IFigure));

            string result;
            string actualResult;

            using (var streamReader = new StreamReader(filePath))
            {
                result = streamReader.ReadToEnd();
                actualResult = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                               "<Figures>\r\n" +
                               "\t<RectanglePaper>\r\n" +
                               "\t\t<Sides>2 4</Sides>\r\n" +
                               "\t\t<Color>Black</Color>\r\n" +
                               "\t</RectanglePaper>\r\n" +
                               "\t<TrianglePaper>\r\n" +
                               "\t\t<Sides>2 4 5</Sides>\r\n" +
                               "\t\t<Color>Blue</Color>\r\n" +
                               "\t</TrianglePaper>\r\n" +
                               "\t<CirclePellicle>\r\n" +
                               "\t\t<Radius>7</Radius>\r\n" +
                               "\t</CirclePellicle>\r\n" +
                               "\t<RectanglePellicle>\r\n" +
                               "\t\t<Sides>3 7</Sides>\r\n" +
                               "\t</RectanglePellicle>\r\n" +
                               "</Figures>\r\n";
            }

            Assert.AreEqual(result, actualResult);
        }
       
        [TestMethod]
        public void TestReadFiguresStreamReader()
        {
            var figures = new List<IFigure>
            {
                new RectanglePaper(new List<double> { 3, 6 }, Color.Black),
                new TrianglePaper(new List<double> { 1, 2, 3 }, Color.Blue),
                new CirclePellicle(9),
                new RectanglePellicle(new List<double> { 7, 8 })
            };

            string filePath = @"..\..\..\..\EPAM_Task3\ResXML\Figures1.xml";
            List<IFigure> result = FileExtension.ReadFiguresStreamReader(filePath);
            List<IFigure> actualResult = figures;

            CollectionAssert.AreEqual(result, actualResult);
        }
    }
}
