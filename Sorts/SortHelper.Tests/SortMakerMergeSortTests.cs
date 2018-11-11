using System;
using NUnit.Framework;
using SortHelper.Tests.Helpers;

namespace SortHelper.Tests
{

    [TestFixture]
    public class SortMakerMergeSortTests
    {
         [Test]
         public void MergeSortMethod_ArrayLengthEqualsNull_ThrowArgumentNullException()
         {
            int[] array = new int[] { };

             Assert.Throws<ArgumentException>(() => SortMaker<int>.MergeSort(ref array));
         }

        [Test]
        public void MergeSortMethod_UnsortedArray_ReturnedSortedArray()
        {
            int[] expectedArray = { 10, 45, 66, 110 };

            int[] actArray = { 110, 66, 10, 45 };
            SortMaker<int>.MergeSort(ref actArray);

            CollectionAssert.AreEqual(expectedArray, actArray);
        }

        [Test]
        public void MergeSortMethod_UnsortedLargeArray_ReturnedSortedArray()
        {
            const int  largeLength = 1000000;
            int[] expectedArray = new int[largeLength];

            expectedArray = TestHelper.GetLargeArray(largeLength);

            int[] actArray = new int[largeLength];
            Array.Copy(expectedArray, actArray, expectedArray.Length);
            Array.Sort(expectedArray);

            SortMaker<int>.MergeSort(ref actArray);

            CollectionAssert.AreEqual(expectedArray, actArray);
        }
    }
}
