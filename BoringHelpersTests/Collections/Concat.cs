using Xunit;
using System.Collections.Generic;
using BoringHelpers.Collections;
using System;

namespace BoringHelpersTests.Collections
{
    public class Concat
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Single(int input)
        {
            IEnumerable<int> orignal = Individual.Enumerable(input);
            const int concatValue = -1;
            var concat = orignal.ConcatIndividual(concatValue);
            var expected = new List<int> { input, concatValue };
            Assert.Equal(expected, concat);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Single_List(int input)
        {
            IList<int> orignal = Individual.List(input);
            const int concatValue = -1;
            var concat = orignal.ConcatIndividual(concatValue);
            var expected = new List<int> { input, concatValue };
            Assert.Equal(expected, concat);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Multiple(int input)
        {
            IEnumerable<int> orignal = Individual.Enumerable(input);
            const int concatValue = -1;
            var concat = orignal.ConcatIndividual(concatValue).ConcatIndividual(concatValue + 1);
            var expected = new List<int> { input, concatValue , concatValue + 1};
            Assert.Equal(expected, concat);
        }
    }
}
