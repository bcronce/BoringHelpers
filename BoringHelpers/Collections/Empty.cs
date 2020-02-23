using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
#if NETSTANDARD2_1
using System.Diagnostics.CodeAnalysis;
#endif

namespace BoringHelpers.Collections
{
    public static class Empty
    {
        private const string ReadOnlyErrorMessage = "Collection is read-only";

        public struct VoidStruct
        {
            public static VoidStruct Singleton = default;
        }

        public static EmptyList<T> List<T>() => EmptyList<T>.Singleton();

        public static EmptyDictionary<TKey, TValue> Dictionary<TKey, TValue>()
#if NETSTANDARD2_1
            where TKey : notnull
#endif
            => EmptyDictionary<TKey, TValue>.Singleton();

        public static EmptyCollection<T> Collection<T>() => EmptyCollection<T>.Singleton();

        public static IEnumerable<T> Enumerable<T>() => Empty.Set<T>();

        public static IEnumerator<T> Enumerator<T>() => EmptyEnumerator<T>.Singleton;

        public static T[] Array<T>() => System.Array.Empty<T>();

        public static EmptySet<TKey> Set<TKey>() => EmptySet<TKey>.Singleton();

        public class EmptyDictionary<TKey, TValue> : EmptyCollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>
#if NETSTANDARD2_1
            where TKey: notnull
#endif
        {
            private static EmptyDictionary<TKey, TValue> m_Singleton = new EmptyDictionary<TKey, TValue>();
            public static new EmptyDictionary<TKey, TValue> Singleton() => m_Singleton;

            public ICollection<TKey> Keys => Empty.Collection<TKey>();

            public ICollection<TValue> Values => Empty.Collection<TValue>();

            IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Empty.Enumerable<TKey>();

            IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Empty.Enumerable<TValue>();

            public TValue this[TKey key]
            {
                get
                {
                    if (key == null) throw new ArgumentNullException("Key cannot be NULL");
                    throw new KeyNotFoundException();
                }
                set => throw new NotSupportedException(ReadOnlyErrorMessage);
            }

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

            public void Add(TKey key, TValue value) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool ContainsKey(TKey key)
            {
                if (key == null) throw new ArgumentNullException("Key cannot be NULL");
                return false;
            }

            public bool TryGetValue(TKey key, out TValue value)
            {
                if (key == null) throw new ArgumentNullException("Key cannot be NULL");
#pragma warning disable CS8653 // Because of CS8653, read that I should just ignore this
                value = default;
#pragma warning restore CS8653
                return false;
            }

            public bool Remove(TKey key) => throw new NotSupportedException(ReadOnlyErrorMessage);
        }

        public class EmptyCollection<TValue> : ICollection<TValue>, IReadOnlyCollection<TValue>
        {
            private static EmptyCollection<TValue> m_Singleton = new EmptyCollection<TValue>();
            public static EmptyCollection<TValue> Singleton() => m_Singleton;

            internal EmptyCollection() { }

            public int Count => 0;

            public bool IsReadOnly => true;

            public void Add(TValue item) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public void Clear() => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool Contains(TValue item) => false;

            public void CopyTo(TValue[] array, int arrayIndex) { } //no-op

            public IEnumerator<TValue> GetEnumerator() => EmptyEnumerator<TValue>.Singleton;

            public bool Remove(TValue item) => throw new NotSupportedException(ReadOnlyErrorMessage);

            IEnumerator IEnumerable.GetEnumerator() => EmptyEnumerator<TValue>.Singleton;
        }

        public class EmptyList<TValue> : EmptyCollection<TValue>, IList<TValue>, IReadOnlyList<TValue>
        {
            private static EmptyList<TValue> m_Singleton = new EmptyList<TValue>();
            public static new EmptyList<TValue> Singleton() => m_Singleton;

            public TValue this[int index] { get => throw new IndexOutOfRangeException(); set => throw new NotSupportedException(ReadOnlyErrorMessage); }

            const int listIndexNotFound = -1;
            public int IndexOf(TValue item) => listIndexNotFound;

            public void Insert(int index, TValue item) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public void RemoveAt(int index) => throw new NotSupportedException(ReadOnlyErrorMessage);
        }

        public class EmptySet<TKey> : EmptyCollection<TKey>, ISet<TKey>
        {
            private static EmptySet<TKey> m_Singleton = new EmptySet<TKey>();
            public static new EmptySet<TKey> Singleton() => m_Singleton;

            public void ExceptWith(IEnumerable<TKey> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public void IntersectWith(IEnumerable<TKey> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool IsProperSubsetOf(IEnumerable<TKey> other) => other.Any(); //The empty set is a proper subset of all sets except itself

            public bool IsProperSupersetOf(IEnumerable<TKey> other) => false; //The empty set can never be a superset of any set

            public bool IsSubsetOf(IEnumerable<TKey> other) => true;

            public bool IsSupersetOf(IEnumerable<TKey> other) => !other.Any(); //The empty set is a non-proper superset of itself

            public bool Overlaps(IEnumerable<TKey> other) => false;

            public bool SetEquals(IEnumerable<TKey> other) => !other.Any();

            public void SymmetricExceptWith(IEnumerable<TKey> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public void UnionWith(IEnumerable<TKey> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            bool ISet<TKey>.Add(TKey item) => throw new NotSupportedException(ReadOnlyErrorMessage);
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
