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

namespace ImageMagick
{
    /// <summary>
    /// Contains the possible exif values.
    /// </summary>
    public static partial class ExifValues
    {
        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.FreeOffsets"/> tag.
        /// </summary>
        public static ExifLongArray FreeOffsets => new ExifLongArray(ExifTag.FreeOffsets);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.FreeByteCounts"/> tag.
        /// </summary>
        public static ExifLongArray FreeByteCounts => new ExifLongArray(ExifTag.FreeByteCounts);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.ColorResponseUnit"/> tag.
        /// </summary>
        public static ExifLongArray ColorResponseUnit => new ExifLongArray(ExifTag.ColorResponseUnit);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.TileOffsets"/> tag.
        /// </summary>
        public static ExifLongArray TileOffsets => new ExifLongArray(ExifTag.TileOffsets);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.SMinSampleValue"/> tag.
        /// </summary>
        public static ExifLongArray SMinSampleValue => new ExifLongArray(ExifTag.SMinSampleValue);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.SMaxSampleValue"/> tag.
        /// </summary>
        public static ExifLongArray SMaxSampleValue => new ExifLongArray(ExifTag.SMaxSampleValue);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.JPEGQTables"/> tag.
        /// </summary>
        public static ExifLongArray JPEGQTables => new ExifLongArray(ExifTag.JPEGQTables);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.JPEGDCTables"/> tag.
        /// </summary>
        public static ExifLongArray JPEGDCTables => new ExifLongArray(ExifTag.JPEGDCTables);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.JPEGACTables"/> tag.
        /// </summary>
        public static ExifLongArray JPEGACTables => new ExifLongArray(ExifTag.JPEGACTables);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.StripRowCounts"/> tag.
        /// </summary>
        public static ExifLongArray StripRowCounts => new ExifLongArray(ExifTag.StripRowCounts);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.IntergraphRegisters"/> tag.
        /// </summary>
        public static ExifLongArray IntergraphRegisters => new ExifLongArray(ExifTag.IntergraphRegisters);

        /// <summary>
        /// Gets a new <see cref="ExifLongArray"/> instance for the <see cref="ExifTag.TimeZoneOffset"/> tag.
        /// </summary>
        public static ExifLongArray TimeZoneOffset => new ExifLongArray(ExifTag.TimeZoneOffset);
    }
}