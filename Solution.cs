using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
namespace MaximumSumOfTriplets
{
    class Program
    {
        static void FillArray(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                Console.WriteLine("Enter element {0}", i + 1);
                array[i] = int.Parse(Console.ReadLine());
            }
        }
        static void PrintArray(int[] array)
        {
            for(int i=0;i<array.Length;i++)
            {
                Console.Write(array[i] + " ");
            }
        }
        static void GetAllTriplets(int[] array,List<List<int>> list)
        {
            List<int> temp = new List<int>();
            int i = 0, j, counter = 1;
            while(true)
            {
                temp.Add(array[i]);
                j = i + counter;
                while(true)
                {
                    if (j == array.Length)
                    {
                        counter++;
                        temp.Clear();
                        break;
                    }
                    if (array[j]>temp[temp.Count-1])
                    {
                        temp.Add(array[j]);
                    }
                    if (temp.Count == 3)
                    {
                        list.Add(new List<int>(temp));
                        temp.RemoveAt(temp.Count - 1);
                    }
                    j++;
                }
                getNextIteration(array, ref counter, ref i);
                if(endOfLoop(array,i)==true)
                {
                    break;
                }
            }
        }
        static void getNextIteration(int[] array,ref int counter,ref int index)
        {
            if(counter==(array.Length-(index+1)))
            {
                index++;
                counter = 1;
            }
        }
        static bool endOfLoop(int[] array,int index)
        {
            if (index == array.Length - 2)
            {
                return true;
            }
            return false;
        }
        static int findMaximumSum(List<List<int>> list)
        {
            int sum = 0, max = 0;
            for(int i=0;i<list.Count;i++)
            {
                for(int j=0;j<list[i].Count;j++)
                {
                    sum = sum + list[i][j];
                }
                if(max<sum)
                {
                    max = sum;
                }
                sum = 0;
            }
            return max;
        }
        static void Main()
        {
            Console.WriteLine("Enter number of elements in the array:");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            List<List<int>> list = new List<List<int>>();
            FillArray(array);
            PrintArray(array);
            Console.WriteLine();
            GetAllTriplets(array, list);
            int sum = findMaximumSum(list);
            Console.WriteLine("Maximum sum:{0}", sum);
        }
    }
}
