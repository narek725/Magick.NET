﻿// Copyright 2013-2021 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System;
using System.Collections.Generic;
using System.Text;

namespace ImageMagick
{
    /// <summary>
    /// Class that can be used to access an Iptc profile.
    /// </summary>
    public interface IIptcProfile : IImageProfile
    {
        /// <summary>
        /// Gets the values of this iptc profile.
        /// </summary>
        IEnumerable<IIptcValue> Values { get; }

        /// <summary>
        /// Returns the first occurrence of a iptc value with the specified tag.
        /// </summary>
        /// <param name="tag">The tag of the iptc value.</param>
        /// <returns>The value with the specified tag.</returns>
        IIptcValue? GetValue(IptcTag tag);

        /// <summary>
        /// Returns all values with the specified tag.
        /// </summary>
        /// <param name="tag">The tag of the iptc value.</param>
        /// <returns>The values found with the specified tag.</returns>
        IEnumerable<IIptcValue> GetAllValues(IptcTag tag);

        /// <summary>
        /// Removes all values with the specified tag.
        /// </summary>
        /// <param name="tag">The tag of the iptc value to remove.</param>
        /// <returns>True when the value was found and removed.</returns>
        bool RemoveValue(IptcTag tag);

        /// <summary>
        /// Removes values with the specified tag and value.
        /// </summary>
        /// <param name="tag">The tag of the iptc value to remove.</param>
        /// <param name="value">The value of the iptc item to remove.</param>
        /// <returns>True when the value was found and removed.</returns>
        bool RemoveValue(IptcTag tag, string value);

        /// <summary>
        /// Sets the value of the specified tag.
        /// </summary>
        /// <param name="tag">The tag of the iptc value.</param>
        /// <param name="value">The value.</param>
        void SetValue(IptcTag tag, string value);

        /// <summary>
        /// Makes sure the datetime is formatted according to the iptc specification.
        /// <example>
        /// A date will be formatted as CCYYMMDD, e.g. "19890317" for 17 March 1989.
        /// A time value will be formatted as HHMMSS±HHMM, e.g. "090000+0200" for 9 o'clock Berlin time,
        /// two hours ahead of UTC.
        /// </example>
        /// </summary>
        /// <param name="tag">The tag of the iptc value.</param>
        /// <param name="dateTimeOffset">The datetime.</param>
        void SetValue(IptcTag tag, DateTimeOffset dateTimeOffset);
    }
}