using Task3.Base.BaseFigures;
using Task3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    /// <summary>
    /// working with figures collection.
    /// </summary>
    public class Box
    {
        /// <summary>
        /// initialize the box through a figures collection.
        /// </summary>
        /// <param name="figures">Figures collection</param>
        public Box(IEnumerable<IFigure> figures)
        {
            Figures = new IFigure[20];
            var arrayFigures = figures.ToArray();
            
            for (var i = 0; i < Figures.Length; i++)
            {
                if (i == arrayFigures.Length)
                {
                    break;
                }

                Figures[i] = arrayFigures[i];
            }
        }

        /// <summary>
        /// repository
        /// </summary>
        public IFigure[] Figures
        { 
            get;
            private set;
        }

        /// <summary>
        /// adding a figure to the collection
        /// </summary>
        /// <param name="figure"></param>
        public void AddFigure(IFigure figure)
        {
            for (var i = 0; i < Figures.Length; i++)
            {
                if (Figures[i] == null)
                {
                    Figures[i] = figure;
                    break;
                }

                if (Figures[i].Equals(figure))
                {
                    throw new ArgumentException("The box already contains this shape.", "figure");
                }
            }
        }

        /// <summary>
        /// returns the shape by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Figure</returns>
        public IFigure ShowFigure(int index)
        {
            return Figures[index];
        }

        /// <summary>
        /// returns the shape by index and deletes it.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>Figure</returns>
        public IFigure GetFigure(int index)
        {
            var figure = Figures[index];
            
            for (var i = 0; i < Figures.Length; i++)
            {
                if (i == index)
                {
                    for (var j = i; j < Figures.Length - 1; j++)
                    {
                        Figures[j] = Figures[j + 1];
                    }
                }
            }

            return figure;
        }

        /// <summary>
        /// replaces the indexed shape with a new shape.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="figure">New figure</param>
        public void SetFigure(int index, IFigure figure)
        {
            Figures[index] = figure;
        }

        /// <summary>
        /// The method returns the specified shape if it is a collection of shapes.
        /// </summary>
        /// <param name="figure"></param>
        /// <returns>Specified figure</returns>
        public IFigure SearchFigure(IFigure figure)
        {
            for (var i = 0; i < Figures.Length; i++)
            {
                if (Figures[i] == null)
                {
                    break;
                }

                if (Figures[i].Equals(figure))
                {
                    return Figures[i];
                }
            }

            return null;
        }

        /// <summary>
        /// returns the number of shapes in the collection.
        /// </summary>
        /// <returns>Count of figures</returns>
        public int GetCountFigures()
        {
            for (var i = 0; i < Figures.Length; i++)
            {
                if (Figures[i] == null)
                {
                    return i;
                }
            }

            return 0;
        }

        /// <summary>
        /// returns the total perimeter of the figures.
        /// </summary>
        /// <returns>Total perimeter</returns>
        public double GetTotalPerimeter()
        {
            double totalPerimeter = 0;

            for (var i = 0; i < GetCountFigures(); i++)
            {
                totalPerimeter += Figures[i].GetPerimeter();
            }

            return totalPerimeter;
        }

        /// <summary>
        /// returns the total area of the figures.
        /// </summary>
        /// <returns>Total area</returns>
        public double GetTotalArea()
        {
            double totalArea = 0;

            for (var i = 0; i < GetCountFigures(); i++)
            {
                totalArea += Figures[i].GetArea();
            }

            return totalArea;
        }

        /// <summary>
        /// returns circles from a figures collection.
        /// </summary>
        /// <returns>Circle collection</returns>
        public List<IFigure> GetCircles()
        {
            var cirles = new List<IFigure>();

            for (var i = 0; i < GetCountFigures(); i++)
            {
                if (Figures[i] is Circle)
                {
                    cirles.Add(Figures[i]);
                }
            }

            return cirles;
        }

        /// <summary>
        /// returns skin figures from a figures collection. 
        /// </summary>
        /// <returns>Skin figures</returns>
        public List<IPellicleFigure> GetSkinFigures()
        {
            var skinFigures = new List<IPellicleFigure>();

            for (var i = 0; i < GetCountFigures(); i++)
            {
                if (Figures[i] is IPellicleFigure)
                {
                    skinFigures.Add((IPellicleFigure)Figures[i]);
                }
            }

            return skinFigures;
        }

        /// <summary>
        /// equal the current object with the specified object.
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            var box = (Box)obj;

            for (var i = 0; i < GetCountFigures(); i++)
            {
                if (!Figures[i].Equals(box.Figures[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return Figures.Select(obj => obj.GetHashCode() >> 20).Sum();
        }

        /// <summary>
        /// creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString()
        {
            string box = "Figures:\n\n";

            foreach (IFigure figure in Figures)
            {
                box += figure.ToString() + "\n\n";
            }

            return box;
        }
    }
}
