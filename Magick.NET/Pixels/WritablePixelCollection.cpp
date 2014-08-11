//=================================================================================================
// Copyright 2013-2014 Dirk Lemstra <https://magick.codeplex.com/>
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
#include "Stdafx.h"
#include "WritablePixelCollection.h"
#include "..\Quantum.h"

namespace ImageMagick
{
	//==============================================================================================
	void WritablePixelCollection::SetPixel(int x, int y, array<Magick::Quantum>^ value)
	{
		CheckIndex(x, y);
		Throw::IfFalse("value", value->Length % Channels == 0, "Value should have {0} channels.", Channels);

		int index = GetIndex(x, y);

		Magick::Quantum *p = _Pixels + index;

		long i = 0;
		while (i < value->Length)
		{
			*(p++) = value[i++];
		}
	}
	//==============================================================================================
	template<typename TType>
	void WritablePixelCollection::SetPixels(array<TType>^ values)
	{
		Throw::IfNullOrEmpty("values", values);
		Throw::IfFalse("values", values->Length % Channels == 0, "Values should have {0} channels.", Channels);

		Magick::Quantum *p = _Pixels;

		long i = 0;
		while (i < values->Length)
		{
			*(p++) = Quantum::Convert((TType)values[i++]);
		}
	}
	//==============================================================================================
	const Magick::Quantum* WritablePixelCollection::Pixels::get()
	{
		return _Pixels;
	}
	//==============================================================================================
	WritablePixelCollection::WritablePixelCollection(Magick::Image* image, int x, int y, int width, int height)
		: PixelBaseCollection(image, width, height)
	{
		Throw::IfTrue("width", x + width > (int)image->size().width(), "Invalid X coordinate specified: {0}.", x);
		Throw::IfTrue("height", y + height > (int)image->size().height(), "Invalid Y coordinate specified: {0}.", y);

		try
		{
			_Pixels = View->set(x, y, width, height);
			CheckPixels();
		}
		catch(Magick::Exception& exception)
		{
			MagickException::Throw(exception);
		}
	}
	//==============================================================================================
	void WritablePixelCollection::Set(Pixel^ pixel)
	{
		Throw::IfNull("pixel", pixel);

		SetPixel(pixel->X, pixel->Y, pixel->Value);
	}
	//==============================================================================================
	void WritablePixelCollection::Set(IEnumerable<Pixel^>^ pixels)
	{
		Throw::IfNull("pixels", pixels);

		IEnumerator<Pixel^>^ enumerator = pixels->GetEnumerator();

		while(enumerator->MoveNext())
		{
			Set(enumerator->Current);
		}
	}
	//==============================================================================================
	void WritablePixelCollection::Set(int x, int y, array<Magick::Quantum>^ value)
	{
		Throw::IfNullOrEmpty("value", value);

		SetPixel(x, y, value);
	}
	//==============================================================================================
#if (MAGICKCORE_QUANTUM_DEPTH > 8)
	void WritablePixelCollection::Set(array<Byte>^ values)
	{
		SetPixels(values);
	}
#endif
	//==============================================================================================
	void WritablePixelCollection::Set(array<double>^ values)
	{
		SetPixels(values);
	}
	//==============================================================================================
	void WritablePixelCollection::Set(array<unsigned int>^ values)
	{
		SetPixels(values);
	}
	//==============================================================================================
	void WritablePixelCollection::Set(array<Magick::Quantum>^ values)
	{
		SetPixels(values);
	}
	//==============================================================================================
#if (MAGICKCORE_QUANTUM_DEPTH != 16 || defined(MAGICKCORE_HDRI_SUPPORT))
	void WritablePixelCollection::Set(array<unsigned short>^ values)
	{
		SetPixels(values);
	}
#endif
	//==============================================================================================
	void WritablePixelCollection::Write()
	{
		View->sync();
	}
	//==============================================================================================
}