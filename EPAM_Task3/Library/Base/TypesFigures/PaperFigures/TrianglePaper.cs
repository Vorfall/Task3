using Task3.Enums;
using Task3.Base.BaseFigures;
using Task3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3.TypesFigures.PaperFigures
{
    /// <summary>
    /// triangle.
    /// </summary>
    public class TrianglePaper : Triangle, IPaperFigure
    {
        /// <summary>
        /// initialize a square through one or three sides and other paper figure.
        /// </summary>
        /// <param name="sidesCollection">Three sides</param>
        /// <param name="color">Other paper figure</param>
        public TrianglePaper(IEnumerable<double> sidesCollection, Color color) : base(sidesCollection)
        {
            Color = color;
            IsRecolor = true;
        }

        /// <summary>
        /// initialize a square through one or three sides and other paper figure.
        /// </summary>
        /// <param name="sidesCollection">Three sides</param>
        /// <param name="figure">Other paper figure</param>
        public TrianglePaper(IEnumerable<double> sidesCollection, IPaperFigure figure) : base(sidesCollection)
        {
            double halfPerimetr = Sides.Sum() / 2;
            double area = Math.Sqrt(halfPerimetr * (halfPerimetr - Sides[0]) * (halfPerimetr - Sides[1]) * (halfPerimetr - Sides[2]));

            if (area > figure.GetArea())
            {
                throw new ArgumentException("You cannot create a shape because the original shape is smaller.", "sidesCollection");
            }

            Color = figure.Color;
            IsRecolor = true;
        }

        /// <summary>
        /// Color
        /// </summary>
        public Color Color { get; private set; }

        /// <summary>
        /// re-creation
        /// </summary>
        public bool IsRecolor { get; private set; }

        /// <summary>
        /// checking if the shape is allowed to change
        /// </summary>
        /// <param name="color"></param>
        public void RecolorFigure(Color color)
        {
            if (!IsRecolor)
            {
                throw new ArgumentException();
            }

            Color = color;
            IsRecolor = false;
        }

        /// <summary>
        /// Equality check
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            TrianglePaper triangle = (TrianglePaper)obj;

            return (base.Equals(obj) && (Color == triangle.Color));
        }

        /// <summary>
        /// Getting a hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() => base.GetHashCode() ^ Color.GetHashCode();
        

        /// <summary>
        /// Getting a string view
        /// </summary>
        /// <returns></returns>
        public override string ToString()=> base.ToString() + string.Format($"\nColor: {Color}");
        
    }
}
