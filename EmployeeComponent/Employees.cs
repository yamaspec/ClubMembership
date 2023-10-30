using System.Collections.ObjectModel;

namespace EmployeeComponent
{
    // The employee view model objects are stored in a generic collection type called ObservableCollection
    // which is a dynamic data collection that provides notifications when the list changes.
    public class Employees
    {
        public ObservableCollection<EmployeeViewModel> GetEmployees()
        {
            var employees = new ObservableCollection<EmployeeViewModel>();
            employees.Add(new EmployeeViewModel
            {
                Id = 1,
                FirstName = "John",
                LastName = "Green",
                AnnualSalary = 40000,
                Gender = 'm',
                IsManager = false
            });
            employees.Add(new EmployeeViewModel
            {
                Id = 2,
                FirstName = "Sally",
                LastName = "Jones",
                AnnualSalary = 55000,
                Gender = 'f',
                IsManager = true
            });
            employees.Add(new EmployeeViewModel
            {
                Id = 3,
                FirstName = "Bill",
                LastName = "Blog",
                AnnualSalary = 30000,
                Gender = 'm',
                IsManager = false
            });
            employees.Add(new EmployeeViewModel
            {
                Id = 4,
                FirstName = "Jamie",
                LastName = "Hopkins",
                AnnualSalary = 80000,
                Gender = 'm',
                IsManager = true
            });
            return employees;
        }
    }
}
