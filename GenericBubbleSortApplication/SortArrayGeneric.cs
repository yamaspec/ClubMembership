using System;

namespace GenericBubbleSortApplication
{
    public class SortArrayGeneric<T> where T : IComparable<T>
    {
        public void BubbleSort(T[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Is arr[j] > arr[j + 1] ?
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        // Then, the two compared values need to be swapped.
                        Swap(arr, j);
                    }
                }
            }

        }

        private void Swap(T[] arr, int j)
        {
            T temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }
    }
}
