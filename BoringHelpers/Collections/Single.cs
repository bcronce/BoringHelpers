using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BoringHelpers.Collections
{
    public static class Single
    {
        public static IList<T> List<T>(T item) => throw new NotImplementedException();

        public static IDictionary<TKey, TValue> Dictionary<TKey, TValue>(KeyValuePair<TKey, TValue> item) => throw new NotImplementedException();

        public static ICollection<T> Collection<T>(T item) => throw new NotImplementedException();

        public static IEnumerable<T> Enumerable<T>(T item) => System.Linq.Enumerable.Repeat(item, 1);

        public static ISet<T> Set<T>(T item) => throw new NotImplementedException();
    }
}
