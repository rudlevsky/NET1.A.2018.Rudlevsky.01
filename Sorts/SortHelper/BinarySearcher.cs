using System;
using System.Collections.Generic;

namespace SortHelper
{
    /// <summary>
    /// Class performs binary searching.
    /// </summary>
    /// <typeparam name="T">Type of searching objects.</typeparam>
    public static class BinarySearcher<T>
    {
        /// <summary>
        /// Searches element in the array.
        /// </summary>
        /// <param name="array">Array for element serching.</param>
        /// <param name="key">Element for searching.</param>
        /// <returns>Position of finded element or null.</returns>
        public static int? BinarySearch(T[] array, T key)
        {
            FindExceptions(array, key);

            return Search(array, key, 0, array.Length, Comparer<T>.Default.Compare);
        }

        public static int? BinarySearch(T[] array, int startIndex, int endIndex, T key)
        {
            FindExceptions(array, key);

            return Search(array, key, startIndex, endIndex, Comparer<T>.Default.Compare);
        }

        public static int? BinarySearch(T[] array, T key, Comparison<T> comparison)
        {
            FindExceptions(array, key);

            return Search(array, key, 0, array.Length, comparison);
        }

        public static int? BinarySearch(T[] array, int startIndex, int endIndex, T key, Comparison<T> comparison)
        {
            FindExceptions(array, key);

            return Search(array, key, startIndex, endIndex, comparison);
        }

        public static int? BinarySearch(T[] array, T key, IComparer<T> comparer)
        {
            FindExceptions(array, key);

            return Search(array, key, 0, array.Length, comparer.Compare);
        }

        public static int? BinarySearch(T[] array, int startIndex, int endIndex, T key, IComparer<T> comparer)
        { 
            FindExceptions(array, key);

            return Search(array, key, startIndex, endIndex, comparer.Compare);
        }

        private static int? Search(T[] array, T key, int startIndex, int endIndex, Comparison<T> comparison)
        {
            int first = startIndex;
            int last = endIndex - 1;

            while (first <= last)
            {
                int mid = (first + last) >> 1;

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
