using System;
using System.Diagnostics.CodeAnalysis;

namespace GenericBubbleSortApplication
{
    public class EmployeeGeneric : IComparable<EmployeeGeneric>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo([AllowNull] EmployeeGeneric employee)
        {
            // It could compare by Id or Name (int/string).
            return this.Id.CompareTo(employee.Id);
        }

        public override string ToString()
        {
            // To show both properties when Console writes them on the screen.
            return $"{Id} {Name}";
        }
    }
}
