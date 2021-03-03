﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using ImageMagick;
using ImageMagick.Formats;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class PsdAdditionalInfoTests
    {
        public class TheFromImageMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenImageIsNull()
            {
                Assert.Throws<ArgumentNullException>("image", () => PsdAdditionalInfo.FromImage(null));
            }

            [Fact]
            public void ShouldReturnNullWhenImageHasNoPsdAdditionalInfo()
            {
                using (var image = new MagickImage(Files.SnakewarePNG))
                {
                    var info = PsdAdditionalInfo.FromImage(image);

                    Assert.Null(info);
                }
            }
        }
    }
}
