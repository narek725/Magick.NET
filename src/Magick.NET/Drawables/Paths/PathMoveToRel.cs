// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace ImageMagick
{
    /// <summary>
    /// Starts a new sub-path at the given coordinate using relative coordinates. The current point
    /// then becomes the specified coordinate.
    /// </summary>
    public sealed class PathMoveToRel : IPath, IDrawingWand
    {
        private readonly PointD _coordinate;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathMoveToRel"/> class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public PathMoveToRel(double x, double y)
         : this(new PointD(x, y))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathMoveToRel"/> class.
        /// </summary>
        /// <param name="coordinate">The coordinate to use.</param>
        public PathMoveToRel(PointD coordinate)
        {
            _coordinate = coordinate;
        }

        /// <summary>
        /// Draws this instance with the drawing wand.
        /// </summary>
        /// <param name="wand">The want to draw on.</param>
        void IDrawingWand.Draw(DrawingWand wand) => wand?.PathMoveToRel(_coordinate.X, _coordinate.Y);
    }
}