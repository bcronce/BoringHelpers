using Xunit;
using System.Collections.Generic;
using BoringHelpers.Collections;
using System;

namespace BoringHelpersTests.Collections
{
    public class Dictionary
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_Contains(int input)
        {
            var dict = Individual.Dictionary(input, true);
            Assert.True(dict.ContainsKey(input));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_Contains_Readonly(int input)
        {
            var dict = Individual.ReadOnlyDictionary(input, true);
            Assert.True(dict.ContainsKey(input));
        }

        [Theory]
        [InlineData("hello world")]
        [InlineData("HELLO WORLD")]
        [InlineData("HeLlO wOrLd")]
        public void Individual_ContainsComparer(string input)
        {
            var dict = Individual.Dictionary(input, true, StringComparer.OrdinalIgnoreCase);
            Assert.True(dict.ContainsKey(input.ToLower()));
            Assert.True(dict.ContainsKey(input.ToUpper()));
        }

        [Theory]
        [InlineData("hello world")]
        [InlineData("HELLO WORLD")]
        [InlineData("HeLlO wOrLd")]
        public void Individual_ContainsComparer_Readonly(string input)
        {
            var dict = Individual.ReadOnlyDictionary(input, true, StringComparer.OrdinalIgnoreCase);
            Assert.True(dict.ContainsKey(input.ToLower()));
            Assert.True(dict.ContainsKey(input.ToUpper()));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_NotContains(int input)
        {
            var dict = Individual.Dictionary(int.MaxValue, true);
            Assert.False(dict.ContainsKey(input));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_TryGetFound(int input)
        {
            var dict = Individual.Dictionary(input, true);
            bool result;
            Assert.True(dict.TryGetValue(input, out result));
            Assert.True(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_TryGetNotFound(int input)
        {
            var dict = Individual.Dictionary(int.MaxValue, true);
            bool result;
            Assert.False(dict.TryGetValue(input, out result));
            Assert.Equal(default(bool), result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_Index(int input)
        {
            var dict = Individual.Dictionary(input, true);
            Assert.True(dict[input]);
        }


        [Fact]
        public void Individual_KeyNotNull_Instantiation()
        {
#pragma warning disable CS8714 // Still want to test this, but this call should not be allowed because of CS8714
#pragma warning disable CS8600 // Still want to test this, but this call should not be allowed because of CS8600
            Assert.Throws<ArgumentNullException>(() => Individual.Dictionary((object)null, true));
#pragma warning restore CS8600
#pragma warning restore CS8714
        }

        [Fact]
        public void Individual_KeyNotNull_TryGet()
        {
            var dict = Individual.Dictionary(new object(), true);
#pragma warning disable CS8625 // Still want to test this, but this call should not be allowed because of CS8625
            Assert.Throws<ArgumentNullException>(() => dict.TryGetValue(null, out bool discard));
#pragma warning restore CS8625
        }

        [Fact]
        public void Individual_KeyNotNull_Contains()
        {
            var dict = Individual.Dictionary(new object(), true);
#pragma warning disable CS8625 // Still want to test this, but this call should not be allowed because of CS8625
            Assert.Throws<ArgumentNullException>(() => dict.ContainsKey(null));
#pragma warning restore CS8625
        }

        [Fact]
        public void Individual_KeyNotNull_Indexer()
        {
            var dict = Individual.Dictionary(new object(), true);
#pragma warning disable CS8625 // Still want to test this, but this call should not be allowed because of CS8625
            Assert.Throws<ArgumentNullException>(() => dict[null]);
#pragma warning restore CS8625
        }

        [Fact]
        public void Individual_SetIndexer()
        {
            var dict = Individual.Dictionary<int, bool>(default, default);
            Assert.Throws<NotSupportedException>(() => dict[default] = default);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IndexMissing(int input)
        {
            var dict = Individual.Dictionary(int.MaxValue, true);
            Assert.Throws<KeyNotFoundException>(() => dict[input]);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_AddNotSupported(int input)
        {
            var dict = Individual.Dictionary(int.MaxValue, true);
            Assert.Throws<NotSupportedException>(() => dict.Add(input, default));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_RemoveNotSupported(int input)
        {
            var dict = Individual.Dictionary(int.MaxValue, true);
            Assert.Throws<NotSupportedException>(() => dict.Remove(input));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_Keys(int input)
        {
            var dict = Individual.Dictionary(input, true);
            Assert.Single(dict.Keys, input);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_Values(int input)
        {
            var dict = Individual.Dictionary(true, input);
            Assert.Single(dict.Values, input);
        }

        [Fact]
        public void Empty_KeyNotNull_TryGet()
        {
            var dict = Empty.Dictionary<object, bool>();
#pragma warning disable CS8625 // Still want to test this, but this call should not be allowed because of CS8625
            Assert.Throws<ArgumentNullException>(() => dict.TryGetValue(null, out bool discard));
#pragma warning restore CS8625
        }

        [Fact]
        public void Empty_KeyNotNull_Contains()
        {
            var dict = Empty.Dictionary<object, bool>();
#pragma warning disable CS8625 // Still want to test this, but this call should not be allowed because of CS8625
            Assert.Throws<ArgumentNullException>(() => dict.ContainsKey(null));
#pragma warning restore CS8625
        }

        [Fact]
        public void Empty_KeyNotNull_Indexer()
        {
            var dict = Empty.Dictionary<object, bool>();
#pragma warning disable CS8625 // Still want to test this, but this call should not be allowed because of CS8625
            Assert.Throws<ArgumentNullException>(() => dict[null]);
#pragma warning restore CS8625
        }

        [Fact]
        public void Empty_SetIndexer()
        {
            var dict = Empty.Dictionary<int, bool>();
            Assert.Throws<NotSupportedException>(() => dict[default] = default);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Empty_NotContains(int input)
        {
            var dict = Empty.Dictionary<int, bool>();
            Assert.False(dict.ContainsKey(input));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Empty_TryGetNotFound(int input)
        {
            var dict = Empty.Dictionary<int, bool>();
            bool result;
            Assert.False(dict.TryGetValue(input, out result));
            Assert.Equal(default(bool), result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Empty_IndexMissing(int input)
        {
            var dict = Empty.Dictionary<int, bool>();
            Assert.Throws<KeyNotFoundException>(() => dict[input]);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Empty_AddNotSupported(int input)
        {
            var dict = Empty.Dictionary<int, bool>();
            Assert.Throws<NotSupportedException>(() => dict.Add(input, default));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Empty_RemoveNotSupported(int input)
        {
            var dict = Empty.Dictionary<int, bool>();
            Assert.Throws<NotSupportedException>(() => dict.Remove(input));
        }

        [Fact]
        public void Empty_Keys()
        {
            var dict = Empty.Dictionary<int, bool>();
            Assert.Empty(dict.Keys);
        }

        [Fact]
        public void Empty_Values()
        {
            var dict = Empty.Dictionary<int, bool>();
            Assert.Empty(dict.Values);
        }
    }
}
