using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortHelper.Tests
{
    [TestClass]
    public class SortMakerTests
    {

        [TestMethod]
        public void QuickSortMethod_UnsortedArray_ReturnedSortedArray()
        {
            int[] expectedArray = { 10, 45, 66, 110 };

            int[] actArray = { 110, 66, 10, 45 };
            SortMaker.QuickSort(actArray);

            CollectionAssert.AreEqual(expectedArray, actArray);
        }

        [TestMethod]
        public void QuickSortMethod_UnsortedLargeArray_ReturnedSortedArray()
        {
            int largeLength = 1000000;
            int[] expectedArray = new int[largeLength];

            for (int i = 0; i < largeLength; i++)
            {
                var random = new Random();
                expectedArray[i] = random.Next();
            }

            int[] actArray = new int[largeLength];
            Array.Copy(expectedArray, actArray, expectedArray.Length);
            Array.Sort(expectedArray);

            SortMaker.QuickSort(actArray);

            CollectionAssert.AreEqual(expectedArray, actArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSortMethod_QuickSortWithNull_ThrowArgumentNullException()
        => SortMaker.QuickSort(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSortMethod_ArrayLengthEqualsNull_ThrowArgumentNullException()
         => SortMaker.QuickSort(new int[] { });

    }
}
