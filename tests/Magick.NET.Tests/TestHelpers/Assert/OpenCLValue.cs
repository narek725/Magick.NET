﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using ImageMagick;

namespace Magick.NET.Tests
{
    internal static class OpenCLValue
    {
        private static bool HasEnabledOpenCLDevices
        {
            get
            {
                if (OpenCL.IsEnabled == false)
                    return false;

                foreach (var device in OpenCL.Devices)
                {
                    if (device.IsEnabled)
                        return true;
                }

                return false;
            }
        }

        public static void Assert(double expectedWith, double expectedWithout, double value, double delta)
        {
            if (HasEnabledOpenCLDevices)
                Xunit.Assert.InRange(value, expectedWith - delta, expectedWith + delta);
            else
                Xunit.Assert.InRange(value, expectedWithout - delta, expectedWithout + delta);
        }

        public static void Assert<T>(T expectedWith, T expectedWithout, T value)
            => Xunit.Assert.Equal(Get(expectedWith, expectedWithout), value);

        public static T Get<T>(T expectedWith, T expectedWithout)
        {
            if (HasEnabledOpenCLDevices)
                return expectedWith;
            else
                return expectedWithout;
        }
    }
}
