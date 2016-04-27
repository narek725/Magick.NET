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
  /// Draws a quadratic Bezier curve from the current point to (x, y) using (x1, y1) as the control
  /// point using relative coordinates. At the end of the command, the new current point becomes
  /// the final (x, y) coordinate pair used in the polybezier.
  ///</summary>
  public sealed class PathQuadraticCurveToRel : IPath
  {
    private PointD _ControlPoint;
    private PointD _End;

    void IPath.Draw(IDrawingWand wand)
    {
      if (wand != null)
        wand.PathQuadraticCurveToAbs(_ControlPoint, _End);
    }

    ///<summary>
    /// Initializes a new instance of the PathQuadraticCurveToRel class.
    ///</summary>
    ///<param name="x1">X coordinate of control point</param>
    ///<param name="y1">Y coordinate of control point</param>
    ///<param name="x">X coordinate of final point</param>
    ///<param name="y">Y coordinate of final point</param>
    public PathQuadraticCurveToRel(double x1, double y1, double x, double y)
      : this(new PointD(x1, y1), new PointD(x, y))
    {
    }

    ///<summary>
    /// Initializes a new instance of the PathQuadraticCurveToRel class.
    ///</summary>
    ///<param name="controlPoint">Coordinate of control point</param>
    ///<param name="end">Coordinate of final point</param>
    public PathQuadraticCurveToRel(PointD controlPoint, PointD end)
    {
      _ControlPoint = controlPoint;
      _End = end;
    }
  }
}