using System;
using System.Collections.Generic;
using System.Text;

namespace BoringHelpers.Types
{
    public abstract class SimpleMetadata<T> : IComparable<SimpleMetadata<T>>, IEquatable<SimpleMetadata<T>>, IComparable where T : IComparable<T>, IComparable
    {
        private const int CompareIsEqual = 0;
        public readonly T Value;

        protected SimpleMetadata(T value)
        {
            this.Value = value;
        }

        protected virtual IEqualityComparer<T> EqualityComparer { get { return EqualityComparer<T>.Default; } }
        protected virtual IComparer<T> Comparer { get { return Comparer<T>.Default; } }

        public override bool Equals(object obj) => this.Equals(obj as SimpleMetadata<T>);

        public bool Equals(SimpleMetadata<T> other)
        {
            if (object.ReferenceEquals(other, null)) return false;
            if (this.GetType() != other.GetType()) return false;
            return this.CompareTo(other) == CompareIsEqual;
        }

        public bool Equals(T other) => Comparer.Compare(this.Value, other) == CompareIsEqual;

        public virtual int CompareTo(object obj)
        {
            if (this.GetType() != obj.GetType()) throw new ArgumentException($"{nameof(obj)} not the same type as this instance");
            return this.CompareTo(obj as SimpleMetadata<T>);
        }

        public virtual int CompareTo(SimpleMetadata<T> other) => Comparer.Compare(this.Value, other.Value);

        public override int GetHashCode() => EqualityComparer.GetHashCode(this.Value);

        public override string ToString() => this.Value.ToString();

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
