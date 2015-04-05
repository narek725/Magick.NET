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

namespace ImageMagick
{
	///=============================================================================================
	///<summary>
	/// Encapsulation of the ImageMagick ImagePerceptualHash object.
	///</summary>
	public sealed class PerceptualHash
	{
		//===========================================================================================
		private Dictionary<PixelChannel, ChannelPerceptualHash> _Channels;
		//===========================================================================================
		private PerceptualHash()
		{
			_Channels = new Dictionary<PixelChannel, ChannelPerceptualHash>();
		}
		//===========================================================================================
		private static ChannelPerceptualHash CreateChannelHash(Wrapper.ChannelPerceptualHash channelHash)
		{
			return new ChannelPerceptualHash(channelHash.Channel, channelHash.SrgbHuPhash,
				channelHash.HclpHuPhash, channelHash.Hash);
		}
		//===========================================================================================
		internal PerceptualHash(IEnumerable<Wrapper.ChannelPerceptualHash> channelHashes)
			: this()
		{
			Dictionary<PixelChannel, ChannelPerceptualHash> channels = new Dictionary<PixelChannel, ChannelPerceptualHash>();
			foreach (Wrapper.ChannelPerceptualHash channelHash in channelHashes)
			{
				_Channels[channelHash.Channel] = CreateChannelHash(channelHash);
			}
		}
		//===========================================================================================
		internal bool Isvalid
		{
			get
			{
				return _Channels.ContainsKey(PixelChannel.Red) &&
					_Channels.ContainsKey(PixelChannel.Green) &&
					_Channels.ContainsKey(PixelChannel.Blue);
			}
		}
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the PerceptualHash class with the specified hash.
		///</summary>
		public PerceptualHash(string perceptualHash)
			: this()
		{
			Throw.IfNullOrEmpty("perceptualHash", perceptualHash);
			Throw.IfFalse("perceptualHash", perceptualHash.Length == 210, "Invalid hash size.");

			_Channels[PixelChannel.Red] = CreateChannelHash(new Wrapper.ChannelPerceptualHash(perceptualHash.Substring(0, 70)));
			_Channels[PixelChannel.Green] = CreateChannelHash(new Wrapper.ChannelPerceptualHash(perceptualHash.Substring(70, 70)));
			_Channels[PixelChannel.Blue] = CreateChannelHash(new Wrapper.ChannelPerceptualHash(perceptualHash.Substring(140, 70)));
		}
		///==========================================================================================
		///<summary>
		/// Perceptual hash for the specified channel.
		///</summary>
		public ChannelPerceptualHash GetChannel(PixelChannel channel)
		{
			ChannelPerceptualHash perceptualHash;
			_Channels.TryGetValue(channel, out perceptualHash);
			return perceptualHash;
		}
		///==========================================================================================
		///<summary>
		/// Returns the sum squared difference between this hash and the other hash.
		///</summary>
		///<param name="other">The PerceptualHash to get the distance of.</param>
		public double SumSquaredDistance(PerceptualHash other)
		{
			Throw.IfNull("other", other);

			return
				_Channels[PixelChannel.Red].SumSquaredDistance(other._Channels[PixelChannel.Red]) +
				_Channels[PixelChannel.Green].SumSquaredDistance(other._Channels[PixelChannel.Green]) +
				_Channels[PixelChannel.Blue].SumSquaredDistance(other._Channels[PixelChannel.Blue]);
		}
		///==========================================================================================
		///<summary>
		/// Returns a string representation of this hash.
		///</summary>
		public override string ToString()
		{
			return
				_Channels[PixelChannel.Red].ToString() +
				_Channels[PixelChannel.Green].ToString() +
				_Channels[PixelChannel.Blue].ToString();
		}
		//===========================================================================================
	}
	//==============================================================================================
}