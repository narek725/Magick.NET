// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Diagnostics.CodeAnalysis;

namespace ImageMagick
{
    /// <summary>
    /// Sets the URL to use as a fill pattern for filling objects. Only local URLs("#identifier") are
    /// supported at this time. These local URLs are normally created by defining a named fill pattern
    /// with DrawablePushPattern/DrawablePopPattern.
    /// </summary>
    public sealed class DrawableFillPatternUrl : IDrawable, IDrawingWand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrawableFillPatternUrl"/> class.
        /// </summary>
        /// <param name="url">Url specifying pattern ID (e.g. "#pattern_id").</param>
        [SuppressMessage("Design", "CA1054:Uri parameters should not be strings", Justification = "Uri won't work in all situations.")]
        public DrawableFillPatternUrl(string url)
        {
            Url = url;
        }

        /// <summary>
        /// Gets or sets the url specifying pattern ID (e.g. "#pattern_id").
        /// </summary>
        [SuppressMessage("Design", "CA1056:Uri properties should not be strings", Justification = "Uri won't work in all situations.")]
        public string Url { get; set; }

        /// <summary>
        /// Draws this instance with the drawing wand.
        /// </summary>
        /// <param name="wand">The want to draw on.</param>
        void IDrawingWand.Draw(DrawingWand wand) => wand?.FillPatternUrl(Url);
    }
}