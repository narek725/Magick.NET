// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace ImageMagick
{
    /// <summary>
    /// Applies a translation to the current coordinate system which moves the coordinate system
    /// origin to the specified coordinate.
    /// </summary>
    public sealed class DrawableTranslation : IDrawable, IDrawingWand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableTranslation"/> class.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public DrawableTranslation(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the X coordinate.
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate.
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// Draws this instance with the drawing wand.
        /// </summary>
        /// <param name="wand">The want to draw on.</param>
        void IDrawingWand.Draw(DrawingWand wand) => wand?.Translation(X, Y);
    }
}