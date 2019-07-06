using Xunit;
using System.Collections.Generic;
using BoringHelpers.Collections;
using System;

namespace BoringHelpersTests.Collections
{
    public class Enumerator
    {

        [Fact]
        public void Individual_MustMoveNext()
        {
            var enumerator = Individual.Enumerator<int>(default);
            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        [Fact]
        public void Individual_ReadAfterSecondMove()
        {
            var enumerator = Individual.Enumerator<int>(default);
            Assert.True(enumerator.MoveNext());
            Assert.False(enumerator.MoveNext());
            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_MoveOnce(int input)
        {
            var enumerator = Individual.Enumerator(input);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(input, enumerator.Current);
        }

        [Fact]
        public void Individual_MoveTwice()
        {
            var enumerator = Individual.Enumerator<int>(default);
            Assert.True(enumerator.MoveNext());
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Empty_MustMoveNext()
        {
            var enumerator = Empty.Enumerator<int>();
            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        [Fact]
        public void Individual_CannotMove()
        {
            var enumerator = Empty.Enumerator<int>();
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Individual_ReadAfterMove()
        {
            var enumerator = Empty.Enumerator<int>();
            Assert.False(enumerator.MoveNext());
            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }
    }
}
