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
  /// Adds a path element to the current path which closes the current subpath by drawing a straight
  /// line from the current point to the current subpath's most recent starting point (usually, the
  /// most recent moveto point).
  ///</summary>
  public sealed class PathClose : IPath
  {
    void IPath.Draw(IDrawingWand wand)
    {
      if (wand != null)
        wand.PathClose();
    }

    ///<summary>
    /// Initializes a new instance of the PathClose class.
    ///</summary>
    public PathClose()
    {
    }
  }
}