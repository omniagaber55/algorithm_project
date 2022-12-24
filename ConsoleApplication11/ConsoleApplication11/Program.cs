using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication11
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the size of array");
            int x = int.Parse(Console.ReadLine());
            int[] arr = new int[x];
            for (int i = 0; i < x; i++)
            {
                Console.WriteLine("Enter the value of index {0}",i);
                arr[i] = int.Parse(Console.ReadLine());
            }
            int key, j;
            for (int i = 1; i < x; i++)
            {
                key = arr[i];
                j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
            Console.WriteLine("The sorted array:");
            for (int i = 0; i < x; i++)
            {
                Console.Write(arr[i]);
                Console.Write(" ");
            }
            Console.ReadKey();
                 }
    }
}
