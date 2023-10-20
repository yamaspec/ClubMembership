using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericDelegatesApplication
{
    static class Program
    {
        // Overkill, but as an example of what can be done with Func is ok.
        delegate TResult Func2<out TResult>();
        delegate TResult Func2<in T1, out TResult>(T1 arg1);
        delegate TResult Func2<in T1, in T2, out TResult>(T1 arg1, T2 arg2);
        delegate TResult Func2<in T1, in T2, in T3, out TResult>(T1 arg1, T2 arg2, T3 arg3);

        static void Main(string[] args)
        {
            // Func generic delegate
            // ---------------------
            MathClass mathClass = new MathClass();
            Func<int, int, int> classicCalc = mathClass.Sum;
            int result = classicCalc(1, 2);
            Console.WriteLine($"Classic Func Result: {result}");

            Func<int, int, int> anonymousCalc = delegate (int a, int b) { return a + b; };
            result = anonymousCalc(1, 2);
            Console.WriteLine($"Anonymous Func Result: {result}");

            Func<int, int, int> lambdaCalc = (a, b) => a + b;
            result = lambdaCalc(1, 2);
            Console.WriteLine($"Lambda Func Result: {result}");

            Func2<int, int, int> Func2Calc = (a, b) => a + b;
            result = lambdaCalc(1, 2);
            Console.WriteLine($"Func2 Result: {result}");

            float d = 2.3f, e = 4.56f;
            int f = 5;
            Func<float, float, int, float> calc2 = (arg1, arg2, arg3) => (arg1 + arg2) * arg3;
            float result2 = calc2(d, e, f);
            Console.WriteLine($"Calc2 Result: {result2}");

            Func<decimal, decimal, decimal> calculateTotalAnnualSalary = (annualSalary, bonusPercentage) => annualSalary + (annualSalary * (bonusPercentage / 100));
            Console.WriteLine($"Calc Total Annual Salary: {calculateTotalAnnualSalary(60000, 2)}");

            // Action generic delegate
            // -----------------------
            Console.WriteLine();
            Console.WriteLine("Action Generic Delegate");
            Action<int, string, string, decimal, char, bool> displayEmployeeDetails = (
                arg1, arg2, arg3, arg4, arg5, arg6
                ) => Console.WriteLine(
                    $"Id: {arg1}{Environment.NewLine}" +
                    $"First Name: {arg2}{Environment.NewLine}" +
                    $"Last Name: {arg3}{Environment.NewLine}" +
                    $"Annual Salary: {arg4}{Environment.NewLine}" +
                    $"Gender: {arg5}{Environment.NewLine}" +
                    $"Manager: {arg6}"
                );
            displayEmployeeDetails(1, "Sarah", "Connors", 60000, 'f', true);

            // Predicate generic delegate
            // --------------------------
            Console.WriteLine();
            Console.WriteLine("Predicate Generic Delegate");
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Sarah",
                    LastName = "Connors",
                    AnnualSalary = calculateTotalAnnualSalary(60000, (decimal)1.5),
                    Gender = 'f',
                    IsManager = true,
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Albert",
                    LastName = "Danube",
                    AnnualSalary = calculateTotalAnnualSalary(60300, (decimal)1.5),
                    Gender = 'm',
                    IsManager = true,
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Daniel",
                    LastName = "Mason",
                    AnnualSalary = calculateTotalAnnualSalary(53700, 2),
                    Gender = 'm',
                    IsManager = false,
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Sandra",
                    LastName = "Emerson",
                    AnnualSalary = calculateTotalAnnualSalary(55000, 2),
                    Gender = 'f',
                    IsManager = false,
                }
            };
            // Using a static method to produce the filteres list.
            List<Employee> employeeList = FilterEmployee(employees, e => e.Gender == 'm');
            foreach (Employee employee in employeeList)
            {
                displayEmployeeDetails(
                    employee.Id,
                    employee.FirstName,
                    employee.LastName,
                    employee.AnnualSalary,
                    employee.Gender,
                    employee.IsManager
                );
                Console.WriteLine();
            }
            // Filtering the list via an extension method attached to List<Employee> employee
            Console.WriteLine();
            Console.WriteLine("Predicate Generic Delegate with extension method");
            employeeList = employees.FilteredList(e => e.Gender == 'f');
            foreach (Employee employee in employeeList)
            {
                displayEmployeeDetails(
                    employee.Id,
                    employee.FirstName,
                    employee.LastName,
                    employee.AnnualSalary,
                    employee.Gender,
                    employee.IsManager
                );
                Console.WriteLine();
            }
            // Filtering the list by using Linq
            Console.WriteLine();
            Console.WriteLine("Predicate Generic Delegate with Linq");
            employeeList = employees.Where(e => e.IsManager == true).ToList();
            foreach (Employee employee in employeeList)
            {
                displayEmployeeDetails(
                    employee.Id,
                    employee.FirstName,
                    employee.LastName,
                    employee.AnnualSalary,
                    employee.Gender,
                    employee.IsManager
                );
                Console.WriteLine();
            }

            Console.ReadKey();
        }

        public static List<Employee> FilterEmployee(this List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> filteredEmployees = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    filteredEmployees.Add(employee);
                }
            }
            return filteredEmployees;
        }
    }

    // Func
    public class MathClass
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    // Action
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public char Gender { get; set; }
        public bool IsManager { get; set; }
    }

    public static class Extensions
    {
        public static List<Employee> FilteredList(this List<Employee> employees, Predicate<Employee> predicate)
        {
            List<Employee> filteredEmployees = new List<Employee>();
            foreach (Employee employee in employees)
            {
                if (predicate(employee))
                {
                    filteredEmployees.Add(employee);
                }
            }
            return filteredEmployees;
        }

    }

}
