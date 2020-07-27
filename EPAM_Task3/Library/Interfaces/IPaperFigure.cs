using Task3.Enums;

namespace Task3.Interfaces
{
  
    public interface IPaperFigure : IFigure
    {
        /// <summary>
        /// Property for determining the ability to recolor a figure.
        /// </summary>
        bool IsRecolor { get; }

        /// <summary>
        /// Property for storing color.
        /// </summary>
        Color Color { get; }

        /// <summary>
        /// Method for recoloring a figure.
        /// </summary>
        /// <param name="color"></param>
        void RecolorFigure(Color color);
    }
}
