using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace BasicUtils
{
    /// <summary>
    /// Provides extension methods for working with <see cref="Dictionary{TKey, TValue}"/> instances, 
    /// enabling additional functionality such as retrieving or adding values in a streamlined manner.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Retrieves the value associated with the specified key from the dictionary. 
        /// If the key does not exist, the method adds a new key-value pair to the dictionary 
        /// using the provided <paramref name="valueFactory"/> function to generate the value.
        /// </summary>
        /// <param name="dictionary">The dictionary to retrieve the value from or add the key-value pair to.</param>
        /// <param name="key">The key whose associated value is to be retrieved or added.</param>
        /// <param name="valueFactory">A function to generate a value if the key does not exist in the dictionary.</param>
        /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of the values in the dictionary. Must be a reference type.</typeparam>
        /// <returns>The value associated with the specified key, or the newly added value if the key was not present.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory)
            where TValue : class
        {
            if (!dictionary.TryGetValue(key, out TValue value))
            {
                value = valueFactory(key);
                dictionary[key] = value;
            }
            return value;
        }
    }
}
