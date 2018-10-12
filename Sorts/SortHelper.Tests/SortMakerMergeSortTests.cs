using System;
using NUnit.Framework;

namespace SortHelper.Tests
{

    [TestFixture]
    public class SortMakerMergeSortTests
    {

         [Test]
         public void MergeSortMethod_MergeSortWithNull_ThrowArgumentNullException()
         {
             Assert.Throws<ArgumentNullException>(() => SortMaker.MergeSort(null));
         }


         [Test]
         public void QuickSortMethod_ArrayLengthEqualsNull_ThrowArgumentNullException()
         {
             Assert.Throws<ArgumentNullException>(() => SortMaker.MergeSort(new int[] { }));
         }
         

        [TestCase(new int[] { 110, 66, 10, 45 },ExpectedResult = new int[] { 10, 45, 66, 110 })]
        [TestCase(new int[] { 11, 667, 65, 1 }, ExpectedResult = new int[] { 1, 11, 65, 667 })]
        public int[] MergeSortMethod_UnsortedArray_ReturnedSortedArray(int [] array)
        {
            return SortMaker.MergeSort(array);
        }

        [Test]
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

            actArray = SortMaker.MergeSort(actArray);

            CollectionAssert.AreEqual(expectedArray, actArray);
        }
    }
}
