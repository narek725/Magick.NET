﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class SettingsFactoryTests
    {
        public class TheCreateMagickReadSettingsMethod
        {
            [Fact]
            public void ShouldCreateInstance()
            {
                var factory = new SettingsFactory();

                var settings = factory.CreateMagickReadSettings();

                Assert.NotNull(settings);
                Assert.IsType<MagickReadSettings>(settings);
            }
        }
    }
}
