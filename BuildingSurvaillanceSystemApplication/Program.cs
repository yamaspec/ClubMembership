using System;

namespace BuildingSurvaillanceSystemApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            // Security system cameras activated (provider)
            SecuritySurveillanceHub securitySurveillanceHub = new();

            // Employees created (Subscriber)
            EmployeeNotify employeeNotify1 = new(
                new Employee
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Jones",
                    JobTitle = "Development Manager",
                }
            );
            EmployeeNotify employeeNotify2 = new(
                new Employee
                {
                    Id = 2,
                    FirstName = "Dave",
                    LastName = "Kendal",
                    JobTitle = "Chief Information Officer",
                }
            );
            
            // Security Team created (Subscriber)
            SecurityNotify securityNotify = new();

            // Subscriptions
            employeeNotify1.Subscribe(securitySurveillanceHub);
            employeeNotify2.Subscribe(securitySurveillanceHub);
            securityNotify.Subscribe(securitySurveillanceHub);
            
            // Visitors arrive
            securitySurveillanceHub.ConfirmExternalVisitorEntersBuilding(
                new ExternalVisitor
                {
                    Id = 1,
                    FirstName = "Andrew",
                    LastName = "Jackson",
                    CompanyName = "The Firm",
                    JobTitle = "Contractor",
                    EntryDateTime = DateTime.Parse("30/10/2023 11:00"),
                    EmployeeContactId = 1,
                }
            );
            securitySurveillanceHub.ConfirmExternalVisitorEntersBuilding(
                new ExternalVisitor
                {
                    Id = 2,
                    FirstName = "James",
                    LastName = "Davidson",
                    CompanyName = "The Company",
                    JobTitle = "Lawyer",
                    EntryDateTime = DateTime.Parse("30/10/2023 12:00"),
                    EmployeeContactId = 2,
                }
            );
            securitySurveillanceHub.ConfirmExternalVisitorEntersBuilding(
                new ExternalVisitor
                {
                    Id = 3,
                    FirstName = "Karl",
                    LastName = "Anderson",
                    CompanyName = "Another Company",
                    JobTitle = "Software Developer",
                    EntryDateTime = DateTime.Parse("30/10/2023 08:00"),
                    EmployeeContactId = 1,
                }
            );

            // Visitors leave
            securitySurveillanceHub.ConfirmExternalVisitorExitsBuilding(1, DateTime.Parse("30/10/2023 13:00"));
            securitySurveillanceHub.ConfirmExternalVisitorExitsBuilding(2, DateTime.Parse("30/10/2023 15:00"));

            // Dave won't receive a Daily Visitors Report when the cut off time is triggered.
            employeeNotify2.UnSubscribe();

            // Cut off time: End of the working day
            securitySurveillanceHub.BuildingEntryCutOffTimeReached();

            Console.ReadKey();
        }
    }
}