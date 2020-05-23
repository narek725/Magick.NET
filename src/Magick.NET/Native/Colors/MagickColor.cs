// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
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
    public partial class MagickColor
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
                public static extern IntPtr MagickColor_Create();
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong MagickColor_Count_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern QuantumType MagickColor_Red_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Red_Set(IntPtr instance, QuantumType value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern QuantumType MagickColor_Green_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Green_Set(IntPtr instance, QuantumType value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern QuantumType MagickColor_Blue_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Blue_Set(IntPtr instance, QuantumType value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern QuantumType MagickColor_Alpha_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Alpha_Set(IntPtr instance, QuantumType value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern QuantumType MagickColor_Black_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Black_Set(IntPtr instance, QuantumType value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool MagickColor_IsCMYK_Get(IntPtr instance);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_IsCMYK_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool MagickColor_FuzzyEquals(IntPtr Instance, IntPtr other, QuantumType fuzz);
                [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool MagickColor_Initialize(IntPtr Instance, IntPtr value);
            }
            #endif
            #if PLATFORM_x86 || PLATFORM_AnyCPU
            public static class X86
            {
                #if PLATFORM_AnyCPU
                static X86() { NativeLibraryLoader.Load(); }
                #endif
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern IntPtr MagickColor_Create();
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Dispose(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern ulong MagickColor_Count_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern QuantumType MagickColor_Red_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Red_Set(IntPtr instance, QuantumType value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern QuantumType MagickColor_Green_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Green_Set(IntPtr instance, QuantumType value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern QuantumType MagickColor_Blue_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Blue_Set(IntPtr instance, QuantumType value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern QuantumType MagickColor_Alpha_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Alpha_Set(IntPtr instance, QuantumType value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern QuantumType MagickColor_Black_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_Black_Set(IntPtr instance, QuantumType value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool MagickColor_IsCMYK_Get(IntPtr instance);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                public static extern void MagickColor_IsCMYK_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool MagickColor_FuzzyEquals(IntPtr Instance, IntPtr other, QuantumType fuzz);
                [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
                [return: MarshalAs(UnmanagedType.Bool)]
                public static extern bool MagickColor_Initialize(IntPtr Instance, IntPtr value);
            }
            #endif
        }
        private sealed class NativeMagickColor : NativeInstance
        {
            static NativeMagickColor() { Environment.Initialize(); }
            protected override void Dispose(IntPtr instance)
            {
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                NativeMethods.X64.MagickColor_Dispose(instance);
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                NativeMethods.X86.MagickColor_Dispose(instance);
                #endif
            }
            public NativeMagickColor()
            {
                #if PLATFORM_AnyCPU
                if (NativeLibrary.Is64Bit)
                #endif
                #if PLATFORM_x64 || PLATFORM_AnyCPU
                Instance = NativeMethods.X64.MagickColor_Create();
                #endif
                #if PLATFORM_AnyCPU
                else
                #endif
                #if PLATFORM_x86 || PLATFORM_AnyCPU
                Instance = NativeMethods.X86.MagickColor_Create();
                #endif
                if (Instance == IntPtr.Zero)
                    throw new InvalidOperationException();
            }
            public NativeMagickColor(IntPtr instance)
            {
                Instance = instance;
            }
            protected override string TypeName
            {
                get
                {
                    return nameof(MagickColor);
                }
            }
            public ulong Count
            {
                get
                {
                    ulong result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickColor_Count_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickColor_Count_Get(Instance);
                    #endif
                    return result;
                }
            }
            public QuantumType Red
            {
                get
                {
                    QuantumType result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickColor_Red_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickColor_Red_Get(Instance);
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.MagickColor_Red_Set(Instance, value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.MagickColor_Red_Set(Instance, value);
                    #endif
                }
            }
            public QuantumType Green
            {
                get
                {
                    QuantumType result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickColor_Green_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickColor_Green_Get(Instance);
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.MagickColor_Green_Set(Instance, value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.MagickColor_Green_Set(Instance, value);
                    #endif
                }
            }
            public QuantumType Blue
            {
                get
                {
                    QuantumType result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickColor_Blue_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickColor_Blue_Get(Instance);
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.MagickColor_Blue_Set(Instance, value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.MagickColor_Blue_Set(Instance, value);
                    #endif
                }
            }
            public QuantumType Alpha
            {
                get
                {
                    QuantumType result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickColor_Alpha_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickColor_Alpha_Get(Instance);
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.MagickColor_Alpha_Set(Instance, value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.MagickColor_Alpha_Set(Instance, value);
                    #endif
                }
            }
            public QuantumType Black
            {
                get
                {
                    QuantumType result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickColor_Black_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickColor_Black_Get(Instance);
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.MagickColor_Black_Set(Instance, value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.MagickColor_Black_Set(Instance, value);
                    #endif
                }
            }
            public bool IsCMYK
            {
                get
                {
                    bool result;
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    result = NativeMethods.X64.MagickColor_IsCMYK_Get(Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    result = NativeMethods.X86.MagickColor_IsCMYK_Get(Instance);
                    #endif
                    return result;
                }
                set
                {
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    NativeMethods.X64.MagickColor_IsCMYK_Set(Instance, value);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    NativeMethods.X86.MagickColor_IsCMYK_Set(Instance, value);
                    #endif
                }
            }
            public bool FuzzyEquals(IMagickColor<QuantumType> other, QuantumType fuzz)
            {
                using (INativeInstance otherNative = MagickColor.CreateInstance(other))
                {
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    return NativeMethods.X64.MagickColor_FuzzyEquals(Instance, otherNative.Instance, fuzz);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    return NativeMethods.X86.MagickColor_FuzzyEquals(Instance, otherNative.Instance, fuzz);
                    #endif
                }
            }
            public bool Initialize(string value)
            {
                using (INativeInstance valueNative = UTF8Marshaler.CreateInstance(value))
                {
                    #if PLATFORM_AnyCPU
                    if (NativeLibrary.Is64Bit)
                    #endif
                    #if PLATFORM_x64 || PLATFORM_AnyCPU
                    return NativeMethods.X64.MagickColor_Initialize(Instance, valueNative.Instance);
                    #endif
                    #if PLATFORM_AnyCPU
                    else
                    #endif
                    #if PLATFORM_x86 || PLATFORM_AnyCPU
                    return NativeMethods.X86.MagickColor_Initialize(Instance, valueNative.Instance);
                    #endif
                }
            }
        }
        internal static INativeInstance CreateInstance(IMagickColor<QuantumType> instance)
        {
            if (instance == null)
                return NativeInstance.Zero;
            return MagickColor.CreateNativeInstance(instance);
        }
        internal static IMagickColor<QuantumType> CreateInstance(IntPtr instance)
        {
            if (instance == IntPtr.Zero)
                return null;
            using (NativeMagickColor nativeInstance = new NativeMagickColor(instance))
            {
                return new MagickColor(nativeInstance);
            }
        }
    }
}
