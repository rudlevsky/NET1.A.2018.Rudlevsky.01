using System;
using NUnit.Framework;

namespace SortHelper.Tests
{
    [TestFixture]
    public class BinarySearcherTests
    {
        [Test]
        public void BinarySearch_NullArgument_ArgumentNullException() =>
            Assert.Throws<ArgumentNullException>(() => BinarySearcher<int>.BinarySearch(null, 3));
          
        [Test]
        public void BinarySearch_ZeroArrayLength_ArgumentException() =>
            Assert.Throws<ArgumentException>(() => BinarySearcher<int>.BinarySearch(new int[] { }, 3));

        [TestCase(new int[] { 1, 2, 3, 4, 5}, 2, ExpectedResult = 1)]
        [TestCase(new int[] { 25, 54, 65, 145, 323 }, 25, ExpectedResult = 0)]
        [TestCase(new int[] { 24, 34, 345, 2344, 5435 }, 5435, ExpectedResult = 4)]
        public int? BinarySearch_PassedArguments_CorrectResults(int [] array, int key) =>
            BinarySearcher<int>.BinarySearch(array, key);

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 2, ExpectedResult = 1)]
        [TestCase(new int[] { 25, 54, 65, 145, 323 }, 65, ExpectedResult = 2)]
        [TestCase(new int[] { 24, 34, 345, 2344, 5435 }, 5435, ExpectedResult = null)]
        public int? BinarySearch_PassedArgumentsIndex_CorrectResults(int[] array, int key) =>
            BinarySearcher<int>.BinarySearch(array, 1, 4, key);
    }
}
