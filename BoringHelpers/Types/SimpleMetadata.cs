using System;
using System.Collections.Generic;
using System.Text;
#if NETSTANDARD2_1
using System.Diagnostics.CodeAnalysis;
#endif

namespace BoringHelpers.Types
{
    public abstract class SimpleMetadata<T> : IComparable<SimpleMetadata<T>>, IEquatable<SimpleMetadata<T>>, IComparable where T : IComparable<T>, IComparable
    {
        private const int CompareIsEqual = 0;
        private const int ThisGreatherThanOther = 1;
#if NETSTANDARD2_1
        [MaybeNull]
#endif
        public readonly T Value;

#if NETSTANDARD2_1
        protected SimpleMetadata([AllowNull]T value)
#else
        protected SimpleMetadata(T value)
#endif
        {
            this.Value = value;
        }

        protected virtual IEqualityComparer<T> EqualityComparer { get { return EqualityComparer<T>.Default; } }
        protected virtual IComparer<T> Comparer { get { return Comparer<T>.Default; } }

#if NETSTANDARD2_1
        public override bool Equals(object? obj)
#else
        public override bool Equals(object obj)
#endif
            => this.Equals(obj as SimpleMetadata<T>);

#if NETSTANDARD2_1
        public bool Equals(SimpleMetadata<T>? other)
#else
        public bool Equals(SimpleMetadata<T> other)
#endif
        {
            if (object.ReferenceEquals(other, null)) return false;
            if (this.GetType() != other.GetType()) return false;
            return this.CompareTo(other) == CompareIsEqual;
        }

        public bool Equals(T other) => Comparer.Compare(this.Value, other) == CompareIsEqual;

#if NETSTANDARD2_1
        public virtual int CompareTo(object? obj)
#else
        public virtual int CompareTo(object obj)
#endif
        {
            if (object.ReferenceEquals(obj, null)) return ThisGreatherThanOther;
            if (this.GetType() != obj.GetType()) throw new ArgumentException($"{nameof(obj)} not the same type as this instance");
            return this.CompareTo(obj as SimpleMetadata<T>);
        }

#if NETSTANDARD2_1
        public virtual int CompareTo(SimpleMetadata<T>? other)
#else
        public virtual int CompareTo(SimpleMetadata<T> other)
#endif
        {
            if (object.ReferenceEquals(other,null)) return ThisGreatherThanOther;
            return Comparer.Compare(this.Value, other.Value);
        }

        public override int GetHashCode() => EqualityComparer.GetHashCode(this.Value);

        public override string ToString()
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.object.tostring?view=netframework-4.8
            //Your ToString() override should not return Empty or a null string.
            //Your ToString() override should not throw an exception.
            if (object.ReferenceEquals(this.Value, null)) return "NULL Value";
            return this.Value.ToString();
        }

        public static bool operator ==(SimpleMetadata<T> obj1, SimpleMetadata<T> obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return object.ReferenceEquals(obj2, null);
            }

            return obj1.Equals(obj2);
        }

        public static bool operator ==(SimpleMetadata<T> obj1, T obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return object.ReferenceEquals(obj2, null);
            }

            return obj1.Equals(obj2);
        }

        public static bool operator !=(SimpleMetadata<T> obj1, SimpleMetadata<T> obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return !object.ReferenceEquals(obj2, null);
            }

            return !obj1.Equals(obj2);
        }

        public static bool operator !=(SimpleMetadata<T> obj1, T obj2)
        {
            if (object.ReferenceEquals(obj1, null))
            {
                return !object.ReferenceEquals(obj2, null);
            }

            return !obj1.Equals(obj2);
        }
    }
}
