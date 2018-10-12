using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortHelper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = { 10, 20, 4, 5 };
            SortMaker.QuickSort(array);
            Console.ReadLine();

        }
    }
}
