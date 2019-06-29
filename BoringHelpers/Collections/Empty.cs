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

        public static ICollection<T> Collection<T>() => Empty.Set<T>();

        public static IEnumerable<T> Enumerable<T>() => Empty.Set<T>();

        public static IEnumerator<T> Enumerator<T>() => EmptyEnumerator<T>.Singleton;

        public static T[] Array<T>() => System.Array.Empty<T>();

        public static ISet<TKey> Set<TKey>() => EmptyCollection<TKey, VoidStruct>.Singleton();

        private class EmptyCollection<TKey, TValue> : IDictionary<TKey, TValue>, ISet<TKey>
        {
            private const string ReadOnlyErrorMessage = "Collection is read-only";

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

            public void Clear() => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool Contains(TKey item) => false;

            public void CopyTo(TKey[] array, int arrayIndex) { } //no-op

            public void ExceptWith(IEnumerable<TKey> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public IEnumerator<TKey> GetEnumerator() => EmptyEnumerator<TKey>.Singleton;

            public void IntersectWith(IEnumerable<TKey> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool IsProperSubsetOf(IEnumerable<TKey> other) => other.Any(); //The empty set is a proper subset of all sets except itself

            public bool IsProperSupersetOf(IEnumerable<TKey> other) => false; //The empty set can never be a superset of any set

            public bool IsSubsetOf(IEnumerable<TKey> other) => true;

            public bool IsSupersetOf(IEnumerable<TKey> other) => !other.Any(); //The empty set is a non-proper superset of itself

            public bool Overlaps(IEnumerable<TKey> other) => false;

            public bool Remove(TKey item) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool SetEquals(IEnumerable<TKey> other) => !other.Any();

            public void SymmetricExceptWith(IEnumerable<TKey> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public void UnionWith(IEnumerable<TKey> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            void ICollection<TKey>.Add(TKey item) => throw new NotSupportedException(ReadOnlyErrorMessage);

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

            public void Add(TKey key, TValue value) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool ContainsKey(TKey key) => false;

            public bool TryGetValue(TKey key, out TValue value)
            {
                value = default;
                return false;
            }

            public void Add(KeyValuePair<TKey, TValue> item) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool Contains(KeyValuePair<TKey, TValue> item) => false;

            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) { } //no-op

            public bool Remove(KeyValuePair<TKey, TValue> item) => throw new NotSupportedException(ReadOnlyErrorMessage);

            IEnumerator<KeyValuePair<TKey, TValue>> IEnumerable<KeyValuePair<TKey, TValue>>.GetEnumerator() => EmptyEnumerator<KeyValuePair<TKey, TValue>>.Singleton;
        }

        private class EmptyEnumerator<T> : IEnumerator<T>
        {

            public static EmptyEnumerator<T> Singleton { get; protected set; } = new EmptyEnumerator<T>();
            protected EmptyEnumerator() { }

            public T Current => throw new InvalidOperationException("Enumeration has not started. Call MoveNext.");

            object IEnumerator.Current => throw new InvalidOperationException("Enumeration has not started. Call MoveNext.");

            public bool MoveNext() => false;

            public void Reset() { }

            public void Dispose() { }

        }
    }
}
