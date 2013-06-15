﻿//=================================================================================================
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
using System.CodeDom.Compiler;
using System.Reflection;

namespace Magick.NET.FileGenerator
{
	//==============================================================================================
	internal sealed class CoordinateGenerator : ConstructorCodeGenerator
	{
		//===========================================================================================
		protected override string ClassName
		{
			get
			{
				return "Coordinate";
			}
		}
		//===========================================================================================
		protected override void WriteCall(IndentedTextWriter writer, MethodBase method, ParameterInfo[] parameters)
		{
			writer.Write("return ");
			writer.Write(method.DeclaringType.Name);
			writer.Write("(");
			WriteParameters(writer, parameters);
			writer.WriteLine(");");
		}
		//===========================================================================================
		protected override void WriteHashtableCall(IndentedTextWriter writer, MethodBase method, ParameterInfo[] parameters)
		{
			writer.Write("return ");
			writer.Write(method.DeclaringType.Name);
			writer.Write("(");
			WriteHashtableParameters(writer, parameters);
			writer.WriteLine(");");
		}
		//===========================================================================================
		public override void WriteIncludes(IndentedTextWriter writer)
		{
			base.WriteIncludes(writer);

			writer.WriteLine(@"#include ""..\..\Drawables\Coordinate.h""");
		}
		//===========================================================================================
	}
	//==============================================================================================
}
