using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    internal class Program
    {
        static readonly Action<IEnumerable<int>> Print = (array) => Console.WriteLine(string.Join(", ", array));
        
        static void PrintT<T>(IEnumerable<T> array) => Console.WriteLine(string.Join(", ", array));
        internal static void PrintTShort<T>(IEnumerable<T> array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in array)
            {
                sb.Append($"{item:0.###} ");
            }
            Console.WriteLine(sb.ToString());
        }

        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] array = Enumerable.Range(0, 30).Select(d => rnd.Next(0, 100)).ToArray();
            // var array = new int[] { 26, 21, 80, 95, 62, 34, 28, 9, 67, 53, 41 };
            PrintTShort(array);

            PrintTShort(SortingAlgorithms.DivideAndConquer<int>(array));
        }
    }

    internal class SortingAlgorithms
    {



        #region Bubble Sort 
        // Сложность	Наилучший случай	В среднем	Наихудший случай
        // Время        O(n)                O(n2)       O(n2)
        // Память       O(1)                O(1)        O(1)
        #endregion
        internal static IEnumerable<T> BubbleSort<T>(IEnumerable<T> arr) where T: IComparable
        {
            var a = arr.ToArray();
            bool exitFlag = false;
            while(exitFlag == false)
            {
                exitFlag = true;
                for (int i = 1, n = arr.Count(); i < n; i++)
                {
                    if (a[i - 1].CompareTo(a[i]) > 0)
                    {
                        (a[i - 1], a[i]) = (a[i], a[i - 1]);
                        exitFlag = false;
                    }
                }
            }
            return a;
        }

        #region Insertion Sort
        // Сложность	Наилучший случай	В среднем	Наихудший случай
        // Время        O(n)                O(n2)       O(n2)
        // Память       O(1)                O(1)        O(1)
        #endregion
        internal static IEnumerable<T> InsertionSort<T>(IEnumerable<T> arr) where T: IComparable
        {
            T[] a = arr.ToArray();
            for (int i = 1; i < arr.Count(); i++)
            {
                int index = 0;
                if ((index = GetIndex(a[0..i], a[i])) != -1)
                {
                    Insert(a, index, i);
                } 
            }
            return a;

            static void Insert(T[] arr, int indexAt, int indexFrom)
            {
  
                T temp = arr[indexAt];
                arr[indexAt] = arr[indexFrom];
                for (int i = indexFrom; i > indexAt + 1; i--)
                {
                    arr[i] = arr[i - 1]; 
                }
                arr[indexAt + 1] = temp;
            }

            static int GetIndex(T[] subarray, T value)
            {
                for (int i = 0, l = subarray.Length; i < l; i++)
                {
                    if (value.CompareTo(subarray[i]) < 0)
                        return i;
                }
                return -1;
            }
        }

        #region Selection Sort
        // Сложность	Наилучший случай	В среднем	Наихудший случай
        // Время        O(n)                O(n2)       O(n2)
        // Память       O(1)                O(1)        O(1)
        #endregion
        internal static IEnumerable<T> SelectionSort<T>(IEnumerable<T> arr) where T : IComparable
        {
            var a = arr.ToArray();
            for (int i = 0, n = a.Length; i < n; i++)
            {
                T min = a[i];
                int index = 0;
                for (int j = i; j < n; j++)
                {
                    if (a[j].CompareTo(min) < 0)
                    {
                        min = a[j];
                        index = j;
                    }
                }
                if (index > i)
                    Insert(a, i, index);
            }
            return a;
            static void Insert(T[] a, int indexAt, int indexFrom)
            {
                T temp = a[indexFrom];
                for (int k = indexFrom; k > indexAt; k--)
                {
                    a[k] = a[k - 1];
                }
                a[indexAt] = temp;
            }
        }

        #region Divide And Conquer
        // Сложность    Наилучший случай    В среднем   Наихудший случай
        // Время        O(n·log n)          O(n·log n)  O(n·log n)
        // Память       O(n)                O(n)        O(n)
        #endregion
        internal static IEnumerable<T> DivideAndConquer<T>(IEnumerable<T> arr) where T : IComparable
        {
            var a = arr.ToArray();
            Sort(a);
            return a;

            static void Sort(T[] a)
            {
                if (a.Length <= 1)
                    return;
                int leftLen = a.Length / 2;
                int rightLen = a.Length - leftLen;
                T[] left = a.Take(leftLen).ToArray();
                T[] right = a.TakeLast(rightLen).ToArray();
                Sort(left);
                Sort(right);

                Merge(a, left, right);
            }

            static void Merge(T[] items, T[] left, T[] right)
            {
                int leftIndex = 0;
                int rightIndex = 0;
                int genIndex = 0;
                int remain = left.Length + right.Length;

                while (remain > 0)
                {
                    if (leftIndex >= left.Length)
                    {
                        items[genIndex] = right[rightIndex++];
                    }
                    else if (rightIndex >= right.Length)
                    {
                        items[genIndex] = left[leftIndex++];
                    }
                    else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                    {
                        items[genIndex] = left[leftIndex++];
                    }
                    else
                    {
                        items[genIndex] = right[rightIndex++];
                    }
                    genIndex++;
                    remain--;
                }
            }
        }
    }
}
