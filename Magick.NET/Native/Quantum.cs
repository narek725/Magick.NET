//=================================================================================================
// Copyright 2013-2016 Dirk Lemstra <https://magick.codeplex.com/>
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
  public static partial class Quantum
  {
    private static class NativeMethods
    {
      #if WIN64 || ANYCPU
      public static class X64
      {
        #if ANYCPU
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.Quantum+NativeMethods.X64#.cctor()")]
        static X64() { NativeLibraryLoader.Load(); }
        #endif
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr Quantum_Depth_Get();
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern QuantumType Quantum_Max_Get();
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte Quantum_ScaleToByte(QuantumType value);
      }
      #endif
      #if !WIN64 || ANYCPU
      public static class X86
      {
        #if ANYCPU
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.Quantum+NativeMethods.X86#.cctor()")]
        static X86() { NativeLibraryLoader.Load(); }
        #endif
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr Quantum_Depth_Get();
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern QuantumType Quantum_Max_Get();
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte Quantum_ScaleToByte(QuantumType value);
      }
      #endif
    }
    private static class NativeQuantum
    {
      public static int Depth
      {
        get
        {
          UIntPtr result;
          #if ANYCPU
          if (NativeLibrary.Is64Bit)
          #endif
          #if WIN64 || ANYCPU
          result = NativeMethods.X64.Quantum_Depth_Get();
          #endif
          #if ANYCPU
          else
          #endif
          #if !WIN64 || ANYCPU
          result = NativeMethods.X86.Quantum_Depth_Get();
          #endif
          return (int)result;
        }
      }
      public static QuantumType Max
      {
        get
        {
          QuantumType result;
          #if ANYCPU
          if (NativeLibrary.Is64Bit)
          #endif
          #if WIN64 || ANYCPU
          result = NativeMethods.X64.Quantum_Max_Get();
          #endif
          #if ANYCPU
          else
          #endif
          #if !WIN64 || ANYCPU
          result = NativeMethods.X86.Quantum_Max_Get();
          #endif
          return result;
        }
      }
      public static byte ScaleToByte(QuantumType value)
      {
        #if ANYCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if WIN64 || ANYCPU
        return NativeMethods.X64.Quantum_ScaleToByte(value);
        #endif
        #if ANYCPU
        else
        #endif
        #if !WIN64 || ANYCPU
        return NativeMethods.X86.Quantum_ScaleToByte(value);
        #endif
      }
    }
  }
}
