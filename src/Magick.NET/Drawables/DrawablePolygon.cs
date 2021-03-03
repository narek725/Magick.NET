// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;

namespace ImageMagick
{
    /// <summary>
    /// Draws a polygon using the current stroke, stroke width, and fill color or texture, using the
    /// specified array of coordinates.
    /// </summary>
    public sealed class DrawablePolygon : IDrawable, IDrawingWand
    {
        private readonly PointDCoordinates _coordinates;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawablePolygon"/> class.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        public DrawablePolygon(params PointD[] coordinates)
        {
            _coordinates = new PointDCoordinates(coordinates, 3);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawablePolygon"/> class.
        /// </summary>
        /// <param name="coordinates">The coordinates.</param>
        public DrawablePolygon(IEnumerable<PointD> coordinates)
        {
            _coordinates = new PointDCoordinates(coordinates, 3);
        }

        /// <summary>
        /// Draws this instance with the drawing wand.
        /// </summary>
        /// <param name="wand">The want to draw on.</param>
        void IDrawingWand.Draw(DrawingWand wand) => wand?.Polygon(_coordinates.ToList());
    }
}