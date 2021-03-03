﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace ImageMagick
{
    /// <summary>
    /// Class that can be used to create various instances.
    /// </summary>
    /// <typeparam name="TQuantumType">The quantum type.</typeparam>
    public interface IMagickFactory<TQuantumType> : IMagickFactory
        where TQuantumType : struct
    {
        /// <summary>
        /// Gets a factory that can be used to create <see cref="IMagickColorFactory{TQuantumType}"/> instances.
        /// </summary>
        IMagickColorFactory<TQuantumType> Color { get; }

        /// <summary>
        /// Gets a factory that can be used to create <see cref="IDrawables{QuantumType}"/> instances.
        /// </summary>
        IDrawablesFactory<TQuantumType> Drawables { get; }

        /// <summary>
        /// Gets a factory that can be used to create <see cref="IMagickImage{TQuantumType}"/> instances.
        /// </summary>
        IMagickImageFactory<TQuantumType> Image { get; }

        /// <summary>
        /// Gets a factory that can be used to create <see cref="IMagickImageCollection{TQuantumType}"/> instances.
        /// </summary>
        IMagickImageCollectionFactory<TQuantumType> ImageCollection { get; }

        /// <summary>
        /// Gets the quantum information of this image.
        /// </summary>
        IQuantumInfo<TQuantumType> QuantumInfo { get; }

        /// <summary>
        /// Gets a factory that can be used to create various settings.
        /// </summary>
        ISettingsFactory<TQuantumType> Settings { get; }
    }
}
