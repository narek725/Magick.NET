//=================================================================================================
// Copyright 2013 Dirk Lemstra <http://magick.codeplex.com/>
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
#pragma once

#include "Base\DrawableWrapper.h"
#include "..\Colors\MagickColor.h"

using namespace System::Drawing;

namespace ImageMagick
{
	///=============================================================================================
	///<summary>
	/// Encapsulation of the DrawableStrokeColor object.
	///</summary>
	public ref class DrawableStrokeColor sealed : DrawableWrapper<Magick::DrawableStrokeColor>
	{
		//===========================================================================================
	private:
		//===========================================================================================
		void Initialize(MagickColor^ color);
		//===========================================================================================
	public:
		///==========================================================================================
		///<summary>
		/// Creates a new DrawableStrokeColor instance.
		///</summary>
		///<param name="color">The color to use.</param>
		DrawableStrokeColor(Color color);
		///==========================================================================================
		///<summary>
		/// Creates a new DrawableStrokeColor instance.
		///</summary>
		///<param name="color">The color to use.</param>
		DrawableStrokeColor(MagickColor^ color);
		///==========================================================================================
		///<summary>
		/// The color to use.
		///</summary>
		property MagickColor^ Color
		{
			MagickColor^ get()
			{
				return gcnew MagickColor(Value->color());
			}
			void set(MagickColor^ value)
			{
				Magick::Color* color = value != nullptr ? value->CreateColor() : new Magick::Color();
				Value->color(*color);
				delete color;
			}
		}
		//===========================================================================================
	};
	//==============================================================================================
}