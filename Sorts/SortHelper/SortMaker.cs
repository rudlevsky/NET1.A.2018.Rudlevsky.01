using System;
using System.Collections.Generic;
using System.Linq;

namespace SortHelper
{
    /// <summary>
    /// SortMaker includes methods for sorting.
    /// </summary>
    public static class SortMaker<T>
    {
        /// <summary>
        /// QuickSort method checks correct data.
        /// </summary>
        /// <param name="array">Transferred array.</param>
        public static void QuickSort(T[] array) 
        {
            CheckExceptions(array);

            QuickSorter(array, 0, array.Length - 1, Comparer<T>.Default.Compare);
        }

        /// <summary>
        /// QuickSort method checks correct data.
        /// </summary>
        /// <param name="array">Transferred array.</param>
        /// <param name="comparer">Passed delegate comparer.</param>
        public static void QuickSort(T[] array, Comparison<T> comparer)
        {
            CheckExceptions(array);

            QuickSorter(array, 0, array.Length - 1, comparer);
        }

        /// <summary>
        /// QuickSort method checks correct data.
        /// </summary>
        /// <param name="array">Transferred array.</param>
        /// <param name="comparer">Passed interface comparer.</param>
        public static void QuickSort(T[] array, IComparer<T> comparer)
        {
            CheckExceptions(array);

            QuickSorter(array, 0, array.Length - 1, comparer.Compare);
        }

        /// <summary>
        /// Performs merge sort.
        /// </summary>
        /// <param name="array">Transferred array.</param>
        /// <returns>Sorted array.</returns>
        public static void MergeSort(T[] array)
        {
            CheckExceptions(array);

            var resultArray = MergeSorter(array, Comparer<T>.Default.Compare);
            resultArray.CopyTo(array, 0);
        }

        /// <summary>
        /// Performs merge sort.
        /// </summary>
        /// <param name="array">Transferred array.</param>
        /// <param name="comparer">Passed interface comparer.</param>
        public static void MergeSort(T[] array, IComparer<T> comparer)
        {
            CheckExceptions(array);

            var resultArray = MergeSorter(array, comparer.Compare);
            resultArray.CopyTo(array, 0);
        }

        /// <summary>
        /// Performs merge sort.
        /// </summary>
        /// <param name="array">Transferred array.</param>
        /// <param name="comparer">Passed delegate comparer.</param>
        public static void MergeSort(T[] array, Comparison<T> comparer)
        {
            CheckExceptions(array);

            var resultArray = MergeSorter(array, comparer);
            resultArray.CopyTo(array, 0);
        }

        /// <summary>
        /// MergeSorter method divides array on two parts.
        /// </summary>
        /// <param name="array">Transferred array.</param>
        /// <returns>Sorted part of the array.</returns>
        private static T[] MergeSorter(T[] array, Comparison<T> comparison)
        {
            if (array.Length == 1)
            {
                return array;
            }
            
            int mid_point = array.Length / 2;
            return Merge(MergeSorter(array.Take(mid_point).ToArray(), comparison), MergeSorter(array.Skip(mid_point).ToArray(), comparison), comparison);
        }

        /// <summary>
        /// Merge method implements sorting.
        /// </summary>
        /// <param name="mass1">First part of the array.</param>
        /// <param name="mass2">Second part of the array.</param>
        /// <returns>Merged array.</returns>
        private static T[] Merge(T[] mass1, T[] mass2, Comparison<T> comparison)
        {
            int a = 0, b = 0;
            T[] merged = new T[mass1.Length + mass2.Length];

            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                {
                    if (comparison(mass1[a], mass2[b]) > 0)
                    {
                        merged[i] = mass2[b++];
                    }
                    else
                    {
                        merged[i] = mass1[a++];
                    }
                }
                else
                {
                    if (b < mass2.Length)
                    {
                        merged[i] = mass2[b++];
                    }
                    else
                    {
                        merged[i] = mass1[a++];
                    }
                }
            }

            return merged;
        }

        /// <summary>
        /// QuickSorter implements sorting.
        /// </summary>
        /// <param name="elements">Array of elements.</param>
        /// <param name="left">Left index.</param>
        /// <param name="right">Right index.</param>
        private static void QuickSorter(T[] elements, int left, int right, Comparison<T> comparison) 
        {
            int i = left, j = right;
            T pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (comparison(elements[i], pivot) < 0)
                {
                    i++;
                }

                while (comparison(elements[j], pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap elements
                    T tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls according to index
            if (left < j)
            {
                QuickSorter(elements, left, j, comparison);
            }

            if (i < right)
            {
                QuickSorter(elements, i, right, comparison);
            }
        }

        private static void CheckExceptions(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array) + " can't be equal to null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentException(nameof(array) + " length can't be equal to 0");
            }
        }
    }
}
