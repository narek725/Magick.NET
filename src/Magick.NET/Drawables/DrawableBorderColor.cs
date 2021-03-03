// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ImageMagick
{
    /// <summary>
    /// Sets the border color to be used for drawing bordered objects.
    /// </summary>
    public sealed partial class DrawableBorderColor : IDrawable, IDrawingWand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableBorderColor"/> class.
        /// </summary>
        /// <param name="color">The color of the border.</param>
        public DrawableBorderColor(IMagickColor<QuantumType> color)
        {
            Throw.IfNull(nameof(color), color);

            Color = color;
        }

        /// <summary>
        /// Gets or sets the color to use.
        /// </summary>
        public IMagickColor<QuantumType> Color { get; set; }

        /// <summary>
        /// Draws this instance with the drawing wand.
        /// </summary>
        /// <param name="wand">The want to draw on.</param>
        void IDrawingWand.Draw(DrawingWand wand) => wand?.BorderColor(Color);
    }
}