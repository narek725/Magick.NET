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

namespace ImageMagick
{
    /// <content/>
    public abstract partial class ExifTag
    {
        /// <summary>
        /// Gets the JPEGTables exif tag.
        /// </summary>
        public static ExifTag<byte[]> JPEGTables { get; } = new ExifTag<byte[]>(ExifTagValue.JPEGTables);

        /// <summary>
        /// Gets the OECF exif tag.
        /// </summary>
        public static ExifTag<byte[]> OECF { get; } = new ExifTag<byte[]>(ExifTagValue.OECF);

        /// <summary>
        /// Gets the ExifVersion exif tag.
        /// </summary>
        public static ExifTag<byte[]> ExifVersion { get; } = new ExifTag<byte[]>(ExifTagValue.ExifVersion);

        /// <summary>
        /// Gets the ComponentsConfiguration exif tag.
        /// </summary>
        public static ExifTag<byte[]> ComponentsConfiguration { get; } = new ExifTag<byte[]>(ExifTagValue.ComponentsConfiguration);

        /// <summary>
        /// Gets the MakerNote exif tag.
        /// </summary>
        public static ExifTag<byte[]> MakerNote { get; } = new ExifTag<byte[]>(ExifTagValue.MakerNote);

        /// <summary>
        /// Gets the UserComment exif tag.
        /// </summary>
        public static ExifTag<byte[]> UserComment { get; } = new ExifTag<byte[]>(ExifTagValue.UserComment);

        /// <summary>
        /// Gets the FlashpixVersion exif tag.
        /// </summary>
        public static ExifTag<byte[]> FlashpixVersion { get; } = new ExifTag<byte[]>(ExifTagValue.FlashpixVersion);

        /// <summary>
        /// Gets the SpatialFrequencyResponse exif tag.
        /// </summary>
        public static ExifTag<byte[]> SpatialFrequencyResponse { get; } = new ExifTag<byte[]>(ExifTagValue.SpatialFrequencyResponse);

        /// <summary>
        /// Gets the SpatialFrequencyResponse2 exif tag.
        /// </summary>
        public static ExifTag<byte[]> SpatialFrequencyResponse2 { get; } = new ExifTag<byte[]>(ExifTagValue.SpatialFrequencyResponse2);

        /// <summary>
        /// Gets the Noise exif tag.
        /// </summary>
        public static ExifTag<byte[]> Noise { get; } = new ExifTag<byte[]>(ExifTagValue.Noise);

        /// <summary>
        /// Gets the CFAPattern exif tag.
        /// </summary>
        public static ExifTag<byte[]> CFAPattern { get; } = new ExifTag<byte[]>(ExifTagValue.CFAPattern);

        /// <summary>
        /// Gets the DeviceSettingDescription exif tag.
        /// </summary>
        public static ExifTag<byte[]> DeviceSettingDescription { get; } = new ExifTag<byte[]>(ExifTagValue.DeviceSettingDescription);

        /// <summary>
        /// Gets the ImageSourceData exif tag.
        /// </summary>
        public static ExifTag<byte[]> ImageSourceData { get; } = new ExifTag<byte[]>(ExifTagValue.ImageSourceData);

        /// <summary>
        /// Gets the GPSProcessingMethod exif tag.
        /// </summary>
        public static ExifTag<byte[]> GPSProcessingMethod { get; } = new ExifTag<byte[]>(ExifTagValue.GPSProcessingMethod);

        /// <summary>
        /// Gets the GPSAreaInformation exif tag.
        /// </summary>
        public static ExifTag<byte[]> GPSAreaInformation { get; } = new ExifTag<byte[]>(ExifTagValue.GPSAreaInformation);

        /// <summary>
        /// Gets the FileSource exif tag.
        /// </summary>
        public static ExifTag<byte> FileSource { get; } = new ExifTag<byte>(ExifTagValue.FileSource);

        /// <summary>
        /// Gets the ImageDescription exif tag.
        /// </summary>
        public static ExifTag<byte> SceneType { get; } = new ExifTag<byte>(ExifTagValue.SceneType);
    }
}