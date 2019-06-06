using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BoringHelpers.Collections
{
    public static class Empty
    {
        public struct VoidStruct { };

        public static IList<T> List<T>() => System.Array.Empty<T>();

        public static IDictionary<TKey, TValue> Dictionary<TKey, TValue>() => EmptyCollection<TKey, TValue>.Singleton();

        public static ICollection<T> Collection<T>() => System.Array.Empty<T>();

        public static IEnumerable<T> Enumerable<T>() => System.Linq.Enumerable.Empty<T>();

        public static T[] Array<T>() => System.Array.Empty<T>();

        public static ISet<TKey> Set<TKey>() => EmptyCollection<TKey, VoidStruct>.Singleton();

        private class EmptyCollection<TKey, TValue> : IDictionary<TKey, TValue>, ISet<TKey>
        {

            private static EmptyCollection<TKey, TValue> m_Singleton = new EmptyCollection<TKey, TValue>();
            public static EmptyCollection<TKey, TValue> Singleton() => m_Singleton;

            private EmptyCollection()
            {}

            public int Count => 0;

            public bool IsReadOnly => true;

            public ICollection<TKey> Keys => Empty.Collection<TKey>();

            public ICollection<TValue> Values => Empty.Collection<TValue>();

            public TValue this[TKey key] { get => throw new KeyNotFoundException(); set => throw new KeyNotFoundException(); }

            public bool Add(TKey item) => false;

            public void Clear() { } //no-op

            public bool Contains(TKey item) => false;

            public void CopyTo(TKey[] array, int arrayIndex) { } //no-op

            public void ExceptWith(IEnumerable<TKey> other) => throw new NotSupportedException($"Empty set does not support {nameof(ExceptWith)}");

            public IEnumerator<TKey> GetEnumerator() => Empty.Enumerable<TKey>().GetEnumerator();

            public void IntersectWith(IEnumerable<TKey> other) => throw new NotSupportedException($"Empty set does not support {nameof(IntersectWith)}");

            public bool IsProperSubsetOf(IEnumerable<TKey> other) => other.Any(); //The empty set is a proper subset of all sets except itself

            public bool IsProperSupersetOf(IEnumerable<TKey> other) => false; //The empty set can never be a superset of any set

            public bool IsSubsetOf(IEnumerable<TKey> other) => true;

            public bool IsSupersetOf(IEnumerable<TKey> other) => !other.Any(); //The empty set is a non-proper superset of itself

            public bool Overlaps(IEnumerable<TKey> other) => false;

            public bool Remove(TKey item) => false;

            public bool SetEquals(IEnumerable<TKey> other) => !other.Any();

            public void SymmetricExceptWith(IEnumerable<TKey> other) => throw new NotSupportedException($"Empty set does not support {nameof(SymmetricExceptWith)}");

            public void UnionWith(IEnumerable<TKey> other) => throw new NotSupportedException($"Empty set does not support {nameof(UnionWith)}");

            void ICollection<TKey>.Add(TKey item) => throw new NotSupportedException($"Empty set does not support {nameof(Add)}");

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

            public void Add(TKey key, TValue value) => throw new NotSupportedException($"Empty set does not support {nameof(Add)}");

            public bool ContainsKey(TKey key) => false;

            public bool TryGetValue(TKey key, out TValue value)
            {
                value = default;
                return false;
            }

            public void Add(KeyValuePair<TKey, TValue> item) => throw new NotSupportedException($"Empty set does not support {nameof(Add)}");

            public bool Contains(KeyValuePair<TKey, TValue> item) => false;

            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) { } //no-op

            public bool Remove(KeyValuePair<TKey, TValue> item) => false;

            IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => Empty.Enumerable<KeyValuePair<TKey, TValue>>().GetEnumerator();
        }
    }
}
