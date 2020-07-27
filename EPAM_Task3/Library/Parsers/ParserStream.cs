using Task3.TypesFigures.PaperFigures;
using Task3.TypesFigures.PellicleFigures;
using System.IO;
using Task3.Enums;

using System;
using System.Collections.Generic;

using System.Linq;

namespace Task3.Parsers
{
    /// <summary>
    /// parsing figures using StreamReader.
    /// </summary>
    public static class ParserFiguresUsingStream
    {
        /// <summary>
        /// parses the xml element into a paper circle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Paper circle</returns>
        public static CirclePaper ParsePaperCircleXmlElement(StreamReader streamReader)
        {
            double r = 0;
            object color = null;
            int count = 0;
            while (count != 2)
            {
                string line = streamReader.ReadLine();
                line = line.TrimStart('\t', ' ');

                if (line.Contains(nameof(CirclePaper.Radius)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(CirclePaper.Radius));
                    r = double.Parse(xmlElementContent);
                    count++;
                }

                if (line.Contains(nameof(CirclePaper.Color)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(CirclePaper.Color));
                    color = Enum.Parse(typeof(Color), xmlElementContent);
                    count++;
                }
            }

            return (new CirclePaper(r, (Color)color));
        }

        /// <summary>
        /// parses the xml element into a paper rectangle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Paper rectangle</returns>
        public static RectanglePaper ParsePaperRectXmlElement(StreamReader streamReader)
        {
            List<double> parties = new List<double>();
            object color = null;
            int count = 0;
            while (count != 2)
            {
                string line = streamReader.ReadLine();
                line = line.TrimStart('\t', ' ');

                if (line.Contains(nameof(RectanglePaper.Sides)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(RectanglePaper.Sides));
                    parties = xmlElementContent.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }

                if (line.Contains(nameof(RectanglePaper.Color)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(RectanglePaper.Color));
                    color = Enum.Parse(typeof(Color), xmlElementContent);
                    count++;
                }
            }

            return (new RectanglePaper(parties, (Color)color));
        }

        /// <summary>
        /// parses the xml element into a paper triangle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Paper triangle</returns>
        public static TrianglePaper ParsePaperTriXmlElement(StreamReader streamReader)
        {
            List<double> parties = new List<double>();
            object color = null;
            int count = 0;
            while (count != 2)
            {
                string line = streamReader.ReadLine();
                line = line.TrimStart('\t', ' ');

                if (line.Contains(nameof(TrianglePaper.Sides)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(TrianglePaper.Sides));
                    parties = xmlElementContent.Split(' ').Select(obj => double.Parse(obj)).ToList();
                    count++;
                }

                if (line.Contains(nameof(TrianglePaper.Color)))
                {
                    string xmlElementContent = GetXmlElementContent(line, nameof(TrianglePaper.Color));
                    color = Enum.Parse(typeof(Color), xmlElementContent);
                    count++;
                }
            }

            return (new TrianglePaper(parties, (Color)color));
        }

        /// <summary>
        /// parses the xml element into a skin circle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Pellicle circle</returns>
        public static CirclePellicle ParsePellicleCircleXmlElement(StreamReader streamReader)
        {
            double r = 0;

            string line = streamReader.ReadLine();
            line = line.TrimStart('\t', ' ');

            if (line.Contains(nameof(CirclePellicle.Radius)))
            {
                string xmlElementContent = GetXmlElementContent(line, nameof(CirclePellicle.Radius));
                r = double.Parse(xmlElementContent);
            }

            return (new CirclePellicle(r));
        }

        /// <summary>
        /// parses the xml element into a skin rectangle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Pellicle rectangle</returns>
        public static RectanglePellicle ParsePellicleRectangleFXmlElement(StreamReader streamReader)
        {
            List<double> parties = new List<double>();

            string line = streamReader.ReadLine();
            line = line.TrimStart('\t', ' ');

            if (line.Contains(nameof(RectanglePellicle.Sides)))
            {
                string xmlElementContent = GetXmlElementContent(line, nameof(RectanglePellicle.Sides));
                parties = xmlElementContent.Split(' ').Select(obj => double.Parse(obj)).ToList();
            }

            return (new RectanglePellicle(parties));
        }

        /// <summary>
        /// parses the xml element into a skin triangle.
        /// </summary>
        /// <param name="streamReader"></param>
        /// <returns>Pellicle triangle</returns>
        public static TrianglePellicle ParsePellicleTriXmlElement(StreamReader streamReader)
        {
            List<double> parties = new List<double>();

            string line = streamReader.ReadLine();
            line = line.TrimStart('\t', ' ');

            if (line.Contains(nameof(TrianglePellicle.Sides)))
            {
                string xmlElementContent = GetXmlElementContent(line, nameof(TrianglePellicle.Sides));
                parties = xmlElementContent.Split(' ').Select(obj => double.Parse(obj)).ToList();
            }

            return (new TrianglePellicle(parties));
        }

