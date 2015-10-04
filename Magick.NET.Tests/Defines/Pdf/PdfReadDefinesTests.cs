﻿//=================================================================================================
// Copyright 2013-2015 Dirk Lemstra <https://magick.codeplex.com/>
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

using System;
using System.Collections;
using System.IO;
using System.Linq;
using ImageMagick;
using ImageMagick.Defines;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
  [TestClass]
  public class PdfReadDefinesTests
  {
    private const string _Category = "PdfReadDefinesTests";

    [TestMethod, TestCategory(_Category)]
    public void Test_UseCropBox_UseTrimBox()
    {
      PdfReadDefines defines = new PdfReadDefines()
      {
        UseCropBox = true,
        UseTrimBox = false
      };

      using (MagickImage image = new MagickImage())
      {
        image.SetDefines(defines);

        Assert.AreEqual("True", image.GetDefine(MagickFormat.Pdf, "use-cropbox"));
        Assert.AreEqual("False", image.GetDefine(MagickFormat.Pdf, "use-trimbox"));
      }
    }

    [TestMethod, TestCategory(_Category)]
    public void Test_FitPage()
    {
      Ghostscript.Initialize();

      MagickReadSettings settings = new MagickReadSettings()
      {
        Defines = new PdfReadDefines()
        {
          FitPage = new MagickGeometry(50, 40)
        }
      };

      using (MagickImage image = new MagickImage())
      {
        image.Read(Files.Coders.CartoonNetworkStudiosLogoAI, settings);

        Assert.IsTrue(image.Width <= 50);
        Assert.IsTrue(image.Height <= 40);
      }
    }
  }
}
