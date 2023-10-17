using System;
using System.Drawing;
using System.IO;
using System.Reflection;

// 	- Covariance permits a method to have a RETURN TYPE that is more derived than that defined in the delegate.
//    The return type of your method points more to the sub class rather than the base class the delegate points to.

//  - Contravariance permits a method that has PARAMETER TYPES that are less derived than those in the delegate type.
//    The parameter types of your method point more to the base class rather than the sub class the delegate points to.

namespace DelegateVarianceApplication
{
    class Program
    {
        // Delegate for Covariance example.
        delegate Car CarFactoryDel(int id, string name);

        // Delegates for Contravariance example.
        delegate void LogICECarDetailsDel(ICECar car);
        delegate void LogEVCarDetailsDel(EVCar car);


        static void Main(string[] args)
        {
            // Covariance allows carFactoryDel to RETURN an ICECar/EVCar type, a sub class of Car class.
            // A more derived type than the delegate specify.

            CarFactoryDel carFactoryDel = CarFactory.ReturnICECar;

            Car iceCar = carFactoryDel(1, "Audi R8");
            Console.WriteLine($"Object type: {iceCar.GetType()}");
            Console.WriteLine($"Car Details: {iceCar.GetCarDetails()}");
            Console.WriteLine();

            carFactoryDel = CarFactory.ReturnEVCar;
            Car evCar = carFactoryDel(2, "Tesla Model-3");
            Console.WriteLine($"Object type: {evCar.GetType()}");
            Console.WriteLine($"Car Details: {evCar.GetCarDetails()}");
            Console.WriteLine();
            Console.ReadKey();

            // Contravariance allows LogCarDetails method to have PARAMETER TYPES that are less derived than those in the delegate type.
            // Parameter types of your method point more to the base class rather than the sub class the delegates point to.

            LogICECarDetailsDel logICECarDetailsDel = LogCarDetails;
            LogEVCarDetailsDel logEVCarDetailsDel = LogCarDetails;

            logICECarDetailsDel(iceCar as ICECar);   // Delegate parameter points to a more derived Car class (ICECar/EVCar subclasses).
            logEVCarDetailsDel(evCar as EVCar);      // LogCarDetails method parameter points to a less derived class (Car base class).

            Console.ReadKey();

        }

        public static void LogCarDetails(Car car)
        {
            if (car is ICECar)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ICEDetails.txt"), true))
                {
                    sw.WriteLine($"Object Type: {car.GetType()}");
                    sw.WriteLine($"Car Details: {car.GetCarDetails()}");
                }
            }
            else if (car is EVCar)
            {
                Console.WriteLine($"Object Type: {car.GetType()}");
                Console.WriteLine($"Car Details: {car.GetCarDetails()}");
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }

    public abstract class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual string GetCarDetails()
        {
            return $"{Id} - {Name} ";
        }
    }

    public class ICECar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Internal Combustion Engine";
        }
    }

    public class EVCar : Car
    {
        public override string GetCarDetails()
        {
            return $"{base.GetCarDetails()} - Electric";
        }
    }

    public static class CarFactory
    {
        public static ICECar ReturnICECar(int id, string name)
        {
            return new ICECar { Id = id, Name = name };
        }

        public static EVCar ReturnEVCar(int id, string name)
        {
            return new EVCar { Id = id, Name = name };
        }
    }
}