using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    internal static class ExtensionMethod
    {
        public static IEnumerable<T> Take<T>(this IEnumerable<T> collection, int count)
        {
            if (collection.Count() == 0)
            {
                yield return default;
            }
            
            var i = 0;
            foreach (var item in collection)
            {
                if (i >= count)
                    yield break;

                yield return item;
                i++;
            }
        }


        public static IEnumerable<T> Top<T>(this IEnumerable<T> collection, int percent)
        {
            return Top(collection, percent, x => x);
        }


        public static IEnumerable<T> Top<T, Selector>(this IEnumerable<T> collection, int percent, Func<T, Selector> selector)
        {
            if (percent < 1 || percent > 100)
                throw new ArgumentOutOfRangeException("percent should be in range of 1-100");

            int count = (int)Math.Ceiling((double)collection.Count() * percent / 100);

            return collection
                        .OrderByDescending(selector)
                        .Take(count);
        }
    }
}
