using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortHelper.Tests.Helpers;

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
            SortMaker<int>.QuickSort(actArray);
            
            CollectionAssert.AreEqual(expectedArray, actArray);
        }

        [TestMethod]
        public void QuickSortMethod_UnsortedLargeArray_ReturnedSortedArray()
        {
            const int LargeLength = 1000000;
            int[] expectedArray = new int[LargeLength];

            expectedArray = TestHelper.GetLargeArray(LargeLength);

            int[] actArray = new int[LargeLength];
            Array.Copy(expectedArray, actArray, expectedArray.Length);
            Array.Sort(expectedArray);

            SortMaker<int>.QuickSort(actArray);

            CollectionAssert.AreEqual(expectedArray, actArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSortMethod_QuickSortWithNull_ThrowArgumentNullException()
        => SortMaker<int>.QuickSort(null);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickSortMethod_ArrayLengthEqualsNull_ThrowArgumentNullException()
         => SortMaker<int>.QuickSort(new int[] { });

    }
}
