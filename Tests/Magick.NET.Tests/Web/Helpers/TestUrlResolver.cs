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

using System;
using System.Xml.XPath;
using ImageMagick;
using ImageMagick.Web;

namespace Magick.NET.Tests
{
  [ExcludeFromCodeCoverage]
  public sealed class TestUrlResolver : IUrlResolver
  {
    public static TestUrlResolverResult Result = new TestUrlResolverResult
    {
      FileName = null,
      Format = MagickFormat.Unknown,
      Script = null
    };

    public string FileName
    {
      get;
      private set;
    }

    public MagickFormat Format
    {
      get;
      private set;
    }

    public IXPathNavigable Script
    {
      get;
      private set;
    }

    public bool Resolve(Uri url)
    {
      if (Result == null)
        return false;

      FileName = Result.FileName;
      Format = Result.Format;
      Script = Result.Script;

      return true;
    }
  }
}
