﻿//=================================================================================================
// Copyright 2013-2015 Dirk Lemstra <https://magick.codeplex.com/>
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

using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick
{
	///=============================================================================================
	///<summary>
	/// Class for defines that are used when a png image is read.
	///</summary>
	public sealed class PngReadDefines : DefineCreator, IReadDefines
	{
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the PngReadDefines class.
		///</summary>
		public PngReadDefines()
			: base(MagickFormat.Png)
		{
		}
		///==========================================================================================
		/// <summary>
		/// By default, the PNG decoder and encoder examine any ICC profile that is present, either
		/// from an iCCP chunk in the PNG input or supplied via an option, and if the profile is
		/// recognized to be the sRGB profile, converts it to the sRGB chunk. You can use this option
		/// to prevent this from happening; in such cases the iCCP chunk will be read. (png:preserve-iCCP)
		/// </summary>
		public bool PreserveiCCP
		{
			get;
			set;
		}
		///==========================================================================================
		/// <summary>
		/// By default, the PNG reader will discard a corrupt image. With this option you will be able
		/// to access the corrupt image after an exception has be thrown.
		/// </summary>
		public bool PreserveCorruptImage
		{
			get;
			set;
		}
		///==========================================================================================
		///<summary>
		/// Specifies the profile that should be skipped when the image is read (profile:skip).
		///</summary>
		public ProfileTypes? SkipProfiles
		{
			get;
			set;
		}
		///==========================================================================================
		/// <summary>
		/// The PNG specification requires that any multi-byte integers be stored in network byte
		/// order (MSB-LSB endian). This option allows you to fix any invalid PNG files that have
		/// 16-bit samples stored incorrectly in little-endian order (LSB-MSB). (png:swap-bytes)
		/// </summary>
		public bool SwapBytes
		{
			get;
			set;
		}
		///==========================================================================================
		///<summary>
		/// The defines that should be set as an define on an image
		///</summary>
		public override IEnumerable<IDefine> Defines
		{
			get
			{
				if (PreserveCorruptImage)
					yield return CreateDefine("preserve-corrupt-image", PreserveCorruptImage);

				if (PreserveiCCP)
					yield return CreateDefine("preserve-iCCP", PreserveiCCP);

				if (SkipProfiles.HasValue)
				{
					string value = EnumHelper.ConvertFlags(SkipProfiles.Value);

					if (!string.IsNullOrEmpty(value))
						yield return new MagickDefine(MagickFormat.Unknown, "profile:skip", value);
				}

				if (SwapBytes)
					yield return CreateDefine("swap-bytes", SwapBytes);
			}
		}
		//===========================================================================================
	}
	//==============================================================================================
}