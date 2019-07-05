using Xunit;
using System.Collections.Generic;
using BoringHelpers.Collections;
using System;
using System.Linq;

namespace BoringHelpersTests.Collections
{
    public class Set_Individual
    {
        [Fact]
        public void Individual_NotSupported_ExceptWith()
        {
            ISet<int> set = Individual.Set<int>(default);
            Assert.Throws<NotSupportedException>(() => set.ExceptWith(System.Linq.Enumerable.Empty<int>()));
        }

        [Fact]
        public void Individual_NotSupported_IntersectWith()
        {
            ISet<int> set = Individual.Set<int>(default);
            Assert.Throws<NotSupportedException>(() => set.IntersectWith(System.Linq.Enumerable.Empty<int>()));
        }

        [Fact]
        public void Individual_NotSupported_SymmetricExceptWith()
        {
            ISet<int> set = Individual.Set<int>(default);
            Assert.Throws<NotSupportedException>(() => set.SymmetricExceptWith(System.Linq.Enumerable.Empty<int>()));
        }

        [Fact]
        public void Individual_NotSupported_UnionWith()
        {
            ISet<int> set = Individual.Set<int>(default);
            Assert.Throws<NotSupportedException>(() => set.UnionWith(System.Linq.Enumerable.Empty<int>()));
        }

        [Fact]
        public void Individual_NotSupported_Add()
        {
            ISet<int> set = Individual.Set<int>(default);
            Assert.Throws<NotSupportedException>(() => set.Add(default));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IsNotProperSubset(int input)
        {
            //Single element set cannot ever be a proper subset of any other single element set
            ISet<int> set = Individual.Set(0);
            var other = new List<int> { input };

            Assert.False(set.IsProperSubsetOf(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IsProperSubset(int input)
        {
            //Single element set is a proper subset if it has any overlap with a set of 2 or more elements
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { 0, 1, 42 };

            Assert.True(set.IsProperSubsetOf(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IsNotSubset(int input)
        {
            //Only the empty set if a subset of the empty set
            ISet<int> set = Individual.Set(input);
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.False(set.IsSubsetOf(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IsSubset_Many(int input)
        {
            //Single element set is a subset of any set with any overlap
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { 0, 1, 42 };

            Assert.True(set.IsSubsetOf(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IsSubset_Single(int input)
        {
            //A single element set cannot be a subset of any other single element set
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { input };

            Assert.True(set.IsSubsetOf(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IsNotProperSuperset(int input)
        {
            //Single element set cannot ever be a proper superset of any other non-empty set
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { 0 };

            Assert.False(set.IsProperSupersetOf(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IsProperSuperset(int input)
        {
            //A single element set can only every be a superset of the empty set
            ISet<int> set = Individual.Set(input);
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.True(set.IsProperSupersetOf(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IsNotSuperset(int input)
        {
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { -1 };

            Assert.False(set.IsSupersetOf(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IsSuperset_Single(int input)
        {
            //Single element set can only be a non-empty superset to itself
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { input };

            Assert.True(set.IsSupersetOf(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_IsSuperset_Empty(int input)
        {
            //All sets are a superset of the empty set
            ISet<int> set = Individual.Set(input);
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.True(set.IsSupersetOf(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_NotOverlaps_Empty(int input)
        {
            ISet<int> set = Individual.Set(input);
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.False(set.Overlaps(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_Overlaps_Single(int input)
        {
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { input };

            Assert.True(set.Overlaps(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_Overlaps_Many(int input)
        {
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { 0, 1, 42 };

            Assert.True(set.Overlaps(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_NotEqual_Empty(int input)
        {
            ISet<int> set = Individual.Set(input);
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.False(set.SetEquals(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_Equal_Single(int input)
        {
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { input };

            Assert.True(set.SetEquals(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_Equal_Repeat(int input)
        {
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { input, input };

            Assert.True(set.SetEquals(other));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(42)]
        public void Individual_NotEqual_Many(int input)
        {
            ISet<int> set = Individual.Set(input);
            var other = new List<int> { input, -1 };

            Assert.False(set.SetEquals(other));
        }
    }
}
