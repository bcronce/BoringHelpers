using System;
using System.Collections.Generic;
using System.Text;

namespace BoringHelpers.Collections
{
    public class KeyThrowingDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get
            {
                if (this.TryGetValue(key, out var result)) return result;
                else
                {
                    //key cannot be null, TryGetValue throws ArgumentNullException
                    throw new KeyNotFoundException($"Key `{key}` not found");
                }
            }
            set
            {
                base[key] = value;
            }
        }

        public new void Add(TKey key, TValue value)
        {
            try
            {
                base.Add(key, value);
            }
            catch (ArgumentException ex)
            {
                //key cannot be null, TryGetValue throws ArgumentNullException
                throw new ArgumentException($"Key `{key}` already exists", ex);
            }
        }
    }
}
