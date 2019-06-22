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
    }
}
