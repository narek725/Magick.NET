﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using System.IO;

namespace Magick.NET.Tests
{
    public class TemporaryDirectory : IDisposable
    {
        private DirectoryInfo _tempDirectory;

        public TemporaryDirectory()
            : this(string.Empty)
        {
        }

        public TemporaryDirectory(string directoryName)
        {
            _tempDirectory = new DirectoryInfo(Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + directoryName));
            _tempDirectory.Create();
        }

        public string FullName
            => _tempDirectory.FullName;

        public void Dispose()
            => Cleanup.DeleteDirectory(_tempDirectory);
    }
}
