using Task3.Base.BaseFigures;
using Task3.Interfaces;
using System;

namespace Task3.TypesFigures.PellicleFigures
{
    /// <summary>
    /// Circle
    /// </summary>
    public class CirclePellicle : Circle, IPellicleFigure
    {
        /// <summary>
        /// initialize a circle through a radius.
        /// </summary>
        /// <param name="radius">Cicle radius</param>
        public CirclePellicle(double radius) : base(radius)
        {
        }

        /// <summary>
        /// initialize a circle through a radius and a other skin figure.
        /// </summary>
        /// <param name="radius">Cicle radius</param>
        /// /// <param name="figure">Other skin figure</param>
        public CirclePellicle(double radius, IPellicleFigure figure) : base(radius)
        {
            double area = Math.PI * Math.Pow(Radius, 2);

            if (area > figure.GetArea())
            {
                throw new ArgumentException();
            }
        }
    }
}
