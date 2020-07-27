using Task3.TypesFigures.PaperFigures;
using Task3.TypesFigures.PellicleFigures;
using System.Xml;
using Task3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;



namespace Task3.Parsers
{

    /// <summary>
    /// parsing figures using XmlReader.
    /// </summary>
    public static class ParserFigureUsingXML
    {
        /// <summary>
        /// parses the xml element into a paper circle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Paper circle</returns>
        public static CirclePaper ParsePaperCircleXmlElement(XmlTextReader xmlReader)
        {
            double radius = 0;
            object color = null;
            int count = 0;
            while (count != 2)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(CirclePaper.Radius)))
                {
                    radius = double.Parse(xmlReader.ReadElementString());
                    count++;
                }

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(CirclePaper.Color)))
                {
                    color = Enum.Parse(typeof(Color), xmlReader.ReadElementString());
                    count++;
                }
            }

            return (new CirclePaper(radius, (Color)color));
        }

        /// <summary>
        /// parses the xml element into a paper rectangle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Paper rectangle</returns>
        public static RectanglePaper ParsePaperRectangleXmlElement(XmlTextReader xmlReader)
        {
            List<double> sides = new List<double>();
            object color = null;
            int count = 0;
            while (count != 2)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(RectanglePaper.Sides)))
                {
                    string listSides = xmlReader.ReadElementString();
                    sides = listSides.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(RectanglePaper.Color)))
                {
                    color = Enum.Parse(typeof(Color), xmlReader.ReadElementString());
                    count++;
                }
            }

            return (new RectanglePaper(sides, (Color)color));
        }

        /// <summary>
        /// parses the xml element into a paper triangle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Paper triangle</returns>
        public static TrianglePaper ParsePaperTriangleXmlElement(XmlTextReader xmlReader)
        {
            List<double> sides = new List<double>();
            object color = null;
            int count = 0;
            while (count != 2)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(TrianglePaper.Sides)))
                {
                    string listSides = xmlReader.ReadElementString();
                    sides = listSides.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(TrianglePaper.Color)))
                {
                    color = Enum.Parse(typeof(Color), xmlReader.ReadElementString());
                    count++;
                }
            }

            return (new TrianglePaper(sides, (Color)color));
        }

        /// <summary>
        /// parses the xml element into a skin circle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Pellicle circle</returns>
        public static CirclePellicle ParsePellicleCircleXmlElement(XmlTextReader xmlReader)
        {
            double radius = 0;
            int count = 0;
            while (count != 1)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(CirclePellicle.Radius)))
                {
                    radius = double.Parse(xmlReader.ReadElementString());
                    count++;
                }
            }

            return (new CirclePellicle(radius));
        }

        /// <summary>
        /// parses the xml element into a skin rectangle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Pellicle rectangle</returns>
        public static RectanglePellicle ParsePellicleRectangleXmlElement(XmlTextReader xmlReader)
        {
            List<double> sides = new List<double>();
            int count = 0;
            while (count != 1)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(RectanglePellicle.Sides)))
                {
                    string listSides = xmlReader.ReadElementString();
                    sides = listSides.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }
            }

            return (new RectanglePellicle(sides));
        }

        /// <summary>
        /// parses the xml element into a skin triangle.
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <returns>Pellicle triangle</returns>
        public static TrianglePellicle ParsePellicleTriangleXmlElement(XmlTextReader xmlReader)
        {
            List<double> sides = new List<double>();
            int count = 0;
            while (count != 1)
            {
                xmlReader.Read();

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == nameof(TrianglePellicle.Sides)))
                {
                    string listSides = xmlReader.ReadElementString();
                    sides = listSides.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }
            }

            return (new TrianglePellicle(sides));
        }
    }

    /// <summary>
    /// parsing xml element using XmlWriter.
    /// </summary>
    public static class ParserXmlElementUsingXML
    {
        /// <summary>
        /// parses the paper circle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="paperCircle">Paper circle</param>
        public static void ParseXmlPaperCircle(XmlTextWriter xmlWriter, CirclePaper paperCircle)
        {
            xmlWriter.WriteStartElement(nameof(CirclePaper));

            xmlWriter.WriteElementString(nameof(CirclePaper.Radius),
                                         paperCircle.Radius.ToString());

            xmlWriter.WriteElementString(nameof(CirclePaper.Color),
                                         paperCircle.Color.ToString());
            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// parses the paper rectangle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="paperRectangle">Paper rectangle</param>
        public static void ParseToXmlElementFromPaperRectangle(XmlTextWriter xmlWriter, RectanglePaper paperRectangle)
        {
            xmlWriter.WriteStartElement(nameof(RectanglePaper));

            xmlWriter.WriteElementString(nameof(RectanglePaper.Sides),
                                         string.Join(' ', paperRectangle.Sides));

            xmlWriter.WriteElementString(nameof(RectanglePaper.Color),
                                         paperRectangle.Color.ToString());
            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// parses the paper triangle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="paperTriangle">Paper triangle</param>
        public static void ParseXmlPaperTriangle(XmlTextWriter xmlWriter, TrianglePaper paperTriangle)
        {
            xmlWriter.WriteStartElement(nameof(TrianglePaper));

            xmlWriter.WriteElementString(nameof(TrianglePaper.Sides),
                                         string.Join(' ', paperTriangle.Sides));

            xmlWriter.WriteElementString(nameof(TrianglePaper.Color),
                                         paperTriangle.Color.ToString());
            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// parses the skin circle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="skinCircle">Pellicle circle</param>
        public static void ParseXmlPellicleCircle(XmlTextWriter xmlWriter, CirclePellicle skinCircle)
        {
            xmlWriter.WriteStartElement(nameof(CirclePellicle));

            xmlWriter.WriteElementString(nameof(CirclePellicle.Radius),
                                         skinCircle.Radius.ToString());

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// parses the skin rectangle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="skinRectangle">Pellicle rectangle</param>
        public static void ParserXmlPellicleRectangle(XmlTextWriter xmlWriter, RectanglePellicle skinRectangle)
        {
            xmlWriter.WriteStartElement(nameof(RectanglePellicle));

            xmlWriter.WriteElementString(nameof(RectanglePellicle.Sides),
                                         string.Join(' ', skinRectangle.Sides));

            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// parses the skin triangle into the xml element.
        /// </summary>
        /// <param name="xmlWriter"></param>
        /// <param name="skinTriangle">Pellicle triangle</param>
        public static void ParseXmlPellicleTriangle(XmlTextWriter xmlWriter, TrianglePellicle skinTriangle)
        {
            xmlWriter.WriteStartElement(nameof(TrianglePellicle));

            xmlWriter.WriteElementString(nameof(TrianglePellicle.Sides),
                                         string.Join(' ', skinTriangle.Sides));

            xmlWriter.WriteEndElement();
        }
    }
}
