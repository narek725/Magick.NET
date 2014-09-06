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
#pragma once

#include "Arguments\MagickGeometry.h"
#include "Arguments\SparseColorArg.h"
#include "Base\MagickWrapper.h"
#include "Colors\MagickColor.h"
#include "Drawables\DrawableAffine.h"
#include "Drawables\Base\Drawable.h"
#include "Enums\AlphaOption.h"
#include "Enums\Channels.h"
#include "Enums\ClassType.h"
#include "Enums\ColorSpace.h"
#include "Enums\ColorType.h"
#include "Enums\CompositeOperator.h"
#include "Enums\CompressionMethod.h"
#include "Enums\DistortMethod.h"
#include "Enums\Endian.h"
#include "Enums\ErrorMetric.h"
#include "Enums\EvaluateOperator.h"
#include "Enums\FillRule.h"
#include "Enums\FilterType.h"
#include "Enums\GifDisposeMethod.h"
#include "Enums\Gravity.h"
#include "Enums\Interlace.h"
#include "Enums\Kernel.h"
#include "Enums\LineCap.h"
#include "Enums\LineJoin.h"
#include "Enums\MagickFormat.h"
#include "Enums\MorphologyMethod.h"
#include "Enums\NoiseType.h"
#include "Enums\OrientationType.h"
#include "Enums\PaintMethod.h"
#include "Enums\PixelIntensityMethod.h"
#include "Enums\PixelInterpolateMethod.h"
#include "Enums\Resolution.h"
#include "Enums\RenderingIntent.h"
#include "Enums\SparseColorMethod.h"
#include "Enums\TextDirection.h"
#include "Enums\VirtualPixelMethod.h"
#include "Events\WarningEventArgs.h"
#include "Exceptions\Base\MagickException.h"
#include "Helpers\EnumHelper.h"
#include "IO\MagickReader.h"
#include "IO\MagickWriter.h"
#include "MagickFormatInfo.h"
#include "Matrices\ColorMatrix.h"
#include "Matrices\ConvolveMatrix.h"
#include "Pixels\PixelCollection.h"
#include "Pixels\WritablePixelCollection.h"
#include "Profiles\ImageProfile.h"
#include "Profiles\8Bim\EightBimProfile.h"
#include "Profiles\Exif\ExifProfile.h"
#include "Profiles\Iptc\IptcProfile.h"
#include "Profiles\Color\ColorProfile.h"
#include "Results\MagickErrorInfo.h"
#include "Results\MagickSearchResult.h"
#include "Results\TypeMetric.h"
#include "Settings\MagickReadSettings.h"
#include "Settings\QuantizeSettings.h"
#include "Statistics\Statistics.h"
#include "Statistics\Moments.h"

using namespace System::Collections::Generic;
using namespace System::Drawing::Imaging;
using namespace System::Text;

#if !(NET20)
using namespace System::Windows::Media::Imaging;
typedef System::Windows::Media::PixelFormat MediaPixelFormat;
typedef System::Windows::Media::PixelFormats MediaPixelFormats;
#endif

