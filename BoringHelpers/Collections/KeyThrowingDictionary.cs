using System;
using System.Collections.Generic;
using System.Text;

namespace BoringHelpers.Collections
{
    public class KeyThrowingDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get
            {
                if (this.TryGetValue(key, out var result)) return result;
                else
                {
                    //key cannot be null, TryGetValue throws ArgumentNullException
                    throw new KeyNotFoundException($"The given key '{key}' was not present in the dictionary.");
                }
            }
            set
            {
                base[key] = value;
            }
        }

        TValue IDictionary<TKey, TValue>.this[TKey key]
        {
            get
            {
                return this[key];
            }
            set
            {
                this[key] = value;
            }
        }

        TValue IReadOnlyDictionary<TKey, TValue>.this[TKey key]
        {
            get
            {
                return this[key];
            }
        }

        public new void Add(TKey key, TValue value)
        {
            try
            {
                base.Add(key, value);
            }
            catch (ArgumentException)
            {
                //key cannot be null, TryGetValue throws ArgumentNullException
                throw new ArgumentException($"An item with the same key has already been added. Key: {key}");
            }
        }

        void IDictionary<TKey, TValue>.Add(TKey key, TValue value) => this.Add(key, value);
    }
}
