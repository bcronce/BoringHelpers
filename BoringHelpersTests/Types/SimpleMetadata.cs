using Xunit;
using System.Collections.Generic;
using BoringHelpers.Types;
using System;
using System.Linq;

namespace BoringHelpersTests.Types
{
    public class SimpleMetadata
    {
        [Fact]
        public void Simple_Equal()
        {
            var value = "foobar";
            var item1 = new SimpleString(value);
            var item2 = new SimpleString(value);
            Assert.Equal(item1, item2);
        }

        [Fact]
        public void Simple_Equal_Direct()
        {
            var value = "foobar";
            var item1 = new SimpleString("foobar");
            Assert.True(item1 == value);
        }

        [Fact]
        public void Simple_NotEqual()
        {
            var value = "foobar";
            var item1 = new SimpleString(value.ToLower());
            var item2 = new SimpleString(value.ToUpper());
            Assert.NotEqual(item1, item2);
        }

        [Fact]
        public void Simple_NotEqual_Direct()
        {
            var value = "foobar";
            var item1 = new SimpleString(value.ToLower());
            Assert.False(item1 == value.ToUpper());
        }

        [Fact]
        public void CaseInsentive_Equal()
        {
            var value = "foobar";
            var item1 = new SimpleStringIgnoreCase(value.ToLower());
            var item2 = new SimpleStringIgnoreCase(value.ToUpper());
            Assert.Equal(item1, item2);
        }

        [Fact]
        public void CaseInsentive_NotEqual()
        {
            var value = "foobar";
            var item1 = new SimpleStringIgnoreCase(value);
            var item2 = new SimpleStringIgnoreCase(value+"_");
            Assert.NotEqual(item1, item2);
        }

        [Fact]
        public void SortedSame()
        {
            var orignal = Enumerable.Range(0,5).Select(i => i.ToString());
            var metadata = orignal.Select(s => new SimpleString(s));

            Assert.Equal(orignal.OrderBy(s => s), metadata.OrderBy(m => m).Select(m => m.Value));
            Assert.Equal(orignal.OrderByDescending(s => s), metadata.OrderByDescending(m => m).Select(m => m.Value));
            Assert.NotEqual(orignal.OrderBy(s => s), metadata.OrderByDescending(m => m).Select(m => m.Value));
        }
    }
}
