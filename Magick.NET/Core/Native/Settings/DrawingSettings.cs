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
  internal partial class DrawingSettings
  {
    private static class NativeMethods
    {
      public static class X64
      {
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.DrawingSettings+NativeMethods.X64#.cctor()")]
        static X64() { NativeLibraryLoader.Load(); }
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_Create();
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_Dispose(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_BorderColor_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_BorderColor_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_FillColor_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FillColor_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_FillRule_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FillRule_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_Font_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_Font_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_FontFamily_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FontFamily_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_FontPointsize_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FontPointsize_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_FontStyle_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FontStyle_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_FontWeight_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FontWeight_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DrawingSettings_StrokeAntiAlias_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeAntiAlias_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_StrokeColor_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeColor_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_StrokeDashOffset_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeDashOffset_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_StrokeLineCap_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeLineCap_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_StrokeLineJoin_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeLineJoin_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_StrokeMiterLimit_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeMiterLimit_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_StrokeWidth_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeWidth_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DrawingSettings_TextAntiAlias_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextAntiAlias_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_TextDirection_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextDirection_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_TextEncoding_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextEncoding_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_TextGravity_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextGravity_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_TextInterlineSpacing_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextInterlineSpacing_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_TextInterwordSpacing_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextInterwordSpacing_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_TextKerning_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextKerning_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_TextUnderColor_Get(IntPtr instance);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextUnderColor_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_SetFillPattern(IntPtr Instance, IntPtr value, out IntPtr exception);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_SetAffine(IntPtr Instance, double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY, out IntPtr exception);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_SetStrokeDashArray(IntPtr Instance, double[] dash, UIntPtr length);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_SetStrokePattern(IntPtr Instance, IntPtr value, out IntPtr exception);
        [DllImport(NativeLibrary.X64Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_SetText(IntPtr Instance, IntPtr value);
      }
      public static class X86
      {
        [SuppressMessage("Microsoft.Performance", "CA1810: InitializeReferenceTypeStaticFieldsInline", Scope = "member", Target = "ImageMagick.DrawingSettings+NativeMethods.X86#.cctor()")]
        static X86() { NativeLibraryLoader.Load(); }
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_Create();
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_Dispose(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_BorderColor_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_BorderColor_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_FillColor_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FillColor_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_FillRule_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FillRule_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_Font_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_Font_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_FontFamily_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FontFamily_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_FontPointsize_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FontPointsize_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_FontStyle_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FontStyle_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_FontWeight_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_FontWeight_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DrawingSettings_StrokeAntiAlias_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeAntiAlias_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_StrokeColor_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeColor_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_StrokeDashOffset_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeDashOffset_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_StrokeLineCap_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeLineCap_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_StrokeLineJoin_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeLineJoin_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_StrokeMiterLimit_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeMiterLimit_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_StrokeWidth_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_StrokeWidth_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DrawingSettings_TextAntiAlias_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextAntiAlias_Set(IntPtr instance, [MarshalAs(UnmanagedType.Bool)] bool value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_TextDirection_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextDirection_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_TextEncoding_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextEncoding_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern UIntPtr DrawingSettings_TextGravity_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextGravity_Set(IntPtr instance, UIntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_TextInterlineSpacing_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextInterlineSpacing_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_TextInterwordSpacing_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextInterwordSpacing_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern double DrawingSettings_TextKerning_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextKerning_Set(IntPtr instance, double value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr DrawingSettings_TextUnderColor_Get(IntPtr instance);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_TextUnderColor_Set(IntPtr instance, IntPtr value);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_SetFillPattern(IntPtr Instance, IntPtr value, out IntPtr exception);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_SetAffine(IntPtr Instance, double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY, out IntPtr exception);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_SetStrokeDashArray(IntPtr Instance, double[] dash, UIntPtr length);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_SetStrokePattern(IntPtr Instance, IntPtr value, out IntPtr exception);
        [DllImport(NativeLibrary.X86Name, CallingConvention = CallingConvention.Cdecl)]
        public static extern void DrawingSettings_SetText(IntPtr Instance, IntPtr value);
      }
    }
    private sealed class NativeDrawingSettings : NativeInstance
    {
      private IntPtr _Instance = IntPtr.Zero;
      protected override void Dispose(IntPtr instance)
      {
        DisposeInstance(instance);
      }
      public static void DisposeInstance(IntPtr instance)
      {
        if (NativeLibrary.Is64Bit)
          NativeMethods.X64.DrawingSettings_Dispose(instance);
        else
          NativeMethods.X86.DrawingSettings_Dispose(instance);
      }
      public NativeDrawingSettings()
      {
        if (NativeLibrary.Is64Bit)
          _Instance = NativeMethods.X64.DrawingSettings_Create();
        else
          _Instance = NativeMethods.X86.DrawingSettings_Create();
        if (_Instance == IntPtr.Zero)
          throw new InvalidOperationException();
      }
      public override IntPtr Instance
      {
        get
        {
          if (_Instance == IntPtr.Zero)
            throw new ObjectDisposedException(typeof(DrawingSettings).ToString());
          return _Instance;
        }
        set
        {
          if (_Instance != IntPtr.Zero)
            Dispose(_Instance);
          _Instance = value;
        }
      }
      public MagickColor BorderColor
      {
        get
        {
          IntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_BorderColor_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_BorderColor_Get(Instance);
          return MagickColor.CreateInstance(result);
        }
        set
        {
          using (INativeInstance valueNative = MagickColor.CreateInstance(value))
          {
            if (NativeLibrary.Is64Bit)
              NativeMethods.X64.DrawingSettings_BorderColor_Set(Instance, valueNative.Instance);
            else
              NativeMethods.X86.DrawingSettings_BorderColor_Set(Instance, valueNative.Instance);
          }
        }
      }
      public MagickColor FillColor
      {
        get
        {
          IntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_FillColor_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_FillColor_Get(Instance);
          return MagickColor.CreateInstance(result);
        }
        set
        {
          using (INativeInstance valueNative = MagickColor.CreateInstance(value))
          {
            if (NativeLibrary.Is64Bit)
              NativeMethods.X64.DrawingSettings_FillColor_Set(Instance, valueNative.Instance);
            else
              NativeMethods.X86.DrawingSettings_FillColor_Set(Instance, valueNative.Instance);
          }
        }
      }
      public FillRule FillRule
      {
        get
        {
          UIntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_FillRule_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_FillRule_Get(Instance);
          return (FillRule)result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_FillRule_Set(Instance, (UIntPtr)value);
          else
            NativeMethods.X86.DrawingSettings_FillRule_Set(Instance, (UIntPtr)value);
        }
      }
      public string Font
      {
        get
        {
          IntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_Font_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_Font_Get(Instance);
          return UTF8Marshaler.NativeToManaged(result);
        }
        set
        {
          using (INativeInstance valueNative = UTF8Marshaler.CreateInstance(value))
          {
            if (NativeLibrary.Is64Bit)
              NativeMethods.X64.DrawingSettings_Font_Set(Instance, valueNative.Instance);
            else
              NativeMethods.X86.DrawingSettings_Font_Set(Instance, valueNative.Instance);
          }
        }
      }
      public string FontFamily
      {
        get
        {
          IntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_FontFamily_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_FontFamily_Get(Instance);
          return UTF8Marshaler.NativeToManaged(result);
        }
        set
        {
          using (INativeInstance valueNative = UTF8Marshaler.CreateInstance(value))
          {
            if (NativeLibrary.Is64Bit)
              NativeMethods.X64.DrawingSettings_FontFamily_Set(Instance, valueNative.Instance);
            else
              NativeMethods.X86.DrawingSettings_FontFamily_Set(Instance, valueNative.Instance);
          }
        }
      }
      public double FontPointsize
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_FontPointsize_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_FontPointsize_Get(Instance);
          return result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_FontPointsize_Set(Instance, value);
          else
            NativeMethods.X86.DrawingSettings_FontPointsize_Set(Instance, value);
        }
      }
      public FontStyleType FontStyle
      {
        get
        {
          UIntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_FontStyle_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_FontStyle_Get(Instance);
          return (FontStyleType)result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_FontStyle_Set(Instance, (UIntPtr)value);
          else
            NativeMethods.X86.DrawingSettings_FontStyle_Set(Instance, (UIntPtr)value);
        }
      }
      public FontWeight FontWeight
      {
        get
        {
          UIntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_FontWeight_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_FontWeight_Get(Instance);
          return (FontWeight)result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_FontWeight_Set(Instance, (UIntPtr)value);
          else
            NativeMethods.X86.DrawingSettings_FontWeight_Set(Instance, (UIntPtr)value);
        }
      }
      public bool StrokeAntiAlias
      {
        get
        {
          bool result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_StrokeAntiAlias_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_StrokeAntiAlias_Get(Instance);
          return result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_StrokeAntiAlias_Set(Instance, value);
          else
            NativeMethods.X86.DrawingSettings_StrokeAntiAlias_Set(Instance, value);
        }
      }
      public MagickColor StrokeColor
      {
        get
        {
          IntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_StrokeColor_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_StrokeColor_Get(Instance);
          return MagickColor.CreateInstance(result);
        }
        set
        {
          using (INativeInstance valueNative = MagickColor.CreateInstance(value))
          {
            if (NativeLibrary.Is64Bit)
              NativeMethods.X64.DrawingSettings_StrokeColor_Set(Instance, valueNative.Instance);
            else
              NativeMethods.X86.DrawingSettings_StrokeColor_Set(Instance, valueNative.Instance);
          }
        }
      }
      public double StrokeDashOffset
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_StrokeDashOffset_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_StrokeDashOffset_Get(Instance);
          return result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_StrokeDashOffset_Set(Instance, value);
          else
            NativeMethods.X86.DrawingSettings_StrokeDashOffset_Set(Instance, value);
        }
      }
      public LineCap StrokeLineCap
      {
        get
        {
          UIntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_StrokeLineCap_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_StrokeLineCap_Get(Instance);
          return (LineCap)result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_StrokeLineCap_Set(Instance, (UIntPtr)value);
          else
            NativeMethods.X86.DrawingSettings_StrokeLineCap_Set(Instance, (UIntPtr)value);
        }
      }
      public LineJoin StrokeLineJoin
      {
        get
        {
          UIntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_StrokeLineJoin_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_StrokeLineJoin_Get(Instance);
          return (LineJoin)result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_StrokeLineJoin_Set(Instance, (UIntPtr)value);
          else
            NativeMethods.X86.DrawingSettings_StrokeLineJoin_Set(Instance, (UIntPtr)value);
        }
      }
      public int StrokeMiterLimit
      {
        get
        {
          UIntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_StrokeMiterLimit_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_StrokeMiterLimit_Get(Instance);
          return (int)result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_StrokeMiterLimit_Set(Instance, (UIntPtr)value);
          else
            NativeMethods.X86.DrawingSettings_StrokeMiterLimit_Set(Instance, (UIntPtr)value);
        }
      }
      public double StrokeWidth
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_StrokeWidth_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_StrokeWidth_Get(Instance);
          return result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_StrokeWidth_Set(Instance, value);
          else
            NativeMethods.X86.DrawingSettings_StrokeWidth_Set(Instance, value);
        }
      }
      public bool TextAntiAlias
      {
        get
        {
          bool result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_TextAntiAlias_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_TextAntiAlias_Get(Instance);
          return result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_TextAntiAlias_Set(Instance, value);
          else
            NativeMethods.X86.DrawingSettings_TextAntiAlias_Set(Instance, value);
        }
      }
      public TextDirection TextDirection
      {
        get
        {
          UIntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_TextDirection_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_TextDirection_Get(Instance);
          return (TextDirection)result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_TextDirection_Set(Instance, (UIntPtr)value);
          else
            NativeMethods.X86.DrawingSettings_TextDirection_Set(Instance, (UIntPtr)value);
        }
      }
      public string TextEncoding
      {
        get
        {
          IntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_TextEncoding_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_TextEncoding_Get(Instance);
          return UTF8Marshaler.NativeToManaged(result);
        }
        set
        {
          using (INativeInstance valueNative = UTF8Marshaler.CreateInstance(value))
          {
            if (NativeLibrary.Is64Bit)
              NativeMethods.X64.DrawingSettings_TextEncoding_Set(Instance, valueNative.Instance);
            else
              NativeMethods.X86.DrawingSettings_TextEncoding_Set(Instance, valueNative.Instance);
          }
        }
      }
      public Gravity TextGravity
      {
        get
        {
          UIntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_TextGravity_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_TextGravity_Get(Instance);
          return (Gravity)result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_TextGravity_Set(Instance, (UIntPtr)value);
          else
            NativeMethods.X86.DrawingSettings_TextGravity_Set(Instance, (UIntPtr)value);
        }
      }
      public double TextInterlineSpacing
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_TextInterlineSpacing_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_TextInterlineSpacing_Get(Instance);
          return result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_TextInterlineSpacing_Set(Instance, value);
          else
            NativeMethods.X86.DrawingSettings_TextInterlineSpacing_Set(Instance, value);
        }
      }
      public double TextInterwordSpacing
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_TextInterwordSpacing_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_TextInterwordSpacing_Get(Instance);
          return result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_TextInterwordSpacing_Set(Instance, value);
          else
            NativeMethods.X86.DrawingSettings_TextInterwordSpacing_Set(Instance, value);
        }
      }
      public double TextKerning
      {
        get
        {
          double result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_TextKerning_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_TextKerning_Get(Instance);
          return result;
        }
        set
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_TextKerning_Set(Instance, value);
          else
            NativeMethods.X86.DrawingSettings_TextKerning_Set(Instance, value);
        }
      }
      public MagickColor TextUnderColor
      {
        get
        {
          IntPtr result;
          if (NativeLibrary.Is64Bit)
            result = NativeMethods.X64.DrawingSettings_TextUnderColor_Get(Instance);
          else
            result = NativeMethods.X86.DrawingSettings_TextUnderColor_Get(Instance);
          return MagickColor.CreateInstance(result);
        }
        set
        {
          using (INativeInstance valueNative = MagickColor.CreateInstance(value))
          {
            if (NativeLibrary.Is64Bit)
              NativeMethods.X64.DrawingSettings_TextUnderColor_Set(Instance, valueNative.Instance);
            else
              NativeMethods.X86.DrawingSettings_TextUnderColor_Set(Instance, valueNative.Instance);
          }
        }
      }
      public void SetFillPattern(MagickImage value)
      {
        IntPtr exception = IntPtr.Zero;
        if (NativeLibrary.Is64Bit)
          NativeMethods.X64.DrawingSettings_SetFillPattern(Instance, MagickImage.GetInstance(value), out exception);
        else
          NativeMethods.X86.DrawingSettings_SetFillPattern(Instance, MagickImage.GetInstance(value), out exception);
        CheckException(exception);
      }
      public void SetAffine(double scaleX, double scaleY, double shearX, double shearY, double translateX, double translateY)
      {
        IntPtr exception = IntPtr.Zero;
        if (NativeLibrary.Is64Bit)
          NativeMethods.X64.DrawingSettings_SetAffine(Instance, scaleX, scaleY, shearX, shearY, translateX, translateY, out exception);
        else
          NativeMethods.X86.DrawingSettings_SetAffine(Instance, scaleX, scaleY, shearX, shearY, translateX, translateY, out exception);
        CheckException(exception);
      }
      public void SetStrokeDashArray(double[] dash, int length)
      {
        if (NativeLibrary.Is64Bit)
          NativeMethods.X64.DrawingSettings_SetStrokeDashArray(Instance, dash, (UIntPtr)length);
        else
          NativeMethods.X86.DrawingSettings_SetStrokeDashArray(Instance, dash, (UIntPtr)length);
      }
      public void SetStrokePattern(MagickImage value)
      {
        IntPtr exception = IntPtr.Zero;
        if (NativeLibrary.Is64Bit)
          NativeMethods.X64.DrawingSettings_SetStrokePattern(Instance, MagickImage.GetInstance(value), out exception);
        else
          NativeMethods.X86.DrawingSettings_SetStrokePattern(Instance, MagickImage.GetInstance(value), out exception);
        CheckException(exception);
      }
      public void SetText(string value)
      {
        using (INativeInstance valueNative = UTF8Marshaler.CreateInstance(value))
        {
          if (NativeLibrary.Is64Bit)
            NativeMethods.X64.DrawingSettings_SetText(Instance, valueNative.Instance);
          else
            NativeMethods.X86.DrawingSettings_SetText(Instance, valueNative.Instance);
        }
      }
    }
    internal static INativeInstance CreateInstance(DrawingSettings instance)
    {
      if (instance == null)
        return NativeInstance.Zero;
      return instance.CreateNativeInstance();
    }
  }
}
