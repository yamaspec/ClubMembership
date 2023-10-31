using System.Collections;
using System.Collections.Generic;

namespace GenericsBasics
{
    public class Salaries
    {
        // private ArrayList _salaryList = new();   // None Generic list: data type could be misinterpreted.
        private List<float> _salaryList = new();

        public Salaries()
        {
            // The type within the angled brackets forces to enter the right data type.
            // Entering 60000.34 would throw a compile error (CS1503: Cannot convert double to float).
            _salaryList.Add(60000.34f);
            _salaryList.Add(40000.51f);
            _salaryList.Add(20000.23f);
        }

        public List<float> GetSalaries()
        {
            return _salaryList;
        }
    }
}
