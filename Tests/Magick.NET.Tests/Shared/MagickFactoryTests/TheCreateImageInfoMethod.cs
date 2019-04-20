﻿// Copyright 2013-2019 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
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

using System.IO;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class MagickFactoryTests
    {
        public partial class TheCreateImageInfoMethod
        {
            [TestMethod]
            public void ShouldCreateMagickImageInfo()
            {
                var factory = new MagickFactory();
                IMagickImageInfo info = factory.CreateImageInfo();

                Assert.IsInstanceOfType(info, typeof(MagickImageInfo));
                Assert.AreEqual(0, info.Width);
            }

            [TestClass]
            public class WithByteArray
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenArrayIsNull()
                {
                    var factory = new MagickFactory();

                    ExceptionAssert.ThrowsArgumentNullException("data", () =>
                    {
                        factory.CreateImageInfo((byte[])null);
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenArrayIsEmpty()
                {
                    var factory = new MagickFactory();

                    ExceptionAssert.ThrowsArgumentException("data", () =>
                    {
                        factory.CreateImageInfo(new byte[] { });
                    });
                }

                [TestMethod]
                public void ShouldCreateMagickImage()
                {
                    var factory = new MagickFactory();
                    var data = File.ReadAllBytes(Files.ImageMagickJPG);

                    IMagickImageInfo info = factory.CreateImageInfo(data);

                    Assert.IsInstanceOfType(info, typeof(MagickImageInfo));
                    Assert.AreEqual(123, info.Width);
                }
            }

            [TestClass]
            public class WithFileInfo
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenFileInfoIsNull()
                {
                    var factory = new MagickFactory();

                    ExceptionAssert.ThrowsArgumentNullException("file", () =>
                    {
                        factory.CreateImageInfo((FileInfo)null);
                    });
                }

                [TestMethod]
                public void ShouldCreateMagickImage()
                {
                    var factory = new MagickFactory();
                    var file = new FileInfo(Files.ImageMagickJPG);

                    IMagickImageInfo info = factory.CreateImageInfo(file);

                    Assert.IsInstanceOfType(info, typeof(MagickImageInfo));
                    Assert.AreEqual(123, info.Width);
                }
            }

            [TestClass]
            public class WithFileName
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenFileInfoIsNull()
                {
                    var factory = new MagickFactory();

                    ExceptionAssert.ThrowsArgumentNullException("fileName", () =>
                    {
                        factory.CreateImageInfo((string)null);
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenFileNameIsEmpty()
                {
                    var factory = new MagickFactory();

                    ExceptionAssert.ThrowsArgumentException("fileName", () =>
                    {
                        factory.CreateImageInfo(string.Empty);
                    });
                }

                [TestMethod]
                public void ShouldCreateMagickImage()
                {
                    var factory = new MagickFactory();

                    IMagickImageInfo info = factory.CreateImageInfo(Files.ImageMagickJPG);

                    Assert.IsInstanceOfType(info, typeof(MagickImageInfo));
                    Assert.AreEqual(123, info.Width);
                }
            }

            [TestClass]
            public class WithStream
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenStreamIsNull()
                {
                    var factory = new MagickFactory();

                    ExceptionAssert.ThrowsArgumentNullException("stream", () =>
                    {
                        factory.CreateImageInfo((Stream)null);
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenStreamIsEmpty()
                {
                    var factory = new MagickFactory();

                    ExceptionAssert.ThrowsArgumentException("stream", () =>
                    {
                        factory.CreateImageInfo(new MemoryStream());
                    });
                }

                [TestMethod]
                public void ShouldCreateMagickImage()
                {
                    var factory = new MagickFactory();

                    using (var stream = File.OpenRead(Files.ImageMagickJPG))
                    {
                        IMagickImageInfo info = factory.CreateImageInfo(stream);

                        Assert.IsInstanceOfType(info, typeof(MagickImageInfo));
                        Assert.AreEqual(123, info.Width);
                    }
                }
            }
        }
    }
}
