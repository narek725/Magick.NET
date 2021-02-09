﻿// Copyright 2013-2021 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickImageCollectionTests
    {
        public class TheCoalesceMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenCollectionIsEmpty()
            {
                using (var images = new MagickImageCollection())
                {
                    Assert.Throws<InvalidOperationException>(() =>
                    {
                        images.Coalesce();
                    });
                }
            }

            [Fact]
            public void ShouldMergeTheImages()
            {
                using (var collection = new MagickImageCollection())
                {
                    collection.Read(Files.RoseSparkleGIF);

                    using (var pixels = collection[1].GetPixels())
                    {
                        var color = pixels.GetPixel(53, 3).ToColor();
                        Assert.Equal(0, color.A);
                    }

                    collection.Coalesce();

                    using (var pixels = collection[1].GetPixels())
                    {
                        var color = pixels.GetPixel(53, 3).ToColor();
                        Assert.Equal(Quantum.Max, color.A);
                    }
                }
            }
        }
    }
}
