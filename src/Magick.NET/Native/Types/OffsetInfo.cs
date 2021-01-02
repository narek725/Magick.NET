// Copyright 2013-2021 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.
// <auto-generated/>

using System;
using System.Security;
using System.Runtime.InteropServices;

namespace ImageMagick
{
    internal partial class OffsetInfo
    {
        #if !NETSTANDARD1_3
        [SuppressUnmanagedCodeSecurity]
        #endif
        private static class NativeMethods
        {
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            public static class X64
            {
                #if PLATFORM_AnyCPU
                static X64() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr OffsetInfo_Create();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void OffsetInfo_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void OffsetInfo_SetX(IntPtr Instance, UIntPtr value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void OffsetInfo_SetY(IntPtr Instance, UIntPtr value);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                #if PLATFORM_AnyCPU
                static X86() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr OffsetInfo_Create();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void OffsetInfo_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void OffsetInfo_SetX(IntPtr Instance, UIntPtr value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void OffsetInfo_SetY(IntPtr Instance, UIntPtr value);
            }
            #endif
        }
        private sealed class NativeOffsetInfo : NativeInstance
        {
            static NativeOffsetInfo() { Environment.Initialize(); }
            protected override void Dispose(IntPtr instance)
            {
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.OffsetInfo_Dispose(instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.OffsetInfo_Dispose(instance);
                #endif
            }
            public NativeOffsetInfo()
            {
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                Instance = NativeMethods.X64.OffsetInfo_Create();
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                Instance = NativeMethods.X86.OffsetInfo_Create();
                #endif
                if (Instance == IntPtr.Zero)
                    throw new InvalidOperationException();
            }
            protected override string TypeName
            {
                get
                {
                    return nameof(OffsetInfo);
                }
            }
            public void SetX(int value)
            {
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.OffsetInfo_SetX(Instance, (UIntPtr)value);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.OffsetInfo_SetX(Instance, (UIntPtr)value);
                #endif
            }
            public void SetY(int value)
            {
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.OffsetInfo_SetY(Instance, (UIntPtr)value);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.OffsetInfo_SetY(Instance, (UIntPtr)value);
                #endif
            }
        }
        internal static INativeInstance CreateInstance(OffsetInfo instance)
        {
            if (instance == null)
                return NativeInstance.Zero;
            return instance.CreateNativeInstance();
        }
    }
}
