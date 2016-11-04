//=================================================================================================
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

using System.Diagnostics.CodeAnalysis;

namespace ImageMagick
{
  /// <summary>
  /// Sets the pattern used for stroking object outlines. Only local URLs("#identifier") are
  /// supported at this time. These local URLs are normally created by defining a named stroke
  /// pattern with DrawablePushPattern/DrawablePopPattern.
  /// </summary>
  public sealed class DrawableStrokePatternUrl : IDrawable
  {
    void IDrawable.Draw(IDrawingWand wand)
    {
      if (wand != null)
        wand.StrokePatternUrl(Url);
    }

    /// <summary>
    /// Creates a new DrawableStrokePatternUrl instance.
    /// </summary>
    /// <param name="url">Url specifying pattern ID (e.g. "#pattern_id").</param>
    [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings", MessageId = "0#")]
    public DrawableStrokePatternUrl(string url)
    {
      Url = url;
    }

    /// <summary>
    /// Url specifying pattern ID (e.g. "#pattern_id")
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1056:UriPropertiesShouldNotBeStrings")]
    public string Url
    {
      get;
      set;
    }
  }
}