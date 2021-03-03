﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if !NETCORE

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class TheLabelCoder
    {
        [Fact]
        public void ShouldUseTheDensity()
        {
            var readSettings = new MagickReadSettings
            {
                FontPointsize = 14,
                FontFamily = "Calibri",
                StrokeColor = MagickColors.Black,
                BackgroundColor = MagickColors.White,
                Density = new Density(96, 96, DensityUnit.PixelsPerInch),
            };

            using (var image = new MagickImage($"label:Masai Mara", readSettings))
            {
                Assert.Equal(91, image.Width);
                Assert.Equal(21, image.Height);
            }
        }

        [Fact]
        public void ShouldCenterSingleCharacter()
        {
            var readSettings = new MagickReadSettings
            {
                BackgroundColor = MagickColors.Transparent,
                FillColor = MagickColors.Red,
                TextUnderColor = MagickColors.Green,
                TextGravity = Gravity.Center,
                Width = 60,
            };

            using (var image = new MagickImage("label:1", readSettings))
            {
                Assert.Equal(119, image.Height);

                ColorAssert.Equal(MagickColors.Green, image, 40, 60);
                ColorAssert.Equal(MagickColors.Red, image, 38, 60);
                ColorAssert.Equal(MagickColors.Red, image, 34, 21);
                ColorAssert.Equal(MagickColors.Green, image, 34, 95);
            }
        }

        [Fact]
        public void ShouldSupportMultipleLines()
        {
            var readSettings = new MagickReadSettings
            {
                BackgroundColor = MagickColors.Transparent,
                FillColor = MagickColors.Red,
                TextUnderColor = MagickColors.Green,
                TextGravity = Gravity.Center,
                Width = 60,
            };

            using (var image = new MagickImage("label:1\n2", readSettings))
            {
                Assert.Equal(237, image.Height);

                ColorAssert.Equal(MagickColors.Green, image, 42, 158);
                ColorAssert.Equal(MagickColors.Red, image, 44, 158);
                ColorAssert.Equal(MagickColors.Green, image, 34, 137);
                ColorAssert.Equal(MagickColors.Red, image, 34, 212);
            }
        }
    }
}

#endif
