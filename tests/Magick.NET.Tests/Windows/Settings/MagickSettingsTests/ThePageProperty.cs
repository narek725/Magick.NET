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

#if WINDOWS_BUILD

using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickSettingsTests
    {
        public class ThePageProperty
        {
            [Fact]
            public void ShouldSetTheCorrectDimensionsWhenReadingImage()
            {
                using (var image = new MagickImage())
                {
                    Assert.Null(image.Settings.Page);

                    image.Settings.Font = "Courier New";
                    image.Settings.Page = new MagickGeometry(50, 50, 100, 100);
                    image.Read("pango:Test");

                    Assert.Equal(136, image.Width);
                    Assert.Equal(117, image.Height);
                }
            }
        }
    }
}

#endif