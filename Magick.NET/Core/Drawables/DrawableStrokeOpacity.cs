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

namespace ImageMagick
{
  /// <summary>
  /// Specifies the alpha of stroked object outlines.
  /// </summary>
  public sealed class DrawableStrokeOpacity : IDrawable
  {

    void IDrawable.Draw(IDrawingWand wand)
    {
      if (wand != null)
        wand.StrokeOpacity((double)Opacity / 100);
    }

    /// <summary>
    /// Creates a new DrawableStrokeOpacity instance.
    /// </summary>
    /// <param name="opacity">The opacity.</param>
    public DrawableStrokeOpacity(Percentage opacity)
    {
      Opacity = opacity;
    }

    /// <summary>
    /// The opacity.
    /// </summary>
    public Percentage Opacity
    {
      get;
      set;
    }
  }
}