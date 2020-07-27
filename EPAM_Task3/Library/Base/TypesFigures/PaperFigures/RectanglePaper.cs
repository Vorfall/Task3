using Task3.Enums;
using Task3.Base.BaseFigures;
using Task3.Interfaces;
using System;
using System.Collections.Generic;

namespace Task3.TypesFigures.PaperFigures
{
    /// <summary>
    /// rectangle.
    /// </summary>
    public class RectanglePaper : Rectangle, IPaperFigure
    {
        /// <summary>
        /// initialize a rectangle through two or four sides and color.
        /// </summary>
        /// <param name="sidesCollection">Two or four sides</param>
        public RectanglePaper(IEnumerable<double> sidesCollection, Color color) : base(sidesCollection)
        {
            Color = color;
            IsRecolor = true;
        }

        /// <summary>
        /// initialize a rectangle through two or four sides and other paper figure.
        /// </summary>
        /// <param name="sidesCollection">Two or four sides</param>
        public RectanglePaper(IEnumerable<double> sidesCollection, IPaperFigure figure) : base(sidesCollection)
        {
            double area = Sides[0] * Sides[1];

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
        public Color Color 
        {
            get;
            private set;
        }

        /// <summary>
        /// Re-creation
        /// </summary>
        public bool IsRecolor
        {
            get;
            private set;
        }

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

            RectanglePaper rectangle = (RectanglePaper)obj;

            return (base.Equals(obj) && (Color == rectangle.Color));
        }

        /// <summary>
        /// Getting a hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (base.GetHashCode() ^ Color.GetHashCode());
        }

        /// <summary>
        /// Getting a string view
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (base.ToString() + string.Format($"\nColor: {Color}"));
        }
    }
}
