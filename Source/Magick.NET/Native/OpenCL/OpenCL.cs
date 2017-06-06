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

namespace ImageMagick
{
  public static partial class OpenCL
  {
    private static class NativeMethods
    {
      #if PLATFORM_x64 || PLATFORM_AnyCPU
      public static class X64
      {
        #if PLATFORM_AnyCPU
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.OpenCL+NativeMethods.X64#.cctor()")]
        static X64() { NativeLibraryLoader.Load(); }
        #endif
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr OpenCL_GetDevices(out UIntPtr length);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr OpenCL_GetDevice(IntPtr list, UIntPtr index);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenCL_SetEnabled([MarshalAs(UnmanagedType.Bool)] bool value);
      }
      #endif
      #if PLATFORM_x86 || PLATFORM_AnyCPU
      public static class X86
      {
        #if PLATFORM_AnyCPU
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.OpenCL+NativeMethods.X86#.cctor()")]
        static X86() { NativeLibraryLoader.Load(); }
        #endif
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr OpenCL_GetDevices(out UIntPtr length);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr OpenCL_GetDevice(IntPtr list, UIntPtr index);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool OpenCL_SetEnabled([MarshalAs(UnmanagedType.Bool)] bool value);
      }
      #endif
    }
    private static class NativeOpenCL
    {
      public static IntPtr GetDevices(out UIntPtr length)
      {
        #if PLATFORM_AnyCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if PLATFORM_x64 || PLATFORM_AnyCPU
        return NativeMethods.X64.OpenCL_GetDevices(out length);
        #endif
        #if PLATFORM_AnyCPU
        else
        #endif
        #if PLATFORM_x86 || PLATFORM_AnyCPU
        return NativeMethods.X86.OpenCL_GetDevices(out length);
        #endif
      }
      public static IntPtr GetDevice(IntPtr list, int index)
      {
        #if PLATFORM_AnyCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if PLATFORM_x64 || PLATFORM_AnyCPU
        return NativeMethods.X64.OpenCL_GetDevice(list, (UIntPtr)index);
        #endif
        #if PLATFORM_AnyCPU
        else
        #endif
        #if PLATFORM_x86 || PLATFORM_AnyCPU
        return NativeMethods.X86.OpenCL_GetDevice(list, (UIntPtr)index);
        #endif
      }
      public static bool SetEnabled(bool value)
      {
        #if PLATFORM_AnyCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if PLATFORM_x64 || PLATFORM_AnyCPU
        return NativeMethods.X64.OpenCL_SetEnabled(value);
        #endif
        #if PLATFORM_AnyCPU
        else
        #endif
        #if PLATFORM_x86 || PLATFORM_AnyCPU
        return NativeMethods.X86.OpenCL_SetEnabled(value);
        #endif
      }
    }
  }
}
