// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System.Xml;
using ImageMagick;
using Xunit;

namespace Magick.NET.Core.Tests
{
    public class XmlHelperTests
    {
        [Fact]
        public void CreateElement_NodeIsXmlDocument_AddsNodeAsDocumentElement()
        {
            var doc = new XmlDocument();
            XmlElement element = XmlHelper.CreateElement(doc, "test");

            Assert.Equal(doc.DocumentElement, element);
            Assert.Equal("test", element.Name);
        }

        [Fact]
        public void CreateElement_NodeIsXmlNode_AddsNodeAsChildElement()
        {
            var doc = new XmlDocument();
            XmlElement root = XmlHelper.CreateElement(doc, "root");

            XmlElement element = XmlHelper.CreateElement(root, "test");

            Assert.Equal(root.FirstChild, element);
            Assert.Equal("test", element.Name);
        }

        [Fact]
        public void SetAttribute_DoesNotHaveAttritubte_AttributeIsAdded()
        {
            var doc = new XmlDocument();
            XmlElement element = doc.CreateElement("test");

            XmlHelper.SetAttribute(element, "attr", "val");

            XmlAttribute attribute = element.Attributes["attr"];
            Assert.NotNull(attribute);
            Assert.Equal("val", attribute.Value);
        }

        [Fact]
        public void SetAttribute_HasAttribute_ValueIsSet()
        {
            var doc = new XmlDocument();
            XmlElement element = doc.CreateElement("test");
            XmlAttribute attribute = doc.CreateAttribute("attr");
            element.Attributes.Append(attribute);

            XmlHelper.SetAttribute(element, "attr", 42);

            Assert.Equal("42", attribute.Value);
        }
    }
}
