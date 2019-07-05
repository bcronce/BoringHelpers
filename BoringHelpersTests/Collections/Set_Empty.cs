using Xunit;
using System.Collections.Generic;
using BoringHelpers.Collections;
using System;
using System.Linq;

namespace BoringHelpersTests.Collections
{
    public class Set_Empty
    {
        [Fact]
        public void Empty_NotSupported_ExceptWith()
        {
            ISet<int> set = Empty.Set<int>();
            Assert.Throws<NotSupportedException>(() => set.ExceptWith(System.Linq.Enumerable.Empty<int>()));
        }

        [Fact]
        public void Empty_NotSupported_IntersectWith()
        {
            ISet<int> set = Empty.Set<int>();
            Assert.Throws<NotSupportedException>(() => set.IntersectWith(System.Linq.Enumerable.Empty<int>()));
        }

        [Fact]
        public void Empty_NotSupported_SymmetricExceptWith()
        {
            ISet<int> set = Empty.Set<int>();
            Assert.Throws<NotSupportedException>(() => set.SymmetricExceptWith(System.Linq.Enumerable.Empty<int>()));
        }

        [Fact]
        public void Empty_NotSupported_UnionWith()
        {
            ISet<int> set = Empty.Set<int>();
            Assert.Throws<NotSupportedException>(() => set.UnionWith(System.Linq.Enumerable.Empty<int>()));
        }

        [Fact]
        public void Empty_NotSupported_Add()
        {
            ISet<int> set = Empty.Set<int>();
            Assert.Throws<NotSupportedException>(() => set.Add(default));
        }

        [Fact]
        public void Empty_IsNotProperSubset()
        {
            //The empty set is a proper subset of all sets except itself
            ISet<int> set = Empty.Set<int>();
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.False(set.IsProperSubsetOf(other));
        }

        [Fact]
        public void Empty_IsProperSubset()
        {
            //The empty set is a proper subset of all non-empty sets
            ISet<int> set = Empty.Set<int>();
            var other = new List<int> { 0 };

            Assert.True(set.IsProperSubsetOf(other));
        }

        [Fact]
        public void Empty_IsSubset_Empty()
        {
            //The empty set is a subset of all sets, including itself
            ISet<int> set = Empty.Set<int>();
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.True(set.IsSubsetOf(other));
        }

        [Fact]
        public void Empty_IsSubset_NonEmpty()
        {
            //The empty set is a subset of all sets
            ISet<int> set = Empty.Set<int>();
            var other = new List<int> { 0 };

            Assert.True(set.IsSubsetOf(other));
        }

        [Fact]
        public void Empty_IsNotProperSuperset_Empty()
        {
            //The empty set is not a proper superset of any sets
            ISet<int> set = Empty.Set<int>();
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.False(set.IsProperSupersetOf(other));
        }

        [Fact]
        public void Empty_IsNotProperSuperset_NonEmpty()
        {
            ///The empty set is not a proper superset of any sets
            ISet<int> set = Empty.Set<int>();
            var other = new List<int> { 0 };

            Assert.False(set.IsProperSupersetOf(other));
        }

        [Fact]
        public void Empty_IsNotSuperset()
        {
            //The empty set is not a superset of any non-empty sets
            ISet<int> set = Empty.Set<int>();
            var other = new List<int> { 0 };

            Assert.False(set.IsSupersetOf(other));
        }

        [Fact]
        public void Empty_IsSuperset()
        {
            //The empty set is only a superset to itself
            ISet<int> set = Empty.Set<int>();
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.True(set.IsSupersetOf(other));
        }

        [Fact]
        public void Empty_NotOverlaps_Empty()
        {
            //The empty set cannot overlap with any set
            ISet<int> set = Empty.Set<int>();
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.False(set.Overlaps(other));
        }

        [Fact]
        public void Empty_NoOverlaps_NonEmpty()
        {
            //The empty set cannot overlap with any set
            ISet<int> set = Empty.Set<int>();
            var other = new List<int> { 0 };

            Assert.False(set.Overlaps(other));
        }

        [Fact]
        public void Empty_Equal()
        {
            //The empty set can only be equal to itself
            ISet<int> set = Empty.Set<int>();
            var other = System.Linq.Enumerable.Empty<int>();

            Assert.True(set.SetEquals(other));
        }

        [Fact]
        public void Empty_NotEqual()
        {
            //The empty set cannot be equal to any non-empty set
            ISet<int> set = Empty.Set<int>();
            var other = new List<int> { 0 };

            Assert.False(set.SetEquals(other));
        }
    }
}
