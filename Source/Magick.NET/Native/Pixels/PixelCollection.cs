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
    public partial class PixelCollection : IDisposable
    {
        private static class NativeMethods
        {
            #if PLATFORM_x64 || PLATFORM_AnyCPU
            public static class X64
            {
                #if PLATFORM_AnyCPU
                [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.PixelCollection+NativeMethods.X64#.cctor()")]
                static X64() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_Create(IntPtr image, out IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PixelCollection_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_GetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, out IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PixelCollection_SetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, QuantumType[] values, UIntPtr length, out IntPtr exception);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_ToByteArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                #if PLATFORM_AnyCPU
                [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.PixelCollection+NativeMethods.X86#.cctor()")]
                static X86() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_Create(IntPtr image, out IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PixelCollection_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_GetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, out IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void PixelCollection_SetArea(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, QuantumType[] values, UIntPtr length, out IntPtr exception);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr PixelCollection_ToByteArray(IntPtr Instance, UIntPtr x, UIntPtr y, UIntPtr width, UIntPtr height, IntPtr mapping, out IntPtr exception);
            }
            #endif
        }
        private NativePixelCollection _NativeInstance;
        private sealed class NativePixelCollection : NativeInstance
        {
            protected override void Dispose(IntPtr instance)
            {
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.PixelCollection_Dispose(instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.PixelCollection_Dispose(instance);
                #endif
            }
            public NativePixelCollection(IMagickImage image)
            {
                IntPtr exception = IntPtr.Zero;
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                Instance = NativeMethods.X64.PixelCollection_Create(image.GetInstance(), out exception);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                Instance = NativeMethods.X86.PixelCollection_Create(image.GetInstance(), out exception);
                #endif
                CheckException(exception, Instance);
                if (Instance == IntPtr.Zero)
                    throw new InvalidOperationException();
            }
            protected override string TypeName
            {
                get
                {
                    return nameof(PixelCollection);
                }
            }
            public IntPtr GetArea(int x, int y, int width, int height)
            {
                IntPtr exception = IntPtr.Zero;
                IntPtr result;
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                result = NativeMethods.X64.PixelCollection_GetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, out exception);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                result = NativeMethods.X86.PixelCollection_GetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, out exception);
                #endif
                CheckException(exception);
                return result;
            }
            public void SetArea(int x, int y, int width, int height, QuantumType[] values, int length)
            {
                IntPtr exception = IntPtr.Zero;
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.PixelCollection_SetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, values, (UIntPtr)length, out exception);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.PixelCollection_SetArea(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, values, (UIntPtr)length, out exception);
                #endif
                CheckException(exception);
            }
            public IntPtr ToByteArray(int x, int y, int width, int height, string mapping)
            {
                using (INativeInstance mappingNative = UTF8Marshaler.CreateInstance(mapping))
                {
                    IntPtr exception = IntPtr.Zero;
                    IntPtr result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.PixelCollection_ToByteArray(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, mappingNative.Instance, out exception);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.PixelCollection_ToByteArray(Instance, (UIntPtr)x, (UIntPtr)y, (UIntPtr)width, (UIntPtr)height, mappingNative.Instance, out exception);
                    #endif
                    MagickException magickException = MagickExceptionHelper.Create(exception);
                    if (MagickExceptionHelper.IsError(magickException))
                    {
                        if (result != IntPtr.Zero)
                            MagickMemory.Relinquish(result);
                        throw magickException;
                    }
                    RaiseWarning(magickException);
                    return result;
                }
            }
        }
    }
}
