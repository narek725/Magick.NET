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

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class DrawablesTests
    {
        public class TheFontTypeMetricsMethod
        {
            [Fact]
            public void ShouldReturnTheCorrectTypeMetrics()
            {
                var drawables = new Drawables()
                    .Font("Arial")
                    .FontPointSize(15);

                var typeMetric = drawables.FontTypeMetrics("Magick.NET");

                Assert.NotNull(typeMetric);
                Assert.Equal(14, typeMetric.Ascent);
                Assert.Equal(-4, typeMetric.Descent);
                Assert.Equal(30, typeMetric.MaxHorizontalAdvance);
                Assert.Equal(18, typeMetric.TextHeight);
                Assert.Equal(82, typeMetric.TextWidth);
                Assert.Equal(-2.138671875, typeMetric.UnderlinePosition);
                Assert.Equal(1.0986328125, typeMetric.UnderlineThickness);
            }

            [Fact]
            public void ShouldUseTheFontSize()
            {
                var drawables = new Drawables()
                    .Font("Arial")
                    .FontPointSize(150);

                var typeMetric = drawables.FontTypeMetrics("Magick.NET");

                Assert.NotNull(typeMetric);
                Assert.Equal(136, typeMetric.Ascent);
                Assert.Equal(-32, typeMetric.Descent);
                Assert.Equal(300, typeMetric.MaxHorizontalAdvance);
                Assert.Equal(168, typeMetric.TextHeight);
                Assert.Equal(816, typeMetric.TextWidth);
                Assert.Equal(-21.38671875, typeMetric.UnderlinePosition);
                Assert.Equal(10.986328125, typeMetric.UnderlineThickness);
            }
        }
    }
}
