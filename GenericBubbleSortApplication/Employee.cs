using System;

namespace GenericBubbleSortApplication
{
    public class Employee : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompareTo(object obj)
        {
            // It could compare by Id or Name (int/string).
            return this.Id.CompareTo(((Employee)obj).Id);
        }

        public override string ToString()
        {
            // To show both properties when Console writes them on the screen.
            return $"{Id} {Name}";
        }
    }
}
