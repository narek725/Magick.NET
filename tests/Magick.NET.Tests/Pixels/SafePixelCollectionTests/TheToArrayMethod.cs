﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class SafePixelCollectionTests
    {
        public class TheToArrayMethod
        {
            [Fact]
            public void ShouldReturnAllPixels()
            {
                using (var image = new MagickImage(Files.ImageMagickJPG))
                {
                    using (var pixels = image.GetPixels())
                    {
                        var values = pixels.ToArray();
                        int length = image.Width * image.Height * image.ChannelCount;

                        Assert.Equal(length, values.Length);
                    }
                }
            }
        }
    }
}
