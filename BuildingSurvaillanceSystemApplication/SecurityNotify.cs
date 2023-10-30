using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSurvaillanceSystemApplication
{
    public class SecurityNotify : Observer
    {
        public override void OnCompleted()
        {
            string header = $"Security Daily Visitors Report.";
            Console.WriteLine();
            OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Security);
            Console.WriteLine(header);
            Console.WriteLine(new string('-', header.Length));
            Console.WriteLine();
            foreach (var externalVisitor in _externalVisitors)
            {
                string entryDateTime = OutputFormatter.DateTimeFormat(externalVisitor.EntryDateTime);
                string exitDateTime = OutputFormatter.DateTimeFormat(externalVisitor.ExitDateTime);
                string status = (externalVisitor.InBuilding) ?
                    "Still in the building".PadRight(25) :
                    $"{exitDateTime,-25}";
                string message = $"{externalVisitor.Id,-6}{externalVisitor.FirstName,-15}" +
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
            string entryDateTime = OutputFormatter.DateTimeFormat(externalVisitor.EntryDateTime);
            string exitDateTime = OutputFormatter.DateTimeFormat(externalVisitor.ExitDateTime);
            var externalVisitorListItem = _externalVisitors.FirstOrDefault(ev => ev.Id == externalVisitor.Id);
            
            // Entering the building notification
            if (externalVisitorListItem == null)
            {
                _externalVisitors.Add(externalVisitor);
                string message = $"Security Notification: a visitor has arrived. " +
                    $"Visitor Id: {externalVisitor.Id}, First Name:{externalVisitor.FirstName}, " +
                    $"Last Name:{externalVisitor.LastName}, entered the building at {entryDateTime}";
                OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Security);
                Console.WriteLine(message);
                OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Normal);
                Console.WriteLine();
            }
            // Exiting the building notification
            if (externalVisitorListItem != null && externalVisitor.InBuilding == false)
            {
                externalVisitorListItem.ExitDateTime = externalVisitor.ExitDateTime;
                externalVisitorListItem.InBuilding = false;
                var message = $"Security Notification: a visitor has left the building. " +
                    $"Visitor Id: {externalVisitor.Id}, First Name:{externalVisitor.FirstName}, " +
                    $"Last Name:{externalVisitor.LastName}, entered the building at " +
                    $"{entryDateTime}, left the building at {exitDateTime}";
                OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Security);
                Console.WriteLine(message);
                OutputFormatter.ChangeOutputTheme(OutputFormatter.TextOutputTheme.Normal);
                Console.WriteLine();
            }
        }
    }
}