using System;
using System.Collections.Generic;

namespace SortHelper
{
    public static class BinarySearcher<T>
    {
        public static int? BinarySearch(T[] array, T key)
        {
            FindExceptions(array, key);

            return BinarySearch(array, key, Comparer<T>.Default.Compare);
        }

        private static int? BinarySearch(T[] array, T key, Comparison<T> comparison)
        {
            int first = 0;
            int last = array.Length - 1;

            while (first <= last)
            {
                int mid = first + (last - first) / 2;

                if (comparison(array[mid], key) < 0)
                {
                    first = mid + 1;
                }
                else
                {
                    last = mid - 1;
                }

                if (comparison(array[mid], key) == 0)
                {
                    return mid;
                }
            }

            return null;
        }

        private static void FindExceptions(T[] array, T key)
        {
            if(array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} can't be equal to null.");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException($"{nameof(array)} length can't be equal to 0.");
            }
        }
    }
}
