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

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickGeometryTests
    {
        public class TheOperators
        {
            [Fact]
            public void ShouldReturnTheCorrectValueWhenInstanceIsNull()
            {
                var geometry = new MagickGeometry(10, 5);

                Assert.False(geometry == null);
                Assert.True(geometry != null);
                Assert.False(geometry < null);
                Assert.False(geometry <= null);
                Assert.True(geometry > null);
                Assert.True(geometry >= null);
                Assert.False(null == geometry);
                Assert.True(null != geometry);
                Assert.True(null < geometry);
                Assert.True(null <= geometry);
                Assert.False(null > geometry);
                Assert.False(null >= geometry);
            }

            [Fact]
            public void ShouldReturnTheCorrectValueWhenInstanceIsSpecified()
            {
                var first = new MagickGeometry(10, 5);
                var second = new MagickGeometry(5, 5);

                Assert.False(first == second);
                Assert.True(first != second);
                Assert.False(first < second);
                Assert.False(first <= second);
                Assert.True(first > second);
                Assert.True(first >= second);
            }

            [Fact]
            public void ShouldReturnTheCorrectValueWhenInstanceHasSameSize()
            {
                var first = new MagickGeometry(10, 5);
                var second = new MagickGeometry(5, 10);

                Assert.False(first == second);
                Assert.True(first != second);
                Assert.False(first < second);
                Assert.True(first <= second);
                Assert.False(first > second);
                Assert.True(first >= second);
            }

            [Fact]
            public void ShouldReturnTheCorrectValueWhenInstanceAreEqual()
            {
                var first = new MagickGeometry(10, 5);
                var second = new MagickGeometry(10, 5);

                Assert.True(first == second);
                Assert.False(first != second);
                Assert.False(first < second);
                Assert.True(first <= second);
                Assert.False(first > second);
                Assert.True(first >= second);
            }
        }
    }
}
