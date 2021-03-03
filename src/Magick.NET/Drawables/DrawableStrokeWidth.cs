// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace ImageMagick
{
    /// <summary>
    /// Sets the width of the stroke used to draw object outlines.
    /// </summary>
    public sealed class DrawableStrokeWidth : IDrawable, IDrawingWand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableStrokeWidth"/> class.
        /// </summary>
        /// <param name="width">The width.</param>
        public DrawableStrokeWidth(double width)
        {
            Width = width;
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// Draws this instance with the drawing wand.
        /// </summary>
        /// <param name="wand">The want to draw on.</param>
        void IDrawingWand.Draw(DrawingWand wand) => wand?.StrokeWidth(Width);
    }
}