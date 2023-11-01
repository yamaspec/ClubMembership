using System;

namespace GenericBubbleSortApplication
{
    public class  SortArray
    {
        public void BubbleSort(object[] arr)
        {
            int n = arr.Length;
            for(int i = 0; i < n - 1; i++)
            {
                for(int j = 0; j < n - i - 1; j++)
                {
                    // No Generic comparison
                    // arr[j] > arr[j + 1]
                    if (((IComparable)arr[j]).CompareTo(arr[j + 1]) > 0)
                    {
                        // The two compared values need to be swapped
                        Swap(arr, j);
                    }
                }
            }

        }

        private void Swap(object[] arr, int j)
        {
            object temp = arr[j];
            arr[j] = arr[j + 1];
            arr[j + 1] = temp;
        }
    }
}
