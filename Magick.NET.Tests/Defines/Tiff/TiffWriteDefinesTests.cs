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

using System;
using System.Collections;
using System.IO;
using System.Linq;
using ImageMagick;
using ImageMagick.Defines;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
	//==============================================================================================
	[TestClass]
	public class TiffWriteDefinesTests
	{
		//===========================================================================================
		private const string _Category = "TiffWriteDefines";
		//===========================================================================================
		private static MagickImage WriteTiff(MagickImage image)
		{
			using (MemoryStream memStream = new MemoryStream())
			{
				image.Format = MagickFormat.Tiff;
				image.Write(memStream);
				memStream.Position = 0;
				return new MagickImage(memStream);
			}
		}
		//===========================================================================================
		[TestMethod, TestCategory(_Category)]
		public void Test_Alpha_Endian()
		{
			TiffWriteDefines defines = new TiffWriteDefines()
			{
				Alpha = TiffAlpha.Associated,
				Endian = Endian.MSB,
			};

			using (MagickImage input = new MagickImage(Files.Logo))
			{
				input.SetDefines(defines);
				input.Alpha(AlphaOption.Set);

				using (MagickImage output = WriteTiff(input))
				{
					Assert.AreEqual("associated", output.GetAttribute("tiff:alpha"));
					Assert.AreEqual("msb", output.GetAttribute("tiff:endian"));
				}
			}
		}
		//===========================================================================================
		[TestMethod, TestCategory(_Category)]
		public void Test_FillOrder_RowsPerStrip()
		{
			TiffWriteDefines defines = new TiffWriteDefines()
			{
				FillOrder = Endian.LSB,
				RowsPerStrip = 42,
				TileGeometry = new MagickGeometry(100, 100)
			};

			using (MagickImage image = new MagickImage(Files.Logo))
			{
				image.SetDefines(defines);

				Assert.AreEqual("LSB", image.GetDefine(MagickFormat.Tiff, "fill-order"));
				Assert.AreEqual("42", image.GetDefine(MagickFormat.Tiff, "rows-per-strip"));
				Assert.AreEqual("100x100", image.GetDefine(MagickFormat.Tiff, "tile-geometry"));
			}
		}
		//===========================================================================================
	}
	//==============================================================================================
}
