﻿// Copyright 2013-2019 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
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

using System.Globalization;

namespace ImageMagick
{
    /// <summary>
    /// Exif value that contains a <see cref="int"/>.
    /// </summary>
    public sealed class ExifSignedLong : ExifValue<int>
    {
        internal ExifSignedLong(ExifTagValue tag)
            : base(tag)
        {
        }

        /// <summary>
        /// Gets the data type of the exif value.
        /// </summary>
        public override ExifDataType DataType => ExifDataType.SignedLong;

        /// <summary>
        /// Gets a string that represents the current value.
        /// </summary>
        protected override string StringValue => Value.ToString(CultureInfo.InvariantCulture);

        internal static ExifSignedLong Create(ExifTagValue tag, int value) => new ExifSignedLong(tag) { Value = value };
    }
}
