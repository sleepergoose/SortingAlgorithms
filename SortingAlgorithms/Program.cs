using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    internal class Program
    {
        static readonly Action<IEnumerable<int>> Print = (array) => Console.WriteLine(string.Join(", ", array));
        

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] array = Enumerable.Range(0, 10).Select(d => rnd.Next(0, 1000)).ToArray();
            // array = new int[] { 5, 4, 3, 2, 1, 0 };
            // array = new int[] { 5, 4, 3, 2, 1, 0 };
            Print(array);
            // var func = SortingAlgorithms.BubbleSort(array);
            var func = SortingAlgorithms.InsertionSort(array);
            Print(func);
        }
    }

    internal class SortingAlgorithms
    {
        // Bubble Sort
        internal static int[] BubbleSort(int[] arr)
        {
            for (int j = 0, s = arr.Length; j < s; j++)
            {
                for (int i = 1, n = arr.Length; i < n; i++)
                {
                    if (arr[i - 1] > arr[i])
                        (arr[i - 1], arr[i]) = (arr[i], arr[i - 1]);
                }
            }
            return arr;
        }

        // Insertion sort
        internal static int[] InsertionSort(int[] arr)
        {
            
            for (int i = 1; i < arr.Length; i++)
            {
                int index = 0;
                if ((index = GetIndex(arr[0..i], arr[i])) != -1)
                {
                    Insert(arr, index, i);
                } 
            }
            return arr;

            static void Insert(int[] arr, int indexAt, int indexFrom)
            {
                int temp = arr[indexAt];
                arr[indexAt] = arr[indexFrom];
                for (int i = indexFrom; i > indexAt + 1; i--)
                {
                    arr[i] = arr[i - 1]; 
                }
                arr[indexAt + 1] = temp;
            }

            static int GetIndex(int[] subarray, int value)
            {
                for (int i = 0, l = subarray.Length; i < l; i++)
                {
                    if (value <= subarray[i])
                        return i;
                }
                return -1;
            }
        }

    }
}
