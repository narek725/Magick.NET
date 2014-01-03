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
#include "ScriptReadEventArgs.h"

namespace ImageMagick
{
	//==============================================================================================
	ScriptReadEventArgs::ScriptReadEventArgs(String^ id, MagickReadSettings^ settings)
	{
		_Id = id;
		_Settings = settings;
	}
	//==============================================================================================
	String^ ScriptReadEventArgs::Id::get()
	{
		return _Id;
	}
	//==============================================================================================
	MagickReadSettings^ ScriptReadEventArgs::Settings::get()
	{
		return _Settings;
	}
	//==============================================================================================
}