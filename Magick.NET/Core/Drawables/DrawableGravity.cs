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
  ///<summary>
  /// Encapsulation of the DrawableGravity object.
  ///</summary>
  public sealed class DrawableGravity : IDrawable
  {
    void IDrawable.Draw(IDrawingWand wand)
    {
      if (wand != null)
        wand.Gravity(Gravity);
    }

    ///<summary>
    /// Creates a new DrawableGravity instance.
    ///</summary>
    ///<param name="gravity">The gravity.</param>
    public DrawableGravity(Gravity gravity)
    {
      Gravity = gravity;
    }

    ///<summary>
    /// The gravity.
    ///</summary>
    public Gravity Gravity
    {
      get;
      set;
    }
  }
}