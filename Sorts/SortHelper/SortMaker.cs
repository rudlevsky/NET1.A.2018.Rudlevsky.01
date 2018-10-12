using System;
using System.Linq;

namespace SortHelper
{
    /// <summary>
    /// SortMaker includes methods for sorting
    /// </summary>
    public static class SortMaker
    {

        /// <summary>
        /// QuickSort method checks correct data
        /// </summary>
        /// <param name="array">Transferred array</param>
        public static void QuickSort(int [] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array can't be equal to null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentNullException("Array length can't be equal to 0");
            }

            QuickSorter(array, 0, array.Length - 1);
        }

        /// <summary>
        /// MergeSort method checks correct data
        /// </summary>
        /// <param name="array">Transferred array</param>
        /// <returns>Sorted array</returns>
        public static int [] MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array can't be equal to null");
            }

            if (array.Length == 0)
            {
                throw new ArgumentNullException("Array length can't be equal to 0");
            }

            return MergeSorter(array);
        }

        /// <summary>
        /// MergeSorter method divides array on two parts
        /// </summary>
        /// <param name="array">Transferred array</param>
        /// <returns>Sorted part of the array</returns>
        private static int[] MergeSorter(int[] array)
        {
            if (array.Length == 1)
            {
                return array;
            }
            
            int mid_point = array.Length / 2;
            return Merge(MergeSorter(array.Take(mid_point).ToArray()), MergeSorter(array.Skip(mid_point).ToArray()));
        }

        /// <summary>
        /// Merge method implements sorting
        /// </summary>
        /// <param name="mass1">First part of the array</param>
        /// <param name="mass2">Second part of the array</param>
        /// <returns>Merged array</returns>
        private static int[] Merge(int[] mass1, int[] mass2)
        {
            int a = 0, b = 0;
            int [] merged = new int[mass1.Length + mass2.Length];

            for (int i = 0; i < mass1.Length + mass2.Length; i++)
            {
                if (b < mass2.Length && a < mass1.Length)
                {
                    if (mass1[a] > mass2[b])
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
        /// QuickSorter implements sorting
        /// </summary>
        /// <param name="elements">Array of elements</param>
        /// <param name="left">Left index</param>
        /// <param name="right">Right index</param>
        private static void QuickSorter(int[] elements, int left, int right)
        {
            int i = left, j = right;
            int pivot = elements[(left + right) / 2];

            while (i <= j)
            {
                while (elements[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elements[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap elements
                    int tmp = elements[i];
                    elements[i] = elements[j];
                    elements[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls according to index
            if (left < j)
            {
                QuickSorter(elements, left, j);
            }

            if (i < right)
            {
                QuickSorter(elements, i, right);
            }
        }
    }
}
