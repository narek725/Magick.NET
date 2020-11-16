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
using System.IO;
using ImageMagick;
using Xunit;

namespace Magick.NET.Tests
{
    public partial class MagickNETTests
    {
        public class TheSetTempDirectoryMethod
        {
            [Fact]
            public void ShouldThrowExceptionWhenPathIsNull()
            {
                Assert.Throws<ArgumentNullException>("path", () =>
                {
                    MagickNET.SetTempDirectory(null);
                });
            }

            [Fact]
            public void ShouldThrowExceptionWhenPathIsInvalid()
            {
                Assert.Throws<ArgumentException>("path", () =>
                {
                    MagickNET.SetTempDirectory("Invalid");
                });
            }

            [Fact]
            public void ShouldNotThrowExceptionWhenPathIsCorrect()
            {
                var tempDir = Path.GetTempPath();
                MagickNET.SetTempDirectory(tempDir);

                Assert.Equal(tempDir, System.Environment.GetEnvironmentVariable("MAGICK_TEMPORARY_PATH"));
            }
        }
    }
}
