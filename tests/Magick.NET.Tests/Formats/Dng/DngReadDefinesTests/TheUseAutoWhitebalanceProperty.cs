﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using ImageMagick.Formats;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class DngReadDefinesTests
    {
        public class TheUseAutoWhitebalanceProperty
        {
            [Fact]
            public void ShouldSetTheDefine()
            {
                var defines = new DngReadDefines
                {
                    UseAutoWhitebalance = true,
                };

                using (var image = new MagickImage())
                {
                    image.Settings.SetDefines(defines);

                    Assert.Equal("true", image.Settings.GetDefine(MagickFormat.Dng, "use_auto_wb"));
                }
            }
        }
    }
}
