// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;

namespace ImageMagick
{
    /// <summary>
    /// Draws a line path from the current point to the given coordinate using absolute coordinates.
    /// The coordinate then becomes the new current point.
    /// </summary>
    public sealed class PathLineToAbs : IPath, IDrawingWand
    {
        private readonly PointDCoordinates _coordinates;

        /// <summary>
        /// Initializes a new instance of the <see cref="PathLineToAbs"/> class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public PathLineToAbs(double x, double y)
          : this(new PointD(x, y))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathLineToAbs"/> class.
        /// </summary>
        /// <param name="coordinates">The coordinates to use.</param>
        public PathLineToAbs(params PointD[] coordinates)
        {
            _coordinates = new PointDCoordinates(coordinates);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PathLineToAbs"/> class.
        /// </summary>
        /// <param name="coordinates">The coordinates to use.</param>
        public PathLineToAbs(IEnumerable<PointD> coordinates)
        {
            _coordinates = new PointDCoordinates(coordinates);
        }

        /// <summary>
        /// Draws this instance with the drawing wand.
        /// </summary>
        /// <param name="wand">The want to draw on.</param>
        void IDrawingWand.Draw(DrawingWand wand) => wand?.PathLineToAbs(_coordinates.ToList());
    }
}