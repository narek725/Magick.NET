﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using ImageMagick.Formats;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class PdfWriteDefinesTests
    {
        public class TheConstructor
        {
            [Fact]
            public void ShouldNotSetAnyDefine()
            {
                using (var image = new MagickImage())
                {
                    image.Settings.SetDefines(new PdfWriteDefines());

                    Assert.Null(image.Settings.GetDefine(MagickFormat.Pdf, "author"));
                    Assert.Null(image.Settings.GetDefine(MagickFormat.Pdf, "producer"));
                    Assert.Null(image.Settings.GetDefine(MagickFormat.Pdf, "title"));
                }
            }
        }
    }
}
