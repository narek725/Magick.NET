﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class SafePixelCollectionTests
    {
        public class TheSetDoublePixelsMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenArrayIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<ArgumentNullException>("values", () =>
                        {
                            pixels.SetDoublePixels(null);
                        });
                    }
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenArrayHasInvalidSize()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<ArgumentException>("values", () =>
                        {
                            pixels.SetDoublePixels(new double[] { 0, 0, 0, 0 });
                        });
                    }
                }
            }

            [Fact]
            public void ShouldThrowExceptionWhenArrayIsTooLong()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        Assert.Throws<ArgumentException>("values", () =>
                        {
                            var values = new double[(image.Width * image.Height * image.ChannelCount) + 1];
                            pixels.SetDoublePixels(values);
                        });
                    }
                }
            }

            [Fact]
            public void ShouldChangePixelsWhenArrayHasMaxNumberOfValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        var values = new double[image.Width * image.Height * image.ChannelCount];
                        pixels.SetDoublePixels(values);

                        ColorAssert.Equal(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }
        }
    }
}