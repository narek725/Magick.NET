﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace ImageMagick
{
    /// <summary>
    /// Interface that represents a kernel profile record for an OpenCL device.
    /// </summary>
    public interface IOpenCLKernelProfileRecord
    {
        /// <summary>
        /// Gets the average duration of all executions in microseconds.
        /// </summary>
        long AverageDuration { get; }

        /// <summary>
        /// Gets the number of times that this kernel was executed.
        /// </summary>
        long Count { get; }

        /// <summary>
        /// Gets the maximum duration of a single execution in microseconds.
        /// </summary>
        long MaximumDuration { get; }

        /// <summary>
        /// Gets the minimum duration of a single execution in microseconds.
        /// </summary>
        long MinimumDuration { get; }

        /// <summary>
        /// Gets the name of the device.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the total duration of all executions in microseconds.
        /// </summary>
        long TotalDuration { get; }
    }
}