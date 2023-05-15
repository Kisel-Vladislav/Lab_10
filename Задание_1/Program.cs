using System.Diagnostics;

namespace Задание_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new int[1000];
            int[] ii = new int[ints.Length];
            Random random = new Random();
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = random.Next(100);
            }
            Stopwatch sw = new Stopwatch();

            ints.CopyTo(ii, 0);


            ii.CopyTo(ints, 0);
            sw.Start();
            MergeSort(ints);
            sw.Stop();
            Console.WriteLine("Cортировкa слиянием " + sw.Elapsed.TotalMilliseconds);

            ii.CopyTo(ints, 0);
            sw.Restart();
            PyramidSort(ints);
            sw.Stop();
            Console.WriteLine("Cортировкa слиянием " + sw.Elapsed.TotalMilliseconds);

            ii.CopyTo(ints, 0);
            sw.Restart();
            QuickSort(ints);
            sw.Stop();
            Console.WriteLine("Cортировкa слиянием " + sw.Elapsed.TotalMilliseconds);
        }
        ////////////////////////////<_сортировки слиянием_>////////////////////////////
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }
        ////////////////////////////<_сортировки слиянием_>////////////////////////////
        
        ////////////////////////////<_сортировки пирамидальная>////////////////////////////
        static int add2pyramid(int[] arr, int i, int N)
        {
            int imax;
            int buf;
            if ((2 * i + 2) < N)
            {
                if (arr[2 * i + 1] < arr[2 * i + 2]) imax = 2 * i + 2;
                else imax = 2 * i + 1;
            }
            else imax = 2 * i + 1;
            if (imax >= N) return i;
            if (arr[i] < arr[imax])
            {
                buf = arr[i];
                arr[i] = arr[imax];
                arr[imax] = buf;
                if (imax < N / 2) i = imax;
            }
            return i;
        }
        public static void PyramidSort(int[] arr)
        {
            int len = arr.Length;

            //шаг 1: постройка пирамиды
            for (int i = len / 2 - 1; i >= 0; --i)
            {
                long prev_i = i;
                i = add2pyramid(arr, i, len);
                if (prev_i != i) ++i;
            }

            //шаг 2: сортировка
            int buf;
            for (int k = len - 1; k > 0; --k)
            {
                buf = arr[0];
                arr[0] = arr[k];
                arr[k] = buf;
                int i = 0, prev_i = -1;
                while (i != prev_i)
                {
                    prev_i = i;
                    i = add2pyramid(arr, i, k);
                }
            }
        }
        ////////////////////////////<_сортировки пирамидальная>////////////////////////////

        ////////////////////////////<_сортировки быстрая>////////////////////////////
        static void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }
        static int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }
        static int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }
        static int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        ////////////////////////////<_сортировки быстрая>////////////////////////////

    }
}