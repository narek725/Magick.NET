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
  public partial class ConnectedComponent
  {
    private static class NativeMethods
    {
      #if WIN64 || ANYCPU
      public static class X64
      {
        #if ANYCPU
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.ConnectedComponent+NativeMethods.X64#.cctor()")]
        static X64() { NativeLibraryLoader.Load(); }
        #endif
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ConnectedComponent_DisposeList(IntPtr list);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ConnectedComponent_GetArea(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr ConnectedComponent_GetHeight(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConnectedComponent_GetInstance(IntPtr list, UIntPtr index);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr ConnectedComponent_GetWidth(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConnectedComponent_GetX(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConnectedComponent_GetY(IntPtr instance);
      }
      #endif
      #if !WIN64 || ANYCPU
      public static class X86
      {
        #if ANYCPU
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.ConnectedComponent+NativeMethods.X86#.cctor()")]
        static X86() { NativeLibraryLoader.Load(); }
        #endif
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void ConnectedComponent_DisposeList(IntPtr list);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double ConnectedComponent_GetArea(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr ConnectedComponent_GetHeight(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConnectedComponent_GetInstance(IntPtr list, UIntPtr index);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr ConnectedComponent_GetWidth(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConnectedComponent_GetX(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ConnectedComponent_GetY(IntPtr instance);
      }
      #endif
    }
    private static class NativeConnectedComponent
    {
      public static void DisposeList(IntPtr list)
      {
        #if ANYCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if WIN64 || ANYCPU
        NativeMethods.X64.ConnectedComponent_DisposeList(list);
        #endif
        #if ANYCPU
        else
        #endif
        #if !WIN64 || ANYCPU
        NativeMethods.X86.ConnectedComponent_DisposeList(list);
        #endif
      }
      public static double GetArea(IntPtr instance)
      {
        #if ANYCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if WIN64 || ANYCPU
        return NativeMethods.X64.ConnectedComponent_GetArea(instance);
        #endif
        #if ANYCPU
        else
        #endif
        #if !WIN64 || ANYCPU
        return NativeMethods.X86.ConnectedComponent_GetArea(instance);
        #endif
      }
      public static int GetHeight(IntPtr instance)
      {
        #if ANYCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if WIN64 || ANYCPU
        return (int)NativeMethods.X64.ConnectedComponent_GetHeight(instance);
        #endif
        #if ANYCPU
        else
        #endif
        #if !WIN64 || ANYCPU
        return (int)NativeMethods.X86.ConnectedComponent_GetHeight(instance);
        #endif
      }
      public static IntPtr GetInstance(IntPtr list, int index)
      {
        #if ANYCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if WIN64 || ANYCPU
        return NativeMethods.X64.ConnectedComponent_GetInstance(list, (UIntPtr)index);
        #endif
        #if ANYCPU
        else
        #endif
        #if !WIN64 || ANYCPU
        return NativeMethods.X86.ConnectedComponent_GetInstance(list, (UIntPtr)index);
        #endif
      }
      public static int GetWidth(IntPtr instance)
      {
        #if ANYCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if WIN64 || ANYCPU
        return (int)NativeMethods.X64.ConnectedComponent_GetWidth(instance);
        #endif
        #if ANYCPU
        else
        #endif
        #if !WIN64 || ANYCPU
        return (int)NativeMethods.X86.ConnectedComponent_GetWidth(instance);
        #endif
      }
      public static int GetX(IntPtr instance)
      {
        #if ANYCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if WIN64 || ANYCPU
        return (int)NativeMethods.X64.ConnectedComponent_GetX(instance);
        #endif
        #if ANYCPU
        else
        #endif
        #if !WIN64 || ANYCPU
        return (int)NativeMethods.X86.ConnectedComponent_GetX(instance);
        #endif
      }
      public static int GetY(IntPtr instance)
      {
        #if ANYCPU
        if (NativeLibrary.Is64Bit)
        #endif
        #if WIN64 || ANYCPU
        return (int)NativeMethods.X64.ConnectedComponent_GetY(instance);
        #endif
        #if ANYCPU
        else
        #endif
        #if !WIN64 || ANYCPU
        return (int)NativeMethods.X86.ConnectedComponent_GetY(instance);
        #endif
      }
    }
  }
}
