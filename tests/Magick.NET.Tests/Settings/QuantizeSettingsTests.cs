﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public class QuantizeSettingsTests
    {
        [Fact]
        public void Constructor_PropertiesAreSet()
        {
            var settings = new QuantizeSettings();

            Assert.Equal(1, settings.Colors);
            Assert.Equal(ColorSpace.Undefined, settings.ColorSpace);
            Assert.Equal(DitherMethod.Riemersma, settings.DitherMethod);
            Assert.False(settings.MeasureErrors);
            Assert.Equal(0, settings.TreeDepth);
        }
    }
}
