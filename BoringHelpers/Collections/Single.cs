using System;
using System.Collections.Generic;
using System.Linq;

namespace BoringHelpers.Collections
{
    public static class Single
    {
        public static IList<T> List<T>(T item) => new SingleList<T>(item);

        public static IDictionary<TKey, TValue> Dictionary<TKey, TValue>(KeyValuePair<TKey, TValue> item) => new SingleDictionary<TKey, TValue>(item);

        public static ICollection<T> Collection<T>(T item) => new SingleList<T>(item);

        public static IEnumerable<T> Enumerable<T>(T item) { yield return item; }

        public static ISet<T> Set<T>(T item) => new SingleSet<T>(item);

        public static IEnumerable<T> ConcatSingle<T>(this IEnumerable<T> left, T single)
        {
            foreach (var item in left) yield return item;
            yield return single;
        }

        public static IEnumerable<T> ConcatSingle<T>(this IList<T> left, T single)
        {
            for(int i = 0; i < left.Count; i++) yield return left[i];
            yield return single;
        }

        private class SingleSet<T> : ISet<T>
        {
            private T item;
            public T Item { get { return this.item; } }
            public SingleSet(T item) => this.item = item;
        }

        private class SingleList<T> : IList<T>
        {
            private T item;
            public T Item { get { return this.item; } }
            public SingleList(T item) => this.item = item;
        }

        private class SingleDictionary<TKey, TValue> : IDictionary<TKey, TValue>
        {
            private KeyValuePair<TKey, TValue> item;
            public KeyValuePair<TKey, TValue> Item { get { return this.item; } }
            public SingleDictionary(KeyValuePair<TKey, TValue> item) => this.item = item;
        }
    }
}
