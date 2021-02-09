﻿// Copyright 2013-2021 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System.Linq;
using System.Text;
using ImageMagick;
using Xunit;

namespace Magick.NET.Core.Tests
{
    public partial class IptcProfileTests
    {
        public class TheRemoveValueMethod
        {
            [Fact]
            public void ShouldRemoveAllValues()
            {
                var profile = new IptcProfile();
                profile.SetValue(IptcTag.Byline, "test");
                profile.SetValue(IptcTag.Byline, "test2");

                var result = profile.RemoveValue(IptcTag.Byline);

                Assert.True(result);
                Assert.Empty(profile.Values);
            }

            [Fact]
            public void ShouldOnlyRemoveTheValueWithTheSpecifiedValue()
            {
                var profile = new IptcProfile();
                profile.SetValue(IptcTag.Byline, "test");
                profile.SetValue(IptcTag.Byline, "test2");

                var result = profile.RemoveValue(IptcTag.Byline, "test2");

                Assert.True(result);
                Assert.Contains(new IptcValue(IptcTag.Byline, Encoding.UTF8.GetBytes("test")), profile.Values);
            }
        }
    }
}
