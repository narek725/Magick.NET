﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

namespace ImageMagick
{
    internal abstract class ExifValue<TValueType> : ExifValue, IExifValue<TValueType>
    {
        public ExifValue(ExifTag<TValueType> tag, TValueType value)
            : base(tag)
        {
            Value = value;
        }

        public ExifValue(ExifTagValue tag, TValueType value)
            : base(tag)
        {
            Value = value;
        }

        public override bool IsArray
            => false;

        public TValueType Value { get; set; }

        protected abstract string StringValue { get; }

        public override object GetValue()
            => Value!;

        public override bool SetValue(object value)
        {
            if (value is null)
                return false;

            if (value is TValueType typeValue)
            {
                Value = typeValue;
                return true;
            }

            return false;
        }

        public override string? ToString()
        {
            if (Value == null)
                return null;

            var description = GetDescription(Tag, Value);
            if (description != null)
                return description;

            return StringValue;
        }

        private static string? GetDescription(ExifTag tag, object value)
        {
            var tagValue = (ExifTagValue)(ushort)tag;
            var attributes = TypeHelper.GetCustomAttributes<ExifTagDescriptionAttribute>(tagValue);

            if (attributes == null || attributes.Length == 0)
                return null;

            foreach (var attribute in attributes)
            {
                if (Equals(attribute.Value, value))
                    return attribute.Description;
            }

            return null;
        }
    }
}