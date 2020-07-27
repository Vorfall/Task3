using Task3.Base.BaseFigures;
using Task3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3.TypesFigures.PellicleFigures
{
    /// <summary>
    /// Triangle
    /// </summary>
    public class TrianglePellicle : Triangle, IPellicleFigure
    {
        /// <summary>
        /// initialize a square through one or three sides.
        /// </summary>
        /// <param name="sidesCollection">Three sides</param>
        public TrianglePellicle(IEnumerable<double> sidesCollection) : base(sidesCollection)
        {
        }

        /// <summary>
        /// initialize a square through one or three sides and other skin figure.
        /// </summary>
        /// <param name="sidesCollection">Three sides</param>
        /// <param name="figure">Other skin figure</param>
        public TrianglePellicle(IEnumerable<double> sidesCollection, IPellicleFigure figure) : base(sidesCollection)
        {
            
            double area = Math.Sqrt((Sides.Sum() / 2) * ((Sides.Sum() / 2) - Sides[0]) * ((Sides.Sum() / 2) - Sides[1]) * ((Sides.Sum() / 2) - Sides[2]));

            if (area > figure.GetArea())
            {
                throw new ArgumentException();
            }
        }
    }
}
