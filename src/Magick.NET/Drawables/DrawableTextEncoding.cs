// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Text;

namespace ImageMagick
{
    /// <summary>
    /// Encapsulation of the DrawableTextEncoding object.
    /// </summary>
    public sealed class DrawableTextEncoding : IDrawable, IDrawingWand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableTextEncoding"/> class.
        /// </summary>
        /// <param name="encoding">Encoding to use.</param>
        public DrawableTextEncoding(Encoding encoding)
        {
            Throw.IfNull(nameof(encoding), encoding);

            Encoding = encoding;
        }

        /// <summary>
        /// Gets or sets the encoding of the text.
        /// </summary>
        public Encoding Encoding { get; set; }

        /// <summary>
        /// Draws this instance with the drawing wand.
        /// </summary>
        /// <param name="wand">The want to draw on.</param>
        void IDrawingWand.Draw(DrawingWand wand) => wand?.TextEncoding(Encoding);
    }
}