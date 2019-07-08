using Xunit;
using System.Collections.Generic;
using BoringHelpers.Collections;
using System;

namespace BoringHelpersTests.Collections
{
    public class Collection
    {
        [Fact]
        public void Individual_CannotAdd()
        {
            var collection = Individual.Collection<int>(default);
            Assert.Throws<NotSupportedException>(() => collection.Add(default));
        }

        [Fact]
        public void Individual_CannotClear()
        {
            var collection = Individual.Collection<int>(default);
            Assert.Throws<NotSupportedException>(() => collection.Clear());
        }

        [Fact]
        public void Individual_CannotRemove()
        {
            var collection = Individual.Collection<int>(default);
            Assert.Throws<NotSupportedException>(() => collection.Remove(default));
        }

        [Fact]
        public void Individual_ReadOnly() => Assert.True(Individual.Collection<int>(default).IsReadOnly);

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_HasOne(int input) => Assert.Single(Individual.Collection(input), input);

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_HasOne_Readonly(int input) => Assert.Single(Individual.ReadOnlyCollection(input), input);

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_HasOne_ReadonlyList(int input) => Assert.Single(Individual.ReadOnlyList(input), input);

        [Fact]
        public void Individual_CountOne() => Assert.Equal(1, Individual.Collection(0).Count);

        [Theory]
        [InlineData("")]
        [InlineData("foobar")]
        [InlineData("HeLlO wOrLd")]
        public void Individual_Contains(string input)
        {
            var collection = Individual.Collection(input);
            Assert.True(collection.Contains(input));
        }

        [Theory]
        [InlineData("")]
        [InlineData("foobar")]
        [InlineData("HeLlO wOrLd")]
        public void Individual_Contains_List(string input)
        {
            var collection = Individual.List(input);
            Assert.True(collection.Contains(input));
        }

        [Theory]
        [InlineData("")]
        [InlineData("foobar")]
        [InlineData("HeLlO wOrLd")]
        public void Individual_Contains_Set(string input)
        {
            var collection = Individual.Set(input);
            Assert.True(collection.Contains(input));
        }

        [Theory]
        [InlineData("")]
        [InlineData("foobar")]
        [InlineData("HeLlO wOrLd")]
        public void Individual_ContainsComparer(string input)
        {
            var collection = Individual.Collection(input, StringComparer.InvariantCultureIgnoreCase);
            Assert.True(collection.Contains(input));

            if (!string.IsNullOrWhiteSpace(input))
            {
                Assert.True(collection.Contains(input.ToLowerInvariant()));
                Assert.True(collection.Contains(input.ToUpperInvariant()));
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData("foobar")]
        [InlineData("HeLlO wOrLd")]
        public void Individual_ContainsComparer_List(string input)
        {
            var collection = Individual.List(input, StringComparer.InvariantCultureIgnoreCase);
            Assert.True(collection.Contains(input));

            if (!string.IsNullOrWhiteSpace(input))
            {
                Assert.True(collection.Contains(input.ToLowerInvariant()));
                Assert.True(collection.Contains(input.ToUpperInvariant()));
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData("foobar")]
        [InlineData("HeLlO wOrLd")]
        public void Individual_ContainsComparer_Set(string input)
        {
            var collection = Individual.Set(input, StringComparer.InvariantCultureIgnoreCase);
            Assert.True(collection.Contains(input));

            if (!string.IsNullOrWhiteSpace(input))
            {
                Assert.True(collection.Contains(input.ToLowerInvariant()));
                Assert.True(collection.Contains(input.ToUpperInvariant()));
            }
        }

        [Theory]
        [InlineData("")]
        [InlineData("foobar")]
        [InlineData("HeLlO wOrLd")]
        public void Individual_CopyTo(string input)
        {
            var collection = Individual.Collection(input);
            var oneArray = new string[1];

            Assert.Null(oneArray[0]);
            collection.CopyTo(oneArray, 0);
            Assert.Equal(input, oneArray[0]);
        }

        [Fact]
        public void Empty_CannotAdd()
        {
            var collection = Empty.Collection<int>();
            Assert.Throws<NotSupportedException>(() => collection.Add(default));
        }

        [Fact]
        public void Empty_CannotClear()
        {
            var collection = Empty.Collection<int>();
            Assert.Throws<NotSupportedException>(() => collection.Clear());
        }

        [Fact]
        public void Empty_CannotRemove()
        {
            var collection = Empty.Collection<int>();
            Assert.Throws<NotSupportedException>(() => collection.Remove(default));
        }

        [Fact]
        public void Empty_ReadOnly() => Assert.True(Empty.Collection<int>().IsReadOnly);

        [Fact]
        public void Empty_HasNone() => Assert.Empty(Empty.Collection<int>());

        [Fact]
        public void Individual_CountZero() => Assert.Equal(0, Empty.Collection<int>().Count);

        [Fact]
        public void Empty_CopyIsNoop()
        {
            var collection = Empty.Collection<int>();
            var emptyArray = new int[0];
            collection.CopyTo(emptyArray, 0);
        }
    }
}
