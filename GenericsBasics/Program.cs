using System;
using System.Collections.Generic;

namespace GenericsBasics
{
    public class Program
    {
        static void Main(string[] args)
        {
            Salaries salaries = new();

            // Non-Generic list requires unboxing
            // ----------------------------------
            // ArrayList salaryList = salaries.GetSalaries();
            // double salary = (double)salaryList[1];
            // salary = salary + (salary * 0.02);

            // Generic list is easier and simpler
            // ----------------------------------
            List<float> salaryList = salaries.GetSalaries();
            float salary = salaryList[1];
            salary = salary + (salary * 0.02f);

            Console.WriteLine(salary);
            Console.ReadKey();
        }
    }
}
