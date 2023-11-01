using System;

namespace GenericBubbleSortApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            // These are different cases which justify the use of Generics.
            // ------------------------------------------------------------
            
            // It works.
            //object[] arr = new object[] { 2, 1, 4, 3 };
            // It works.
            //string[] arr = new string[] { "Bob", "Henry", "Albert", "Zac" };
            // Must implement IComparable to work. Otherwise, throws a System.InvalidCastException: Cannot cast from Employee to IComparable.
            Employee[] arr = new Employee[]
            {
                new Employee {Id = 4, Name = "John"},
                new Employee {Id = 3, Name = "Joshua"},
                new Employee {Id = 1, Name = "Ben"},
                new Employee {Id = 2, Name = "Henry"},
            };

            SortArray sortArray = new();
            sortArray.BubbleSort(arr);

            foreach (var item in arr)
            {
                // When using Employee needs to cast to Employee in order to work.
                // But if it does, cannot process int/string unless checks the item type.
                if (item != null && item is Employee)
                {
                    Console.WriteLine((Employee)item);
                }
                else
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // This is the Generic way.
            // ------------------------
            // Readable code, less convoluted and type safe at compile time.

            //int[] arrGeneric = new int[] { 2, 1, 4, 3 };
            //string[] arrGeneric = new string[] { "Bob", "Henry", "Albert", "Zac" };
            EmployeeGeneric[] arrGeneric = new EmployeeGeneric[]
            {
                new EmployeeGeneric {Id = 4, Name = "John"},
                new EmployeeGeneric {Id = 3, Name = "Joshua"},
                new EmployeeGeneric {Id = 1, Name = "Ben"},
                new EmployeeGeneric {Id = 2, Name = "Henry"},
            };

            //SortArrayGeneric<int> sortArrayGeneric = new();
            //SortArrayGeneric<string> sortArrayGeneric = new();
            SortArrayGeneric<EmployeeGeneric> sortArrayGeneric = new();

            sortArrayGeneric.BubbleSort(arrGeneric);
            foreach (var item in arrGeneric)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
