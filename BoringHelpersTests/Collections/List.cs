using Xunit;
using System.Collections.Generic;
using BoringHelpers.Collections;
using System;

namespace BoringHelpersTests.Collections
{
    public class List
    {
        [Fact]
        public void Individual_CannotInsert()
        {
            var list = Individual.List<int>(default);
            Assert.Throws<NotSupportedException>(() => list.Insert(0, default));
        }

        [Fact]
        public void Individual_CannotRemove()
        {
            var list = Individual.List<int>(default);
            Assert.Throws<NotSupportedException>(() => list.RemoveAt(0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IndexOf(int input)
        {
            var list = Individual.List(input);
            const int expectedIndex = 0;
            Assert.Equal(expectedIndex, list.IndexOf(input));
        }

        [Fact]
        public void Empty_CannotInsert()
        {
            var list = Empty.List<int>();
            Assert.Throws<NotSupportedException>(() => list.Insert(0, default));
        }

        [Fact]
        public void Empty_CannotRemove()
        {
            var list = Empty.List<int>();
            Assert.Throws<NotSupportedException>(() => list.RemoveAt(0));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Empty_IndexOf(int input)
        {
            var list = Empty.List<int>();
            const int notFound = -1;
            Assert.Equal(notFound, list.IndexOf(input));
        }
    }
}
