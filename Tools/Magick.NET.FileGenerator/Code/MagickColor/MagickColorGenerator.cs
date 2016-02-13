﻿//=================================================================================================
// Copyright 2013-2016 Dirk Lemstra <https://magick.codeplex.com/>
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
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace Magick.NET.FileGenerator
{
  //==============================================================================================
  internal sealed class MagickColorGenerator : CodeGenerator
  {
    Type _Type = typeof(Color);

    private string GetArguments(Color color)
    {
      return string.Format(CultureInfo.InvariantCulture, "{0}, {1}, {2}, {3}", color.R, color.G, color.B, color.A);
    }

    private string GetComment(Color color)
    {
      return string.Format(CultureInfo.InvariantCulture, "Gets a system-defined color that has an RGBA value of #{0:X2}{1:X2}{2:X2}{3:X2}.", color.R, color.G, color.B, color.A);
    }

    private void WriteColor(PropertyInfo property)
    {
      if (property.PropertyType != _Type)
        return;

      Color color = (Color)property.GetValue(null, null);

      WriteComment(GetComment(color));
      WriteLine("public static MagickColor " + property.Name);
      WriteStartColon();
      WriteLine("get");
      WriteStartColon();
      WriteLine("return MagickColor.FromRgba(" + GetArguments(color) + ");");
      WriteEndColon();
      WriteEndColon();
    }

    private void WriteColors()
    {
      WriteComment("Class that contains the same colors as System.Drawing.Colors.");
      WriteLine("[System.CodeDom.Compiler.GeneratedCode(\"Magick.NET.FileGenerator\", \"\")]");
      WriteLine("public static class MagickColors");
      WriteStartColon();

      var properties = _Type.GetProperties(BindingFlags.Public | BindingFlags.Static);
      foreach (var property in properties)
        WriteColor(property);

      WriteEndColon();
    }

    private void WriteComment(string comment)
    {
      WriteLine("/// <summary>");
      WriteLine("/// " + comment);
      WriteLine("/// </summary>");
    }

    public static void Generate()
    {
      MagickColorGenerator generator = new MagickColorGenerator();
      generator.CreateWriter(Config.RootFolder + @"Magick.NET\Core\Colors\MagickColors.cs");
      generator.WriteStart("ImageMagick");
      generator.WriteColors();
      generator.WriteEnd();
      generator.CloseWriter();
    }
  }
}
