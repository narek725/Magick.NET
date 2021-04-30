﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using System.CodeDom.Compiler;
using System.IO;

namespace FileGenerator
{
    public abstract class CodeGenerator
    {
        private IndentedTextWriter _Writer;

        protected CodeGenerator()
        {
        }

        protected CodeGenerator(CodeGenerator parent)
            => _Writer = parent._Writer;

        protected int Indent
        {
            get => _Writer.Indent;
            set => _Writer.Indent = value;
        }

        protected void Write(char value)
            => _Writer.Write(value);

        protected void Write(int value)
            => _Writer.Write(value);

        protected void Write(string value)
            => _Writer.Write(value);

        protected void WriteEnd()
            => WriteEndColon();

        protected void WriteElse(string action)
        {
            WriteLine("else");
            Indent++;
            WriteLine(action);
            Indent--;
        }

        protected void WriteEndColon()
        {
            Indent--;
            WriteLine("}");
        }

        protected void WriteIf(string condition, string action)
        {
            WriteLine("if (" + condition + ")");
            Indent++;
            WriteLine(action);
            Indent--;
        }

        protected void WriteLine()
        {
            int indent = Indent;
            Indent = 0;
            _Writer.WriteLine();
            Indent = indent;
        }

        protected void WriteLine(string value)
            => _Writer.WriteLine(value);

        protected void WriteQuantumType()
        {
            _Writer.WriteLine();
            _Writer.WriteLine("#if Q8");
            _Writer.WriteLine("using QuantumType = System.Byte;");
            _Writer.WriteLine("#elif Q16");
            _Writer.WriteLine("using QuantumType = System.UInt16;");
            _Writer.WriteLine("#elif Q16HDRI");
            _Writer.WriteLine("using QuantumType = System.Single;");
            _Writer.WriteLine("#else");
            _Writer.WriteLine("#error Not implemented!");
            _Writer.WriteLine("#endif");
            _Writer.WriteLine();
        }

        protected void WriteStart(string namespaceName)
        {
            _Writer.WriteLine("// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.");
            _Writer.WriteLine("// Licensed under the Apache License, Version 2.0.");
            _Writer.WriteLine("// <auto-generated/>");
            _Writer.WriteLine("#nullable enable");
            _Writer.WriteLine();
            WriteUsing();
            _Writer.WriteLine("namespace " + namespaceName);
            WriteStartColon();
        }

        protected void WriteStartColon()
        {
            WriteLine("{");
            Indent++;
        }

        protected virtual void WriteUsing()
        {
        }

        public void CloseWriter()
        {
            _Writer.InnerWriter.Dispose();
            _Writer.Dispose();
        }

        public void CreateWriter(string fileName)
        {
            Console.WriteLine("Creating: " + fileName);

            var streamWriter = new StreamWriter(fileName);
            _Writer = new IndentedTextWriter(streamWriter, "    ");
        }
    }
}
