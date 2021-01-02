﻿// Copyright 2013-2021 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
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
using Xunit;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace Magick.NET.Tests
{
    public partial class MagickColorTests
    {
        public class TheConstructor
        {
            [Fact]
            public void ShouldThrowExceptionWhenColorIsNull()
            {
                Assert.Throws<ArgumentNullException>("color", () =>
                {
                    new MagickColor((string)null);
                });
            }

            [Fact]
            public void ShouldThrowExceptionWhenColorIsEmpty()
            {
                Assert.Throws<ArgumentException>("color", () =>
                {
                    new MagickColor(string.Empty);
                });
            }

            [Fact]
            public void ShouldThrowExceptionWhenColorDoesNotStartWithHash()
            {
                Assert.Throws<ArgumentException>("color", () =>
                {
                    new MagickColor("FFFFFF");
                });
            }

            [Fact]
            public void ShouldThrowExceptionWhenColorHasInvalidLength()
            {
                Assert.Throws<ArgumentException>("color", () =>
                {
                    new MagickColor("#FFFFF");
                });
            }

            [Fact]
            public void ShouldThrowExceptionWhenColorHasInvalidHexValue()
            {
                Assert.Throws<ArgumentException>("color", () =>
                {
                    new MagickColor("#FGF");
                });

                Assert.Throws<ArgumentException>("color", () =>
                {
                    new MagickColor("#GGFFFF");
                });

                Assert.Throws<ArgumentException>("color", () =>
                {
                    new MagickColor("#FFFG000000000000");
                });
            }

            [Fact]
            public void ShouldInitializeTheInstanceCorrectly()
            {
                TestColor("#FF", Quantum.Max, Quantum.Max, Quantum.Max, false);
                TestColor("#F00", Quantum.Max, 0, 0, false);
                TestColor("#0F00", 0, Quantum.Max, 0, true);
                TestColor("#0000FF", 0, 0, Quantum.Max, false);
                TestColor("#FF00FF00", Quantum.Max, 0, Quantum.Max, true);

                TestColor("#0000FFFF0000", 0, Quantum.Max, 0, false);
                TestColor("#000080000000", 0, (QuantumType)((Quantum.Max / 2.0) + 0.5), 0, false);
                TestColor("#FFFf000000000000", Quantum.Max, 0, 0, true);

                float half = Quantum.Max * 0.5f;
                TestColor("gray(50%) ", half, half, half, false, 1);
                TestColor("rgba(100%, 0%, 0%, 0.0)", Quantum.Max, 0, 0, true);
            }

            private void TestColor(string hexValue, double red, double green, double blue, bool isTransparent)
                => TestColor(hexValue, red, green, blue, isTransparent, 0.01);

            private void TestColor(string hexValue, double red, double green, double blue, bool isTransparent, double delta)
            {
                var color = new MagickColor(hexValue);

                Assert.InRange(color.R, red - delta, red + delta);
                Assert.InRange(color.G, green - delta, green + delta);
                Assert.InRange(color.B, blue - delta, blue + delta);

                if (isTransparent)
                    ColorAssert.Transparent(color.A);
                else
                    ColorAssert.NotTransparent(color.A);
            }
        }
    }
}
