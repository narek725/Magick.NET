﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.IO;

namespace ImageMagick
{
    /// <summary>
    /// Class that can be used to create <see cref="IMagickImageInfo"/> instances.
    /// </summary>
    public interface IMagickImageInfoFactory
    {
        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageInfo"/>.
        /// </summary>
        /// <returns>A new <see cref="IMagickImageInfo"/> instance.</returns>
        IMagickImageInfo Create();

        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageInfo"/>.
        /// </summary>
        /// <param name="data">The byte array to read the information from.</param>
        /// <returns>A new <see cref="IMagickImageInfo"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImageInfo Create(byte[] data);

        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageInfo"/>.
        /// </summary>
        /// <param name="data">The byte array to read the information from.</param>
        /// <param name="offset">The offset at which to begin reading data.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>A new <see cref="IMagickImageInfo"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImageInfo Create(byte[] data, int offset, int count);

        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageInfo"/>.
        /// </summary>
        /// <param name="file">The file to read the image from.</param>
        /// <returns>A new <see cref="IMagickImageInfo"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImageInfo Create(FileInfo file);

        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageInfo"/>.
        /// </summary>
        /// <param name="stream">The stream to read the image data from.</param>
        /// <returns>A new <see cref="IMagickImageInfo"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImageInfo Create(Stream stream);

        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageInfo"/>.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
        /// <returns>A new <see cref="IMagickImageInfo"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        IMagickImageInfo Create(string fileName);
    }
}
