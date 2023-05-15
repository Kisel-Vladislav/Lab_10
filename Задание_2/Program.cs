namespace Задание_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte[] banknotes = { 1, 2, 5, 10, 20, 50, 100 };

            byte[] bank = GetBanknotes(banknotes);

            foreach (var item in bank)
                Console.Write(item + " ");

            Console.WriteLine();
            CountingSort(bank);

            foreach (var item in bank)
                Console.Write(item + " ");
        }
        static byte[] GetBanknotes(byte[] banknotes)
        {
            byte[] bank = new byte[100];

            Random r = new Random();
            for (int i = 0; i < bank.Length; i++)
            {
                bank[i] = banknotes[r.Next(banknotes.Length)];
            }

            return bank;
        }
        static void CountingSort(byte[] arr)
        {
            int max = GetMaxValue(arr);
            byte[] counts = new byte[max + 1];
            byte[] sortedArr = new byte[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                counts[arr[i]]++;
            }

            for (int i = 1; i < counts.Length; i++)
            {
                counts[i] += counts[i - 1];
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                sortedArr[counts[arr[i]] - 1] = arr[i];
                counts[arr[i]]--;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = sortedArr[i];
            }
        }

        static int GetMaxValue(byte[] arr)
        {
            int max = int.MinValue;

            foreach (int num in arr)
            {
                if (num > max)
                {
                    max = num;
                }
            }

            return max;
        }
    }
}