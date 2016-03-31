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
  public partial class TypeMetric
  {
    private static class NativeMethods
    {
      public static class X64
      {
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.TypeMetric+NativeMethods.X64#.cctor()")]
        static X64() { NativeLibraryLoader.Load(); }
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TypeMetric_Dispose(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_Ascent_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_Descent_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_MaxHorizontalAdvance_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_TextHeight_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_TextWidth_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_UnderlinePosition_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_UnderlineThickness_Get(IntPtr instance);
      }
      public static class X86
      {
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.TypeMetric+NativeMethods.X86#.cctor()")]
        static X86() { NativeLibraryLoader.Load(); }
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TypeMetric_Dispose(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_Ascent_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_Descent_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_MaxHorizontalAdvance_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_TextHeight_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_TextWidth_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_UnderlinePosition_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double TypeMetric_UnderlineThickness_Get(IntPtr instance);
      }
    }
    private sealed class NativeTypeMetric : NativeInstance
    {
      private IntPtr _Instance = IntPtr.Zero;
      protected override void Dispose(IntPtr instance)
      {
        DisposeInstance(instance);
      }
      public static void DisposeInstance(IntPtr instance)
      {
        if (NativeLibrary.Is64Bit)
          NativeMethods.X64.TypeMetric_Dispose(instance);
        else
          NativeMethods.X86.TypeMetric_Dispose(instance);
      }
      public NativeTypeMetric(IntPtr instance)
      {
        _Instance = instance;
      }
      public override IntPtr Instance
      {
        get
        {
          if (_Instance == IntPtr.Zero)
            throw new ObjectDisposedException(typeof(TypeMetric).ToString());
          return _Instance;
        }
        set
        {
          if (_Instance != IntPtr.Zero)
            Dispose(_Instance);
          _Instance = value;
        }
      }
      public double Ascent
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.TypeMetric_Ascent_Get(Instance);
          else
            result = NativeMethods.X86.TypeMetric_Ascent_Get(Instance);
          return result;
        }
      }
      public double Descent
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.TypeMetric_Descent_Get(Instance);
          else
            result = NativeMethods.X86.TypeMetric_Descent_Get(Instance);
          return result;
        }
      }
      public double MaxHorizontalAdvance
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.TypeMetric_MaxHorizontalAdvance_Get(Instance);
          else
            result = NativeMethods.X86.TypeMetric_MaxHorizontalAdvance_Get(Instance);
          return result;
        }
      }
      public double TextHeight
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.TypeMetric_TextHeight_Get(Instance);
          else
            result = NativeMethods.X86.TypeMetric_TextHeight_Get(Instance);
          return result;
        }
      }
      public double TextWidth
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.TypeMetric_TextWidth_Get(Instance);
          else
            result = NativeMethods.X86.TypeMetric_TextWidth_Get(Instance);
          return result;
        }
      }
      public double UnderlinePosition
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.TypeMetric_UnderlinePosition_Get(Instance);
          else
            result = NativeMethods.X86.TypeMetric_UnderlinePosition_Get(Instance);
          return result;
        }
      }
      public double UnderlineThickness
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.TypeMetric_UnderlineThickness_Get(Instance);
          else
            result = NativeMethods.X86.TypeMetric_UnderlineThickness_Get(Instance);
          return result;
        }
      }
    }
    internal static TypeMetric CreateInstance(IntPtr instance)
    {
      if (instance == IntPtr.Zero)
        return null;
      using (NativeTypeMetric nativeInstance = new NativeTypeMetric(instance))
      {
        return new TypeMetric(nativeInstance);
      }
    }
  }
}
