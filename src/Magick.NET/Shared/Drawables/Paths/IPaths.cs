﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ImageMagick
{
    /// <summary>
    /// Class that can be used to chain path actions.
    /// </summary>
    [SuppressMessage("Naming", "CA1710", Justification = "No need to use Collection suffix.")]
    public partial interface IPaths : IEnumerable<IPath>
    {
        /// <summary>
        /// Converts the specified <see cref="IPaths"/> to a <see cref="Drawables"/> instance.
        /// </summary>
        /// <returns>A new <see cref="Drawables"/> instance.</returns>
        Drawables Drawables();
    }
}
