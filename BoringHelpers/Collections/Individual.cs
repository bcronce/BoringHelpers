using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace BoringHelpers.Collections
{
    public static class Individual
    {
        private const string ReadOnlyErrorMessage = "Collection is read-only";

        public static IReadOnlyList<T> ReadOnlyList<T>(T item) => new SingleList<T>(item);

        public static IReadOnlyList<T> ReadOnlyList<T>(T item, IEqualityComparer<T> comparer) => new SingleList<T>(item, comparer);

        public static IReadOnlyDictionary<TKey, TValue> ReadOnlyDictionary<TKey, TValue>(KeyValuePair<TKey, TValue> item) => new SingleDictionary<TKey, TValue>(item);

        public static IReadOnlyDictionary<TKey, TValue> ReadOnlyDictionary<TKey, TValue>(KeyValuePair<TKey, TValue> item, IEqualityComparer<TKey> comparer) => new SingleDictionary<TKey, TValue>(item, comparer);

        public static IReadOnlyCollection<T> ReadOnlyCollection<T>(T item) => new SingleCollection<T>(item);

        public static IReadOnlyCollection<T> ReadOnlyCollection<T>(T item, IEqualityComparer<T> comparer) => new SingleCollection<T>(item, comparer);

        public static IList<T> List<T>(T item) => new SingleList<T>(item);

        public static IList<T> List<T>(T item, IEqualityComparer<T> comparer) => new SingleList<T>(item, comparer);

        public static IDictionary<TKey, TValue> Dictionary<TKey, TValue>(KeyValuePair<TKey, TValue> item) => new SingleDictionary<TKey, TValue>(item);

        public static IDictionary<TKey, TValue> Dictionary<TKey, TValue>(KeyValuePair<TKey, TValue> item, IEqualityComparer<TKey> comparer) => new SingleDictionary<TKey, TValue>(item, comparer);

        public static ICollection<T> Collection<T>(T item) => new SingleCollection<T>(item);

        public static ICollection<T> Collection<T>(T item, IEqualityComparer<T> comparer) => new SingleCollection<T>(item, comparer);

        public static IEnumerable<T> Enumerable<T>(T item) => new SingleItem<T>(item);

        public static IEnumerator<T> Enumerator<T>(T item) => new SingleEnumerator<T>(item);

        public static ISet<T> Set<T>(T item) => new SingleSet<T>(item);

        public static ISet<T> Set<T>(T item, IEqualityComparer<T> comparer) => new SingleSet<T>(item, comparer);

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

        private class SingleItem<T> : IEnumerable<T>
        {
            protected T item;

            public SingleItem(T item) => this.item = item;

            public IEnumerator<T> GetEnumerator() => Individual.Enumerator(item);

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
        }

        private class SingleEnumerator<T> : IEnumerator<T>
        {
            private T item;
            private State state = State.Reset;
            private enum State : byte
            {
                Reset,
                Moved,
                Done
            }

            public SingleEnumerator(T item) => this.item = item;

            public T Current
            {
                get
                {
                    if (this.state == State.Moved)
                    {
                        return this.item;
                    }
                    throw new InvalidOperationException("Enumeration has not started. Call MoveNext.");
                }
            }

            object IEnumerator.Current => this.Current;

            public bool MoveNext()
            {
                if (this.state == State.Reset)
                {
                    this.state = State.Moved;
                    return true;
                }
                else
                {
                    this.state = State.Done;
                    return false;
                }
            }

            public void Reset() => this.state = State.Reset;

            public void Dispose()
            {

            }
        }

        private class SingleCollection<T> : ICollection<T>, IReadOnlyCollection<T>
        {
            protected T item;

            protected IEqualityComparer<T> comparer;

            public int Count => 1;

            public bool IsReadOnly => true;

            public void Add(T item) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public void Clear() => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool Contains(T item) => this.comparer.Equals(item, this.item);

            public void CopyTo(T[] array, int arrayIndex) => array[arrayIndex] = this.item;

            public bool Remove(T item) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public IEnumerator<T> GetEnumerator() => Individual.Enumerator(this.item);

            IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

            public SingleCollection(T item)
            {
                this.item = item;
                this.comparer = EqualityComparer<T>.Default;
            }

            public SingleCollection(T item, IEqualityComparer<T> comparer)
            {
                this.item = item;
                this.comparer = comparer;
            }
        }

        private class SingleSet<T> : SingleCollection<T>, ISet<T>
        {
            public SingleSet(T item) : base(item) { }

            public SingleSet(T item, IEqualityComparer<T> comparer) : base(item, comparer) { }

            public void ExceptWith(IEnumerable<T> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public void IntersectWith(IEnumerable<T> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            protected bool IsSameComparer(IEqualityComparer<T> otherComparer) => EqualityComparer<IEqualityComparer<T>>.Default.Equals(this.comparer, otherComparer);

            public bool IsProperSubsetOf(IEnumerable<T> other)
            {
                var otherHashset = other as HashSet<T>;
                if (otherHashset != null)
                {
                    if (otherHashset != null && this.IsSameComparer(otherHashset.Comparer)) return otherHashset.Count > 1 && otherHashset.Contains(this.item);
                }

                bool containsSame = false;
                bool containsOther = false;
                foreach(var item in other)
                {
                    var compareResult = this.comparer.Equals(this.item, item);
                    if (compareResult) containsSame = true;
                    else containsOther = true;

                    if (containsSame && containsOther) return true;
                }
                return false;
            }

            public bool IsProperSupersetOf(IEnumerable<T> other) => !other.Any(); //Can only be a proper superset of an empty set

            //Since this is a set of one, if there is any overlap, then it is also a subset
            public bool IsSubsetOf(IEnumerable<T> other) => this.Overlaps(other);

            public bool IsSupersetOf(IEnumerable<T> other)
            {
                return other.Where(i => !this.comparer.Equals(i, this.item)).Any();
            }

            public bool Overlaps(IEnumerable<T> other)
            {
                var otherHashSet = other as HashSet<T>;
                if (otherHashSet != null && this.IsSameComparer(otherHashSet.Comparer)) return otherHashSet.Contains(this.item);
                else return other.Contains(this.item, this.comparer);
            }

            public bool SetEquals(IEnumerable<T> other)
            {
                bool containsSame = false;
                foreach (var item in other)
                {
                    if (this.comparer.Equals(item, this.item)) containsSame = true;
                    else return false;
                }
                return containsSame;
            }

            public void SymmetricExceptWith(IEnumerable<T> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public void UnionWith(IEnumerable<T> other) => throw new NotSupportedException(ReadOnlyErrorMessage);

            bool ISet<T>.Add(T item) => throw new NotSupportedException(ReadOnlyErrorMessage);
        }

        private class SingleList<T> : SingleCollection<T>, IList<T>, IReadOnlyList<T>
        {
            public T this[int index]
            {
                get => index == 0 ? this.item : throw new IndexOutOfRangeException();
                set => throw new NotSupportedException(ReadOnlyErrorMessage);
            }

            public SingleList(T item) : base(item) { }
            public SingleList(T item, IEqualityComparer<T> comparer) : base(item, comparer) { }

            private const int ItemNotFound = -1;
            public int IndexOf(T item) => this.comparer.Equals(item, this.item) ? 0 : ItemNotFound;

            public void Insert(int index, T item) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public void RemoveAt(int index) => throw new NotSupportedException(ReadOnlyErrorMessage);
        }

        private class SingleDictionary<TKey, TValue> : SingleCollection<KeyValuePair<TKey, TValue>>, IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>
        {
            protected IEqualityComparer<TKey> keyComparer;

            public ICollection<TKey> Keys => Individual.Collection(this.item.Key);

            public ICollection<TValue> Values => Individual.Collection(this.item.Value);

            IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys => Individual.Enumerable(this.item.Key);

            IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values => Individual.Enumerable(this.item.Value);

            public TValue this[TKey key]
            {
                get
                {
                    if (this.TryGetValue(key, out var result)) return result;
                    else throw new KeyNotFoundException();
                }
                set => throw new NotSupportedException(ReadOnlyErrorMessage);
            }

            public SingleDictionary(KeyValuePair<TKey, TValue> item) : base(item)
                => this.keyComparer = EqualityComparer<TKey>.Default;

            public SingleDictionary(KeyValuePair<TKey, TValue> item, IEqualityComparer<TKey> comparer)
                : base(item) => this.keyComparer = comparer;

            public void Add(TKey key, TValue value) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool ContainsKey(TKey key) => this.TryGetValue(key, out var discard);

            public bool Remove(TKey key) => throw new NotSupportedException(ReadOnlyErrorMessage);

            public bool TryGetValue(TKey key, out TValue value)
            {
                if (this.keyComparer.Equals(key, this.item.Key))
                {
                    value = this.item.Value;
                    return true;
                }
                else
                {
                    value = default;
                    return false;
                }
            }
        }
    }
}
