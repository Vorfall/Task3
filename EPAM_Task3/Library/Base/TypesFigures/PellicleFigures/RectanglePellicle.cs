using Task3.Base.BaseFigures;
using Task3.Interfaces;
using System;
using System.Collections.Generic;

namespace Task3.TypesFigures.PellicleFigures
{   /// <summary>
    /// Rectangle
    /// </summary>
    public class RectanglePellicle : Rectangle, IPellicleFigure
    {
        /// <summary>
        /// initialize a rectangle through two or four sides.
        /// </summary>
        /// <param name="sidesCollection">Two or four sides</param>
        public RectanglePellicle(IEnumerable<double> sidesCollection) : base(sidesCollection)
        {
        }

        /// <summary>
        /// initialize a rectangle through two or four sides and other skin figure.
        /// </summary>
        /// <param name="sidesCollection">Two or four sides</param>
        /// <param name="figure">Other skin figure</param>
        public RectanglePellicle(IEnumerable<double> sidesCollection, IPellicleFigure figure) : base(sidesCollection)
        {
            double area = Sides[0] * Sides[1];

            if (area > figure.GetArea())
            {
                throw new ArgumentException();
            }
        }
    }
}
