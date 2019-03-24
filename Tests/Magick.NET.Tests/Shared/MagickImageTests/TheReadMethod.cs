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
using System.Text;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        public partial class TheReadMethod
        {
            [TestClass]
            public class WithByteArray
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenArrayIsNull()
                {
                    ExceptionAssert.ThrowsArgumentNullException("data", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read((byte[])null);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenArrayIsEmpty()
                {
                    ExceptionAssert.ThrowsArgumentException("data", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(new byte[] { });
                        }
                    });
                }

                [TestMethod]
                public void ShouldReadImage()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(File.ReadAllBytes(Files.SnakewarePNG));
                        Assert.AreEqual(286, image.Width);
                        Assert.AreEqual(67, image.Height);
                    }
                }
            }

            [TestClass]
            public class WithByteArrayAndMagickReadSettings
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenArrayIsNull()
                {
                    ExceptionAssert.ThrowsArgumentNullException("data", () =>
                    {
                        var settings = new MagickReadSettings();

                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read((byte[])null, settings);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenArrayIsEmpty()
                {
                    ExceptionAssert.ThrowsArgumentException("data", () =>
                    {
                        var settings = new MagickReadSettings();

                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(new byte[] { }, settings);
                        }
                    });
                }

                [TestMethod]
                public void ShouldNotThrowExceptionWhenSettingsIsNull()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(File.ReadAllBytes(Files.CirclePNG), (MagickReadSettings)null);
                    }
                }

                [TestMethod]
                public void ShouldUseTheCorrectReaderWhenFormatIsSet()
                {
                    var bytes = Encoding.ASCII.GetBytes("%PDF-");
                    var settings = new MagickReadSettings()
                    {
                        Format = MagickFormat.Png,
                    };

                    using (IMagickImage image = new MagickImage())
                    {
                        ExceptionAssert.Throws<MagickCorruptImageErrorException>(() =>
                        {
                            image.Read(bytes, settings);
                        }, "ReadPNGImage");
                    }
                }

                [TestMethod]
                public void ShouldResetTheFormatAfterReadingBytes()
                {
                    var readSettings = new MagickReadSettings()
                    {
                        Format = MagickFormat.Png,
                    };

                    var bytes = File.ReadAllBytes(Files.CirclePNG);

                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(bytes, readSettings);

                        Assert.AreEqual(MagickFormat.Unknown, image.Settings.Format);
                    }
                }
            }

            [TestClass]
            public class WithColor
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenColorIsNull()
                {
                    ExceptionAssert.ThrowsArgumentNullException("color", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read((MagickColor)null, 1, 1);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenWidthIsZero()
                {
                    ExceptionAssert.ThrowsArgumentException("width", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(MagickColors.Red, 0, 1);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenHeightIsZero()
                {
                    ExceptionAssert.ThrowsArgumentException("height", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(MagickColors.Red, 1, 0);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenWidthIsNegative()
                {
                    ExceptionAssert.ThrowsArgumentException("width", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(MagickColors.Red, -1, 1);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenHeightIsNegative()
                {
                    ExceptionAssert.ThrowsArgumentException("height", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(MagickColors.Red, 1, -1);
                        }
                    });
                }

                [TestMethod]
                public void ShouldReadImage()
                {
                    MagickColor red = new MagickColor("red");

                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(red, 20, 30);
                        Assert.AreEqual(20, image.Width);
                        Assert.AreEqual(30, image.Height);
                        ColorAssert.AreEqual(red, image, 10, 10);
                    }
                }

                [TestMethod]
                public void ShouldReadImageFromCmkyColorName()
                {
                    MagickColor red = new MagickColor("cmyk(0%,100%,100%,0)");

                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(red, 20, 30);
                        Assert.AreEqual(20, image.Width);
                        Assert.AreEqual(30, image.Height);
                        Assert.AreEqual(ColorSpace.CMYK, image.ColorSpace);
                        image.Clamp();
                        ColorAssert.AreEqual(red, image, 10, 10);
                    }
                }
            }

            [TestClass]
            public class WithFileInfo
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenFileInfoIsNull()
                {
                    ExceptionAssert.ThrowsArgumentNullException("file", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read((FileInfo)null);
                        }
                    });
                }
            }

            [TestClass]
            public class WithFileInfoAndMagickReadSettings
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenFileInfoIsNull()
                {
                    ExceptionAssert.ThrowsArgumentNullException("file", () =>
                    {
                        var settings = new MagickReadSettings();

                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read((FileInfo)null, settings);
                        }
                    });
                }

                [TestMethod]
                public void ShouldNotThrowExceptionWhenSettingsIsNull()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(new FileInfo(Files.CirclePNG), null);
                    }
                }
            }

            [TestClass]
            public class WithFileName
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenFileNameIsNull()
                {
                    ExceptionAssert.ThrowsArgumentNullException("fileName", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read((string)null);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenFileNameIsEmpty()
                {
                    ExceptionAssert.ThrowsArgumentException("fileName", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(string.Empty);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenFileIsMissing()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        ExceptionAssert.Throws<MagickBlobErrorException>(() =>
                        {
                            image.Read(Files.Missing);
                        }, "error/blob.c/OpenBlob");
                    }
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenFileWithFormatIsMissing()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        ExceptionAssert.Throws<MagickBlobErrorException>(() =>
                        {
                            image.Read("png:" + Files.Missing);
                        }, "error/blob.c/OpenBlob");
                    }
                }

                [TestMethod]
                public void ShouldReadImage()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(Files.SnakewarePNG);
                        Assert.AreEqual(286, image.Width);
                        Assert.AreEqual(67, image.Height);
                        Assert.AreEqual(MagickFormat.Png, image.Format);
                    }
                }

                [TestMethod]
                public void ShouldReadBuiltinImage()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(Files.Builtin.Rose);
                        Assert.AreEqual(70, image.Width);
                        Assert.AreEqual(46, image.Height);
                        Assert.AreEqual(MagickFormat.Pnm, image.Format);
                    }
                }

                [TestMethod]
                public void ShouldReadImageWithNonAsciiFileName()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(Files.RoseSparkleGIF);
                        Assert.AreEqual("RöseSparkle.gif", Path.GetFileName(image.FileName));
                        Assert.AreEqual(70, image.Width);
                        Assert.AreEqual(46, image.Height);
                        Assert.AreEqual(MagickFormat.Gif, image.Format);
                    }
                }

                [TestMethod]
                public void ShouldReadImageWithFormat()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read("png:" + Files.SnakewarePNG);
                        Assert.AreEqual(286, image.Width);
                        Assert.AreEqual(67, image.Height);
                        Assert.AreEqual(MagickFormat.Png, image.Format);
                    }
                }

                [TestMethod]
                public void ShouldReadImageFromXcColorName()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read("xc:red", 50, 50);
                        Assert.AreEqual(50, image.Width);
                        Assert.AreEqual(50, image.Height);
                        ColorAssert.AreEqual(MagickColors.Red, image, 5, 5);
                    }
                }
            }

            [TestClass]
            public class WithFileNameAndMagickReadSettings
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenFileNameIsNull()
                {
                    ExceptionAssert.ThrowsArgumentNullException("fileName", () =>
                    {
                        var settings = new MagickReadSettings();

                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read((string)null, settings);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenFileNameIsEmpty()
                {
                    ExceptionAssert.ThrowsArgumentException("fileName", () =>
                    {
                        var settings = new MagickReadSettings();

                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(string.Empty, settings);
                        }
                    });
                }

                [TestMethod]
                public void ShouldNotThrowExceptionWhenSettingsIsNull()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(Files.CirclePNG, null);
                    }
                }

                [TestMethod]
                public void ShouldResetTheFormatAfterReadingFile()
                {
                    var readSettings = new MagickReadSettings()
                    {
                        Format = MagickFormat.Png,
                    };

                    using (IMagickImage image = new MagickImage())
                    {
                        image.Read(Files.CirclePNG, readSettings);

                        Assert.AreEqual(MagickFormat.Unknown, image.Settings.Format);
                    }
                }
            }

            [TestClass]
            public class WithStream
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenStreamIsNull()
                {
                    ExceptionAssert.ThrowsArgumentNullException("stream", () =>
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read((Stream)null);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenStreamIsEmpty()
                {
                    ExceptionAssert.ThrowsArgumentException("stream", () =>
                    {
                        var settings = new MagickReadSettings();

                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(new MemoryStream());
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenStreamIsNotReadable()
                {
                    ExceptionAssert.ThrowsArgumentException("stream", () =>
                    {
                        using (TestStream testStream = new TestStream(false, true, true))
                        {
                            using (IMagickImage image = new MagickImage())
                            {
                                image.Read(testStream);
                            }
                        }
                    });
                }

                [TestMethod]
                public void ShouldReadImage()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        using (FileStream fs = File.OpenRead(Files.SnakewarePNG))
                        {
                            image.Read(fs);
                            Assert.AreEqual(286, image.Width);
                            Assert.AreEqual(67, image.Height);
                            Assert.AreEqual(MagickFormat.Png, image.Format);
                        }
                    }
                }

                [TestMethod]
                public void ShouldReadImageFromSeekablePartialStream()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        using (FileStream fs = File.OpenRead(Files.ImageMagickJPG))
                        {
                            image.Read(fs);

                            fs.Position = 0;
                            using (PartialStream partialStream = new PartialStream(fs, true))
                            {
                                using (IMagickImage testImage = new MagickImage())
                                {
                                    testImage.Read(partialStream);

                                    Assert.AreEqual(image.Width, testImage.Width);
                                    Assert.AreEqual(image.Height, testImage.Height);
                                    Assert.AreEqual(image.Format, testImage.Format);
                                    Assert.AreEqual(0.0, image.Compare(testImage, ErrorMetric.RootMeanSquared));
                                }
                            }
                        }
                    }
                }

                [TestMethod]
                public void ShouldReadImageFromNonSeekablePartialStream()
                {
                    using (IMagickImage image = new MagickImage())
                    {
                        using (FileStream fs = File.OpenRead(Files.ImageMagickJPG))
                        {
                            image.Read(fs);

                            fs.Position = 0;
                            using (PartialStream partialStream = new PartialStream(fs, false))
                            {
                                using (IMagickImage testImage = new MagickImage())
                                {
                                    testImage.Read(partialStream);

                                    Assert.AreEqual(image.Width, testImage.Width);
                                    Assert.AreEqual(image.Height, testImage.Height);
                                    Assert.AreEqual(image.Format, testImage.Format);
                                    Assert.AreEqual(0.0, image.Compare(testImage, ErrorMetric.RootMeanSquared));
                                }
                            }
                        }
                    }
                }
            }

            [TestClass]
            public class WithStreamAndMagickReadSettings
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenStreamIsNull()
                {
                    ExceptionAssert.ThrowsArgumentNullException("stream", () =>
                    {
                        var settings = new MagickReadSettings();

                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read((Stream)null, settings);
                        }
                    });
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenStreamIsEmpty()
                {
                    ExceptionAssert.ThrowsArgumentException("stream", () =>
                    {
                        var settings = new MagickReadSettings();

                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(new MemoryStream(), settings);
                        }
                    });
                }

                [TestMethod]
                public void ShouldNotThrowExceptionWhenSettingsIsNull()
                {
                    using (var fileStream = File.OpenRead(Files.CirclePNG))
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(fileStream, null);
                        }
                    }
                }

                [TestMethod]
                public void ShouldUseTheCorrectReaderWhenFormatIsSet()
                {
                    var bytes = Encoding.ASCII.GetBytes("%PDF-");
                    var settings = new MagickReadSettings()
                    {
                        Format = MagickFormat.Png,
                    };

                    using (MemoryStream stream = new MemoryStream(bytes))
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            ExceptionAssert.Throws<MagickCorruptImageErrorException>(() =>
                            {
                                image.Read(stream, settings);
                            }, "ReadPNGImage");
                        }
                    }
                }

                [TestMethod]
                public void ShouldResetTheFormatAfterReadingStream()
                {
                    var readSettings = new MagickReadSettings()
                    {
                        Format = MagickFormat.Png,
                    };

                    using (var stream = File.OpenRead(Files.CirclePNG))
                    {
                        using (IMagickImage image = new MagickImage())
                        {
                            image.Read(stream, readSettings);

                            Assert.AreEqual(MagickFormat.Unknown, image.Settings.Format);
                        }
                    }
                }
            }
        }
    }
}