        /// <summary>
        /// returning xml element content.
        /// </summary>
        /// <param name="line">Xml string element</param>
        /// <param name="tagContent">Tag content</param>
        /// <returns>Xml element content</returns>
        private static string GetXmlElementContent(string line, string tagContent)
        {
            int startIndex = 0;
            int newCount = tagContent.Length + 2;
            string xmlElementContent = line.Remove(startIndex, newCount);
            startIndex = xmlElementContent.Length - tagContent.Length - 3;
            newCount = tagContent.Length + 3;
            xmlElementContent = xmlElementContent.Remove(startIndex, newCount);
            return xmlElementContent;
        }
    }
    /// <summary>
    /// parsing xml element using StreamWriter.
    /// </summary>
    public static class ParserXmlElementUsingStream
    {
        /// <summary>
        /// parses the paper circle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="paperCircle">Paper circle</param>
        public static void ParseXmlPaperCircle(StreamWriter streamWriter, CirclePaper paperCircle)
        {
            streamWriter.WriteLine($"\t<{nameof(CirclePaper)}>");
            streamWriter.WriteLine($"\t\t<{nameof(CirclePaper.Radius)}>{paperCircle.Radius}</{nameof(CirclePaper.Radius)}>");
            streamWriter.WriteLine($"\t\t<{nameof(CirclePaper.Color)}>{paperCircle.Color}</{nameof(CirclePaper.Color)}>");
            streamWriter.WriteLine($"\t</{nameof(CirclePaper)}>");
        }

        /// <summary>
        /// parses the paper rectangle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="paperRectangle">Paper rectangle</param>
        public static void ParseXmlPaperRectangle(StreamWriter streamWriter, RectanglePaper paperRectangle)
        {
            streamWriter.WriteLine($"\t<{nameof(RectanglePaper)}>");
            streamWriter.WriteLine($"\t\t<{nameof(RectanglePaper.Sides)}>{string.Join(' ', paperRectangle.Sides)}</{nameof(RectanglePaper.Sides)}>");
            streamWriter.WriteLine($"\t\t<{nameof(RectanglePaper.Color)}>{paperRectangle.Color}</{nameof(RectanglePaper.Color)}>");
            streamWriter.WriteLine($"\t</{nameof(RectanglePaper)}>");
        }

        /// <summary>
        /// parses the paper triangle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="paperTriangle">Paper triangle</param>
        public static void ParseXmlPaperTriangle(StreamWriter streamWriter, TrianglePaper paperTriangle)
        {
            streamWriter.WriteLine($"\t<{nameof(TrianglePaper)}>");
            streamWriter.WriteLine($"\t\t<{nameof(TrianglePaper.Sides)}>{string.Join(' ', paperTriangle.Sides)}</{nameof(TrianglePaper.Sides)}>");
            streamWriter.WriteLine($"\t\t<{nameof(TrianglePaper.Color)}>{paperTriangle.Color}</{nameof(TrianglePaper.Color)}>");
            streamWriter.WriteLine($"\t</{nameof(TrianglePaper)}>");
        }

        /// <summary>
        /// parses the skin circle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="skinCircle">Pellicle circle</param>
        public static void ParseXmlPellicleCircle(StreamWriter streamWriter, CirclePellicle skinCircle)
        {
            streamWriter.WriteLine($"\t<{nameof(CirclePellicle)}>");
            streamWriter.WriteLine($"\t\t<{nameof(CirclePellicle.Radius)}>{skinCircle.Radius}</{nameof(CirclePellicle.Radius)}>");
            streamWriter.WriteLine($"\t</{nameof(CirclePellicle)}>");
        }

        /// <summary>
        /// parses the skin rectangle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="skinRectangle">Pellicle rectangle</param>
        public static void ParseXmlPellicleRectangle(StreamWriter streamWriter, RectanglePellicle skinRectangle)
        {
            streamWriter.WriteLine($"\t<{nameof(RectanglePellicle)}>");
            streamWriter.WriteLine($"\t\t<{nameof(RectanglePellicle.Sides)}>{string.Join(' ', skinRectangle.Sides)}</{nameof(RectanglePellicle.Sides)}>");
            streamWriter.WriteLine($"\t</{nameof(RectanglePellicle)}>");
        }

        /// <summary>
        /// parses the skin triangle into the xml element.
        /// </summary>
        /// <param name="streamWriter"></param>
        /// <param name="skinTriangle">Pellicle triangle</param>
        public static void ParseXmlPellicleTriangle(StreamWriter streamWriter, TrianglePellicle skinTriangle)
        {
            streamWriter.WriteLine($"\t<{nameof(TrianglePellicle)}>");
            streamWriter.WriteLine($"\t\t<{nameof(TrianglePellicle.Sides)}>{string.Join(' ', skinTriangle.Sides)}</{nameof(TrianglePellicle.Sides)}>");
            streamWriter.WriteLine($"\t</{nameof(TrianglePellicle)}>");
        }
    }
}
