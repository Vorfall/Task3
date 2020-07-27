using Task3.Enums;
using Task3.TypesFigures.PaperFigures;
using Task3.TypesFigures.PellicleFigures;
using Task3.Interfaces;
using Task3.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace Task3.FileWork
{
    /// <summary>
    /// wirking with file.
    /// </summary>
    public static class FileExtension
    {
           public static List<IFigure> ReadFiguresXmlReader(string way)
        {
            using (var xmlReader = new XmlTextReader(way))
            {
                var generalFigure = new List<IFigure>();

                while (xmlReader.Read())
                {
                    if (!Enum.TryParse(typeof(TypeFigure), xmlReader.Name, out object typeFigure))
                    {
                        continue;
                    }

                    switch (typeFigure)
                    {
                        case TypeFigure.CirclePaper:
                            CirclePaper paperCircle = ParserFigureUsingXML.ParsePaperCircleXmlElement(xmlReader);
                            generalFigure.Add(paperCircle);
                            break;
                        case TypeFigure.RectanglePaper:
                            RectanglePaper paperRectangle = ParserFigureUsingXML.ParsePaperRectangleXmlElement(xmlReader);
                            generalFigure.Add(paperRectangle);
                            break;

                        case TypeFigure.TrianglePaper:
                            TrianglePaper paperTriangle = ParserFigureUsingXML.ParsePaperTriangleXmlElement(xmlReader);
                            generalFigure.Add(paperTriangle);
                            break;

                        case TypeFigure.CirclePellicle:
                            CirclePellicle skinCircle = ParserFigureUsingXML.ParsePellicleCircleXmlElement(xmlReader);
                            generalFigure.Add(skinCircle);
                            break;

                        case TypeFigure.RectanglePellicle:
                            RectanglePellicle skinRectangle = ParserFigureUsingXML.ParsePellicleRectangleXmlElement(xmlReader);
                            generalFigure.Add(skinRectangle);
                            break;

                        case TypeFigure.TrianglePellicle:
                            TrianglePellicle skinTriangle = ParserFigureUsingXML.ParsePellicleTriangleXmlElement(xmlReader);
                            generalFigure.Add(skinTriangle);
                            break;
                    }

                    xmlReader.Read();
                }

                return generalFigure;
            }
        }

        /// <summary>
        /// The method writes data to the file using XmlWriter.
        /// </summary>
        /// <param name="figuresCollection">Figures collection</param>
        /// <param name="way">Path to the file</param>
        /// <param name="typeMaterialFigure">Type material</param>
        public static void WriteFiguresXmlWriter(IEnumerable<IFigure> figuresCollection, string way, Type typeMaterialFigure)
        {
            using (var xmlWriter = new XmlTextWriter(way, System.Text.Encoding.UTF8))
            {
                xmlWriter.Formatting = Formatting.Indented;
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("Figures");

                foreach (IFigure figure in figuresCollection)
                {
                    Type materialFigure = figure.GetType().GetInterface(typeMaterialFigure.Name);

                    if (materialFigure != typeMaterialFigure)
                    {
                        continue;
                    }

                    var typeFigure = Enum.Parse(typeof(TypeFigure), figure.GetType().Name);

                    switch (typeFigure)
                    {
                        case TypeFigure.CirclePaper:
                            var paperCircle = (CirclePaper)figure;
                            ParserXmlElementUsingXML.ParseXmlPaperCircle(xmlWriter, paperCircle);
                            break;
                        case TypeFigure.RectanglePaper:
                            var paperRectangle = (RectanglePaper)figure;
                            ParserXmlElementUsingXML.ParseToXmlElementFromPaperRectangle(xmlWriter, paperRectangle);
                            break;
                        case TypeFigure.TrianglePaper:
                            var paperTriangle = (TrianglePaper)figure;
                            ParserXmlElementUsingXML.ParseXmlPaperTriangle(xmlWriter, paperTriangle);
                            break;
                        case TypeFigure.CirclePellicle:
                            var skinCircle = (CirclePellicle)figure;
                            ParserXmlElementUsingXML.ParseXmlPellicleCircle(xmlWriter, skinCircle);
                            break;
                        case TypeFigure.RectanglePellicle:
                            var skinRectangle = (RectanglePellicle)figure;
                            ParserXmlElementUsingXML.ParserXmlPellicleRectangle(xmlWriter, skinRectangle);
                            break;
                        case TypeFigure.TrianglePellicle:
                            var skinTriangle = (TrianglePellicle)figure;
                            ParserXmlElementUsingXML.ParseXmlPellicleTriangle(xmlWriter, skinTriangle);
                            break;
                    }
                }

                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Flush();
            }
        }

        /// <summary>
        /// The method reads data from a file using StreamReader and returns a list of generalFigure.
        /// </summary>
        /// <returns>Figure list</returns>
        public static List<IFigure> ReadFiguresStreamReader(string way)
        {
            using (var streamReader = new StreamReader(way))
            {
                var generalFigure = new List<IFigure>();
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string elementContent = line.Trim('<', '>', '/', '\t', ' ');

                    if (!Enum.TryParse(typeof(TypeFigure), elementContent, out object typeFigure))
                    {
                        continue;
                    }

                    switch (typeFigure)
                    {
                        case TypeFigure.CirclePaper:
                            CirclePaper paperCircle = ParserFiguresUsingStream.ParsePaperCircleXmlElement(streamReader);
                            generalFigure.Add(paperCircle);
                            break;
                        case TypeFigure.RectanglePaper:
                            RectanglePaper paperRectangle = ParserFiguresUsingStream.ParsePaperRectXmlElement(streamReader);
                            generalFigure.Add(paperRectangle);
                            break;
                        case TypeFigure.TrianglePaper:
                            TrianglePaper paperTriangle = ParserFiguresUsingStream.ParsePaperTriXmlElement(streamReader);
                            generalFigure.Add(paperTriangle);
                            break;
                        case TypeFigure.CirclePellicle:
                            CirclePellicle skinCircle = ParserFiguresUsingStream.ParsePellicleCircleXmlElement(streamReader);
                            generalFigure.Add(skinCircle);
                            break;
                        case TypeFigure.RectanglePellicle:
                            RectanglePellicle skinRectangle = ParserFiguresUsingStream.ParsePellicleRectangleFXmlElement(streamReader);
                            generalFigure.Add(skinRectangle);
                            break;
                        case TypeFigure.TrianglePellicle:
                            TrianglePellicle skinTriangle = ParserFiguresUsingStream.ParsePellicleTriXmlElement(streamReader);
                            generalFigure.Add(skinTriangle);
                            break;
                    }

                    streamReader.ReadLine();
                }

                return generalFigure;
            }
        }

        /// <summary>
        /// The method writes data to the file using StreamWriter.
        /// </summary>
        /// <param name="figuresCollection">Figures collection</param>
        /// <param name="way">Path to the file</param>
        /// <param name="typeMaterialFigure">Type material</param>
        public static void WriteFiguresStreamWriter(IEnumerable<IFigure> figuresCollection, string way, Type typeMaterialFigure)
        {
            using (var streamWriter = new StreamWriter(way))
            {
                streamWriter.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                streamWriter.WriteLine("<Figures>");

                foreach (IFigure figure in figuresCollection)
                {
                    Type materialFigure = figure.GetType().GetInterface(typeMaterialFigure.Name);

                    if (materialFigure != typeMaterialFigure)
                    {
                        continue;
                    }

                    var typeFigure = Enum.Parse(typeof(TypeFigure), figure.GetType().Name);

                    switch (typeFigure)
                    {
                        case TypeFigure.CirclePaper:
                            var paperCircle = (CirclePaper)figure;
                            ParserXmlElementUsingStream.ParseXmlPaperCircle(streamWriter, paperCircle);
                            break;
                        case TypeFigure.RectanglePaper:
                            var paperRectangle = (RectanglePaper)figure;
                            ParserXmlElementUsingStream.ParseXmlPaperRectangle(streamWriter, paperRectangle);
                            break;
                        case TypeFigure.TrianglePaper:
                            var paperTriangle = (TrianglePaper)figure;
                            ParserXmlElementUsingStream.ParseXmlPaperTriangle(streamWriter, paperTriangle);
                            break;
                        case TypeFigure.CirclePellicle:
                            var skinCircle = (CirclePellicle)figure;
                            ParserXmlElementUsingStream.ParseXmlPellicleCircle(streamWriter, skinCircle);
                            break;
                        case TypeFigure.RectanglePellicle:
                            var skinRectangle = (RectanglePellicle)figure;
                            ParserXmlElementUsingStream.ParseXmlPellicleRectangle(streamWriter, skinRectangle);
                            break;
                        case TypeFigure.TrianglePellicle:
                            var skinTriangle = (TrianglePellicle)figure;
                            ParserXmlElementUsingStream.ParseXmlPellicleTriangle(streamWriter, skinTriangle);
                            break;
                    }
                }

                streamWriter.WriteLine("</Figures>");
            }
        }
    }
}
