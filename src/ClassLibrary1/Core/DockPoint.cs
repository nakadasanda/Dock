using System.Globalization;

namespace Dock.Model
{
    /// <summary>
    /// Point structure.
    /// </summary>
    public struct DockPoint
    {
        /// <summary>
        /// Gets Xcoordinate
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets Xcoordinate
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Initialize the new instance of the <see cref="DockPoint"/>.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public DockPoint(double x,double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns the string represention of the point.
        /// </summary>
        /// <returns>The string representation of the point.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0},{1}", X, Y);
        }

    }
}
