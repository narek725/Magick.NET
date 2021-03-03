﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickSettingsTests
    {
        public class TheFontFamilyProperty
        {
            [Fact]
            public void ShouldChangeTheFont()
            {
                using (var image = new MagickImage())
                {
                    Assert.Null(image.Settings.FontFamily);
                    Assert.Equal(0, image.Settings.FontPointsize);
                    Assert.Equal(FontStyleType.Undefined, image.Settings.FontStyle);
                    Assert.Equal(FontWeight.Undefined, image.Settings.FontWeight);

                    image.Settings.FontFamily = "Courier New";
                    image.Settings.FontPointsize = 40;
                    image.Settings.FontStyle = FontStyleType.Oblique;
                    image.Settings.FontWeight = FontWeight.ExtraBold;
                    image.Read("label:Test");

                    Assert.Contains(image.Width, new[] { 97, 98 });
                    Assert.Equal(48, image.Height);

                    // Different result on MacOS
                    if (image.Width != 97)
                        ColorAssert.Equal(MagickColors.Black, image, 13, 13);
                }
            }
        }
    }
}
