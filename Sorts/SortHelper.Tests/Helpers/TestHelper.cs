using System;

namespace SortHelper.Tests.Helpers
{
    public static class TestHelper
    {
        public static int[] GetLargeArray(int length)
        {
            int[] expectedArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                var random = new Random();
                expectedArray[i] = random.Next();
            }

            return expectedArray;
        }
    }
}
