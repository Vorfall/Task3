using Task3.Enums;
using Task3.Base.BaseFigures;
using Task3.Interfaces;
using System;

namespace Task3.TypesFigures.PaperFigures
{
    /// <summary>
    /// Paper circle
    /// </summary>
    public class CirclePaper : Circle, IPaperFigure
    {
        /// <summary>
        /// Initialization through radius and color
        /// </summary>
        /// <param name="radius">Cicle radius</param>
        /// <param name="color">Cicle color</param>
        public CirclePaper(double radius, Color color) : base(radius)
        {
            Color = color;
            IsRecolor = true;
        }

        /// <summary>
        /// Initialization via radius and another shape
        /// </summary>
        /// <param name="radius">Cicle radius</param>
        /// <param name="figure">Other paper figure</param>
        public CirclePaper(double radius, IPaperFigure figure) : base(radius)
        {
            double area = Math.PI * Math.Pow(Radius, 2);

            if (area > figure.GetArea())
            {
                throw new ArgumentException("You cannot create a shape because the original shape is smaller.", "radius");
            }

            Color = figure.Color;
            IsRecolor = true;
        }

        /// <summary>
        /// Color
        /// </summary>
        public Color Color { get; private set; }

        /// <summary>
        /// Re-creation
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

            CirclePaper circle = (CirclePaper)obj;

            return ((Color == circle.Color) && base.Equals(obj));
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
        public override string ToString() => base.ToString() + string.Format($"\nColor: {Color}");
        }
    }

