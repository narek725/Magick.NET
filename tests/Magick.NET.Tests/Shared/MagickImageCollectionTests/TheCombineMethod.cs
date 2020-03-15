﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class MagickImageCollectionTests
    {
        [TestClass]
        public class TheCombineMethod
        {
            [TestMethod]
            public void ShouldThrowExceptionWhenCollectionIsEmpty()
            {
                using (IMagickImage rose = new MagickImage(Files.Builtin.Rose))
                {
                    using (IMagickImageCollection collection = new MagickImageCollection())
                    {
                        ExceptionAssert.Throws<InvalidOperationException>(() =>
                        {
                            collection.Combine();
                        });
                    }
                }
            }

            [TestMethod]
            public void ShouldCombineSeparatedImages()
            {
                using (IMagickImage rose = new MagickImage(Files.Builtin.Rose))
                {
                    using (IMagickImageCollection collection = new MagickImageCollection())
                    {
                        collection.AddRange(rose.Separate(Channels.RGB));

                        Assert.AreEqual(3, collection.Count);

                        using (IMagickImage image = collection.Combine())
                        {
                            Assert.AreEqual(rose.TotalColors, image.TotalColors);
                        }
                    }
                }
            }

            [TestMethod]
            public void ShouldCombineCmykImage()
            {
                using (IMagickImage cmyk = new MagickImage(Files.CMYKJPG))
                {
                    using (IMagickImageCollection collection = new MagickImageCollection())
                    {
                        collection.AddRange(cmyk.Separate(Channels.CMYK));

                        Assert.AreEqual(4, collection.Count);

                        using (IMagickImage image = collection.Combine(ColorSpace.CMYK))
                        {
                            Assert.AreEqual(0.0, cmyk.Compare(image, ErrorMetric.RootMeanSquared));
                        }
                    }
                }
            }
        }
    }
}
