﻿//=================================================================================================
// Copyright 2013-2017 Dirk Lemstra <https://magick.codeplex.com/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   http://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
// express or implied. See the License for the specific language governing permissions and
// limitations under the License.
//=================================================================================================

#if !NETCOREAPP1_1

using System.Drawing;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
  public partial class MagickGeometryTests
  {
    [TestMethod]
    public void Test_Rectangle()
    {
      var rectangle = new Rectangle(1, 2, 3, 4);

      var geometry = new MagickGeometry(rectangle);
      Assert.AreEqual(1, geometry.X);
      Assert.AreEqual(2, geometry.Y);
      Assert.AreEqual(3, geometry.Width);
      Assert.AreEqual(4, geometry.Height);

      Assert.AreEqual(geometry,  (MagickGeometry)rectangle);
    }
  }
}

#endif