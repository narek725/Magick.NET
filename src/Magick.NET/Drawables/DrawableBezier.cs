// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;

namespace ImageMagick
{
    /// <summary>
    /// Draws a bezier curve through a set of points on the image.
    /// </summary>
    public sealed class DrawableBezier : IDrawable, IDrawingWand
    {
        private readonly PointDCoordinates _coordinates;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableBezier"/> class.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        public DrawableBezier(params PointD[] coordinates)
        {
            _coordinates = new PointDCoordinates(coordinates, 3);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableBezier"/> class.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        public DrawableBezier(IEnumerable<PointD> coordinates)
        {
            _coordinates = new PointDCoordinates(coordinates, 3);
        }

        /// <summary>
        /// Gets the coordinates.
        /// </summary>
        public IEnumerable<PointD> Coordinates => _coordinates.ToList();

        /// <summary>
        /// Draws this instance with the drawing wand.
        /// </summary>
        /// <param name="wand">The want to draw on.</param>
        void IDrawingWand.Draw(DrawingWand wand) => wand?.Bezier(_coordinates.ToList());
    }
}