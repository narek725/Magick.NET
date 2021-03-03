﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.IO;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        public class TheOrientationProperty
        {
            [Fact]
            public void ShouldOverwriteTheExifOrientation()
            {
                using (var image = new MagickImage(Files.FujiFilmFinePixS1ProJPG))
                {
                    var profile = image.GetExifProfile();
                    var exifOrientation = profile.GetValue(ExifTag.Orientation).Value;
                    Assert.Equal((ushort)1, exifOrientation);

                    Assert.Equal(OrientationType.TopLeft, image.Orientation);

                    profile.SetValue(ExifTag.Orientation, (ushort)6); // RightTop
                    image.SetProfile(profile);

                    image.Orientation = OrientationType.LeftBotom;

                    using (var stream = new MemoryStream())
                    {
                        image.Write(stream);

                        stream.Position = 0;
                        using (var output = new MagickImage(stream))
                        {
                            profile = output.GetExifProfile();
                            exifOrientation = profile.GetValue(ExifTag.Orientation).Value;
                            Assert.Equal((ushort)8, exifOrientation);

                            Assert.Equal(OrientationType.LeftBotom, image.Orientation);
                        }
                    }
                }
            }
        }
    }
}