namespace ImageMagick
{
	///=============================================================================================
	///<summary>
	/// Encapsulation of the ImageMagick image object.
	///</summary>
	public ref class MagickImage sealed : MagickWrapper<Magick::Image>,
		IEquatable<MagickImage^>, IComparable<MagickImage^>
	{
		//===========================================================================================
	private:
		//===========================================================================================
		static initonly MagickGeometry^ _DefaultFrameGeometry = gcnew MagickGeometry(25, 25, 6, 6);
		MagickWarningException^ _ReadWarning;
		EventHandler<WarningEventArgs^>^ _WarningEvent;
		//===========================================================================================
		template<class TImageProfile>
		TImageProfile^ CreateProfile(String^ name);
		//===========================================================================================
		void FloodFill(int alpha, int x, int y, bool invert);
		//===========================================================================================
		void FloodFill(MagickColor^ color, int x, int y, bool invert);
		//===========================================================================================
		void FloodFill(MagickColor^ color, int x, int y, MagickColor^ borderColor, bool invert);
		//===========================================================================================
		void FloodFill(MagickColor^ color, MagickGeometry^ geometry, bool invert);
		//===========================================================================================
		void FloodFill(MagickColor^ color, MagickGeometry^ geometry, MagickColor^ borderColor, bool invert);
		//===========================================================================================
		void FloodFill(MagickImage^ image, int x, int y, bool invert);
		//===========================================================================================
		void FloodFill(MagickImage^ image, int x, int y, MagickColor^ borderColor, bool invert);
		//===========================================================================================
		void FloodFill(MagickImage^ image, MagickGeometry^ geometry, bool invert);
		//===========================================================================================
		void FloodFill(MagickImage^ image, MagickGeometry^ geometry, MagickColor^ borderColor, bool invert);
		//===========================================================================================
		String^ FormatedFileSize();
		//===========================================================================================
		static MagickFormat GetCoderFormat(MagickFormat format);
		//===========================================================================================
		void HandleException(const Magick::Exception& exception);
		//===========================================================================================
		void HandleException(MagickException^ exception);
		//===========================================================================================
		MagickWarningException^ HandleReadException(MagickException^ exception);
		//===========================================================================================
		static bool IsSupportedImageFormat(ImageFormat^ format);
		//===========================================================================================
		void LevelColors(MagickColor^ blackColor, MagickColor^ whiteColor, bool invert);
		//===========================================================================================
		void LevelColors(MagickColor^ blackColor, MagickColor^ whiteColor, Channels channels, bool invert);
		//===========================================================================================
		void Opaque(MagickColor^ target, MagickColor^ fill, bool invert);
		//===========================================================================================
		void RaiseOrLower(int size, bool raiseFlag);
		//===========================================================================================
		void RandomThreshold(Magick::Quantum low, Magick::Quantum high, bool isPercentage);
		//===========================================================================================
		void RandomThreshold(Magick::Quantum low, Magick::Quantum high, Channels channels, bool isPercentage);
		//===========================================================================================
		void SetFormat(ImageFormat^ format);
		//===========================================================================================
		void SetOption(String^ name, String^ value);
		//===========================================================================================
		template<typename TMagickOption>
		void SetOption(String^ name, TMagickOption commandOption, ssize_t value);
		//===========================================================================================
		void SetProfile(String^ name, Magick::Blob& blob);
		//===========================================================================================
	internal:
		//===========================================================================================
		MagickImage(const Magick::Image& image);
		//===========================================================================================
		void Apply(QuantizeSettings^ settings);
		//===========================================================================================
		const Magick::Image& ReuseValue();
		//===========================================================================================
	public:
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class.
		///</summary>
		MagickImage();
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified byte array.
		///</summary>
		///<param name="data">The byte array to read the image data from.</param>
		///<exception cref="MagickException"/>
		MagickImage(array<Byte>^ data);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified byte array.
		///</summary>
		///<param name="data">The byte array to read the image data from.</param>
		///<param name="readSettings">The settings to use when reading the image.</param>
		///<exception cref="MagickException"/>
		MagickImage(array<Byte>^ data, MagickReadSettings^ readSettings);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified bitmap.
		///</summary>
		///<param name="bitmap">The bitmap to use.</param>
		///<exception cref="MagickException"/>
		MagickImage(Bitmap^ bitmap);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified file.
		///</summary>
		///<param name="file">The file to read the image from.</param>
		///<exception cref="MagickException"/>
		MagickImage(FileInfo^ file);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified file.
		///</summary>
		///<param name="file">The file to read the image from.</param>
		///<param name="readSettings">The settings to use when reading the image.</param>
		///<exception cref="MagickException"/>
		MagickImage(FileInfo^ file, MagickReadSettings^ readSettings);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified width, height
		/// and color.
		///</summary>
		///<param name="color">The color to fill the image with.</param>
		///<param name="width">The width.</param>
		///<param name="height">The height.</param>
		MagickImage(MagickColor^ color, int width, int height);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class by creating a copy of the specified
		/// image.
		///</summary>
		///<param name="image">The image to create a copy of.</param>
		MagickImage(MagickImage^ image);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified filename.
		///</summary>
		///<param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
		///<exception cref="MagickException"/>
		MagickImage(String^ fileName);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified filename
		///</summary>
		///<param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
		///<param name="readSettings">The settings to use when reading the image.</param>
		///<exception cref="MagickException"/>
		MagickImage(String^ fileName, MagickReadSettings^ readSettings);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified stream.
		///</summary>
		///<param name="stream">The stream to read the image data from.</param>
		///<exception cref="MagickException"/>
		MagickImage(Stream^ stream);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified stream.
		///</summary>
		///<param name="stream">The stream to read the image data from.</param>
		///<param name="readSettings">The settings to use when reading the image.</param>
		///<exception cref="MagickException"/>
		MagickImage(Stream^ stream, MagickReadSettings^ readSettings);
		///==========================================================================================
		///<summary>
		/// Join images into a single multi-image file.
		///</summary>
		property bool Adjoin
		{
			bool get();
			void set(bool value);
		}
		///==========================================================================================
		///<summary>
		/// Transparent color.
		///</summary>
		property MagickColor^ AlphaColor
		{
			MagickColor^ get();
			void set(MagickColor^ value);
		}
		///==========================================================================================
		///<summary>
		/// Time in 1/100ths of a second which must expire before splaying the next image in an
		/// animated sequence.
		///</summary>
		property int AnimationDelay
		{
			int get();
			void set(int value);
		}
		///==========================================================================================
		///<summary>
		/// Number of iterations to loop an animation (e.g. Netscape loop extension) for.
		///</summary>
		property int AnimationIterations
		{
			int get();
			void set(int value);
		}
		///==========================================================================================
		///<summary>
		/// Anti-alias Postscript and TrueType fonts (default true).
		///</summary>
		property bool AntiAlias
		{
			bool get();
			void set(bool value);
		}
		///==========================================================================================
		///<summary>
		/// Background color of the image.
		///</summary>
		property MagickColor^ BackgroundColor
		{
			MagickColor^ get();
			void set(MagickColor^ value);
		}
		///==========================================================================================
		///<summary>
		/// Height of the image before transformations.
		///</summary>
		property int BaseHeight
		{
			int get();
		}
		///==========================================================================================
		///<summary>
		/// Width of the image before transformations.
		///</summary>
		property int BaseWidth
		{
			int get();
		}
		///==========================================================================================
		///<summary>
		/// Use black point compensation.
		///</summary>
		property bool BlackPointCompensation
		{
			bool get();
			void set(bool value);
		}
		///==========================================================================================
		///<summary>
		/// Return smallest bounding box enclosing non-border pixels. The current fuzz value is used
		/// when discriminating between pixels.
		///</summary>
		property MagickGeometry^ BoundingBox
		{
			MagickGeometry^ get();
		}
		///==========================================================================================
		///<summary>
		/// Border color of the image.
		///</summary>
		property MagickColor^ BorderColor
		{
			MagickColor^ get();
			void set(MagickColor^ value);
		}
		///==========================================================================================
		///<summary>
		/// Text bounding-box base color.
		///</summary>
		property MagickColor^ BoxColor
		{
			MagickColor^ get();
			void set(MagickColor^ value);
		}
		///==========================================================================================
		///<summary>
		/// Image class (DirectClass or PseudoClass)
		/// NOTE: Setting a DirectClass image to PseudoClass will result in the loss of color information
		/// if the number of colors in the image is greater than the maximum palette size (either 256 (Q8)
		/// or 65536 (Q16).
		///</summary>
		property ClassType ClassType
		{
			ImageMagick::ClassType get();
			void set(ImageMagick::ClassType value);
		}
		///==========================================================================================
		///<summary>
		/// Associate a clip mask with the image. The clip mask must be the same dimensions as the
		/// image. Pass null to unset an existing clip mask.
		///</summary>
		property MagickImage^ ClipMask
		{
			MagickImage^ get();
			void set(MagickImage^ value);
		}
		///==========================================================================================
		///<summary>
		/// Colors within this distance are considered equal.
		///</summary>
		property Percentage ColorFuzz
		{
			Percentage get();
			void set(Percentage value);
		}
		///==========================================================================================
		///<summary>
		/// Colormap size (number of colormap entries).
		///</summary>
		property int ColorMapSize
		{
			int get();
			void set(int value);
		}
		///==========================================================================================
		///<summary>
		/// Color space of the image.
		///</summary>
		property ColorSpace ColorSpace
		{
			ImageMagick::ColorSpace get();
			void set(ImageMagick::ColorSpace value);
		}
		///==========================================================================================
		///<summary>
		/// Color type of the image.
		///</summary>
		property ColorType ColorType
		{
			ImageMagick::ColorType get();
			void set(ImageMagick::ColorType value);
		}
		///==========================================================================================
		///<summary>
		/// Comment text of the image.
		///</summary>
		property String^ Comment
		{
			String^ get();
			void set(String^ value);
		}
		///==========================================================================================
		///<summary>
		/// Composition operator to be used when composition is implicitly used (such as for image flattening).
		///</summary>
		property CompositeOperator Compose
		{
			CompositeOperator get();
			void set(CompositeOperator value);
		}
		///==========================================================================================
		///<summary>
		/// Compression method to use.
		///</summary>
		property CompressionMethod CompressionMethod
		{
			ImageMagick::CompressionMethod get();
			void set(ImageMagick::CompressionMethod value);
		}
		///<summary>
		/// Enable printing of debug messages from ImageMagick when a debugger is attached.
		///</summary>
		property bool Debug
		{
			bool get();
			void set(bool value);
		} 
		///==========================================================================================
		///<summary>
		/// Vertical and horizontal resolution in pixels of the image.
		///</summary>
		property MagickGeometry^ Density
		{
			MagickGeometry^ get();
			void set(MagickGeometry^ value);
		}
		///==========================================================================================
		///<summary>
		/// The depth (bits allocated to red/green/blue components).
		///</summary>
		property int Depth
		{
			int get();
			void set(int value);
		}
		///==========================================================================================
		///<summary>
		/// Endianness (little like Intel or big like SPARC) for image formats which support
		/// endian-specific options.
		///</summary>
		//===========================================================================================
		property Endian Endian
		{
			ImageMagick::Endian get();
			void set(ImageMagick::Endian value);
		}
		///==========================================================================================
		///<summary>
		/// Image file size.
		///</summary>
		property long FileSize
		{
			long get();
		}
		///==========================================================================================
		///<summary>
		/// Original file name of the image (only available if read from disk).
		///</summary>
		property String^ FileName
		{
			String^ get();
		}
		///==========================================================================================
		///<summary>
		/// Color to use when drawing inside an object.
		///</summary>
		property MagickColor^ FillColor
		{
			MagickColor^ get();
			void set(MagickColor^ value);
		}
		///==========================================================================================
		///<summary>
		/// Pattern to use while filling drawn objects.
		///</summary>
		property MagickImage^ FillPattern
		{
			MagickImage^ get();
			void set(MagickImage^ value);
		}
		///==========================================================================================
		///<summary>
		/// Rule to use when filling drawn objects.
		///</summary>
		property FillRule FillRule
		{
			ImageMagick::FillRule get();
			void set(ImageMagick::FillRule value);
		}
		///==========================================================================================
		///<summary>
		/// Filter to use when resizing image.
		///</summary>
		property FilterType FilterType
		{
			ImageMagick::FilterType get();
			void set(ImageMagick::FilterType value);
		}
		///==========================================================================================
		///<summary>
		/// FlashPix viewing parameters.
		///</summary>
		property String^ FlashPixView
		{
			String^ get();
			void set(String^ value);
		}
		///==========================================================================================
		///<summary>
		/// Text rendering font.
		///</summary>
		property String^ Font
		{
			String^ get();
			void set(String^ value);
		}
		///==========================================================================================
		///<summary>
		/// Font point size.
		///</summary>
		property double FontPointsize
		{
			double get();
			void set(double value);
		}
		///==========================================================================================
		///<summary>
		/// The format of the image.
		///</summary>
		property MagickFormat Format
		{
			MagickFormat get();
			void set(MagickFormat value);
		}
		///==========================================================================================
		///<summary>
		/// The information about the format of the image.
		///</summary>
		property MagickFormatInfo^ FormatInfo
		{
			MagickFormatInfo^ get();
		}
		///==========================================================================================
		///<summary>
		/// Gif disposal method.
		///</summary>
		property GifDisposeMethod GifDisposeMethod
		{
			ImageMagick::GifDisposeMethod get();
			void set(ImageMagick::GifDisposeMethod value);
		}
		///==========================================================================================
		///<summary>
		/// Image supports transparency (alpha channel).
		///</summary>
		property bool HasAlpha
		{
			bool get();
			void set(bool value);
		}
		///==========================================================================================
		///<summary>
		/// Height of the image.
		///</summary>
		property int Height
		{
			int get();
		}
		///==========================================================================================
		///<summary>
		/// Type of interlacing to use.
		///</summary>
		property Interlace Interlace
		{
			ImageMagick::Interlace get();
			void set(ImageMagick::Interlace value);
		}
		///==========================================================================================
		///<summary>
		/// Pixel color interpolate method to use.
		///</summary>
		property PixelInterpolateMethod Interpolate
		{
			PixelInterpolateMethod get();
			void set(PixelInterpolateMethod);
		}
		///==========================================================================================
		///<summary>
		/// Transform image to black and white.
		///</summary>
		property bool IsMonochrome
		{
			bool get();
			void set(bool value);
		}
		///==========================================================================================
		///<summary>
		/// The label of the image.
		///</summary>
		property String^ Label
		{
			String^ get();
			void set(String^ value);
		}
		///==========================================================================================
		///<summary>
		/// Associate a mask with the image. The mask must be the same dimensions as the image. Pass
		/// null to unset an existing mask.
		///</summary>
		property MagickImage^ Mask
		{
			MagickImage^ get();
			void set(MagickImage^ value);
		}
		///==========================================================================================
		///<summary>
		/// Photo orientation of the image.
		///</summary>
		property OrientationType Orientation
		{
			OrientationType get();
			void set(OrientationType value);
		}
		///==========================================================================================
		///<summary>
		/// Preferred size and location of an image canvas.
		///</summary>
		property MagickGeometry^ Page
		{
			MagickGeometry^ get();
			void set(MagickGeometry^ value);
		}
		///==========================================================================================
		///<summary>
		/// The names of the profiles.
		///</summary>
		property IEnumerable<String^>^ ProfileNames
		{
			IEnumerable<String^>^ get();
		}
		///==========================================================================================
		///<summary>
		/// JPEG/MIFF/PNG compression level (default 75).
		///</summary>
		property int Quality
		{
			int get();
			void set(int value);
		}
		///==========================================================================================
		///<summary>
		/// Returns the warning that was raised during the read operation.
		///</summary>
		property MagickWarningException^ ReadWarning
		{
			MagickWarningException^ get();
		}
		///==========================================================================================
		///<summary>
		/// The type of rendering intent.
		///</summary>
		property RenderingIntent RenderingIntent
		{
			ImageMagick::RenderingIntent get();
			void set(ImageMagick::RenderingIntent value);
		} 
		///==========================================================================================
		///<summary>
		/// Units of image resolution.
		///</summary>
		property Resolution ResolutionUnits
		{
			Resolution get();
			void set(Resolution value);
		}
		///==========================================================================================
		///<summary>
		/// The X resolution of the image.
		///</summary>
		property double ResolutionX
		{
			double get();
		}
		///==========================================================================================
		///<summary>
		/// The Y resolution of the image.
		///</summary>
		property double ResolutionY
		{
			double get();
		}
		///==========================================================================================
		///<summary>
		/// Enabled/disable stroke anti-aliasing.
		///</summary>
		property bool StrokeAntiAlias
		{
			bool get();
			void set(bool value);
		}
		///==========================================================================================
		///<summary>
		/// Color to use when drawing object outlines.
		///</summary>
		property MagickColor^ StrokeColor
		{
			MagickColor^ get();
			void set(MagickColor^ value);
		}
		///==========================================================================================
		///<summary>
		/// Specify the pattern of dashes and gaps used to stroke paths. This represents a
		/// zero-terminated array of numbers that specify the lengths of alternating dashes and gaps
		/// in pixels. If a zero value is not found it will be added. If an odd number of values is
		/// provided, then the list of values is repeated to yield an even number of values.
		///</summary>
		property array<double>^ StrokeDashArray
		{
			array<double>^ get();
			void set(array<double>^ value);
		}
		///==========================================================================================
		///<summary>
		/// While drawing using a dash pattern, specify distance into the dash pattern to start the
		/// dash (default 0).
		///</summary>
		property double StrokeDashOffset
		{
			double get();
			void set(double value);
		}
		///==========================================================================================
		///<summary>
		/// Specify the shape to be used at the end of open subpaths when they are stroked.
		///</summary>
		property LineCap StrokeLineCap
		{
			LineCap get();
			void set(ImageMagick::LineCap value);
		}
		///==========================================================================================
		///<summary>
		/// Specify the shape to be used at the corners of paths (or other vector shapes) when they
		/// are stroked.
		///</summary>
		property LineJoin StrokeLineJoin
		{
			LineJoin get();
			void set(LineJoin value);
		}
		///==========================================================================================
		///<summary>
		/// Specify miter limit. When two line segments meet at a sharp angle and miter joins have
		/// been specified for 'lineJoin', it is possible for the miter to extend far beyond the thickness
		/// of the line stroking the path. The miterLimit' imposes a limit on the ratio of the miter
		/// length to the 'lineWidth'. The default value is 4.
		///</summary>
		property int StrokeMiterLimit
		{
			int get();
			void set(int value);
		}
		///==========================================================================================
		///<summary>
		/// Pattern image to use while stroking object outlines.
		///</summary>
		property MagickImage^ StrokePattern
		{
			MagickImage^ get();
			void set(MagickImage^ value);
		}
		///==========================================================================================
		///<summary>
		/// Stroke width for drawing lines, circles, ellipses, etc.
		///</summary>
		property double StrokeWidth
		{
			double get();
			void set(double value);
		}
		///==========================================================================================
		///<summary>
		/// Render text right-to-left or left-to-right. 
		///</summary>
		property TextDirection TextDirection
		{
			ImageMagick::TextDirection get();
			void set(ImageMagick::TextDirection value);
		}
		///==========================================================================================
		///<summary>
		/// Annotation text encoding (e.g. "UTF-16").
		///</summary>
		property Encoding^ TextEncoding
		{
			Encoding^ get();
			void set(Encoding^ value);
		}
		///==========================================================================================
		///<summary>
		/// Annotation text gravity.
		///</summary>
		property Gravity TextGravity
		{
			Gravity get();
			void set(Gravity value);
		}
		///==========================================================================================
		///<summary>
		/// Text inter-line spacing.
		///</summary>
		property double TextInterlineSpacing
		{
			double get();
			void set(double value);
		}
		///==========================================================================================
		///<summary>
		/// Text inter-word spacing.
		///</summary>
		property double TextInterwordSpacing
		{
			double get();
			void set(double value);
		}
		///==========================================================================================
		///<summary>
		/// Text inter-character kerning.
		///</summary>
		property double TextKerning
		{
			double get();
			void set(double value);
		}
		///==========================================================================================
		///<summary>
		/// Number of colors in the image.
		///</summary>
		property int TotalColors
		{
			int get();
		}
		///==========================================================================================
		///<summary>
		/// Turn verbose output on/off.
		///</summary>
		///==========================================================================================
		property bool Verbose 
		{
			bool get();
			void set(bool verbose);
		}
		///==========================================================================================
		///<summary>
		/// Virtual pixel method.
		///</summary>
		property VirtualPixelMethod VirtualPixelMethod
		{
			ImageMagick::VirtualPixelMethod get();
			void set(ImageMagick::VirtualPixelMethod value);
		}
		///==========================================================================================
		///<summary>
		/// Width of the image.
		///</summary>
		property int Width
		{
			int get();
		}
		//===========================================================================================
		static bool operator == (MagickImage^ left, MagickImage^ right);
		//===========================================================================================
		static bool operator != (MagickImage^ left, MagickImage^ right);
		//===========================================================================================
		static bool operator > (MagickImage^ left, MagickImage^ right);
		//===========================================================================================
		static bool operator < (MagickImage^ left, MagickImage^ right);
		//===========================================================================================
		static bool operator >= (MagickImage^ left, MagickImage^ right);
		//===========================================================================================
		static bool operator <= (MagickImage^ left, MagickImage^ right);
		//===========================================================================================
		static explicit operator array<Byte>^ (MagickImage^ image);
		///==========================================================================================
		///<summary>
		/// Event that will we raised when a warning is thrown by ImageMagick.
		///</summary>
		event EventHandler<WarningEventArgs^>^ Warning
		{
			void add(EventHandler<WarningEventArgs^>^ handler);
			void remove(EventHandler<WarningEventArgs^>^ handler);
		}
		///==========================================================================================
		///<summary>
		/// Adaptive-blur image with the default blur factor (0x1).
		///</summary>
		///<exception cref="MagickException"/>
		void AdaptiveBlur();
		///==========================================================================================
		///<summary>
		/// Adaptive-blur image with specified blur factor.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<exception cref="MagickException"/>
		void AdaptiveBlur(double radius, double sigma);
		///==========================================================================================
		///<summary>
		/// Resize using mesh interpolation. It works well for small resizes of less than +/- 50%
		/// of the original image size. For larger resizing on images a full filtered and slower resize
		/// function should be used instead.
		///</summary>
		///<param name="width">The new width.</param>
		///<param name="height">The new height.</param>
		///<exception cref="MagickException"/>
		void AdaptiveResize(int width, int height);
		///==========================================================================================
		///<summary>
		/// Resize using mesh interpolation. It works well for small resizes of less than +/- 50%
		/// of the original image size. For larger resizing on images a full filtered and slower resize
		/// function should be used instead.
		///</summary>
		///<param name="geometry">The geometry to use.</param>
		///<exception cref="MagickException"/>
		void AdaptiveResize(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Adaptively sharpens the image by sharpening more intensely near image edges and less
		/// intensely far from edges.
		///</summary>
		///<exception cref="MagickException"/>
		void AdaptiveSharpen();
		///==========================================================================================
		///<summary>
		/// Adaptively sharpens the image by sharpening more intensely near image edges and less
		/// intensely far from edges.
		///</summary>
		///<param name="channels">The channel(s) that should be sharpened.</param>
		///<exception cref="MagickException"/>
		void AdaptiveSharpen(Channels channels);
		///==========================================================================================
		///<summary>
		/// Adaptively sharpens the image by sharpening more intensely near image edges and less
		/// intensely far from edges.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<exception cref="MagickException"/>
		void AdaptiveSharpen(double radius, double sigma);
		///==========================================================================================
		///<summary>
		/// Adaptively sharpens the image by sharpening more intensely near image edges and less
		/// intensely far from edges.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<param name="channels">The channel(s) that should be sharpened.</param>
		void AdaptiveSharpen(double radius, double sigma, Channels channels);
		///==========================================================================================
		///<summary>
		/// Local adaptive threshold image.
		/// http://www.dai.ed.ac.uk/HIPR2/adpthrsh.htm
		///</summary>
		///<param name="width">The width of the pixel neighborhood.</param>
		///<param name="height">The height of the pixel neighborhood.</param>
		///<exception cref="MagickException"/>
		void AdaptiveThreshold(int width, int height);
		///==========================================================================================
		///<summary>
		/// Local adaptive threshold image.
		/// http://www.dai.ed.ac.uk/HIPR2/adpthrsh.htm
		///</summary>
		///<param name="width">The width of the pixel neighborhood.</param>
		///<param name="height">The height of the pixel neighborhood.</param>
		///<param name="offset">Constant to subtract from pixel neighborhood mean.</param>
		///<exception cref="MagickException"/>
		void AdaptiveThreshold(int width, int height, int offset);
		///==========================================================================================
		///<summary>
		/// Add noise to image with the specified noise type.
		///</summary>
		///<param name="noiseType">The type of noise that should be added to the image.</param>
		///<exception cref="MagickException"/>
		void AddNoise(NoiseType noiseType);
		///==========================================================================================
		///<summary>
		/// Add noise to the specified channel of the image with the specified noise type.
		///</summary>
		///<param name="noiseType">The type of noise that should be added to the image.</param>
		///<param name="channels">The channel(s) where the noise should be added.</param>
		///<exception cref="MagickException"/>
		void AddNoise(NoiseType noiseType, Channels channels);
		///==========================================================================================
		///<summary>
		/// Adds the specified profile to the image or overwrites it.
		///</summary>
		///<param name="profile">The profile to add or overwrite.</param>
		///<exception cref="MagickException"/>
		void AddProfile(ImageProfile^ profile);
		///==========================================================================================
		///<summary>
		/// Affine Transform image.
		///</summary>
		///<param name="affineMatrix">The affine matrix to use.</param>
		///<exception cref="MagickException"/>
		void AffineTransform(DrawableAffine^ affineMatrix);
		///==========================================================================================
		///<summary>
		/// Applies the specified alpha option.
		///</summary>
		///<param name="option">The option to use.</param>
		///<exception cref="MagickException"/>
		void Alpha(AlphaOption option);
		///==========================================================================================
		///<summary>
		/// Annotate using specified text, and bounding area.
		///</summary>
		///<param name="text">The text to use.</param>
		///<param name="boundingArea">The bounding area.</param>
		///<exception cref="MagickException"/>
		void Annotate(String^ text, MagickGeometry^ boundingArea);
		///==========================================================================================
		///<summary>
		/// Annotate using specified text, bounding area, and placement gravity.
		///</summary>
		///<param name="text">The text to use.</param>
		///<param name="boundingArea">The bounding area.</param>
		///<param name="gravity">The placement gravity.</param>
		///<exception cref="MagickException"/>
		void Annotate(String^ text, MagickGeometry^ boundingArea, Gravity gravity);
		///==========================================================================================
		///<summary>
		/// Annotate using specified text, bounding area, and placement gravity.
		///</summary>
		///<param name="text">The text to use.</param>
		///<param name="boundingArea">The bounding area.</param>
		///<param name="gravity">The placement gravity.</param>
		///<param name="degrees">The rotation.</param>
		///<exception cref="MagickException"/>
		void Annotate(String^ text, MagickGeometry^ boundingArea, Gravity gravity, double degrees);
		///==========================================================================================
		///<summary>
		/// Annotate with text (bounding area is entire image) and placement gravity.
		///</summary>
		///<param name="text">The text to use.</param>
		///<param name="gravity">The placement gravity.</param>
		///<exception cref="MagickException"/>
		void Annotate(String^ text, Gravity gravity);
		///==========================================================================================
		///<summary>
		/// Extracts the 'mean' from the image and adjust the image to try make set its gamma 
		/// appropriatally.
		///</summary>
		///<exception cref="MagickException"/>
		void AutoGamma();
		///==========================================================================================
		///<summary>
		/// Extracts the 'mean' from the image and adjust the image to try make set its gamma 
		/// appropriatally.
		///</summary>
		///<param name="channels">The channel(s) to set the gamma for.</param>
		///<exception cref="MagickException"/>
		void AutoGamma(Channels channels);
		///==========================================================================================
		///<summary>
		/// Adjusts the levels of a particular image channel by scaling the minimum and maximum values
		/// to the full quantum range.
		///</summary>
		///<exception cref="MagickException"/>
		void AutoLevel();
		///==========================================================================================
		///<summary>
		/// Adjusts the levels of a particular image channel by scaling the minimum and maximum values
		/// to the full quantum range.
		///</summary>
		///<param name="channels">The channel(s) to level.</param>
		///<exception cref="MagickException"/>
		void AutoLevel(Channels channels);
		///==========================================================================================
		///<summary>
		/// Adjusts an image so that its orientation is suitable for viewing.
		///</summary>
		///<exception cref="MagickException"/>
		void AutoOrient();
		///==========================================================================================
		///<summary>
		/// Returns the bit depth (bits allocated to red/green/blue components).
		///</summary>
		///<exception cref="MagickException"/>
		int BitDepth();
		///==========================================================================================
		///<summary>
		/// Returns the bit depth (bits allocated to red/green/blue components) of the specified channel.
		///</summary>
		///<param name="channels">The channel to get the depth for.</param>
		///<exception cref="MagickException"/>
		int BitDepth(Channels channels);
		///==========================================================================================
		///<summary>
		/// Set the bit depth (bits allocated to red/green/blue components) of the specified channel.
		///</summary>
		///<param name="value">The depth.</param>
		///<param name="channels">The channel to set the depth for.</param>
		///<exception cref="MagickException"/>
		void BitDepth(Channels channels, int value);
		///==========================================================================================
		///<summary>
		/// Set the bit depth (bits allocated to red/green/blue components).
		///</summary>
		///<param name="value">The depth.</param>
		///<exception cref="MagickException"/>
		void BitDepth(int value);
		///==========================================================================================
		///<summary>
		/// Forces all pixels below the threshold into black while leaving all pixels at or above
		/// the threshold unchanged.
		///</summary>
		///<param name="threshold">The threshold to use.</param>
		///<exception cref="MagickException"/>
		void BlackThreshold(Percentage threshold);
		///==========================================================================================
		///<summary>
		/// Forces all pixels below the threshold into black while leaving all pixels at or above
		/// the threshold unchanged.
		///</summary>
		///<param name="threshold">The threshold to use.</param>
		///<param name="channels">The channel(s) to make black.</param>
		///<exception cref="MagickException"/>
		void BlackThreshold(Percentage threshold, Channels channels);
		///==========================================================================================
		///<summary>
		/// Simulate a scene at nighttime in the moonlight.
		///</summary>
		///<exception cref="MagickException"/>
		void BlueShift();
		///==========================================================================================
		///<summary>
		/// Simulate a scene at nighttime in the moonlight.
		///</summary>
		///<param name="factor">The factor to use.</param>
		///<exception cref="MagickException"/>
		void BlueShift(double factor);
		///==========================================================================================
		///<summary>
		/// Blur image with the default blur factor (0x1).
		///</summary>
		///<exception cref="MagickException"/>
		void Blur();
		///==========================================================================================
		///<summary>
		/// Blur image the specified channel of the image with the default blur factor (0x1).
		///</summary>
		///<param name="channels">The channel(s) that should be blurred.</param>
		///<exception cref="MagickException"/>
		void Blur(Channels channels);
		///==========================================================================================
		///<summary>
		/// Blur image with specified blur factor.
		///</summary>
		///<param name="radius">The radius of the Gaussian in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<exception cref="MagickException"/>
		void Blur(double radius, double sigma);
		///==========================================================================================
		///<summary>
		/// Blur image with specified blur factor and channel.
		///</summary>
		///<param name="radius">The radius of the Gaussian in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<param name="channels">The channel(s) that should be blurred.</param>
		///<exception cref="MagickException"/>
		void Blur(double radius, double sigma, Channels channels);
		///==========================================================================================
		///<summary>
		/// Border image (add border to image).
		///</summary>
		///<param name="size">The size of the border.</param>
		///<exception cref="MagickException"/>
		void Border(int size);
		///==========================================================================================
		///<summary>
		/// Border image (add border to image).
		///</summary>
		///<param name="width">The width of the border.</param>
		///<param name="height">The height of the border.</param>
		///<exception cref="MagickException"/>
		void Border(int width, int height);
		///==========================================================================================
		///<summary>
		/// Changes the brightness and/or contrast of an image. It converts the brightness and
		/// contrast parameters into slope and intercept and calls a polynomical function to apply
		/// to the image.
		///</summary>
		///<param name="brightness">The brightness.</param>
		///<param name="contrast">The contrast.</param>
		///<exception cref="MagickException"/>
		void BrightnessContrast(Percentage brightness, Percentage contrast);
		///==========================================================================================
		///<summary>
		/// Changes the brightness and/or contrast of an image. It converts the brightness and
		/// contrast parameters into slope and intercept and calls a polynomical function to apply
		/// to the image.
		///</summary>
		///<param name="brightness">The brightness.</param>
		///<param name="contrast">The contrast.</param>
		///<param name="channels">The channel(s) that should be changed.</param>
		///<exception cref="MagickException"/>
		void BrightnessContrast(Percentage brightness, Percentage contrast, Channels channels);
		///==========================================================================================
		///<summary>
		/// Uses a multi-stage algorithm to detect a wide range of edges in images.
		///</summary>
		///<exception cref="MagickException"/>
		void CannyEdge();
		///==========================================================================================
		///<summary>
		/// Uses a multi-stage algorithm to detect a wide range of edges in images.
		///</summary>
		///<param name="radius">The radius of the gaussian smoothing filter.</param>
		///<param name="sigma">The sigma of the gaussian smoothing filter.</param>
		///<param name="lower">Percentage of edge pixels in the lower threshold.</param>
		///<param name="upper">Percentage of edge pixels in the upper threshold.</param>
		///<exception cref="MagickException"/>
		void CannyEdge(double radius, double sigma, Percentage lower, Percentage upper);
		///==========================================================================================
		///<summary>
		/// Applies the color decision list from the specified ASC CDL file.
		///</summary>
		///<param name="fileName">The file to read the ASC CDL information from.</param>
		///<exception cref="MagickException"/>
		void CDL(String^ fileName);
		///==========================================================================================
		///<summary>
		/// Changes the ColorSpace of the image without applying a color profile.
		///</summary>
		void ChangeColorSpace(ImageMagick::ColorSpace value);
		///==========================================================================================
		///<summary>
		/// Charcoal effect image (looks like charcoal sketch).
		///</summary>
		///<exception cref="MagickException"/>
		void Charcoal();
		///==========================================================================================
		///<summary>
		/// Charcoal effect image (looks like charcoal sketch).
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<exception cref="MagickException"/>
		void Charcoal(double radius, double sigma);
		///==========================================================================================
		///<summary>
		/// Chop image (remove vertical and horizontal subregion of image).
		///</summary>
		///<param name="xOffset">The X offset from origin.</param>
		///<param name="width">The width of the part to chop horizontally.</param>
		///<param name="yOffset">The Y offset from origin.</param>
		///<param name="height">The height of the part to chop vertically.</param>
		///<exception cref="MagickException"/>
		void Chop(int xOffset, int width, int yOffset, int height);
		///==========================================================================================
		///<summary>
		/// Chop image (remove vertical or horizontal subregion of image) using the specified geometry.
		///</summary>
		///<param name="geometry">The geometry to use.</param>
		///<exception cref="MagickException"/>
		void Chop(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Chop image (remove horizontal subregion of image).
		///</summary>
		///<param name="offset">The X offset from origin.</param>
		///<param name="width">The width of the part to chop horizontally.</param>
		///<exception cref="MagickException"/>
		void ChopHorizontal(int offset, int width);
		///==========================================================================================
		///<summary>
		/// Chop image (remove horizontal subregion of image).
		///</summary>
		///<param name="offset">The Y offset from origin.</param>
		///<param name="height">The height of the part to chop vertically.</param>
		///<exception cref="MagickException"/>
		void ChopVertical(int offset, int height);
		///==========================================================================================
		///<summary>
		/// Chromaticity blue primary point.
		///</summary>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		void ChromaBluePrimary(double x, double y);
		///==========================================================================================
		///<summary>
		/// Chromaticity green primary point.
		///</summary>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		void ChromaGreenPrimary(double x, double y);
		///==========================================================================================
		///<summary>
		/// Chromaticity red primary point.
		///</summary>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		void ChromaRedPrimary(double x, double y);
		///==========================================================================================
		///<summary>
		/// Chromaticity red primary point.
		///</summary>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		void ChromaWhitePoint(double x, double y);
		///==========================================================================================
		///<summary>
		/// Set each pixel whose value is below zero to zero and any the pixel whose value is above
		/// the quantum range to the quantum range (e.g. 65535) otherwise the pixel value
		/// remains unchanged.
		///</summary>
		///<exception cref="MagickException"/>
		void Clamp();
		///==========================================================================================
		///<summary>
		/// Set each pixel whose value is below zero to zero and any the pixel whose value is above
		/// the quantum range to the quantum range (e.g. 65535) otherwise the pixel value
		/// remains unchanged.
		///</summary>
		///<param name="channels">The channel(s) to clamp.</param>
		///<exception cref="MagickException"/>
		void Clamp(Channels channels);
		///==========================================================================================
		///<summary>
		/// Sets the image clip mask based on any clipping path information if it exists.
		///</summary>
		///<exception cref="MagickException"/>
		void Clip();
		///==========================================================================================
		///<summary>
		/// Sets the image clip mask based on any clipping path information if it exists.
		///</summary>
		///<param name="pathName">Name of clipping path resource. If name is preceded by #, use
		/// clipping path numbered by name.</param>
		///<param name="inside">Specifies if operations take effect inside or outside the clipping
		/// path</param>
		///<exception cref="MagickException"/>
		void Clip(String^ pathName, bool inside);
		///==========================================================================================
		///<summary>
		/// Creates a clone of the current image.
		///</summary>
		MagickImage^ Clone();
		///==========================================================================================
		///<summary>
		/// Apply a color lookup table (CLUT) to the image.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="method">Pixel interpolate method.</param>
		///<exception cref="MagickException"/>
		void Clut(MagickImage^ image, PixelInterpolateMethod method);
		///==========================================================================================
		///<summary>
		/// Apply a color lookup table (CLUT) to the image.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="method">Pixel interpolate method.</param>
		///<param name="channels">The channel(s) to clut.</param>
		///<exception cref="MagickException"/>
		void Clut(MagickImage^ image, PixelInterpolateMethod method, Channels channels);
		///==========================================================================================
		///<summary>
		/// Sets the alpha channel to the specified color.
		///</summary>
		///<param name="color">The color to use.</param>
		///<exception cref="MagickException"/>
		void ColorAlpha(MagickColor^ color);
		///==========================================================================================
		///<summary>
		/// Colorize image with the specified color, using specified percent alpha.
		///</summary>
		///<param name="color">The color to use.</param>
		///<param name="alpha">The alpha percentage.</param>
		///<exception cref="MagickException"/>
		void Colorize(MagickColor^ color, Percentage alpha);
		///==========================================================================================
		///<summary>
		/// Colorize image with the specified color, using specified percent alpha for red, green,
		/// and blue quantums
		///</summary>
		///<param name="color">The color to use.</param>
		///<param name="alphaRed">The alpha percentage for red.</param>
		///<param name="alphaGreen">The alpha percentage for green.</param>
		///<param name="alphaBlue">The alpha percentage for blue.</param>
		///<exception cref="MagickException"/>
		void Colorize(MagickColor^ color, Percentage alphaRed, Percentage alphaGreen,
			Percentage alphaBlue);
		///==========================================================================================
		///<summary>
		// Get color at colormap position index.
		///</summary>
		///<param name="index">The position index.</param>
		///<exception cref="MagickException"/>
		MagickColor^ ColorMap(int index);
		///==========================================================================================
		///<summary>
		// Set color at colormap position index.
		///</summary>
		///<param name="index">The position index.</param>
		///<exception cref="MagickException"/>
		void ColorMap(int index, MagickColor^ color);
		///==========================================================================================
		///<summary>
		/// Apply a color matrix to the image channels.
		///</summary>
		///<param name="matrix">The color matrix to use.</param>
		///<exception cref="MagickException"/>
		void ColorMatrix(ColorMatrix^ matrix);
		///==========================================================================================
		///<summary>
		/// Compare current image with another image and returns error information.
		///</summary>
		///<param name="image">The other image to compare with this image.</param>
		///<exception cref="MagickException"/>
		MagickErrorInfo^ Compare(MagickImage^ image);
		///==========================================================================================
		///<summary>
		/// Returns the distortion based on the specified metric.
		///</summary>
		///<param name="image">The other image to compare with this image.</param>
		///<param name="metric">The metric to use.</param>
		///<exception cref="MagickException"/>
		double Compare(MagickImage^ image, ErrorMetric metric);
		///==========================================================================================
		///<summary>
		/// Returns the distortion based on the specified metric.
		///</summary>
		///<param name="image">The other image to compare with this image.</param>
		///<param name="metric">The metric to use.</param>
		///<param name="channels">The channel(s) to compare.</param>
		///<exception cref="MagickException"/>
		double Compare(MagickImage^ image, ErrorMetric metric, Channels channels);
		///==========================================================================================
		///<summary>
		/// Returns the distortion based on the specified metric.
		///</summary>
		///<param name="image">The other image to compare with this image.</param>
		///<param name="metric">The metric to use.</param>
		///<param name="difference">The image that will contain the difference.</param>
		///<exception cref="MagickException"/>
		double Compare(MagickImage^ image, ErrorMetric metric, MagickImage^ difference);
		///==========================================================================================
		///<summary>
		/// Returns the distortion based on the specified metric.
		///</summary>
		///<param name="image">The other image to compare with this image.</param>
		///<param name="metric">The metric to use.</param>
		///<param name="difference">The image that will contain the difference.</param>
		///<exception cref="MagickException"/>
		double Compare(MagickImage^ image, ErrorMetric metric, MagickImage^ difference, Channels channels);
		///==========================================================================================
		///<summary>
		/// Compares the current instance with another image. Only the size of the image is compared.
		///</summary>
		///<param name="other">The object to compare this image with.</param>
		virtual int CompareTo(MagickImage^ other);
		//==========================================================================================
		///<summary>
		/// Compose an image onto another at specified offset using the 'In' operator.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="x">The X offset from origin.</param>
		///<param name="y">The Y offset from origin.</param>
		///<exception cref="MagickException"/>
		void Composite(MagickImage^ image, int x, int y);
		//==========================================================================================
		///<summary>
		/// Compose an image onto another at specified offset using the specified algorithm.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="x">The X offset from origin.</param>
		///<param name="y">The Y offset from origin.</param>
		///<param name="compose">The algorithm to use.</param>
		///<exception cref="MagickException"/>
		void Composite(MagickImage^ image, int x, int y, CompositeOperator compose);
		//==========================================================================================
		///<summary>
		/// Compose an image onto another at specified offset using the specified algorithm.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="x">The X offset from origin.</param>
		///<param name="y">The Y offset from origin.</param>
		///<param name="compose">The algorithm to use.</param>
		///<param name="args">The arguments for the algorithm (compose:args).</param>
		///<exception cref="MagickException"/>
		void Composite(MagickImage^ image, int x, int y, CompositeOperator compose, String^ args);
		//==========================================================================================
		///<summary>
		/// Compose an image onto another at specified offset using the 'In' operator.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="offset">The offset from origin.</param>
		///<exception cref="MagickException"/>
		void Composite(MagickImage^ image, MagickGeometry^ offset);
		//==========================================================================================
		///<summary>
		/// Compose an image onto another at specified offset using the specified algorithm.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="offset">The offset from origin.</param>
		///<param name="compose">The algorithm to use.</param>
		///<exception cref="MagickException"/>
		void Composite(MagickImage^ image, MagickGeometry^ offset, CompositeOperator compose);
		//==========================================================================================
		///<summary>
		/// Compose an image onto another at specified offset using the specified algorithm.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="offset">The offset from origin.</param>
		///<param name="compose">The algorithm to use.</param>
		///<param name="args">The arguments for the algorithm (compose:args).</param>
		///<exception cref="MagickException"/>
		void Composite(MagickImage^ image, MagickGeometry^ offset, CompositeOperator compose, String^ args);
		//==========================================================================================
		///<summary>
		/// Compose an image onto another at specified offset using the 'In' operator.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="gravity">The placement gravity.</param>
		///<exception cref="MagickException"/>
		void Composite(MagickImage^ image, Gravity gravity);
		//==========================================================================================
		///<summary>
		/// Compose an image onto another at specified offset using the specified algorithm.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="gravity">The placement gravity.</param>
		///<param name="compose">The algorithm to use.</param>
		///<exception cref="MagickException"/>
		void Composite(MagickImage^ image, Gravity gravity, CompositeOperator compose);
		//==========================================================================================
		///<summary>
		/// Compose an image onto another at specified offset using the specified algorithm.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="gravity">The placement gravity.</param>
		///<param name="compose">The algorithm to use.</param>
		///<param name="args">The arguments for the algorithm (compose:args).</param>
		///<exception cref="MagickException"/>
		void Composite(MagickImage^ image, Gravity gravity, CompositeOperator compose, String^ args);
		//==========================================================================================
		///<summary>
		/// Contrast image (enhance intensity differences in image)
		///</summary>
		///<exception cref="MagickException"/>
		void Contrast();
		//==========================================================================================
		///<summary>
		/// Contrast image (enhance intensity differences in image)
		///</summary>
		///<param name="enhance">Use true to enhance the contrast and false to reduce the contrast.</param>
		///<exception cref="MagickException"/>
		void Contrast(bool enhance);
		///==========================================================================================
		///<summary>
		/// A simple image enhancement technique that attempts to improve the contrast in an image by
		/// 'stretching' the range of intensity values it contains to span a desired range of values.
		/// It differs from the more sophisticated histogram equalization in that it can only apply a
		/// linear scaling function to the image pixel values. As a result the 'enhancement' is less harsh.
		///</summary>
		///<param name="blackPoint">The black point.</param>
		///<param name="whitePoint">The white point.</param>
		///<exception cref="MagickException"/>
		void ContrastStretch(Percentage blackPoint, Percentage whitePoint);
		///==========================================================================================
		///<summary>
		/// A simple image enhancement technique that attempts to improve the contrast in an image by
		/// 'stretching' the range of intensity values it contains to span a desired range of values.
		/// It differs from the more sophisticated histogram equalization in that it can only apply a
		/// linear scaling function to the image pixel values. As a result the 'enhancement' is less harsh.
		///</summary>
		///<param name="blackPoint">The black point.</param>
		///<param name="whitePoint">The white point.</param>
		///<param name="channels">The channel(s) to constrast stretch.</param>
		///<exception cref="MagickException"/>
		void ContrastStretch(Percentage blackPoint, Percentage whitePoint, Channels channels);
		//==========================================================================================
		///<summary>
		/// Convolve image. Applies a user-specified convolution to the image.
		///</summary>
		///<exception cref="MagickException"/>
		void Convolve(ConvolveMatrix^ convolveMatrix);
		///==========================================================================================
		///<summary>
		/// Crop image (subregion of original image).
		///</summary>
		///<param name="geometry">The subregion to crop.</param>
		///<exception cref="MagickException"/>
		void Crop(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Crop image (subregion of original image) using CropPosition.Center.
		///</summary>
		///<param name="width">The width of the subregion.</param>
		///<param name="height">The height of the subregion.</param>
		///<exception cref="MagickException"/>
		void Crop(int width, int height);
		///==========================================================================================
		///<summary>
		/// Crop image (subregion of original image).
		///</summary>
		///<param name="width">The width of the subregion.</param>
		///<param name="height">The height of the subregion.</param>
		///<param name="gravity">The position where the cropping should start from.</param>
		///<exception cref="MagickException"/>
		void Crop(int width, int height, Gravity gravity);
		///==========================================================================================
		///<summary>
		/// Creates tiles of the current image in the specified dimension.
		///</summary>
		///<param name="width">The width of the tile.</param>
		///<param name="height">The height of the tile.</param>
		IEnumerable<MagickImage^>^ CropToTiles(int width, int height);
		///==========================================================================================
		///<summary>
		/// Creates tiles of the current image in the specified dimension.
		///</summary>
		///<param name="geometry">The size of the tile.</param>
		IEnumerable<MagickImage^>^ CropToTiles(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Displaces an image's colormap by a given number of positions.
		///</summary>
		///<param name="amount">Displace the colormap this amount.</param>
		///<exception cref="MagickException"/>
		void CycleColormap(int amount);
		///==========================================================================================
		///<summary>
		/// Converts cipher pixels to plain pixels.
		///</summary>
		///<param name="passphrase">The password that was used to encrypt the image.</param>
		///<exception cref="MagickException"/>
		void Decipher(String^ passphrase);
		///==========================================================================================
		///<summary>
		/// Removes skew from the image. Skew is an artifact that occurs in scanned images because of
		/// the camera being misaligned, imperfections in the scanning or surface, or simply because
		/// the paper was not placed completely flat when scanned. The value of threshold ranges
		/// from 0 to QuantumRange.
		///</summary>
		///<param name="threshold">The threshold.</param>
		///<exception cref="MagickException"/>
		void Deskew(Percentage threshold);
		///==========================================================================================
		///<summary>
		/// Despeckle image (reduce speckle noise).
		///</summary>
		///<exception cref="MagickException"/>
		void Despeckle();
		///==========================================================================================
		///<summary>
		/// Determines the color type of the image. This method can be used to automaticly make the
		/// type GrayScale.
		///</summary>
		///<exception cref="MagickException"/>
		void DetermineColorType();
		///==========================================================================================
		///<summary>
		/// Distorts an image using various distortion methods, by mapping color lookups of the source
		/// image to a new destination image of the same size as the source image.
		///</summary>
		///<param name="method">The distortion method to use.</param>
		///<param name="arguments">An array containing the arguments for the distortion.</param>
		///<exception cref="MagickException"/>
		void Distort(DistortMethod method, array<double>^ arguments);
		///==========================================================================================
		///<summary>
		/// Distorts an image using various distortion methods, by mapping color lookups of the source
		/// image to a new destination image usually of the same size as the source image, unless
		/// 'bestfit' is set to true.
		///</summary>
		///<param name="method">The distortion method to use.</param>
		///<param name="arguments">An array containing the arguments for the distortion.</param>
		///<param name="bestfit">Attempt to 'bestfit' the size of the resulting image.</param>
		///<exception cref="MagickException"/>
		void Distort(DistortMethod method, array<double>^ arguments, bool bestfit);
		///==========================================================================================
		///<summary>
		/// Draw on image using one or more drawables.
		///</summary>
		///<param name="drawables">The drawable(s) to draw on the image.</param>
		///<exception cref="MagickException"/>
		void Draw(... array<Drawable^>^ drawables);
		///==========================================================================================
		///<summary>
		/// Draw on image using a collection of drawables.
		///</summary>
		///<param name="drawables">The drawables to draw on the image.</param>
		///<exception cref="MagickException"/>
		void Draw(IEnumerable<Drawable^>^ drawables);
		///==========================================================================================
		///<summary>
		/// Edge image (hilight edges in image).
		///</summary>
		///<param name="radius">The radius of the pixel neighborhood.</param>
		///<exception cref="MagickException"/>
		void Edge(double radius);
		///==========================================================================================
		///<summary>
		/// Emboss image (hilight edges with 3D effect) with default value (0x1).
		///</summary>
		///<exception cref="MagickException"/>
		void Emboss();
		///==========================================================================================
		///<summary>
		/// Emboss image (hilight edges with 3D effect).
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<exception cref="MagickException"/>
		void Emboss(double radius, double sigma);
		///==========================================================================================
		///<summary>
		/// Converts pixels to cipher-pixels.
		///</summary>
		///<exception cref="MagickException"/>
		void Encipher(String^ passphrase);
		///==========================================================================================
		///<summary>
		/// Preferred size of the image when encoding.
		///</summary>
		///<exception cref="MagickException"/>
		MagickGeometry^ EncodingGeometry();
		///==========================================================================================
		///<summary>
		/// Applies a digital filter that improves the quality of a noisy image.
		///</summary>
		///<exception cref="MagickException"/>
		void Enhance();
		///==========================================================================================
		///<summary>
		/// Applies a histogram equalization to the image.
		///</summary>
		///<exception cref="MagickException"/>
		void Equalize();
		///==========================================================================================
		///<summary>
		/// Determines whether the specified object is equal to the current image.
		///</summary>
		///<param name="obj">The object to compare this image with.</param>
		virtual bool Equals(Object^ obj) override;
		///==========================================================================================
		///<summary>
		/// Determines whether the specified image is equal to the current image.
		///</summary>
		///<param name="other">The image to compare this image with.</param>
		virtual bool Equals(MagickImage^ other);
		///==========================================================================================
		///<summary>
		/// Apply an arithmetic or bitwise operator to the image pixel quantums.
		///</summary>
		///<param name="channels">The channel(s) to apply the operator on.</param>
		///<param name="evaluateOperator">The operator.</param>
		///<param name="value">The value.</param>
		///<exception cref="MagickException"/>
		void Evaluate(Channels channels, EvaluateOperator evaluateOperator, double value);
		///==========================================================================================
		///<summary>
		/// Apply an arithmetic or bitwise operator to the image pixel quantums.
		///</summary>
		///<param name="channels">The channel(s) to apply the operator on.</param>
		///<param name="geometry">The geometry to use.</param>
		///<param name="evaluateOperator">The operator.</param>
		///<param name="value">The value.</param>
		///<exception cref="MagickException"/>
		void Evaluate(Channels channels, MagickGeometry^ geometry, EvaluateOperator evaluateOperator, double value);
		///==========================================================================================
		///<summary>
		/// Extend the image as defined by the width and height.
		///</summary>
		///<param name="width">The width to extend the image to.</param>
		///<param name="height">The height to extend the image to.</param>
		///<exception cref="MagickException"/>
		void Extent(int width, int height);
		///==========================================================================================
		///<summary>
		/// Extend the image as defined by the width and height.
		///</summary>
		///<param name="width">The width to extend the image to.</param>
		///<param name="height">The height to extend the image to.</param>
		///<param name="backgroundColor">The background color to use.</param>
		///<exception cref="MagickException"/>
		void Extent(int width, int height, MagickColor^ backgroundColor);
		///==========================================================================================
		///<summary>
		/// Extend the image as defined by the width and height.
		///</summary>
		///<param name="width">The width to extend the image to.</param>
		///<param name="height">The height to extend the image to.</param>
		///<param name="gravity">The placement gravity.</param>
		///<exception cref="MagickException"/>
		void Extent(int width, int height, Gravity gravity);
		///==========================================================================================
		///<summary>
		/// Extend the image as defined by the width and height.
		///</summary>
		///<param name="width">The width to extend the image to.</param>
		///<param name="height">The height to extend the image to.</param>
		///<param name="gravity">The placement gravity.</param>
		///<param name="backgroundColor">The background color to use.</param>
		///<exception cref="MagickException"/>
		void Extent(int width, int height, Gravity gravity, MagickColor^ backgroundColor);
		///==========================================================================================
		///<summary>
		/// Extend the image as defined by the geometry.
		///</summary>
		///<param name="geometry">The geometry to extend the image to.</param>
		///<exception cref="MagickException"/>
		void Extent(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Extend the image as defined by the geometry.
		///</summary>
		///<param name="geometry">The geometry to extend the image to.</param>
		///<param name="backgroundColor">The background color to use.</param>
		///<exception cref="MagickException"/>
		void Extent(MagickGeometry^ geometry, MagickColor^ backgroundColor);
		///==========================================================================================
		///<summary>
		/// Extend the image as defined by the geometry.
		///</summary>
		///<param name="geometry">The geometry to extend the image to.</param>
		///<param name="gravity">The placement gravity.</param>
		///<exception cref="MagickException"/>
		void Extent(MagickGeometry^ geometry, Gravity gravity);
		///==========================================================================================
		///<summary>
		/// Extend the image as defined by the geometry.
		///</summary>
		///<param name="geometry">The geometry to extend the image to.</param>
		///<param name="gravity">The placement gravity.</param>
		///<param name="backgroundColor">The background color to use.</param>
		///<exception cref="MagickException"/>
		void Extent(MagickGeometry^ geometry, Gravity gravity, MagickColor^ backgroundColor);
		///==========================================================================================
		///<summary>
		/// Flip image (reflect each scanline in the vertical direction).
		///</summary>
		///<exception cref="MagickException"/>
		void Flip();
		///==========================================================================================
		///<summary>
		/// Floodfill pixels matching color (within fuzz factor) of target pixel(x,y) with replacement
		/// alpha value using method.
		///</summary>
		///<param name="alpha">The alpha to use.</param>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<exception cref="MagickException"/>
		void FloodFill(int alpha, int x, int y);
		///==========================================================================================
		///<summary>
		/// Flood-fill color across pixels that match the color of the  target pixel and are neighbors
		/// of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="color">The color to use.</param>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<exception cref="MagickException"/>
		void FloodFill(MagickColor^ color, int x, int y);
		///==========================================================================================
		///<summary>
		/// Flood-fill color across pixels that match the color of the  target pixel and are neighbors
		/// of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="color">The color to use.</param>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<param name="borderColor">The color of the border.</param>
		///<exception cref="MagickException"/>
		void FloodFill(MagickColor^ color, int x, int y, MagickColor^ borderColor);
		///==========================================================================================
		///<summary>
		/// Flood-fill color across pixels that match the color of the  target pixel and are neighbors
		/// of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="color">The color to use.</param>
		///<param name="geometry">The position of the pixel.</param>
		///<exception cref="MagickException"/>
		void FloodFill(MagickColor^ color, MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Flood-fill color across pixels that match the color of the target pixel and are neighbors
		/// of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="color">The color to use.</param>
		///<param name="geometry">The position of the pixel.</param>
		///<param name="borderColor">The color of the border.</param>
		///<exception cref="MagickException"/>
		void FloodFill(MagickColor^ color, MagickGeometry^ geometry, MagickColor^ borderColor);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that match the color of the target pixel and are neighbors
		/// of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<exception cref="MagickException"/>
		void FloodFill(MagickImage^ image, int x, int y);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that match the color of the target pixel and are neighbors
		/// of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<param name="borderColor">The color of the border.</param>
		///<exception cref="MagickException"/>
		void FloodFill(MagickImage^ image, int x, int y, MagickColor^ borderColor);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that match the color of the target pixel and are neighbors
		/// of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="geometry">The position of the pixel.</param>
		///<exception cref="MagickException"/>
		void FloodFill(MagickImage^ image, MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that match the color of the target pixel and are neighbors
		/// of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="geometry">The position of the pixel.</param>
		///<param name="borderColor">The color of the border.</param>
		///<exception cref="MagickException"/>
		void FloodFill(MagickImage^ image, MagickGeometry^ geometry, MagickColor^ borderColor);
		///==========================================================================================
		///<summary>
		/// Flop image (reflect each scanline in the horizontal direction).
		///</summary>
		///<exception cref="MagickException"/>
		void Flop();
		///==========================================================================================
		///<summary>
		/// Obtain font metrics for text string given current font, pointsize, and density settings.
		///</summary>
		///<exception cref="MagickException"/>
		TypeMetric^ FontTypeMetrics(String^ text);
		///==========================================================================================
		///<summary>
		/// Obtain font metrics for text string given current font, pointsize, and density settings.
		///</summary>
		///<param name="ignoreNewLines">Specifies if new lines should be ignored.</param>
		///<exception cref="MagickException"/>
		TypeMetric^ FontTypeMetrics(String^ text, bool ignoreNewLines);
		///==========================================================================================
		///<summary>
		/// Formats the specified expression, more info here: http://www.imagemagick.org/script/escape.php.
		///</summary>
		///<exception cref="MagickException"/>
		String^ FormatExpression(String^ expression);
		///==========================================================================================
		///<summary>
		/// Frame image with the default geometry (25x25+6+6).
		///</summary>
		///<exception cref="MagickException"/>
		void Frame();
		///==========================================================================================
		///<summary>
		/// Frame image with the specified geometry.
		///</summary>
		///<param name="geometry">The geometry of the frame.</param>
		///<exception cref="MagickException"/>
		void Frame(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Frame image with the specified with and height.
		///</summary>
		///<param name="width">The width of the frame.</param>
		///<param name="height">The height of the frame.</param>
		///<exception cref="MagickException"/>
		void Frame(int width, int height);
		///==========================================================================================
		///<summary>
		/// Frame image with the specified with, height, innerBevel and outerBevel.
		///</summary>
		///<param name="width">The width of the frame.</param>
		///<param name="height">The height of the frame.</param>
		///<param name="innerBevel">The inner bevel of the frame.</param>
		///<param name="outerBevel">The outer bevel of the frame.</param>
		///<exception cref="MagickException"/>
		void Frame(int width, int height, int innerBevel, int outerBevel);
		///==========================================================================================
		///<summary>
		/// Initializes a new instance of the MagickImage class using the specified base64 string.
		///</summary>
		///<param name="value">The base64 string to load the image from.</param>
		static MagickImage^ FromBase64(String^ value);
		///==========================================================================================
		///<summary>
		/// Applies a mathematical expression to the image.
		///</summary>
		///<param name="expression">The expression to apply.</param>
		///<exception cref="MagickException"/>
		void Fx(String^ expression);
		///==========================================================================================
		///<summary>
		/// Applies a mathematical expression to the image.
		///</summary>
		///<param name="expression">The expression to apply.</param>
		///<param name="channels">The channel(s) to apply the expression to.</param>
		///<exception cref="MagickException"/>
		void Fx(String^ expression, Channels channels);
		///==========================================================================================
		///<summary>
		/// Gamma level of the image.
		///</summary>
		///<exception cref="MagickException"/>
		double Gamma();
		///==========================================================================================
		///<summary>
		/// Gamma correct image.
		///</summary>
		///<param name="value">The image gamma.</param>
		///<exception cref="MagickException"/>
		void Gamma(double value);
		///==========================================================================================
		///<summary>
		/// Gamma correct image.
		///</summary>
		///<param name="gammeRed">The image gamma for the red channel.</param>
		///<param name="gammeGreen">The image gamma for the green channel.</param>
		///<param name="gammeBlue">The image gamma for the blue channel.</param>
		///<exception cref="MagickException"/>
		void Gamma(double gammeRed, double gammeGreen, double gammeBlue);
		///==========================================================================================
		///<summary>
		/// Gaussian blur image.
		///</summary>
		///<param name="width">The number of neighbor pixels to be included in the convolution.</param>
		///<param name="sigma">The standard deviation of the gaussian bell curve.</param>
		///<exception cref="MagickException"/>
		void GaussianBlur(double width, double sigma);
		///==========================================================================================
		///<summary>
		/// Gaussian blur image.
		///</summary>
		///<param name="width">The number of neighbor pixels to be included in the convolution.</param>
		///<param name="sigma">The standard deviation of the gaussian bell curve.</param>
		///<param name="channels">The channel(s) to blur.</param>
		///<exception cref="MagickException"/>
		void GaussianBlur(double width, double sigma, Channels channels);
		///==========================================================================================
		///<summary>
		/// Returns the value of the artifact with the specified name.
		///</summary>
		///<param name="name">The name of the artifact.</param>
		String^ GetArtifact(String^ name);
		///==========================================================================================
		///<summary>
		/// Returns the value of a named image attribute.
		///</summary>
		///<param name="name">The name of the attribute.</param>
		String^ GetAttribute(String^ name);
		///==========================================================================================
		///<summary>
		/// Retrieve the color profile from the image.
		///</summary>
		///<exception cref="MagickException"/>
		ColorProfile^ GetColorProfile();
		///==========================================================================================
		///<summary>
		/// Retrieve the 8bim profile from the image.
		///</summary>
		///<exception cref="MagickException"/>
		EightBimProfile^ Get8BimProfile();
		///==========================================================================================
		///<summary>
		/// Retrieve the exif profile from the image.
		///</summary>
		///<exception cref="MagickException"/>
		ExifProfile^ GetExifProfile();
		///==========================================================================================
		///<summary>
		/// Servers as a hash of this type.
		///</summary>
		virtual int GetHashCode() override;
		///==========================================================================================
		///<summary>
		/// Retrieve the iptc profile from the image.
		///</summary>
		///<exception cref="MagickException"/>
		IptcProfile^ GetIptcProfile();
		///==========================================================================================
		///<summary>
		/// Gets a format-specific option.
		///</summary>
		///<param name="format">The format to get the option for.</param>
		///<param name="name">The name of the option.</param>
		String^ GetOption(MagickFormat format, String^ name);
		///==========================================================================================
		///<summary>
		/// Retrieve a named profile from the image.
		///</summary>
		///<param name="name">The name of the profile (e.g. "ICM", "IPTC", or a generic profile name).</param>
		///<exception cref="MagickException"/>
		ImageProfile^ GetProfile(String^ name);
		///==========================================================================================
		///<summary>
		/// Returns a read-only pixel collection that can be used to access the pixels of this image.
		///</summary>
		///<exception cref="MagickException"/>
		PixelCollection^ GetReadOnlyPixels();
		///==========================================================================================
		///<summary>
		/// Returns a read-only pixel collection that can be used to access the pixels of this image.
		///</summary>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<param name="width">The width of the pixel area.</param>
		///<param name="height">The height of the pixel area.</param>
		///<exception cref="MagickException"/>
		PixelCollection^ GetReadOnlyPixels(int x, int y, int width, int height);
		///==========================================================================================
		///<summary>
		/// Returns a writable pixel collection that can be used to access the pixels of this image.
		///</summary>
		///<exception cref="MagickException"/>
		WritablePixelCollection^ GetWritablePixels();
		///==========================================================================================
		///<summary>
		/// Returns a writable pixel collection that can be used to access the pixels of this image.
		///</summary>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<param name="width">The width of the pixel area.</param>
		///<param name="height">The height of the pixel area.</param>
		///<exception cref="MagickException"/>
		WritablePixelCollection^ GetWritablePixels(int x, int y, int width, int height);
		///==========================================================================================
		///<summary>
		/// Converts the colors in the image to gray.
		///</summary>
		///<param name="method">The pixel intensity method to use.</param>
		///<exception cref="MagickException"/>
		void Grayscale(PixelIntensityMethod method);
		///==========================================================================================
		///<summary>
		/// Apply a color lookup table (Hald CLUT) to the image.
		///</summary>
		///<param name="image">The image to use.</param>
		///<exception cref="MagickException"/>
		void HaldClut(MagickImage^ image);
		///==========================================================================================
		///<summary>
		/// Creates a color color histogram.
		///</summary>
		///<exception cref="MagickException"/>
		Dictionary<MagickColor^, int>^ Histogram();
		///==========================================================================================
		///<summary>
		/// Identifies lines in the image.
		///</summary>
		///<exception cref="MagickException"/>
		void HoughLine();
		///==========================================================================================
		///<summary>
		/// Identifies lines in the image.
		///</summary>
		///<param name="width">Find line pairs as local maxima in this neighborhood.</param>
		///<param name="height">Find line pairs as local maxima in this neighborhood.</param>
		///<param name="threshold">The line count threshold.</param>
		///<exception cref="MagickException"/>
		void HoughLine(int width, int height, int threshold);
		///==========================================================================================
		///<summary>
		/// Implode image (special effect).
		///</summary>
		///<param name="factor">The extent of the implosion.</param>
		///<exception cref="MagickException"/>
		void Implode(double factor);
		///==========================================================================================
		///<summary>
		/// Floodfill pixels not matching color (within fuzz factor) of target pixel(x,y) with
		/// replacement alpha value using method.
		///</summary>
		///<param name="alpha">The alpha to use.</param>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<exception cref="MagickException"/>
		void InverseFloodFill(int alpha, int x, int y);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that do not match the color of the target pixel and are
		/// neighbors of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="color">The color to use.</param>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<exception cref="MagickException"/>
		void InverseFloodFill(MagickColor^ color, int x, int y);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that do not match the color of the target pixel and are
		/// neighbors of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="color">The color to use.</param>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<param name="borderColor">The color of the border.</param>
		///<exception cref="MagickException"/>
		void InverseFloodFill(MagickColor^ color, int x, int y, MagickColor^ borderColor);
		///==========================================================================================
		///<summary>
		/// Flood-fill color across pixels that match the color of the  target pixel and are neighbors
		/// of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="color">The color to use.</param>
		///<param name="geometry">The position of the pixel.</param>
		///<exception cref="MagickException"/>
		void InverseFloodFill(MagickColor^ color, MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that do not match the color of the target pixel and are
		/// neighbors of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="color">The color to use.</param>
		///<param name="geometry">The position of the pixel.</param>
		///<param name="borderColor">The color of the border.</param>
		///<exception cref="MagickException"/>
		void InverseFloodFill(MagickColor^ color, MagickGeometry^ geometry, MagickColor^ borderColor);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that do not match the color of the target pixel and are
		/// neighbors of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<exception cref="MagickException"/>
		void InverseFloodFill(MagickImage^ image, int x, int y);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that match the color of the target pixel and are neighbors
		/// of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<param name="borderColor">The color of the border.</param>
		///<exception cref="MagickException"/>
		void InverseFloodFill(MagickImage^ image, int x, int y, MagickColor^ borderColor);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that do not match the color of the target pixel and are
		/// neighbors of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="geometry">The position of the pixel.</param>
		///<exception cref="MagickException"/>
		void InverseFloodFill(MagickImage^ image, MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Flood-fill texture across pixels that do not match the color of the target pixel and are
		/// neighbors of the target pixel. Uses current fuzz setting when determining color match.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="geometry">The position of the pixel.</param>
		///<param name="borderColor">The color of the border.</param>
		///<exception cref="MagickException"/>
		void InverseFloodFill(MagickImage^ image, MagickGeometry^ geometry, MagickColor^ borderColor);
		///==========================================================================================
		///<summary>
		/// Implements the inverse discrete Fourier transform (DFT) of the image as a magnitude phase.
		///</summary>
		///<param name="image">The image to use.</param>
		///<exception cref="MagickException"/>
		void InverseFourierTransform(MagickImage^ image);
		///==========================================================================================
		///<summary>
		/// Implements the inverse discrete Fourier transform (DFT) of the image either as a magnitude
		/// phase or real / imaginary image pair.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="magnitude">Magnitude phase or real / imaginary image pair.</param>
		///<exception cref="MagickException"/>
		void InverseFourierTransform(MagickImage^ image, bool magnitude);
		///==========================================================================================
		///<summary>
		/// Maps the given color to "black" and "white" values, linearly spreading out the colors, and
		/// level values on a channel by channel bases, as per level(). The given colors allows you to
		/// specify different level ranges for each of the color channels separately.
		///</summary>
		///<param name="blackColor">The color to map black to/from</param>
		///<param name="whiteColor">The color to map white to/from</param>
		///<exception cref="MagickException"/>
		void InverseLevelColors(MagickColor^ blackColor, MagickColor^ whiteColor);
		///==========================================================================================
		///<summary>
		/// Maps the given color to "black" and "white" values, linearly spreading out the colors, and
		/// level values on a channel by channel bases, as per level(). The given colors allows you to
		/// specify different level ranges for each of the color channels separately.
		///</summary>
		///<param name="blackColor">The color to map black to/from</param>
		///<param name="whiteColor">The color to map white to/from</param>
		///<param name="channels">The channel(s) to level.</param>
		///<exception cref="MagickException"/>
		void InverseLevelColors(MagickColor^ blackColor, MagickColor^ whiteColor, Channels channels);
		///==========================================================================================
		///<summary>
		/// Changes any pixel that does not match the target with the color defined by fill.
		///</summary>
		///<param name="target">The color to replace.</param>
		///<param name="fill">The color to replace opaque color with.</param>
		///<exception cref="MagickException"/>
		void InverseOpaque(MagickColor^ target, MagickColor^ fill);
		///==========================================================================================
		///<summary>
		/// Adjust the levels of the image by scaling the colors falling between specified white and
		/// black points to the full available quantum range. Uses a midpoint of 1.0.
		///</summary>
		///<param name="blackPoint">The darkest color in the image. Colors darker are set to zero.</param>
		///<param name="whitePoint">The lightest color in the image. Colors brighter are set to the maximum quantum value.</param>
		///<exception cref="MagickException"/>
		QUANTUM_CLS_COMPLIANT void Level(Magick::Quantum blackPoint, Magick::Quantum whitePoint);
		///==========================================================================================
		///<summary>
		/// Adjust the levels of the image by scaling the colors falling between specified white and
		/// black points to the full available quantum range. Uses a midpoint of 1.0.
		///</summary>
		///<param name="blackPoint">The darkest color in the image. Colors darker are set to zero.</param>
		///<param name="whitePoint">The lightest color in the image. Colors brighter are set to the maximum quantum value.</param>
		///<param name="channels">The channel(s) to level.</param>
		///<exception cref="MagickException"/>
		QUANTUM_CLS_COMPLIANT void Level(Magick::Quantum blackPoint, Magick::Quantum whitePoint, Channels channels);
		///==========================================================================================
		///<summary>
		/// Adjust the levels of the image by scaling the colors falling between specified white and
		/// black points to the full available quantum range.
		///</summary>
		///<param name="blackPoint">The darkest color in the image. Colors darker are set to zero.</param>
		///<param name="whitePoint">The lightest color in the image. Colors brighter are set to the maximum quantum value.</param>
		///<param name="midpoint">The gamma correction to apply to the image. (Useful range of 0 to 10)</param>
		///<exception cref="MagickException"/>
		QUANTUM_CLS_COMPLIANT void Level(Magick::Quantum blackPoint, Magick::Quantum whitePoint, double midpoint);
		///==========================================================================================
		///<summary>
		/// Adjust the levels of the image by scaling the colors falling between specified white and
		/// black points to the full available quantum range.
		///</summary>
		///<param name="blackPoint">The darkest color in the image. Colors darker are set to zero.</param>
		///<param name="whitePoint">The lightest color in the image. Colors brighter are set to the maximum quantum value.</param>
		///<param name="midpoint">The gamma correction to apply to the image. (Useful range of 0 to 10)</param>
		///<param name="channels">The channel(s) to level.</param>
		///<exception cref="MagickException"/>
		QUANTUM_CLS_COMPLIANT void Level(Magick::Quantum blackPoint, Magick::Quantum whitePoint, double midpoint, Channels channels);
		///==========================================================================================
		///<summary>
		/// Maps the given color to "black" and "white" values, linearly spreading out the colors, and
		/// level values on a channel by channel bases, as per level(). The given colors allows you to
		/// specify different level ranges for each of the color channels separately.
		///</summary>
		///<param name="blackColor">The color to map black to/from</param>
		///<param name="whiteColor">The color to map white to/from</param>
		///<exception cref="MagickException"/>
		void LevelColors(MagickColor^ blackColor, MagickColor^ whiteColor);
		///==========================================================================================
		///<summary>
		/// Maps the given color to "black" and "white" values, linearly spreading out the colors, and
		/// level values on a channel by channel bases, as per level(). The given colors allows you to
		/// specify different level ranges for each of the color channels separately.
		///</summary>
		///<param name="blackColor">The color to map black to/from</param>
		///<param name="whiteColor">The color to map white to/from</param>
		///<param name="channels">The channel(s) to level.</param>
		///<exception cref="MagickException"/>
		void LevelColors(MagickColor^ blackColor, MagickColor^ whiteColor, Channels channels);
		///==========================================================================================
		///<summary>
		/// Discards any pixels below the black point and above the white point and levels the remaining pixels.
		///</summary>
		///<param name="blackPoint">The black point.</param>
		///<param name="whitePoint">The white point.</param>
		///<exception cref="MagickException"/>
		void LinearStretch(Percentage blackPoint, Percentage whitePoint);
		///==========================================================================================
		///<summary>
		/// Rescales image with seam carving.
		///</summary>
		///<param name="geometry">The geometry to use.</param>
		///<exception cref="MagickException"/>
		void LiquidRescale(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Lower image (lighten or darken the edges of an image to give a 3-D lowered effect).
		///</summary>
		///<param name="size">The size of the edges.</param>
		///<exception cref="MagickException"/>
		void Lower(int size);
		///==========================================================================================
		///<summary>
		/// Magnify image by integral size.
		///</summary>
		///<exception cref="MagickException"/>
		void Magnify();
		///==========================================================================================
		///<summary>
		/// Remap image colors with closest color from reference image.
		///</summary>
		///<param name="image">The image to use.</param>
		///<exception cref="MagickException"/>
		MagickErrorInfo^ Map(MagickImage^ image);
		///==========================================================================================
		///<summary>
		/// Remap image colors with closest color from reference image.
		///</summary>
		///<param name="image">The image to use.</param>
		///<param name="settings">Quantize settings.</param>
		///<exception cref="MagickException"/>
		MagickErrorInfo^ Map(MagickImage^ image, QuantizeSettings^ settings);
		///==========================================================================================
		///<summary>
		/// Filter image by replacing each pixel component with the median color in a circular neighborhood.
		///</summary>
		///<exception cref="MagickException"/>
		void MedianFilter();
		///==========================================================================================
		///<summary>
		/// Filter image by replacing each pixel component with the median color in a circular neighborhood.
		///</summary>
		///<param name="radius">The radius of the pixel neighborhood.</param>
		///<exception cref="MagickException"/>
		void MedianFilter(double radius);
		///==========================================================================================
		///<summary>
		/// Reduce image by integral size.
		///</summary>
		///<exception cref="MagickException"/>
		void Minify();
		///==========================================================================================
		///<summary>
		/// Modulate percent hue, saturation, and brightness of an image.
		///</summary>
		///<param name="brightness">The brightness percentage.</param>
		///<param name="saturation">The saturation percentage.</param>
		///<param name="hue">The hue percentage.</param>
		///<exception cref="MagickException"/>
		void Modulate(Percentage brightness, Percentage saturation, Percentage hue);
		///==========================================================================================
		///<summary>
		/// Returns the normalized moments of one or more image channels.
		///</summary>
		///<exception cref="MagickException"/>
		Moments^ Moments(); 
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="kernel">Built-in kernel.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, Kernel kernel);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="kernel">Built-in kernel.</param>
		///<param name="channels">The channels to apply the kernel to.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, Kernel kernel, Channels channels);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="kernel">Built-in kernel.</param>
		///<param name="channels">The channels to apply the kernel to.</param>
		///<param name="iterations">The number of iterations.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, Kernel kernel, Channels channels, int iterations);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="kernel">Built-in kernel.</param>
		///<param name="iterations">The number of iterations.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, Kernel kernel, int iterations);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="kernel">Built-in kernel.</param>
		///<param name="arguments">Kernel arguments.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, Kernel kernel, String^ arguments);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="kernel">Built-in kernel.</param>
		///<param name="arguments">Kernel arguments.</param>
		///<param name="channels">The channels to apply the kernel to.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, Kernel kernel, String^ arguments, Channels channels);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="kernel">Built-in kernel.</param>
		///<param name="arguments">Kernel arguments.</param>
		///<param name="channels">The channels to apply the kernel to.</param>
		///<param name="iterations">The number of iterations.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, Kernel kernel, String^ arguments, Channels channels, int iterations);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="kernel">Built-in kernel.</param>
		///<param name="arguments">Kernel arguments.</param>
		///<param name="iterations">The number of iterations.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, Kernel kernel, String^ arguments, int iterations);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="userKernel">User suplied kernel.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, String^ userKernel);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="userKernel">User suplied kernel.</param>
		///<param name="channels">The channels to apply the kernel to.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, String^ userKernel, Channels channels);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="userKernel">User suplied kernel.</param>
		///<param name="channels">The channels to apply the kernel to.</param>
		///<param name="iterations">The number of iterations.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, String^ userKernel, Channels channels, int iterations);
		///==========================================================================================
		///<summary>
		/// Applies a kernel to the image according to the given mophology method.
		///</summary>
		///<param name="method">The morphology method.</param>
		///<param name="userKernel">User suplied kernel.</param>
		///<param name="iterations">The number of iterations.</param>
		///<exception cref="MagickException"/>
		void Morphology(MorphologyMethod method, String^ userKernel, int iterations);
		///==========================================================================================
		///<summary>
		/// Motion blur image with specified blur factor.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<param name="angle">The angle the object appears to be comming from (zero degrees is from the right).</param>
		///<exception cref="MagickException"/>
		void MotionBlur(double radius, double sigma, double angle);
		///==========================================================================================
		///<summary>
		/// Negate colors in image.
		///</summary>
		///<exception cref="MagickException"/>
		void Negate();
		///==========================================================================================
		///<summary>
		/// Negate colors in image.
		///</summary>
		///<param name="onlyGrayscale">Use true to negate only the grayscale colors.</param>
		///<exception cref="MagickException"/>
		void Negate(bool onlyGrayscale);
		///==========================================================================================
		///<summary>
		/// Negate colors in image for the specified channel.
		///</summary>
		///<param name="channels">The channel(s) that should be negated.</param>
		///<exception cref="MagickException"/>
		void Negate(Channels channels);
		///==========================================================================================
		///<summary>
		/// Negate colors in image for the specified channel.
		///</summary>
		///<param name="channels">The channel(s) that should be negated.</param>
		///<param name="onlyGrayscale">Use true to negate only the grayscale colors.</param>
		///<exception cref="MagickException"/>
		void Negate(Channels channels, bool onlyGrayscale);
		///==========================================================================================
		///<summary>
		/// Normalize image (increase contrast by normalizing the pixel values to span the full range
		/// of color values)
		///</summary>
		///<exception cref="MagickException"/>
		void Normalize();
		///==========================================================================================
		///<summary>
		/// Oilpaint image (image looks like oil painting)
		///</summary>
		void OilPaint();
		///==========================================================================================
		///<summary>
		/// Oilpaint image (image looks like oil painting)
		///</summary>
		///<param name="radius">The radius of the circular neighborhood.</param>
		///<exception cref="MagickException"/>
		void OilPaint(double radius);
		///==========================================================================================
		///<summary>
		/// Changes any pixel that matches target with the color defined by fill.
		///</summary>
		///<param name="target">The color to replace.</param>
		///<param name="fill">The color to replace opaque color with.</param>
		///<exception cref="MagickException"/>
		void Opaque(MagickColor^ target, MagickColor^ fill);
		///==========================================================================================
		///<summary>
		/// Perform a ordered dither based on a number of pre-defined dithering threshold maps, but over
		/// multiple intensity levels.
		///</summary>
		///<param name="thresholdMap">A string containing the name of the threshold dither map to use,
		///followed by zero or more numbers representing the number of color levels tho dither between.</param>
		///<exception cref="MagickException"/>
		void OrderedDither(String^ thresholdMap);
		///==========================================================================================
		///<summary>
		/// Perform a ordered dither based on a number of pre-defined dithering threshold maps, but over
		/// multiple intensity levels.
		///</summary>
		///<param name="thresholdMap">A string containing the name of the threshold dither map to use,
		///followed by zero or more numbers representing the number of color levels tho dither between.</param>
		///<param name="channels">The channel(s) to dither.</param>
		///<exception cref="MagickException"/>
		void OrderedDither(String^ thresholdMap, Channels channels);
		///==========================================================================================
		///<summary>
		/// Set each pixel whose value is less than epsilon to epsilon or -epsilon (whichever is closer)
		/// otherwise the pixel value remains unchanged.
		///</summary>
		///<param name="epsilon">The epsilon threshold.</param>
		///<exception cref="MagickException"/>
		void Perceptible(double epsilon);
		///==========================================================================================
		///<summary>
		/// Set each pixel whose value is less than epsilon to epsilon or -epsilon (whichever is closer)
		/// otherwise the pixel value remains unchanged.
		///</summary>
		///<param name="epsilon">The epsilon threshold.</param>
		///<param name="channels">The channel(s) to perceptible.</param>
		///<exception cref="MagickException"/>
		void Perceptible(double epsilon, Channels channels);
		///==========================================================================================
		///<summary>
		/// Reads only metadata and not the pixel data.
		///</summary>
		///<param name="data">The byte array to read the information from.</param>
		///<exception cref="MagickException"/>
		MagickWarningException^ Ping(array<Byte>^ data);
		///==========================================================================================
		///<summary>
		/// Reads only metadata and not the pixel data.
		///</summary>
		///<param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
		///<exception cref="MagickException"/>
		MagickWarningException^ Ping(String^ fileName);
		///==========================================================================================
		///<summary>
		/// Reads only metadata and not the pixel data.
		///</summary>
		///<param name="stream">The stream to read the image data from.</param>
		///<exception cref="MagickException"/>
		MagickWarningException^ Ping(Stream^ stream);
		///==========================================================================================
		///<summary>
		/// Simulates a Polaroid picture.
		///</summary>
		///<param name="caption">The caption to put on the image.</param>
		///<param name="angle">The angle of image.</param>
		///<param name="method">Pixel interpolate method.</param>
		///<exception cref="MagickException"/>
		void Polaroid(String^ caption, double angle, PixelInterpolateMethod method);
		///==========================================================================================
		///<summary>
		/// Reduces the image to a limited number of colors for a "poster" effect.
		///</summary>
		///<param name="levels">Number of color levels allowed in each channel.</param>
		///<exception cref="MagickException"/>
		void Posterize(int levels);
		///==========================================================================================
		///<summary>
		/// Reduces the image to a limited number of colors for a "poster" effect.
		///</summary>
		///<param name="levels">Number of color levels allowed in each channel.</param>
		///<param name="method">Dither method to use.</param>
		///<exception cref="MagickException"/>
		void Posterize(int levels, DitherMethod method);
		///==========================================================================================
		///<summary>
		/// Reduces the image to a limited number of colors for a "poster" effect.
		///</summary>
		///<param name="levels">Number of color levels allowed in each channel.</param>
		///<param name="method">Dither method to use.</param>
		///<param name="channels">The channel(s) to posterize.</param>
		///<exception cref="MagickException"/>
		void Posterize(int levels, DitherMethod method, Channels channels);
		///==========================================================================================
		///<summary>
		/// Reduces the image to a limited number of colors for a "poster" effect.
		///</summary>
		///<param name="levels">Number of color levels allowed in each channel.</param>
		///<param name="channels">The channel(s) to posterize.</param>
		///<exception cref="MagickException"/>
		void Posterize(int levels, Channels channels);
		///==========================================================================================
		///<summary>
		/// Sets an internal option to preserve the color type.
		///</summary>
		///<exception cref="MagickException"/>
		void PreserveColorType();
		///==========================================================================================
		///<summary>
		/// Quantize image (reduce number of colors).
		///</summary>
		///<param name="settings">Quantize settings.</param>
		///<exception cref="MagickException"/>
		MagickErrorInfo^ Quantize(QuantizeSettings^ settings);
		///==========================================================================================
		///<summary>
		/// Raise image (lighten or darken the edges of an image to give a 3-D raised effect).
		///</summary>
		///<param name="size">The size of the edges.</param>
		///<exception cref="MagickException"/>
		void Raise(int size);
		///==========================================================================================
		///<summary>
		/// Changes the value of individual pixels based on the intensity of each pixel compared to a
		/// random threshold. The result is a low-contrast, two color image.
		///</summary>
		///<param name="percentageLow">The low threshold.</param>
		///<param name="percentageHigh">The low threshold.</param>
		///<exception cref="MagickException"/>
		void RandomThreshold(Percentage percentageLow, Percentage percentageHigh);
		///==========================================================================================
		///<summary>
		/// Changes the value of individual pixels based on the intensity of each pixel compared to a
		/// random threshold. The result is a low-contrast, two color image.
		///</summary>
		///<param name="percentageLow">The low threshold.</param>
		///<param name="percentageHigh">The low threshold.</param>
		///<param name="channels">The channel(s) to use.</param>
		///<exception cref="MagickException"/>
		void RandomThreshold(Percentage percentageLow, Percentage percentageHigh, Channels channels);
		///==========================================================================================
		///<summary>
		/// Changes the value of individual pixels based on the intensity of each pixel compared to a
		/// random threshold. The result is a low-contrast, two color image.
		///</summary>
		///<param name="low">The low threshold.</param>
		///<param name="high">The low threshold.</param>
		///<exception cref="MagickException"/>
		QUANTUM_CLS_COMPLIANT void RandomThreshold(Magick::Quantum low, Magick::Quantum high);
		///==========================================================================================
		///<summary>
		/// Changes the value of individual pixels based on the intensity of each pixel compared to a
		/// random threshold. The result is a low-contrast, two color image.
		///</summary>
		///<param name="low">The low threshold.</param>
		///<param name="high">The low threshold.</param>
		///<param name="channels">The channel(s) to use.</param>
		///<exception cref="MagickException"/>
		QUANTUM_CLS_COMPLIANT void RandomThreshold(Magick::Quantum low, Magick::Quantum high, Channels channels);
		///==========================================================================================
		///<summary>
		/// Read single image frame.
		///</summary>
		///<param name="data">The byte array to read the image data from.</param>
		///<returns>If a warning was raised while reading the image that warning will be returned.</returns>
		///<exception cref="MagickException"/>
		MagickWarningException^ Read(array<Byte>^ data);
		///==========================================================================================
		///<summary>
		/// Read single vector image frame.
		///</summary>
		///<param name="data">The byte array to read the image data from.</param>
		///<param name="readSettings">The settings to use when reading the image.</param>
		///<returns>If a warning was raised while reading the image that warning will be returned.</returns>
		///<exception cref="MagickException"/>
		MagickWarningException^ Read(array<Byte>^ data, MagickReadSettings^ readSettings);
		///==========================================================================================
		///<summary>
		/// Read single image frame.
		///</summary>
		///<param name="bitmap">The bitmap to read the image from.</param>
		///<returns>If a warning was raised while reading the image that warning will be returned.</returns>
		///<exception cref="MagickException"/>
		MagickWarningException^ Read(Bitmap^ bitmap);
		///==========================================================================================
		///<summary>
		/// Read single image frame.
		///</summary>
		///<param name="file">The file to read the image from.</param>
		///<returns>If a warning was raised while reading the image that warning will be returned.</returns>
		///<exception cref="MagickException"/>
		MagickWarningException^ Read(FileInfo^ file);
		///==========================================================================================
		///<summary>
		/// Read single vector image frame.
		///</summary>
		///<param name="file">The file to read the image from.</param>
		///<param name="readSettings">The settings to use when reading the image.</param>
		///<returns>If a warning was raised while reading the image that warning will be returned.</returns>
		///<exception cref="MagickException"/>
		MagickWarningException^ Read(FileInfo^ file, MagickReadSettings^ readSettings);
		///==========================================================================================
		///<summary>
		/// Read single image frame.
		///</summary>
		///<param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
		///<returns>If a warning was raised while reading the image that warning will be returned.</returns>
		///<exception cref="MagickException"/>
		MagickWarningException^ Read(String^ fileName);
		///==========================================================================================
		///<summary>
		/// Read single vector image frame.
		///</summary>
		///<param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
		///<param name="readSettings">The settings to use when reading the image.</param>
		///<returns>If a warning was raised while reading the image that warning will be returned.</returns>
		///<exception cref="MagickException"/>
		MagickWarningException^ Read(String^ fileName, MagickReadSettings^ readSettings);
		///==========================================================================================
		///<summary>
		/// Read single image frame.
		///</summary>
		///<param name="stream">The stream to read the image data from.</param>
		///<returns>If a warning was raised while reading the image that warning will be returned.</returns>
		///<exception cref="MagickException"/>
		MagickWarningException^ Read(Stream^ stream);
		///==========================================================================================
		///<summary>
		/// Read single image frame.
		///</summary>
		///<param name="stream">The stream to read the image data from.</param>
		///<param name="readSettings">The settings to use when reading the image.</param>
		///<returns>If a warning was raised while reading the image that warning will be returned.</returns>
		///<exception cref="MagickException"/>
		MagickWarningException^ Read(Stream^ stream, MagickReadSettings^ readSettings);
		///==========================================================================================
		///<summary>
		/// Reduce noise in image using a noise peak elimination filter.
		///</summary>
		///<exception cref="MagickException"/>
		void ReduceNoise();
		///==========================================================================================
		///<summary>
		/// Reduce noise in image using a noise peak elimination filter.
		///</summary>
		///<param name="order">The order to use.</param>
		///<exception cref="MagickException"/>
		void ReduceNoise(int order);
		///==========================================================================================
		///<summary>
		/// Remove a named profile from the image.
		///</summary>
		///<param name="name">The name of the profile (e.g. "ICM", "IPTC", or a generic profile name).</param>
		///<exception cref="MagickException"/>
		void RemoveProfile(String^ name);
		///==========================================================================================
		///<summary>
		/// Resets the page property of this image.
		///</summary>
		///<exception cref="MagickException"/>
		void RePage();
		///==========================================================================================
		///<summary>
		/// Resize image in terms of its pixel size.
		///</summary>
		///<param name="resolutionX">The new X resolution.</param>
		///<param name="resolutionY">The new Y resolution.</param>
		///<exception cref="MagickException"/>
		void Resample(int resolutionX, int resolutionY);
		///==========================================================================================
		///<summary>
		/// Resize image in terms of its pixel size.
		///</summary>
		///<param name="geometry">The geometry to use.</param>
		///<exception cref="MagickException"/>
		void Resample(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Resize image to specified size.
		///</summary>
		///<param name="width">The new width.</param>
		///<param name="height">The new height.</param>
		///<exception cref="MagickException"/>
		void Resize(int width, int height);
		///==========================================================================================
		///<summary>
		/// Resize image to specified geometry.
		///</summary>
		///<param name="geometry">The geometry to use.</param>
		///<exception cref="MagickException"/>
		void Resize(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Resize image to specified percentage.
		///</summary>
		///<param name="percentage">The percentage.</param>
		///<exception cref="MagickException"/>
		void Resize(Percentage percentage);
		///==========================================================================================
		///<summary>
		/// Resize image to specified percentage.
		///</summary>
		///<param name="percentageWidth">The percentage of the width.</param>
		///<param name="percentageHeight">The percentage of the height.</param>
		///<exception cref="MagickException"/>
		void Resize(Percentage percentageWidth, Percentage percentageHeight);
		///==========================================================================================
		///<summary>
		/// Roll image (rolls image vertically and horizontally).
		///</summary>
		///<param name="xOffset">The X offset from origin.</param>
		///<param name="yOffset">The Y offset from origin.</param>
		///<exception cref="MagickException"/>
		void Roll(int xOffset, int yOffset);
		///==========================================================================================
		///<summary>
		/// Rotate image counter-clockwise by specified number of degrees.
		///</summary>
		///<param name="degrees">The number of degrees to rotate.</param>
		///<exception cref="MagickException"/>
		void Rotate(double degrees);
		///==========================================================================================
		///<summary>
		/// Rotational blur image.
		///</summary>
		///<param name="angle">The angle to use.</param>
		///<exception cref="MagickException"/>
		void RotationalBlur(double angle);
		///==========================================================================================
		///<summary>
		/// Rotational blur image.
		///</summary>
		///<param name="angle">The angle to use.</param>
		///<param name="channels">The channel(s) to use.</param>
		///<exception cref="MagickException"/>
		void RotationalBlur(double angle, Channels channels);
		///==========================================================================================
		///<summary>
		/// Resize image by using pixel sampling algorithm.
		///</summary>
		///<param name="width">The new width.</param>
		///<param name="height">The new height.</param>
		///<exception cref="MagickException"/>
		void Sample(int width, int height);
		///==========================================================================================
		///<summary>
		/// Resize image by using pixel sampling algorithm.
		///</summary>
		///<param name="geometry">The geometry to use.</param>
		///<exception cref="MagickException"/>
		void Sample(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Resize image by using pixel sampling algorithm to the specified percentage.
		///</summary>
		///<param name="percentage">The percentage.</param>
		///<exception cref="MagickException"/>
		void Sample(Percentage percentage);
		///==========================================================================================
		///<summary>
		/// Resize image by using pixel sampling algorithm to the specified percentage.
		///</summary>
		///<param name="percentageWidth">The percentage of the width.</param>
		///<param name="percentageHeight">The percentage of the height.</param>
		///<exception cref="MagickException"/>
		void Sample(Percentage percentageWidth, Percentage percentageHeight);
		///==========================================================================================
		///<summary>
		/// Resize image by using simple ratio algorithm.
		///</summary>
		///<param name="width">The new width.</param>
		///<param name="height">The new height.</param>
		///<exception cref="MagickException"/>
		void Scale(int width, int height);
		///==========================================================================================
		///<summary>
		/// Resize image by using simple ratio algorithm.
		///</summary>
		///<param name="geometry">The geometry to use.</param>
		///<exception cref="MagickException"/>
		void Scale(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Resize image by using simple ratio algorithm to the specified percentage.
		///</summary>
		///<param name="percentage">The percentage.</param>
		///<exception cref="MagickException"/>
		void Scale(Percentage percentage);
		///==========================================================================================
		///<summary>
		/// Resize image by using simple ratio algorithm to the specified percentage.
		///</summary>
		///<param name="percentageWidth">The percentage of the width.</param>
		///<param name="percentageHeight">The percentage of the height.</param>
		///<exception cref="MagickException"/>
		void Scale(Percentage percentageWidth, Percentage percentageHeight);
		///==========================================================================================
		///<summary>
		/// Segment (coalesce similar image components) by analyzing the histograms of the color
		/// components and identifying units that are homogeneous with the fuzzy c-means technique.
		/// Also uses QuantizeColorSpace and Verbose image attributes.
		///</summary>
		///<exception cref="MagickException"/>
		void Segment();
		///==========================================================================================
		///<summary>
		/// Segment (coalesce similar image components) by analyzing the histograms of the color
		/// components and identifying units that are homogeneous with the fuzzy c-means technique.
		/// Also uses QuantizeColorSpace and Verbose image attributes.
		///</summary>
		///<param name="quantizeColorSpace">Quantize colorspace</param>
		///<param name="clusterThreshold">This represents the minimum number of pixels contained in
		/// a hexahedra before it can be considered valid (expressed as a percentage).</param>
		///<param name="smoothingThreshold">The smoothing threshold eliminates noise in the second
		/// derivative of the histogram. As the value is increased, you can expect a smoother second
		/// derivative</param>
		///<exception cref="MagickException"/>
		void Segment(ImageMagick::ColorSpace quantizeColorSpace, double clusterThreshold, double smoothingThreshold);
		///==========================================================================================
		///<summary>
		/// Selectively blur pixels within a contrast threshold. It is similar to the unsharpen mask
		/// that sharpens everything with contrast above a certain threshold.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Gaussian, in pixels.</param>
		///<param name="threshold">Only pixels within this contrast threshold are included in the blur operation.</param>
		///<exception cref="MagickException"/>
		void SelectiveBlur(double radius, double sigma, double threshold);
		///==========================================================================================
		///<summary>
		/// Selectively blur pixels within a contrast threshold. It is similar to the unsharpen mask
		/// that sharpens everything with contrast above a certain threshold.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Gaussian, in pixels.</param>
		///<param name="threshold">Only pixels within this contrast threshold are included in the blur operation.</param>
		///<param name="channels">The channel(s) to blur.</param>
		///<exception cref="MagickException"/>
		void SelectiveBlur(double radius, double sigma, double threshold, Channels channels);
		///==========================================================================================
		///<summary>
		/// Separates the channels from the image and returns it as grayscale images.
		///</summary>
		///<exception cref="MagickException"/>
		IEnumerable<MagickImage^>^ Separate();
		///==========================================================================================
		///<summary>
		/// Separates the specified channels from the image and returns it as grayscale images.
		///</summary>
		///<param name="channels">The channel(s) to separates.</param>
		///<exception cref="MagickException"/>
		IEnumerable<MagickImage^>^ Separate(Channels channels);
		///==========================================================================================
		///<summary>
		/// Applies a special effect to the image, similar to the effect achieved in a photo darkroom
		/// by sepia toning.
		///</summary>
		///<exception cref="MagickException"/>
		void SepiaTone();
		///==========================================================================================
		///<summary>
		/// Applies a special effect to the image, similar to the effect achieved in a photo darkroom
		/// by sepia toning.
		///</summary>
		///<param name="threshold">The tone threshold.</param>
		///<exception cref="MagickException"/>
		void SepiaTone(Percentage threshold);
		///==========================================================================================
		///<summary>
		/// Inserts the artifact with the specified name and value into the artifact tree of the image.
		///</summary>
		///<param name="name">The name of the artifact.</param>
		///<param name="value">The value of the artifact.</param>
		///<exception cref="MagickException"/>
		void SetArtifact(String^ name, String^ value);
		///==========================================================================================
		///<summary>
		/// Lessen (or intensify) when adding noise to an image.
		///</summary>
		///<param name="attenuate">The attenuate value.</param>
		void SetAttenuate(double attenuate);
		///==========================================================================================
		///<summary>
		/// Sets a named image attribute.
		///</summary>
		///<param name="name">The name of the attribute.</param>
		///<param name="value">The value of the attribute.</param>
		///<exception cref="MagickException"/>
		void SetAttribute(String^ name, String^ value);
		///==========================================================================================
		///<summary>
		/// Sets a format-specific option.
		///</summary>
		///<param name="format">The format to set the option for.</param>
		///<param name="name">The name of the option.</param>
		///<param name="flag">The value of the option.</param>
		void SetDefine(MagickFormat format, String^ name, bool flag);
		///==========================================================================================
		///<summary>
		/// Sets a format-specific option.
		///</summary>
		///<param name="format">The format to set the option for.</param>
		///<param name="name">The name of the option.</param>
		///<param name="value">The value of the option.</param>
		void SetDefine(MagickFormat format, String^ name, String^ value);
		///==========================================================================================
		///<summary>
		/// When comparing images, emphasize pixel differences with this color.
		///</summary>
		///<param name="color">The color.</param>
		void SetHighlightColor(MagickColor^ color);
		///==========================================================================================
		///<summary>
		/// When comparing images, de-emphasize pixel differences with this color.
		///</summary>
		///<param name="color">The color.</param>
		void SetLowlightColor(MagickColor^ color);
		///==========================================================================================
		///<summary>
		/// Shade image using distant light source.
		///</summary>
		///<exception cref="MagickException"/>
		void Shade();
		///==========================================================================================
		///<summary>
		/// Shade image using distant light source.
		///</summary>
		///<param name="azimuth">The light source direction.</param>
		///<param name="elevation">The light source direction.</param>
		///<param name="colorShading">Specify true to shade the intensity of each pixel.</param>
		///<exception cref="MagickException"/>
		void Shade(double azimuth, double elevation, bool colorShading);
		///==========================================================================================
		///<summary>
		/// Simulate an image shadow.
		///</summary>
		///<exception cref="MagickException"/>
		void Shadow();
		///==========================================================================================
		///<summary>
		/// Simulate an image shadow.
		///</summary>
		///<param name="color">The color of the shadow.</param>
		///<exception cref="MagickException"/>
		void Shadow(MagickColor^ color);
		///==========================================================================================
		///<summary>
		/// Simulate an image shadow.
		///</summary>
		///<param name="x">the shadow x-offset.</param>
		///<param name="y">the shadow y-offset.</param>
		///<param name="sigma">The standard deviation of the Gaussian, in pixels.</param>
		///<param name="alpha">Transparency percentage.</param>
		///<exception cref="MagickException"/>
		void Shadow(int x, int y, double sigma, Percentage alpha);
		///==========================================================================================
		///<summary>
		/// Simulate an image shadow.
		///</summary>
		///<param name="x">the shadow x-offset.</param>
		///<param name="y">the shadow y-offset.</param>
		///<param name="sigma">The standard deviation of the Gaussian, in pixels.</param>
		///<param name="alpha">Transparency percentage.</param>
		///<param name="color">The color of the shadow.</param>
		///<exception cref="MagickException"/>
		void Shadow(int x, int y, double sigma, Percentage alpha, MagickColor^ color);
		///==========================================================================================
		///<summary>
		/// Sharpen pixels in image.
		///</summary>
		///<exception cref="MagickException"/>
		void Sharpen();
		///==========================================================================================
		///<summary>
		/// Sharpen pixels in image.
		///</summary>
		///<param name="channels">The channel(s) that should be sharpened.</param>
		///<exception cref="MagickException"/>
		void Sharpen(Channels channels);
		///==========================================================================================
		///<summary>
		/// Sharpen pixels in image.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<exception cref="MagickException"/>
		void Sharpen(double radius, double sigma);
		///==========================================================================================
		///<summary>
		/// Sharpen pixels in image.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<param name="channels">The channel(s) that should be sharpened.</param>
		void Sharpen(double radius, double sigma, Channels channels);
		///==========================================================================================
		///<summary>
		/// Shave pixels from image edges.
		///</summary>
		///<param name="leftRight">The number of pixels to shave left and right.</param>
		///<param name="topBottom">The number of pixels to shave top and bottom.</param>
		///<exception cref="MagickException"/>
		void Shave(int leftRight, int topBottom);
		///==========================================================================================
		///<summary>
		/// Shear image (create parallelogram by sliding image by X or Y axis).
		///</summary>
		///<param name="xAngle">Specifies the number of degrees to shear the image.</param>
		///<param name="yAngle">Specifies the number of degrees to shear the image.</param>
		///<exception cref="MagickException"/>
		void Shear(double xAngle, double yAngle);
		///==========================================================================================
		///<summary>
		/// adjust the image contrast with a non-linear sigmoidal contrast algorithm
		///</summary>
		///<param name="sharpen">Specifies if sharpening should be used.</param>
		///<param name="contrast">The contrast</param>
		///<exception cref="MagickException"/>
		void SigmoidalContrast(bool sharpen, double contrast);
		///==========================================================================================
		///<summary>
		/// adjust the image contrast with a non-linear sigmoidal contrast algorithm
		///</summary>
		///<param name="sharpen">Specifies if sharpening should be used.</param>
		///<param name="contrast">The contrast to use.</param>
		///<param name="midpoint">The midpoint to use.</param>
		///<exception cref="MagickException"/>
		void SigmoidalContrast(bool sharpen, double contrast, double midpoint);
		///==========================================================================================
		///<summary>
		/// Simulates a pencil sketch.
		///</summary>
		///<exception cref="MagickException"/>
		void Sketch();
		///==========================================================================================
		///<summary>
		/// Simulates a pencil sketch. We convolve the image with a Gaussian operator of the given
		/// radius and standard deviation (sigma). For reasonable results, radius should be larger than sigma.
		/// Use a radius of 0 and sketch selects a suitable radius for you.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<param name="angle">Apply the effect along this angle.</param>
		///<exception cref="MagickException"/>
		void Sketch(double radius, double sigma, double angle);
		///==========================================================================================
		///<summary>
		/// Solarize image (similar to effect seen when exposing a photographic film to light during
		/// the development process)
		///</summary>
		///<exception cref="MagickException"/>
		void Solarize();
		///==========================================================================================
		///<summary>
		/// Solarize image (similar to effect seen when exposing a photographic film to light during
		/// the development process)
		///</summary>
		///<param name="factor">The factor to use.</param>
		///<exception cref="MagickException"/>
		void Solarize(double factor);
		///==========================================================================================
		///<summary>
		/// Sparse color image, given a set of coordinates, interpolates the colors found at those
		/// coordinates, across the whole image, using various methods.
		///</summary>
		///<param name="method">The sparse color method to use.</param>
		///<param name="args">The sparse color arguments.</param>
		///<exception cref="MagickException"/>
		void SparseColor(SparseColorMethod method, IEnumerable<SparseColorArg^>^ args);
		///==========================================================================================
		///<summary>
		/// Sparse color image, given a set of coordinates, interpolates the colors found at those
		/// coordinates, across the whole image, using various methods.
		///</summary>
		///<param name="channels">The channel(s) to use.</param>
		///<param name="method">The sparse color method to use.</param>
		///<param name="args">The sparse color arguments.</param>
		///<exception cref="MagickException"/>
		void SparseColor(Channels channels, SparseColorMethod method, IEnumerable<SparseColorArg^>^ args);
		///==========================================================================================
		///<summary>
		/// Spread pixels randomly within image.
		///</summary>
		///<exception cref="MagickException"/>
		void Spread();
		///==========================================================================================
		///<summary>
		/// Spread pixels randomly within image by specified ammount.
		///</summary>
		///<exception cref="MagickException"/>
		void Spread(int amount);
		///==========================================================================================
		///<summary>
		/// Returns image statistics.
		///</summary>
		///<exception cref="MagickException"/>
		Statistics^ Statistics();
		///==========================================================================================
		///<summary>
		/// Add a digital watermark to the image (based on second image)
		///</summary>
		///<param name="watermark">The image to use as a watermark.</param>
		///<exception cref="MagickException"/>
		void Stegano(MagickImage^ watermark);
		///==========================================================================================
		///<summary>
		/// Create an image which appears in stereo when viewed with red-blue glasses (Red image on
		/// left, blue on right)
		///</summary>
		///<param name="rightImage">The image to use as the right part of the resulting image.</param>
		///<exception cref="MagickException"/>
		void Stereo(MagickImage^ rightImage);
		///==========================================================================================
		///<summary>
		/// Strips an image of all profiles and comments.
		///</summary>
		///<exception cref="MagickException"/>
		void Strip();
		///==========================================================================================
		///<summary>
		/// Swirl image (image pixels are rotated by degrees).
		///</summary>
		///<param name="degrees">The number of degrees.</param>
		///<exception cref="MagickException"/>
		void Swirl(double degrees);
		///==========================================================================================
		///<summary>
		/// Search for the specified image at EVERY possible location in this image. This is slow!
		/// very very slow.. It returns a similarity image such that an exact match location is
		/// completely white and if none of the pixels match, black, otherwise some gray level in-between.
		///</summary>
		///<param name="image">The image to search for.</param>
		///<exception cref="MagickException"/>
		MagickSearchResult^ SubImageSearch(MagickImage^ image);
		///==========================================================================================
		///<summary>
		/// Search for the specified image at EVERY possible location in this image. This is slow!
		/// very very slow.. It returns a similarity image such that an exact match location is
		/// completely white and if none of the pixels match, black, otherwise some gray level in-between.
		///</summary>
		///<param name="image">The image to search for.</param>
		///<param name="metric">The metric to use.</param>
		///<exception cref="MagickException"/>
		MagickSearchResult^ SubImageSearch(MagickImage^ image, ErrorMetric metric);
		///==========================================================================================
		///<summary>
		/// Search for the specified image at EVERY possible location in this image. This is slow!
		/// very very slow.. It returns a similarity image such that an exact match location is
		/// completely white and if none of the pixels match, black, otherwise some gray level in-between.
		///</summary>
		///<param name="image">The image to search for.</param>
		///<param name="metric">The metric to use.</param>
		///<param name="similarityThreshold">Minimum distortion for (sub)image match.</param>
		///<exception cref="MagickException"/>
		MagickSearchResult^ SubImageSearch(MagickImage^ image, ErrorMetric metric, double similarityThreshold);
		///==========================================================================================
		///<summary>
		/// Channel a texture on image background.
		///</summary>
		///<param name="image">The image to use as a texture on image background.</param>
		///<exception cref="MagickException"/>
		void Texture(MagickImage^ image);
		///==========================================================================================
		///<summary>
		/// Threshold image.
		///</summary>
		///<param name="percentage">The threshold percentage.</param>
		///<exception cref="MagickException"/>
		void Threshold(Percentage percentage);
		///==========================================================================================
		///<summary>
		/// Resize image to thumbnail size.
		///</summary>
		///<param name="width">The new width.</param>
		///<param name="height">The new height.</param>
		///<exception cref="MagickException"/>
		void Thumbnail(int width, int height);
		///==========================================================================================
		///<summary>
		/// Resize image to thumbnail size.
		///</summary>
		///<param name="geometry">The geometry to use.</param>
		///<exception cref="MagickException"/>
		void Thumbnail(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		/// Resize image to thumbnail size.
		///</summary>
		///<param name="percentage">The percentage.</param>
		///<exception cref="MagickException"/>
		void Thumbnail(Percentage percentage);
		///==========================================================================================
		///<summary>
		/// Resize image to thumbnail size.
		///</summary>
		///<param name="percentageWidth">The percentage of the width.</param>
		///<param name="percentageHeight">The percentage of the height.</param>
		///<exception cref="MagickException"/>
		void Thumbnail(Percentage percentageWidth, Percentage percentageHeight);
		//==========================================================================================
		///<summary>
		/// Compose an image repeated across and down the image.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="compose">The algorithm to use.</param>
		///<exception cref="MagickException"/>
		void Tile(MagickImage^ image, CompositeOperator compose);
		//==========================================================================================
		///<summary>
		/// Compose an image repeated across and down the image.
		///</summary>
		///<param name="image">The image to composite with this image.</param>
		///<param name="compose">The algorithm to use.</param>
		///<param name="args">The arguments for the algorithm (compose:args).</param>
		///<exception cref="MagickException"/>
		void Tile(MagickImage^ image, CompositeOperator compose, String^ args);
		///==========================================================================================
		///<summary>
		/// Applies a color vector to each pixel in the image. The length of the vector is 0 for black
		/// and white and at its maximum for the midtones. The vector weighting function is
		/// f(x)=(1-(4.0*((x-0.5)*(x-0.5))))
		///</summary>
		///<param name="opacity">A color value used for tinting.</param>
		///<exception cref="MagickException"/>
		void Tint(String^ opacity);
		///==========================================================================================
		///<summary>
		/// Converts this instance to a base64 string.
		///</summary>
		String^ ToBase64();
		///==========================================================================================
		///<summary>
		/// Converts this instance to a bitmap using ImageFormat.Bitmap.
		///</summary>
		Bitmap^ ToBitmap();
		///==========================================================================================
		///<summary>
		/// Converts this instance to a bitmap using the specified ImageFormat. Supported formats are:
		/// Bmp, Gif, Icon, Jpeg, Png, Tiff.
		///</summary>
		Bitmap^ ToBitmap(ImageFormat^ imageFormat);
		///==========================================================================================
		///<summary>
		/// Converts this instance to a byte array.
		///</summary>
		array<Byte>^ ToByteArray();
		///==========================================================================================
		///<summary>
		/// Converts this instance to a byte array.
		///</summary>
		///<param name="format">The format to use.</param>
		array<Byte>^ ToByteArray(MagickFormat format);
		///==========================================================================================
		///<summary>
		/// Returns a string that represents the current image.
		///</summary>
		virtual String^ ToString() override;
		///==========================================================================================
		///<summary>
		/// Transform image based on image geometry.
		///</summary>
		///<param name="imageGeometry">The image geometry.</param>
		///<exception cref="MagickException"/>
		void Transform(MagickGeometry^ imageGeometry);
		///==========================================================================================
		///<summary>
		/// Transform image based on image geometry.
		///</summary>
		///<param name="imageGeometry">The image geometry.</param>
		///<param name="cropGeometry">The crop geometry.</param>
		///<exception cref="MagickException"/>
		void Transform(MagickGeometry^ imageGeometry, MagickGeometry^ cropGeometry);
		///==========================================================================================
		///<summary>
		/// Origin of coordinate system to use when annotating with text or drawing.
		///</summary>
		///<param name="x">The X coordinate.</param>
		///<param name="y">The Y coordinate.</param>
		///<exception cref="MagickException"/>
		void TransformOrigin(double x, double y);
		///==========================================================================================
		///<summary>
		/// Rotation to use when annotating with text or drawing.
		///</summary>
		///<param name="angle">The angle.</param>
		///<exception cref="MagickException"/>
		void TransformRotation(double angle);
		///==========================================================================================
		///<summary>
		/// Reset transformation parameters to default.
		///</summary>
		///<exception cref="MagickException"/>
		void TransformReset();
		///==========================================================================================
		///<summary>
		/// Scale to use when annotating with text or drawing.
		///</summary>
		///<param name="scaleX">The X coordinate scaling element.</param>
		///<param name="scaleY">The Y coordinate scaling element.</param>
		///<exception cref="MagickException"/>
		void TransformScale(double scaleX, double scaleY);
		///==========================================================================================
		///<summary>
		/// Skew to use in X axis when annotating with text or drawing.
		///</summary>
		///<param name="skewX">The X skew.</param>
		///<exception cref="MagickException"/>
		void TransformSkewX(double skewX);
		///==========================================================================================
		///<summary>
		/// Skew to use in Y axis when annotating with text or drawing.
		///</summary>
		///<param name="skewY">The Y skew.</param>
		///<exception cref="MagickException"/>
		void TransformSkewY(double skewY);
		///==========================================================================================
		///<summary>
		/// Add alpha channel to image, setting pixels matching color to transparent.
		///</summary>
		///<param name="color">The color to make transparent.</param>
		///<exception cref="MagickException"/>
		void Transparent(MagickColor^ color);
		///==========================================================================================
		///<summary>
		/// Add alpha channel to image, setting pixels that lie in between the given two colors to
		/// transparent.
		///</summary>
		///<exception cref="MagickException"/>
		void TransparentChroma(MagickColor^ colorLow, MagickColor^ colorHigh);
		///==========================================================================================
		///<summary>
		/// Creates a horizontal mirror image by reflecting the pixels around the central y-axis while
		/// rotating them by 90 degrees. 
		///</summary>
		///<exception cref="MagickException"/>
		void Transpose();
		///==========================================================================================
		///<summary>
		/// Creates a vertical mirror image by reflecting the pixels around the central x-axis while
		/// rotating them by 270 degrees. 
		///</summary>
		///<exception cref="MagickException"/>
		void Transverse();
		///==========================================================================================
		///<summary>
		/// Trim edges that are the background color from the image.
		///</summary>
		///<exception cref="MagickException"/>
		void Trim();
		///==========================================================================================
		///<summary>
		/// Returns the unique colors of an image.
		///</summary>
		///<exception cref="MagickException"/>
		MagickImage^ UniqueColors();
		///==========================================================================================
		///<summary>
		/// Replace image with a sharpened version of the original image using the unsharp mask algorithm.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<exception cref="MagickException"/>
		void Unsharpmask(double radius, double sigma);
		///==========================================================================================
		///<summary>
		/// Replace image with a sharpened version of the original image using the unsharp mask algorithm.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<param name="channels">The channel(s) that should be sharpened.</param>
		///<exception cref="MagickException"/>
		void Unsharpmask(double radius, double sigma, Channels channels);
		///==========================================================================================
		///<summary>
		/// Replace image with a sharpened version of the original image using the unsharp mask algorithm.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<param name="amount">The percentage of the difference between the original and the blur image
		/// that is added back into the original.</param>
		///<param name="threshold">The threshold in pixels needed to apply the diffence amount.</param>
		///<exception cref="MagickException"/>
		void Unsharpmask(double radius, double sigma, double amount, double threshold);
		///==========================================================================================
		///<summary>
		/// Replace image with a sharpened version of the original image using the unsharp mask algorithm.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<param name="amount">The percentage of the difference between the original and the blur image
		/// that is added back into the original.</param>
		///<param name="threshold">The threshold in pixels needed to apply the diffence amount.</param>
		///<param name="channels">The channel(s) that should be sharpened.</param>
		///<exception cref="MagickException"/>
		void Unsharpmask(double radius, double sigma, double amount, double threshold, Channels channels);
		///==========================================================================================
		///<summary>
		/// Softens the edges of the image in vignette style.
		///</summary>
		///<exception cref="MagickException"/>
		void Vignette();
		///==========================================================================================
		///<summary>
		/// Softens the edges of the image in vignette style.
		///</summary>
		///<param name="radius">The radius of the Gaussian, in pixels, not counting the center pixel.</param>
		///<param name="sigma">The standard deviation of the Laplacian, in pixels.</param>
		///<param name="x">The x ellipse offset.</param>
		///<param name="y">the y ellipse offset.</param>
		///<exception cref="MagickException"/>
		void Vignette(double radius, double sigma, int x, int y);
		///==========================================================================================
		///<summary>
		/// Map image pixels to a sine wave.
		///</summary>
		///<exception cref="MagickException"/>
		void Wave();
		///==========================================================================================
		///<summary>
		/// Map image pixels to a sine wave.
		///</summary>
		///<param name="amplitude">The amplitude.</param>
		///<param name="length">The length of the wave.</param>
		///<exception cref="MagickException"/>
		void Wave(double amplitude, double length);
		///==========================================================================================
		///<summary>
		/// Forces all pixels above the threshold into white while leaving all pixels at or below
		/// the threshold unchanged.
		///</summary>
		///<param name="threshold">The threshold to use.</param>
		///<exception cref="MagickException"/>
		void WhiteThreshold(Percentage threshold);
		///==========================================================================================
		///<summary>
		/// Forces all pixels above the threshold into white while leaving all pixels at or below
		/// the threshold unchanged.
		///</summary>
		///<param name="threshold">The threshold to use.</param>
		///<param name="channels">The channel(s) to make black.</param>
		///<exception cref="MagickException"/>
		void WhiteThreshold(Percentage threshold, Channels channels);
		///==========================================================================================
		///<summary>
		/// Writes the image to the specified file.
		///</summary>
		///<param name="file">The file to write the image to.</param>
		///<exception cref="MagickException"/>
		void Write(FileInfo^ file);
		///==========================================================================================
		///<summary>
		/// Writes the image to the specified stream.
		///</summary>
		///<param name="stream">The stream to write the image data to.</param>
		///<exception cref="MagickException"/>
		void Write(Stream^ stream);
		///==========================================================================================
		///<summary>
		/// Writes the image to the specified stream.
		///</summary>
		///<param name="stream">The stream to write the image data to.</param>
		///<param name="format">The format to use.</param>
		///<exception cref="MagickException"/>
		void Write(Stream^ stream, MagickFormat format);
		///==========================================================================================
		///<summary>
		/// Writes the image to the specified file name.
		///</summary>
		///<param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
		///<exception cref="MagickException"/>
		void Write(String^ fileName);
		///==========================================================================================
		///<summary>
		// Zoom image to specified size.
		///</summary>
		///<param name="width">The new width.</param>
		///<param name="height">The new height.</param>
		///<exception cref="MagickException"/>
		void Zoom(int width, int height);
		///==========================================================================================
		///<summary>
		// Zoom image to specified size.
		///</summary>
		///<param name="geometry">The geometry to use.</param>
		///<exception cref="MagickException"/>
		void Zoom(MagickGeometry^ geometry);
		///==========================================================================================
		///<summary>
		// Zoom image to specified size.
		///</summary>
		///<param name="percentage">The percentage.</param>
		///<exception cref="MagickException"/>
		void Zoom(Percentage percentage);
		///==========================================================================================
		///<summary>
		/// Zoom image to specified size.
		///</summary>
		///<param name="percentageWidth">The percentage of the width.</param>
		///<param name="percentageHeight">The percentage of the height.</param>
		///<exception cref="MagickException"/>
		void Zoom(Percentage percentageWidth, Percentage percentageHeight);
		//===========================================================================================
#if !(NET20)
		///==========================================================================================
		///<summary>
		/// Converts this instance to a BitmapSource.
		///</summary>
		BitmapSource^ ToBitmapSource();
		//===========================================================================================
#endif
		//===========================================================================================
	};
	//==============================================================================================
}