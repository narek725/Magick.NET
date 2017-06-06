//=================================================================================================
// Copyright 2013-2017 Dirk Lemstra <https://magick.codeplex.com/>
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
// <auto-generated/>

using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ImageMagick.ImageOptimizers
{
  public partial class JpegOptimizer
  {
    private static class NativeMethods
    {
      #if PLATFORM_x64 || PLATFORM_AnyCPU
      public static class X64
      {
        #if PLATFORM_AnyCPU
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.JpegOptimizer+NativeMethods.X64#.cctor()")]
        static X64() { NativeLibraryLoader.Load(); }
        #endif
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr JpegOptimizer_Compress(IntPtr input, IntPtr output, [MarshalAs(UnmanagedType.Bool)] bool progressive, [MarshalAs(UnmanagedType.Bool)] bool lossless, UIntPtr quality);
      }
      #endif
      #if PLATFORM_x86 || PLATFORM_AnyCPU
      public static class X86
      {
        #if PLATFORM_AnyCPU
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.JpegOptimizer+NativeMethods.X86#.cctor()")]
        static X86() { NativeLibraryLoader.Load(); }
        #endif
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr JpegOptimizer_Compress(IntPtr input, IntPtr output, [MarshalAs(UnmanagedType.Bool)] bool progressive, [MarshalAs(UnmanagedType.Bool)] bool lossless, UIntPtr quality);
      }
      #endif
    }
    private static class NativeJpegOptimizer
    {
      public static int Compress(string input, string output, bool progressive, bool lossless, int quality)
      {
        using (INativeInstance inputNative = UTF8Marshaler.CreateInstance(input))
        {
          using (INativeInstance outputNative = UTF8Marshaler.CreateInstance(output))
          {
            #if PLATFORM_AnyCPU
            if (NativeLibrary.Is64Bit)
            #endif
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            return (int)NativeMethods.X64.JpegOptimizer_Compress(inputNative.Instance, outputNative.Instance, progressive, lossless, (UIntPtr)quality);
            #endif
            #if PLATFORM_AnyCPU
            else
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            return (int)NativeMethods.X86.JpegOptimizer_Compress(inputNative.Instance, outputNative.Instance, progressive, lossless, (UIntPtr)quality);
            #endif
          }
        }
      }
    }
  }
}
