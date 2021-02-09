﻿// Copyright 2013-2021 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System.Collections.Generic;
using System.IO;
#if NETSTANDARD
using System.Threading.Tasks;
#endif

namespace ImageMagick
{
    /// <summary>
    /// Represents the collection of images.
    /// </summary>
    /// <typeparam name="TQuantumType">The quantum type.</typeparam>
    public interface IMagickImageCollection<TQuantumType> : IMagickImageCollection, IList<IMagickImage<TQuantumType>>
        where TQuantumType : struct
    {
        /// <summary>
        /// Adds the image(s) from the specified byte array to the collection.
        /// </summary>
        /// <param name="data">The byte array to read the image data from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void AddRange(byte[] data, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Adds a Clone of the specified images to this collection.
        /// </summary>
        /// <param name="images">The images to add to the collection.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void AddRange(IEnumerable<IMagickImage<TQuantumType>> images);

        /// <summary>
        /// Adds the image(s) from the specified file name to the collection.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void AddRange(string fileName, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Adds the image(s) from the specified stream to the collection.
        /// </summary>
        /// <param name="stream">The stream to read the images from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void AddRange(Stream stream, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Creates a single image, by appending all the images in the collection horizontally (+append).
        /// </summary>
        /// <returns>A single image, by appending all the images in the collection horizontally (+append).</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> AppendHorizontally();

        /// <summary>
        /// Creates a single image, by appending all the images in the collection vertically (-append).
        /// </summary>
        /// <returns>A single image, by appending all the images in the collection vertically (-append).</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> AppendVertically();

        /// <summary>
        /// Creates a clone of the current image collection.
        /// </summary>
        /// <returns>A clone of the current image collection.</returns>
        IMagickImageCollection<TQuantumType> Clone();

        /// <summary>
        /// Combines the images into a single image. The typical ordering would be
        /// image 1 => Red, 2 => Green, 3 => Blue, etc.
        /// </summary>
        /// <returns>The images combined into a single image.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> Combine();

        /// <summary>
        /// Combines the images into a single image. The grayscale value of the pixels of each image
        /// in the sequence is assigned in order to the specified channels of the combined image.
        /// The typical ordering would be image 1 => Red, 2 => Green, 3 => Blue, etc.
        /// </summary>
        /// <param name="colorSpace">The image colorspace.</param>
        /// <returns>The images combined into a single image.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> Combine(ColorSpace colorSpace);

        /// <summary>
        /// Evaluate image pixels into a single image. All the images in the collection must be the
        /// same size in pixels.
        /// </summary>
        /// <param name="evaluateOperator">The operator.</param>
        /// <returns>The resulting image of the evaluation.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> Evaluate(EvaluateOperator evaluateOperator);

        /// <summary>
        /// Use the virtual canvas size of first image. Images which fall outside this canvas is clipped.
        /// This can be used to 'fill out' a given virtual canvas.
        /// </summary>
        /// <returns>The resulting image of the flatten operation.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> Flatten();

        /// <summary>
        /// Flatten this collection into a single image.
        /// This is useful for combining Photoshop layers into a single image.
        /// </summary>
        /// <param name="backgroundColor">The background color of the output image.</param>
        /// <returns>The resulting image of the flatten operation.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> Flatten(IMagickColor<TQuantumType> backgroundColor);

        /// <summary>
        /// Remap image colors with closest color from reference image.
        /// </summary>
        /// <param name="image">The image to use.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Map(IMagickImage<TQuantumType> image);

        /// <summary>
        /// Remap image colors with closest color from reference image.
        /// </summary>
        /// <param name="image">The image to use.</param>
        /// <param name="settings">Quantize settings.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Map(IMagickImage<TQuantumType> image, IQuantizeSettings settings);

        /// <summary>
        /// Merge all layers onto a canvas just large enough to hold all the actual images. The virtual
        /// canvas of the first image is preserved but otherwise ignored.
        /// </summary>
        /// <returns>The resulting image of the merge operation.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> Merge();

        /// <summary>
        /// Create a composite image by combining the images with the specified settings.
        /// </summary>
        /// <param name="settings">The settings to use.</param>
        /// <returns>The resulting image of the montage operation.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> Montage(IMontageSettings<TQuantumType> settings);

        /// <summary>
        /// Start with the virtual canvas of the first image, enlarging left and right edges to contain
        /// all images. Images with negative offsets will be clipped.
        /// </summary>
        /// <returns>The resulting image of the mosaic operation.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> Mosaic();

        /// <summary>
        /// Reads only metadata and not the pixel data from all image frames.
        /// </summary>
        /// <param name="data">The byte array to read the image data from.</param>
        /// <param name="offset">The offset at which to begin reading data.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Ping(byte[] data, int offset, int count, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Read only metadata and not the pixel data from all image frames.
        /// </summary>
        /// <param name="data">The byte array to read the image data from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Ping(byte[] data, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Read only metadata and not the pixel data from all image frames.
        /// </summary>
        /// <param name="file">The file to read the frames from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Ping(FileInfo file, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Read only metadata and not the pixel data from all image frames.
        /// </summary>
        /// <param name="stream">The stream to read the image data from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Ping(Stream stream, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Read only metadata and not the pixel data from all image frames.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Ping(string fileName, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Returns a new image where each pixel is the sum of the pixels in the image sequence after applying its
        /// corresponding terms (coefficient and degree pairs).
        /// </summary>
        /// <param name="terms">The list of polynomial coefficients and degree pairs and a constant.</param>
        /// <returns>A new image where each pixel is the sum of the pixels in the image sequence after applying its
        /// corresponding terms (coefficient and degree pairs).</returns>
        IMagickImage<TQuantumType> Polynomial(double[] terms);

        /// <summary>
        /// Read all image frames.
        /// </summary>
        /// <param name="data">The byte array to read the image data from.</param>
        /// <param name="offset">The offset at which to begin reading data.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Read(byte[] data, int offset, int count, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Read all image frames.
        /// </summary>
        /// <param name="data">The byte array to read the image data from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Read(byte[] data, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Read all image frames.
        /// </summary>
        /// <param name="file">The file to read the frames from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Read(FileInfo file, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Read all image frames.
        /// </summary>
        /// <param name="stream">The stream to read the image data from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Read(Stream stream, IMagickReadSettings<TQuantumType> readSettings);

        /// <summary>
        /// Read all image frames.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        void Read(string fileName, IMagickReadSettings<TQuantumType> readSettings);

#if NETSTANDARD
        /// <summary>
        /// Read all image frames.
        /// </summary>
        /// <param name="stream">The stream to read the image data from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task ReadAsync(Stream stream, IMagickReadSettings<TQuantumType> readSettings);
#endif

        /// <summary>
        /// Smush images from list into single image in horizontal direction.
        /// </summary>
        /// <param name="offset">Minimum distance in pixels between images.</param>
        /// <returns>The resulting image of the smush operation.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> SmushHorizontal(int offset);

        /// <summary>
        /// Smush images from list into single image in vertical direction.
        /// </summary>
        /// <param name="offset">Minimum distance in pixels between images.</param>
        /// <returns>The resulting image of the smush operation.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImage<TQuantumType> SmushVertical(int offset);
    }
}