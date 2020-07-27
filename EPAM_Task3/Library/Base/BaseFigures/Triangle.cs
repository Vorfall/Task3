using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3.Base.BaseFigures
{
    /// <summary>
    /// Abstract class for working with a triangle.
    /// </summary>
    public abstract class Triangle
    {
        /// <summary>
        /// Constructor to initialize a square through one or three sides.
        /// </summary>
        /// <param name="sidesCollection">Three sides</param>
        public Triangle(IEnumerable<double> sidesCollection)
        {
            if (sidesCollection.Count() != 3)
            {
                throw new ArgumentException("The count of sides is not equal to three.", "sides");
            }

            Sides = sidesCollection.ToList();
        }

        /// <summary>
        /// Property for storing sides.
        /// </summary>
        public List<double> Sides { get; }


        /// <summary>
        /// Method for equal the current object with the specified object.
        /// </summary>
        /// <param name="obj">Any object</param>
        /// <returns>True or False</returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }

            Triangle triangle = (Triangle)obj;

            for (int i = 0; i < Sides.Count; i++)
            {
                if (Sides[i] != triangle.Sides[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <inheritdoc cref="IFigure.GetArea()"/>
        public double GetArea() => Math.Sqrt(GetPerimeter() / 2 * (GetPerimeter() / 2 - Sides[0]) * (GetPerimeter() / 2 - Sides[1]) * (GetPerimeter() / 2 - Sides[2]));


        /// <inheritdoc cref="IFigure.GetPerimeter()"/>
        public double GetPerimeter() => Sides.Sum();


        /// <summary>
        /// The method calculates the hash code for the current object.
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode() => Sides.Select(obj => obj.GetHashCode() >> 3).Sum();
        

        /// <summary>
        /// The method creates and returns a string representation of the object.
        /// </summary>
        /// <returns>String representation</returns>
        public override string ToString() => string.Format($"Type Figure: {GetType().Name}\n" +
                                                           $"Area: {GetArea()}\n" +
                                                           $"Perimeter: {GetPerimeter()}");
        
    }
}
