﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class UnsafePixelCollectionTests
    {
        public class TheSetIntAreaMethod
        {
            [Fact]
            public void ShouldNotThrowExceptionWhenArrayIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        pixels.SetIntArea(10, 10, 1000, 1000, null);
                    }
                }
            }

            [Fact]
            public void ShouldNotThrowExceptionWhenArrayHasInvalidSize()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        pixels.SetIntArea(10, 10, 1000, 1000, new int[] { 0, 0, 0, 0 });
                    }
                }
            }

            [Fact]
            public void ShouldNotThrowExceptionWhenArrayHasTooManyValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        var values = new int[(113 * 108 * image.ChannelCount) + image.ChannelCount];
                        pixels.SetIntArea(10, 10, 113, 108, values);
                    }
                }
            }

            [Fact]
            public void ShouldChangePixelsWhenArrayHasMaxNumberOfValues()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        var values = new int[113 * 108 * image.ChannelCount];
                        pixels.SetIntArea(10, 10, 113, 108, values);

                        ColorAssert.Equal(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }

            [Fact]
            public void ShouldNotThrowExceptionWhenArrayIsSpecifiedAndGeometryIsNull()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        pixels.SetIntArea(null, new int[] { 0 });
                    }
                }
            }

            [Fact]
            public void ShouldChangePixelsWhenGeometryAndArrayAreSpecified()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixelsUnsafe())
                    {
                        var values = new int[113 * 108 * image.ChannelCount];
                        pixels.SetIntArea(new MagickGeometry(10, 10, 113, 108), values);

                        ColorAssert.Equal(MagickColors.Black, image, image.Width - 1, image.Height - 1);
                    }
                }
            }
        }
    }
}