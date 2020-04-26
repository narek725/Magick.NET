// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
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
    /// Extension methods for IPTC tags.
    /// </summary>
    public static class IptcTagExtensions
    {
        /// <summary>
        /// Determines if the given tag can be repeated according to the specification.
        /// </summary>
        /// <param name="tag">The tag to check.</param>
        /// <returns>True, if the tag can occur multiple times.</returns>
        public static bool IsRepeatable(this IptcTag tag)
        {
            switch (tag)
            {
                case IptcTag.RecordVersion:
                case IptcTag.ObjectType:
                case IptcTag.Title:
                case IptcTag.EditStatus:
                case IptcTag.EditorialUpdate:
                case IptcTag.Priority:
                case IptcTag.Category:
                case IptcTag.FixtureIdentifier:
                case IptcTag.ReleaseDate:
                case IptcTag.ReleaseTime:
                case IptcTag.ExpirationDate:
                case IptcTag.ExpirationTime:
                case IptcTag.SpecialInstructions:
                case IptcTag.ActionAdvised:
                case IptcTag.CreatedDate:
                case IptcTag.CreatedTime:
                case IptcTag.DigitalCreationDate:
                case IptcTag.DigitalCreationTime:
                case IptcTag.OriginatingProgram:
                case IptcTag.ProgramVersion:
                case IptcTag.ObjectCycle:
                case IptcTag.City:
                case IptcTag.SubLocation:
                case IptcTag.ProvinceState:
                case IptcTag.CountryCode:
                case IptcTag.Country:
                case IptcTag.OriginalTransmissionReference:
                case IptcTag.Headline:
                case IptcTag.Credit:
                case IptcTag.Source:
                case IptcTag.CopyrightNotice:
                case IptcTag.Caption:
                case IptcTag.ImageType:
                case IptcTag.ImageOrientation:
                    return false;

                default:
                    return true;
            }
        }

        /// <summary>
        /// Determines if the tag is a datetime tag which needs to be formatted as CCYYMMDD.
        /// </summary>
        /// <param name="tag">The tag to check.</param>
        /// <returns>True, if its a datetime tag.</returns>
        public static bool IsDate(this IptcTag tag)
        {
            switch (tag)
            {
                case IptcTag.CreatedDate:
                case IptcTag.DigitalCreationDate:
                case IptcTag.ExpirationDate:
                case IptcTag.ReferenceDate:
                case IptcTag.ReleaseDate:
                    return true;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Determines if the tag is a time tag which need to be formatted as HHMMSS±HHMM.
        /// </summary>
        /// <param name="tag">The tag to check.</param>
        /// <returns>True, if its a time tag.</returns>
        public static bool IsTime(this IptcTag tag)
        {
            switch (tag)
            {
                case IptcTag.CreatedTime:
                case IptcTag.DigitalCreationTime:
                case IptcTag.ExpirationTime:
                case IptcTag.ReleaseTime:
                    return true;

                default:
                    return false;
            }
        }
    }
}
