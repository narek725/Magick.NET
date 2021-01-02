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

using ImageMagick;
using ImageMagick.Formats.Tiff;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class TiffWriteDefinesTests
    {
        public class ThePreserveCompressionProperty : TiffWriteDefinesTests
        {
            [Fact]
            public void ShouldSetTheDefineWhenSetToTrue()
            {
                using (var image = new MagickImage(Files.Builtin.Logo))
                {
                    image.Settings.SetDefines(new TiffWriteDefines
                    {
                        PreserveCompression = true,
                    });

                    Assert.Equal("true", image.Settings.GetDefine(MagickFormat.Tiff, "preserve-compression"));
                }
            }

            [Fact]
            public void ShouldNotSetTheDefineWhenSetToFalse()
            {
                using (var image = new MagickImage())
                {
                    image.Settings.SetDefines(new TiffWriteDefines
                    {
                        PreserveCompression = false,
                    });

                    Assert.Null(image.Settings.GetDefine(MagickFormat.Png, "preserve-compression"));
                }
            }
        }
    }
}
