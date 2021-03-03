﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;

namespace ImageMagick
{
    /// <summary>
    /// Interface that describes an image profile.
    /// </summary>
    public interface IImageProfile : IEquatable<IImageProfile>
    {
        /// <summary>
        /// Gets the name of the profile.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Returns the <see cref="byte"/> array of this profile.
        /// </summary>
        /// <returns>A <see cref="byte"/> array.</returns>
        byte[]? GetData();

        /// <summary>
        /// Converts this instance to a byte array.
        /// </summary>
        /// <returns>A <see cref="byte"/> array.</returns>
        byte[]? ToByteArray();
    }
}
