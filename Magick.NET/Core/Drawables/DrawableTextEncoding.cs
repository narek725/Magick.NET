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

using System.Text;

namespace ImageMagick
{
  /// <summary>
  /// Encapsulation of the DrawableTextEncoding object.
  /// </summary>
  public sealed class DrawableTextEncoding : IDrawable
  {
    void IDrawable.Draw(IDrawingWand wand)
    {
      if (wand != null)
        wand.TextEncoding(Encoding);
    }

    /// <summary>
    /// Creates a new DrawableTextEncoding instance.
    /// </summary>
    /// <param name="encoding">Encoding to use.</param>
    public DrawableTextEncoding(Encoding encoding)
    {
      Throw.IfNull(nameof(encoding), encoding);

      Encoding = encoding;
    }

    /// <summary>
    /// The encoding of the text.
    /// </summary>
    public Encoding Encoding
    {
      get;
      set;
    }
  }
}