// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace ImageMagick
{
    /// <summary>
    /// Specifies the pattern of dashes and gaps used to stroke paths. The stroke dash array
    /// represents an array of numbers that specify the lengths of alternating dashes and gaps in
    /// pixels. If an odd number of values is provided, then the list of values is repeated to yield
    /// an even number of values. To remove an existing dash array, pass a null dasharray. A typical
    /// stroke dash array might contain the members 5 3 2.
    /// </summary>
    public sealed class DrawableStrokeDashArray : IDrawable, IDrawingWand
    {
        private readonly double[] _dash;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableStrokeDashArray"/> class.
        /// </summary>
        /// <param name="dash">An array containing the dash information.</param>
        public DrawableStrokeDashArray(params double[] dash)
        {
            _dash = dash;
        }

        /// <summary>
        /// Draws this instance with the drawing wand.
        /// </summary>
        /// <param name="wand">The want to draw on.</param>
        void IDrawingWand.Draw(DrawingWand wand) => wand?.StrokeDashArray(_dash);
    }
}