using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSurvaillanceSystemApplication
{
    public class EmployeeNotify : Observer
    {
        private readonly IEmployee _employee = null;

        public EmployeeNotify(IEmployee employee)
        {
            _employee = employee;
        }

        public override void OnCompleted()
        {
            string header = $"{_employee.FirstName} {_employee.LastName} Daily Visitors Report.";
            Console.WriteLine();
            OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Employee);
            Console.WriteLine(header);
            Console.WriteLine(new string('-', header.Length));
            Console.WriteLine();
            foreach(var externalVisitor in _externalVisitors)
            {
                string entryDateTime = OutputFormatter.DateTimeFormat(externalVisitor.EntryDateTime);
                string exitDateTime = OutputFormatter.DateTimeFormat(externalVisitor.ExitDateTime);
                string status = (externalVisitor.InBuilding) ? 
                    "Still in the building".PadRight(25) : 
                    $"{exitDateTime, -25}";
                string message = $"{externalVisitor.Id,-6}{externalVisitor.FirstName,-15} " +
                    $"{externalVisitor.LastName,15} {entryDateTime,-25}" +
                    $"{status}";
                Console.WriteLine(message);
            }
            OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Normal);
            Console.WriteLine();
            Console.WriteLine();
        }

        public override void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public override void OnNext(ExternalVisitor externalVisitor)
        {
            if (externalVisitor.EmployeeContactId == _employee.Id)
            {
                string entryDateTime = OutputFormatter.DateTimeFormat(externalVisitor.EntryDateTime);
                var externalVisitorListItem = _externalVisitors.FirstOrDefault(ev => ev.Id == externalVisitor.Id);
                // Entering the building notification
                if (externalVisitorListItem == null)
                { 
                    _externalVisitors.Add(externalVisitor);
                    var message = $"{_employee.FirstName} {_employee.LastName}, your visitor has arrived. " +
                        $"Visitor Id: {externalVisitor.Id}, First Name:{externalVisitor.FirstName}, " +
                        $"Last Name:{externalVisitor.LastName}, entered the building at " +
                        $"{entryDateTime}";
                    OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Employee);
                    Console.WriteLine(message);
                    OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Normal);
                    Console.WriteLine();
                }
                // Exiting the building notification
                if (externalVisitorListItem != null && externalVisitor.InBuilding == false)
                {
                    externalVisitorListItem.ExitDateTime = externalVisitor.ExitDateTime;
                    externalVisitorListItem.InBuilding = false;
                }
            }
        }
    }
}